using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Infrastructure.Interface;
using Oracle.ManagedDataAccess.Client;
using Transversal.Common;

namespace Infrastructure.Repository
{
    public class RutaRepository : IRutaRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public RutaRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public async Task<TM_RUTA> Delete(TM_RUTA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idruta_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDRUTA);
                dyParam.Add("num_identidadusuario_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDADUSUARIO);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTA.SP_EliminarRuta");
                var result = await connection.QueryFirstOrDefaultAsync<TM_RUTA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_RUTA> Get(TM_RUTA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idruta_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDRUTA);
                dyParam.Add("num_identidadusuario_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDADUSUARIO);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTA.SP_GetListaRutaxId");
                var result = await connection.QueryFirstOrDefaultAsync<TM_RUTA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TM_RUTA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                // CREAR VARIABLE EN CASO SEAS MAS DE UN FILTRO
                var splFilter = filter.Split('@');
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_filtrotipo_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[0]);
                dyParam.Add("str_filtrovalor_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[1].ToUpper());
                dyParam.Add("num_identidadusuario_", OracleDbType.Int32, ParameterDirection.Input, splFilter[2]);
                dyParam.Add("num_pagina_", OracleDbType.Varchar2, ParameterDirection.Input, pagina);
                dyParam.Add("num_registros_", OracleDbType.Varchar2, ParameterDirection.Input, cantidadXPagina);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTA.SP_GetListaRuta");
                var result = await connection.QueryAsync<TM_RUTA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public Task<List<TM_RUTA>> GetCombo(TM_RUTA input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_RUTA> Insert(TM_RUTA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("str_nombreruta_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NOMBRERUTA);
                dyParam.Add("str_itinerario_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_ITINERARIO);
                dyParam.Add("str_kilometro_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_KILOMETRO);
                dyParam.Add("str_estado_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_ESTADO);
                dyParam.Add("num_identidadusuario_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDADUSUARIO);
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTA.SP_RegistroRuta");
                var result = await connection.QueryFirstOrDefaultAsync<TM_RUTA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_RUTA> Update(TM_RUTA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idruta_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDRUTA);
                dyParam.Add("str_itinerario_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_ITINERARIO); 
                dyParam.Add("str_kilometro_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_KILOMETRO);
                dyParam.Add("str_estado_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_ESTADO);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTA.SP_ActualizarRuta");
                var result = await connection.QueryFirstOrDefaultAsync<TM_RUTA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
