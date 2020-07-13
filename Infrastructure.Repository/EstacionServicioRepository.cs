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
    public class EstacionServicioRepository : IEstacionServicioRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public EstacionServicioRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }
        public async Task<TM_ESTACIONSERVICIO> Delete(TM_ESTACIONSERVICIO input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idestservicio_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDESTSERVICIO);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_ESTACIONSERVICIO.SP_EliminarEstacionServicio");
                var result = await connection.QueryFirstOrDefaultAsync<TM_ESTACIONSERVICIO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_ESTACIONSERVICIO> Get(TM_ESTACIONSERVICIO input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idestservicio_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDESTSERVICIO);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_ESTACIONSERVICIO.SP_GetListaEstacionServicioxId");
                var result = await connection.QueryFirstOrDefaultAsync<TM_ESTACIONSERVICIO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TM_ESTACIONSERVICIO>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                // CREAR VARIABLE EN CASO SEAS MAS DE UN FILTRO
                var splFilter = filter.Split('@');
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_filtrotipo_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[0]);
                dyParam.Add("str_filtrovalor_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[1].ToUpper());
                dyParam.Add("num_pagina_", OracleDbType.Varchar2, ParameterDirection.Input, pagina);
                dyParam.Add("num_registros_", OracleDbType.Varchar2, ParameterDirection.Input, cantidadXPagina);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_ESTACIONSERVICIO.SP_GetListaEstacionServicio");
                var result = await connection.QueryAsync<TM_ESTACIONSERVICIO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public Task<List<TM_ESTACIONSERVICIO>> GetCombo(TM_ESTACIONSERVICIO input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_ESTACIONSERVICIO> Insert(TM_ESTACIONSERVICIO input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("str_numruc_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMRUC);
                dyParam.Add("str_razonsocial_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_RAZONSOCIAL);
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
                dyParam.Add("str_nrosucursales_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NROSUCURSALES);
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("str_representante_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_REPRESENTANTE);
                dyParam.Add("num_identidadsso_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDADSSO);
                dyParam.Add("num_idlocalsso_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDLOCALSSO);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_ESTACIONSERVICIO.SP_RegistrarEstacionServicio");
                var result = await connection.QueryFirstOrDefaultAsync<TM_ESTACIONSERVICIO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<TM_ESTACIONSERVICIO> Update(TM_ESTACIONSERVICIO input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idestservicio_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDESTSERVICIO);
                dyParam.Add("str_numruc_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMRUC);
                dyParam.Add("str_razonsocial_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_RAZONSOCIAL);
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
                dyParam.Add("str_nrosucursales_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NROSUCURSALES);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("str_representante_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_REPRESENTANTE);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_ESTACIONSERVICIO.SP_ActualizarEstacionServicio");
                var result = await connection.QueryFirstOrDefaultAsync<TM_ESTACIONSERVICIO>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
