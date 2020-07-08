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
    public class MunicipalidadRepository:IMunicipalidadRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public MunicipalidadRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public async Task<TM_MUNICIPALIDAD> Delete(TM_MUNICIPALIDAD input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_identidad_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDENTIDAD);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_MUNICIPALIDAD.SP_EliminarMunicipalidad");
                var result = await connection.QueryFirstOrDefaultAsync<TM_MUNICIPALIDAD>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_MUNICIPALIDAD> Get(TM_MUNICIPALIDAD input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_identidad_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDENTIDAD);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_MUNICIPALIDAD.SP_GetListaMunicipalidadxId");
                var result = await connection.QueryFirstOrDefaultAsync<TM_MUNICIPALIDAD>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }   
        }

        public async Task<List<TM_MUNICIPALIDAD>> GetAllByFilter(int cantidadXPagina,int pagina, string filter)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                // CREAR VARIABLE EN CASO SEAS MAS DE UN FILTRO
                var splFilter = filter.Split('@');
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_filtrotipo_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[0]);
                dyParam.Add("str_filtrovalor_", OracleDbType.Varchar2, ParameterDirection.Input,splFilter[1]);
                dyParam.Add("int_pagina_", OracleDbType.Varchar2, ParameterDirection.Input, pagina);
                dyParam.Add("int_registros_", OracleDbType.Varchar2, ParameterDirection.Input, cantidadXPagina);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_SIROS.SP_MUNICIPALIDAD_GETALLBYFILTER");
                var result = await connection.QueryAsync<TM_MUNICIPALIDAD>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<TM_MUNICIPALIDAD>> GetCombo(TM_MUNICIPALIDAD input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_MUNICIPALIDAD> Insert(TM_MUNICIPALIDAD input)
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
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("str_representante_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_REPRESENTANTE);
                dyParam.Add("num_identidadsso_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDADSSO);
                dyParam.Add("num_idlocalsso_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDLOCALSSO);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_MUNICIPALIDAD.SP_RegistrarMunicipalidad");
                var result = await connection.QueryFirstOrDefaultAsync<TM_MUNICIPALIDAD>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_MUNICIPALIDAD> Update(TM_MUNICIPALIDAD input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_identidad_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDENTIDAD);
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
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("str_representante_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_REPRESENTANTE);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_MUNICIPALIDAD.SP_ActualizarMunicipalidad");
                var result = await connection.QueryFirstOrDefaultAsync<TM_MUNICIPALIDAD>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
