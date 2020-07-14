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
    public class CombustibleRepository : ICombustibleRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public CombustibleRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public Task<TM_COMBUSTIBLE> Delete(TM_COMBUSTIBLE input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_COMBUSTIBLE> Get(TM_COMBUSTIBLE input)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TM_COMBUSTIBLE>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
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
                var query = _connectionFactory.GetQueryForSIROS("PKG_COMBUSTIBLE.SP_GetListaCombustible");
                var result = await connection.QueryAsync<TM_COMBUSTIBLE>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public Task<List<TM_COMBUSTIBLE>> GetCombo(TM_COMBUSTIBLE input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_COMBUSTIBLE> Insert(TM_COMBUSTIBLE input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_COMBUSTIBLE> Update(TM_COMBUSTIBLE input)
        {
            throw new NotImplementedException();
        }
    }
}
