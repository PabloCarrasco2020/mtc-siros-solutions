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
    public class SucursalESRepository : ISucursalESRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public SucursalESRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }
        public async Task<TM_SUCURSAL_ES> Delete(TM_SUCURSAL_ES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idsucursalxes_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDSUCURSALXES);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_SUCURSAL.SP_EliminarSucursal");
                var result = await connection.QueryFirstOrDefaultAsync<TM_SUCURSAL_ES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_SUCURSAL_ES> Get(TM_SUCURSAL_ES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idsucursalxes_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDSUCURSALXES);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_SUCURSAL.SP_GetListaSucursalxId");
                var result = await connection.QueryFirstOrDefaultAsync<TM_SUCURSAL_ES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TM_SUCURSAL_ES>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var splFilter = filter.Split('@');
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_filtrotipo_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[0]);
                dyParam.Add("str_filtrovalor_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[1].ToUpper());
                dyParam.Add("num_identidadusuario_", OracleDbType.Int32, ParameterDirection.Input, splFilter[2]);
                dyParam.Add("num_pagina_", OracleDbType.Varchar2, ParameterDirection.Input, pagina);
                dyParam.Add("num_registros_", OracleDbType.Varchar2, ParameterDirection.Input, cantidadXPagina);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_SUCURSAL.SP_GetListaSucursal");
                var result = await connection.QueryAsync<TM_SUCURSAL_ES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public Task<List<TM_SUCURSAL_ES>> GetCombo(TM_SUCURSAL_ES input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_SUCURSAL_ES> Insert(TM_SUCURSAL_ES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idestservicio_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDESTSERVICIO);
                dyParam.Add("num_idtpvia_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDTPVIA);
                dyParam.Add("str_nomvia_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NOMVIA);
                dyParam.Add("num_idccpp_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDCCPP);
                dyParam.Add("str_nomccpp_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NOMCCPP);
                dyParam.Add("num_idnumakm_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDNUMAKM);
                dyParam.Add("str_nummzkil_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMMZKIL);
                dyParam.Add("num_idloindp_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDLOINDP);
                dyParam.Add("str_intlote_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_INTLOTE);
                dyParam.Add("str_referencia_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_REFERENCIA);
                dyParam.Add("str_cdpto_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_CDPTO);
                dyParam.Add("str_cdprov_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_CDPROV);
                dyParam.Add("str_cddist_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_CDDIST);
                dyParam.Add("str_latitud_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_LATITUD);
                dyParam.Add("str_longitud_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_LONGITUD);
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("num_identidadusuario_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDADUSUARIO);
                dyParam.Add("num_identidadsso_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDADSSO);
                dyParam.Add("num_idlocalsso_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDLOCALSSO);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_SUCURSAL.SP_RegistrarSucursal");
                var result = await connection.QueryFirstOrDefaultAsync<TM_SUCURSAL_ES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_SUCURSAL_ES> Update(TM_SUCURSAL_ES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idsucursalxes_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSUCURSALXES);
                dyParam.Add("num_idtpvia_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDTPVIA);
                dyParam.Add("str_nomvia_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NOMVIA);
                dyParam.Add("num_idccpp_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDCCPP);
                dyParam.Add("str_nomccpp_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NOMCCPP);
                dyParam.Add("num_idnumakm_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDNUMAKM);
                dyParam.Add("str_nummzkil_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMMZKIL);
                dyParam.Add("num_idloindp_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDLOINDP);
                dyParam.Add("str_intlote_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_INTLOTE);
                dyParam.Add("str_referencia_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_REFERENCIA);
                dyParam.Add("str_cdpto_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_CDPTO);
                dyParam.Add("str_cdprov_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_CDPROV);
                dyParam.Add("str_cddist_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_CDDIST);
                dyParam.Add("str_latitud_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_LATITUD);
                dyParam.Add("str_longitud_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_LONGITUD);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_SUCURSAL.SP_ActualizarSucursal");
                var result = await connection.QueryFirstOrDefaultAsync<TM_SUCURSAL_ES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
