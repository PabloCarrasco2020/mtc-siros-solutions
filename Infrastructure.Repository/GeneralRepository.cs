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

namespace Infrastructure.Repository
{
    public class GeneralRepository:IGeneralRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public GeneralRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public async Task<List<GENERAL.CARGO_REPRESENTANTELEGAL>> GetCargoRepresentanteLegal()
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_GENERAL.SP_GetCargoRpte");
                var result = await connection.QueryAsync<GENERAL.CARGO_REPRESENTANTELEGAL>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<GENERAL.CENTRO_POBLADO>> GetCentroPoblado()
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_GENERAL.SP_ObtenerCcpp");
                var result = await connection.QueryAsync<GENERAL.CENTRO_POBLADO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<GENERAL.DEPARTAMENTO>> GetDepartamento()
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_GENERAL.SP_ObtenerDpto");
                var result = await connection.QueryAsync<GENERAL.DEPARTAMENTO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<GENERAL.DISTRITO>> GetDistrito(string sCodDepartamento, string sCodProvincia)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("str_cdpto_", OracleDbType.Varchar2, ParameterDirection.Input, sCodDepartamento);
                dyParam.Add("str_cdprov_", OracleDbType.Varchar2, ParameterDirection.Input, sCodProvincia);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_GENERAL.SP_GetDistritos");
                var result = await connection.QueryAsync<GENERAL.DISTRITO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<GENERAL.LOTE_INTERIOR>> GetLoteInterior()
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_GENERAL.SP_ObtenerLoInDp");
                var result = await connection.QueryAsync<GENERAL.LOTE_INTERIOR>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<GENERAL.NUMERO_MANZANA>> GetNumeroManzana()
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_GENERAL.SP_ObtenerNuMaKm");
                var result = await connection.QueryAsync<GENERAL.NUMERO_MANZANA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<GENERAL.PROVINCIA>> GetProvincia(string sCodDepartamento)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("str_cdpto_", OracleDbType.Varchar2, ParameterDirection.Input, sCodDepartamento);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_GENERAL.SP_ObtenerProv");
                var result = await connection.QueryAsync<GENERAL.PROVINCIA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }
        public async Task<List<GENERAL.TIPO_DOCUMENTO_REPRESENTANTELEGAL>> GetTipoDoc(string sTipoConsulta)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("str_tipoconsulta_", OracleDbType.Varchar2, ParameterDirection.Input, sTipoConsulta);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_GENERAL.SP_GetTipoDocRpte");
                var result = await connection.QueryAsync<GENERAL.TIPO_DOCUMENTO_REPRESENTANTELEGAL>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }
        public async Task<List<GENERAL.TIPO_OPERADOR>> GetTipoOperador(string sTipoConsulta)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("str_tipoconsulta_", OracleDbType.Varchar2, ParameterDirection.Input, sTipoConsulta);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_GENERAL.SP_GetTipoOper");
                var result = await connection.QueryAsync<GENERAL.TIPO_OPERADOR>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<GENERAL.TIPO_VIA>> GetTipoVia()
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_GENERAL.SP_ObtenerTpVia");
                var result = await connection.QueryAsync<GENERAL.TIPO_VIA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }
    }
}
