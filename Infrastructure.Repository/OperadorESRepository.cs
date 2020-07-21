using Dapper;
using Domain.Entities;
using Infrastructure.Interface;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Extensions;

namespace Infrastructure.Repository
{
    public class OperadorESRepository : IOperadorESRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public OperadorESRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }
        public async Task<TM_OPERADOR_ES> Delete(TM_OPERADOR_ES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idnominaxsucursal_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDNOMINAXSUCURSAL);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_SUCURSAL.SP_EliminarOperadorSuc");
                var result = await connection.QueryFirstOrDefaultAsync<TM_OPERADOR_ES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_OPERADOR_ES> Get(TM_OPERADOR_ES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idnominaxsucursal_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDNOMINAXSUCURSAL);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_SUCURSAL.SP_GetListaOperadorxIdSuc");
                var result = await connection.QueryFirstOrDefaultAsync<TM_OPERADOR_ES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TM_OPERADOR_ES>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var splFilter = filter.Split('@');
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_filtrotipo_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[0]);
                dyParam.Add("str_filtrovalor_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[1].ToUpper());
                dyParam.Add("num_pagina_", OracleDbType.Varchar2, ParameterDirection.Input, pagina);
                dyParam.Add("num_registros_", OracleDbType.Varchar2, ParameterDirection.Input, cantidadXPagina);
                dyParam.Add("num_idsucursalxes_", OracleDbType.Int32, ParameterDirection.Input, splFilter[2]);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_SUCURSAL.SP_GetListaOperadorSuc");
                var result = await connection.QueryAsync<TM_OPERADOR_ES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public Task<List<TM_OPERADOR_ES>> GetCombo(TM_OPERADOR_ES input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_OPERADOR_ES> Insert(TM_OPERADOR_ES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idsucursalxes_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSUCURSALXES);
                dyParam.Add("num_idtpdocumento_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDTPDOCUMENTO);
                dyParam.Add("str_numdocumento_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMDOCUMENTO);
                dyParam.Add("str_apepaterno_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_APEPATERNO);
                dyParam.Add("str_apematerno_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_APEMATERNO);
                dyParam.Add("str_nombre_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NOMBRE);
                dyParam.Add("num_idtipooper_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDTIPOOPER);
                dyParam.Add("dte_fecnacimiento_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECNACIMIENTO.ToBDSirosDate());
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_SUCURSAL.SP_RegistrarOperadorSuc");
                var result = await connection.QueryFirstOrDefaultAsync<TM_OPERADOR_ES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_OPERADOR_ES> Update(TM_OPERADOR_ES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idnominaxsucursal_  ", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDNOMINAXSUCURSAL);
                dyParam.Add("num_idtipooper_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDTIPOOPER);
                dyParam.Add("dte_fecnacimiento_", OracleDbType.Int32, ParameterDirection.Input, input.DTE_FECNACIMIENTO.ToBDSirosDate());
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_SUCURSAL.SP_ActualizarOperadorSuc");
                var result = await connection.QueryFirstOrDefaultAsync<TM_OPERADOR_ES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
