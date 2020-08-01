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
    public class FormularioOGTURepository : IFormularioOGTURepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public FormularioOGTURepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }
        public async Task<TM_FORMULARIO_OGTU> Delete(TM_FORMULARIO_OGTU input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idformulariotu_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDFORMULARIOTU);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_FORMULARIOGTU.SP_EliminarFormularioGTU");
                var result = await connection.QueryFirstOrDefaultAsync<TM_FORMULARIO_OGTU>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_FORMULARIO_OGTU> Get(TM_FORMULARIO_OGTU input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idformulariotu_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDFORMULARIOTU);
                dyParam.Add("num_identidadusuario_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_IDENTIDADUSUARIO);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_FORMULARIOGTU.SP_GetListaFormularioGTUxId");
                var result = await connection.QueryFirstOrDefaultAsync<TM_FORMULARIO_OGTU>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TM_FORMULARIO_OGTU>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
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
                dyParam.Add("num_identidadusuario_", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[2]);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_FORMULARIOGTU.SP_GetListaFormularioGTU");
                var result = await connection.QueryAsync<TM_FORMULARIO_OGTU>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<TM_FORMULARIO_OGTU>> GetCombo(TM_FORMULARIO_OGTU input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_FORMULARIO_OGTU> Insert(TM_FORMULARIO_OGTU input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("str_placa_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_PLACA);
                dyParam.Add("num_idempresa_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDEMPRESA);
                dyParam.Add("num_idsucursalxes_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSUCURSALXES);
                dyParam.Add("num_idvehxemp_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDVEHXEMP);
                dyParam.Add("num_monto_", OracleDbType.Decimal, ParameterDirection.Input, input.NUM_MONTO);
                dyParam.Add("dte_fecsum_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECSUM.ToBDSirosDate());
                dyParam.Add("str_horasum_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_HORASUM);
                dyParam.Add("str_minutosum_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_MINUTOSUM);
                dyParam.Add("str_nombrearchivo_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NOMBREARCHIVO);
                dyParam.Add("num_idtpdocumentoopexemp_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDTPDOCUMENTOOPEXEMP);
                dyParam.Add("str_numdocumentoopexemp_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMDOCUMENTOOPEXEMP);
                dyParam.Add("num_idtpdocumentoopexest_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDTPDOCUMENTOOPEXEST);
                dyParam.Add("str_numdocumentoopexest_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMDOCUMENTOOPEXEST);
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_FORMULARIOGTU.SP_RegistroFormularioGTU");
                var result = await connection.QueryFirstOrDefaultAsync<TM_FORMULARIO_OGTU>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_FORMULARIO_OGTU> Update(TM_FORMULARIO_OGTU input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idformulariotu_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDFORMULARIOTU);
                dyParam.Add("num_idempresa_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDEMPRESA);
                dyParam.Add("num_idsucursalxes_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSUCURSALXES);
                dyParam.Add("str_placa_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_PLACA);
                dyParam.Add("num_monto_", OracleDbType.Decimal, ParameterDirection.Input, input.NUM_MONTO);
                dyParam.Add("dte_fecsum_", OracleDbType.Varchar2, ParameterDirection.Input, input.DTE_FECSUM.ToBDSirosDate());
                dyParam.Add("str_horasum_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_HORASUM);
                dyParam.Add("str_minutosum_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_MINUTOSUM);
                dyParam.Add("str_nombrearchivo_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NOMBREARCHIVO);
                dyParam.Add("num_idtpdocumentoopexemp_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDTPDOCUMENTOOPEXEMP);
                dyParam.Add("str_numdocumentoopexemp_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMDOCUMENTOOPEXEMP);
                dyParam.Add("num_idtpdocumentoopexest_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDTPDOCUMENTOOPEXEST);
                dyParam.Add("str_numdocumentoopexest_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_NUMDOCUMENTOOPEXEST);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);

                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_FORMULARIOGTU.SP_ActualizarFormularioGTU");
                var result = await connection.QueryFirstOrDefaultAsync<TM_FORMULARIO_OGTU>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
