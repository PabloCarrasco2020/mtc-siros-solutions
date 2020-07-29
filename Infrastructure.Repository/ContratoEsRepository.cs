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
    public class ContratoEsRepository : IContratoEsRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ContratoEsRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public async Task<TM_CONTRATOES> Delete(TM_CONTRATOES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idestservicioxent_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDESTSERVICIOXENT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_CONTRATOES.SP_EliminarContratoES");
                var result = await connection.QueryFirstOrDefaultAsync<TM_CONTRATOES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_CONTRATOES> Get(TM_CONTRATOES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idestservicioxent_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDESTSERVICIOXENT);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_CONTRATOES.SP_GetListaContratoESxId");
                var result = await connection.QueryFirstOrDefaultAsync<TM_CONTRATOES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TM_CONTRATOES>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
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
                var query = _connectionFactory.GetQueryForSIROS("PKG_CONTRATOES.SP_GetListaContratoES");
                var result = await connection.QueryAsync<TM_CONTRATOES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<TM_CONTRATOES>> GetCombo(TM_CONTRATOES input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_CONTRATOES> Insert(TM_CONTRATOES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idestservicio_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDESTSERVICIO);
                dyParam.Add("num_identidadusuario_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDAD);
                dyParam.Add("str_numcontrato_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMCONTRATO);
                dyParam.Add("dte_feccontrato_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECCONTRATO.ToBDSirosDate());
                dyParam.Add("dte_fecinivig_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECINIVIG.ToBDSirosDate());
                dyParam.Add("dte_fecvenvig_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECVENVIG.ToBDSirosDate());
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_CONTRATOES.SP_RegistroContratoES");
                var result = await connection.QueryFirstOrDefaultAsync<TM_CONTRATOES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_CONTRATOES> Update(TM_CONTRATOES input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idestservicioxent_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDESTSERVICIOXENT);
                dyParam.Add("str_numcontrato_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMCONTRATO);
                dyParam.Add("dte_feccontrato_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECCONTRATO.ToBDSirosDate());
                dyParam.Add("dte_fecinivig_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECINIVIG.ToBDSirosDate());
                dyParam.Add("dte_fecvenvig_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECVENVIG.ToBDSirosDate());
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_CONTRATOES.SP_ActualizarContratoES");
                var result = await connection.QueryFirstOrDefaultAsync<TM_CONTRATOES>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
