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
    public class OperadorEmpresaRepository : IOperadorEmpresaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public OperadorEmpresaRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }
        public async Task<TM_OPERADOR_EMPRESA> Delete(TM_OPERADOR_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idnominaxemp_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDNOMINAXEMP);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_EMPRESA.SP_EliminarOperadorEmp");
                var result = await connection.QueryFirstOrDefaultAsync<TM_OPERADOR_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_OPERADOR_EMPRESA> Get(TM_OPERADOR_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idnominaxemp_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDNOMINAXEMP);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_EMPRESA.SP_GetListaOperadorEmpxId");
                var result = await connection.QueryFirstOrDefaultAsync<TM_OPERADOR_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TM_OPERADOR_EMPRESA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
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
                var query = _connectionFactory.GetQueryForSIROS("PKG_EMPRESA.SP_GetListaOperadorEmp");
                var result = await connection.QueryAsync<TM_OPERADOR_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public Task<List<TM_OPERADOR_EMPRESA>> GetCombo(TM_OPERADOR_EMPRESA input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_OPERADOR_EMPRESA> Insert(TM_OPERADOR_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idempresa_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDEMPRESA);
                dyParam.Add("num_idtpdocumento_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDTPDOCUMENTO);
                dyParam.Add("str_numdocumento_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMDOCUMENTO);
                dyParam.Add("str_apepaterno_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_APEPATERNO);
                dyParam.Add("str_apematerno_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_APEMATERNO);
                dyParam.Add("str_nombre_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NOMBRE);
                dyParam.Add("num_idtipooper_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDTIPOOPER);
                dyParam.Add("dte_fecnacimiento_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECNACIMIENTO.ToBDSirosDate());
                dyParam.Add("str_foto_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_FOTO);
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_EMPRESA.SP_RegistrarOperadorEmp");
                var result = await connection.QueryFirstOrDefaultAsync<TM_OPERADOR_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_OPERADOR_EMPRESA> Update(TM_OPERADOR_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idnominaxemp_  ", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDNOMINAXEMP);
                dyParam.Add("num_idtipooper_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDTIPOOPER);
                dyParam.Add("dte_fecnacimiento_", OracleDbType.Int32, ParameterDirection.Input, input.DTE_FECNACIMIENTO.ToBDSirosDate());
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_EMPRESA.SP_ActualizarOperadorEmp");
                var result = await connection.QueryFirstOrDefaultAsync<TM_OPERADOR_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
