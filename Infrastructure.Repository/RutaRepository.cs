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
    public class RutaRepository : IRutaRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public RutaRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public Task<TM_RUTA> Delete(TM_RUTA input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_RUTA> Get(TM_RUTA input)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TM_RUTA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
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
                var query = _connectionFactory.GetQueryForSIROS("PKG_RUTA.SP_GetListaRuta");
                var result = await connection.QueryAsync<TM_RUTA>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public Task<List<TM_RUTA>> GetCombo(TM_RUTA input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_RUTA> Insert(TM_RUTA input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_RUTA> Update(TM_RUTA input)
        {
            throw new NotImplementedException();
        }
    }
}
