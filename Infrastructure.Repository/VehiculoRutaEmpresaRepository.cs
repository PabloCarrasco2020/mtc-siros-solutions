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
    public class VehiculoRutaEmpresaRepository : IVehiculoRutaEmpresaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public VehiculoRutaEmpresaRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public async Task<TM_VEHICULO_RUTA_EMPRESA> Delete(TM_VEHICULO_RUTA_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_vehxemp_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_VEHXEMP);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_VEHXEMP.SP_EliminarVehxEmp");
                var result = await connection.QueryFirstOrDefaultAsync<TM_VEHICULO_RUTA_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_VEHICULO_RUTA_EMPRESA> Get(TM_VEHICULO_RUTA_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_vehxemp_", OracleDbType.Varchar2, ParameterDirection.Input, input.NUM_VEHXEMP);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_VEHXEMP.SP_GetListaVehxEmpxId");
                var result = await connection.QueryFirstOrDefaultAsync<TM_VEHICULO_RUTA_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TM_VEHICULO_RUTA_EMPRESA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
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
                dyParam.Add("num_idrutaxemp_", OracleDbType.Int32, ParameterDirection.Input, splFilter[3]);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_VEHXEMP.SP_GetListaVehxEmp");
                var result = await connection.QueryAsync<TM_VEHICULO_RUTA_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public Task<List<TM_VEHICULO_RUTA_EMPRESA>> GetCombo(TM_VEHICULO_RUTA_EMPRESA input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_VEHICULO_RUTA_EMPRESA> Insert(TM_VEHICULO_RUTA_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_idempresa_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDEMPRESA);
                dyParam.Add("num_idrutaxemp_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDRUTAXEMP);
                dyParam.Add("num_idsucursalxes_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSUCURSALXES);
                dyParam.Add("str_placa_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_PLACA);
                dyParam.Add("num_idcombustible_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDCOMBUSTIBLE);
                dyParam.Add("str_anofab_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_ANOFAB);
                dyParam.Add("str_anomodelo_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_ANOMODELO);
                dyParam.Add("str_marca_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_MARCA);
                dyParam.Add("num_asientos_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_ASIENTOS);
                dyParam.Add("str_usucreacion_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUCREACION);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_VEHXEMP.SP_RegistroVehxEmp");
                var result = await connection.QueryFirstOrDefaultAsync<TM_VEHICULO_RUTA_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<TM_VEHICULO_RUTA_EMPRESA> Update(TM_VEHICULO_RUTA_EMPRESA input)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("num_vehxemp_  ", OracleDbType.Int32, ParameterDirection.Input, input.NUM_VEHXEMP);
                dyParam.Add("num_idsucursalxes_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSUCURSALXES);
                dyParam.Add("num_idcombustible_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDCOMBUSTIBLE);
                dyParam.Add("str_usuact_", OracleDbType.Varchar2, ParameterDirection.Input, input.STR_USUACT);
                dyParam.Add("num_idsesion_", OracleDbType.Int32, ParameterDirection.Input, input.NUM_IDSESION);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_VEHXEMP.SP_ActualizarVehxEmp");
                var result = await connection.QueryFirstOrDefaultAsync<TM_VEHICULO_RUTA_EMPRESA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
