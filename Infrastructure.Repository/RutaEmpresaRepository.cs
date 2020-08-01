using Dapper;
using Domain.Entities;
using Infrastructure.Interface;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Extensions;

namespace Infrastructure.Repository
{
    public class RutaEmpresaRepository : IRutaEmpresaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public RutaEmpresaRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }
        public async Task<TM_RUTA_EMPRESA> Delete(TM_RUTA_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idrutaxemp_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDRUTAXEMP);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTAXEMP.SP_EliminarRutaxEmp");
                var result = await connection.QueryFirstOrDefaultAsync<TM_RUTA_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_RUTA_EMPRESA> Get(TM_RUTA_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idrutaxemp_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDRUTAXEMP);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTAXEMP.SP_GetListaRutaxEmpxId");
                var result = await connection.QueryFirstOrDefaultAsync<TM_RUTA_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TM_RUTA_EMPRESA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var splFilter = filter.Split('@');
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_filtrotipo_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[0]);
                dyParam.Add("str_filtrovalor_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[1].ToUpper());
                dyParam.Add("num_pagina_", OracleDbType.Varchar2, ParameterDirection.Input, pagina);
                dyParam.Add("num_registros_", OracleDbType.Varchar2, ParameterDirection.Input, cantidadXPagina);
                dyParam.Add("num_idempresa_", OracleDbType.Int32, ParameterDirection.Input, splFilter[2]);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTAXEMP.SP_GetListaRutaxEmp");
                var result = await connection.QueryAsync<TM_RUTA_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<TM_RUTA_EMPRESA>> GetCombo(TM_RUTA_EMPRESA input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_RUTA_EMPRESA> Insert(TM_RUTA_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idempresa_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDEMPRESA);
                dyParam.Add("num_idruta_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDRUTA);
                dyParam.Add("dte_fecinivig_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECINIVIG.ToBDSirosDate());
                dyParam.Add("dte_fecvenvig_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECVENVIG.ToBDSirosDate());
                dyParam.Add("str_numdocauto_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMDOCAUTO);
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTAXEMP.SP_RegistroRutaxEmp");
                var result = await connection.QueryFirstOrDefaultAsync<TM_RUTA_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_RUTA_EMPRESA> Update(TM_RUTA_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idrutaxemp_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDRUTAXEMP);
                dyParam.Add("num_idruta_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDRUTA);
                dyParam.Add("dte_fecinivig_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECINIVIG.ToBDSirosDate());
                dyParam.Add("dte_fecvenvig_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECVENVIG.ToBDSirosDate());
                dyParam.Add("str_numdocauto_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMDOCAUTO);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTAXEMP.SP_ActualizarRutaxEmp");
                var result = await connection.QueryFirstOrDefaultAsync<TM_RUTA_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
