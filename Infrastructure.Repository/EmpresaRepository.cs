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
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public EmpresaRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public async Task<TM_EMPRESA> Delete(TM_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idempresa_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDEMPRESA);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("num_identidadusuario_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDAD);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_EMPRESA.SP_EliminarEmpresa");
                var result = await connection.QueryFirstOrDefaultAsync<TM_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_EMPRESA> Get(TM_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idempresa_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDEMPRESA);
                dyParam.Add("num_identidadusuario_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDENTIDAD);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_EMPRESA.SP_GetListaEmpresaxId");
                var result = await connection.QueryFirstOrDefaultAsync<TM_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TM_EMPRESA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
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
                var query = _connectionFactory.GetQueryForSIROS("PKG_EMPRESA.SP_GetListaEmpresa");
                var result = await connection.QueryAsync<TM_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<TM_EMPRESA>> GetCombo(TM_EMPRESA input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_EMPRESA> Insert(TM_EMPRESA input)
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
                dyParam.Add("str_telefono_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_TELEFONO);
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("str_representante_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_REPRESENTANTE);
                dyParam.Add("num_identidadusuario_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDAD);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_EMPRESA.SP_RegistrarEmpresa");
                var result = await connection.QueryFirstOrDefaultAsync<TM_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_EMPRESA> Update(TM_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idempresa_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDEMPRESA);
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
                dyParam.Add("str_telefono_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_TELEFONO);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("str_representante_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_REPRESENTANTE);
                dyParam.Add("num_identidadusuario_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDENTIDAD);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_EMPRESA.SP_ActualizarEmpresa");
                var result = await connection.QueryFirstOrDefaultAsync<TM_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
