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

        public async Task<TM_MUNICIPALIDAD> Get(TM_MUNICIPALIDAD input)
        {
            /*
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("NID", OracleDbType.Varchar2, ParameterDirection.Input, input.NID);
                dyParam.Add("VAR_CURSOR_OUT", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_SIROS.SP_MUNICIPALIDAD_GET");
                var result = await connection.QueryFirstOrDefaultAsync<TM_MUNICIPALIDAD>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            */
            return new TM_MUNICIPALIDAD { NID = 1, SNOMBRE = "Test", SDIRECCION = "MTC" };
        }

        public async Task<List<TM_MUNICIPALIDAD>> GetAllByFilter(int pagina, string filter)
        {
            /*using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                // CREAR VARIABLE EN CASO SEAS MAS DE UN FILTRO
                var splFilter = filter.Split('@');

                var dyParam = new OracleDynamicParameters();
                dyParam.Add("NPAGINO", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[0]);
                dyParam.Add("SNOMBRE", OracleDbType.Varchar2, ParameterDirection.Input,splFilter[0]);
                dyParam.Add("SDIRECCION", OracleDbType.Varchar2, ParameterDirection.Input, splFilter[0]);
                dyParam.Add("VAR_CURSOR_OUT", OracleDbType.RefCursor, ParameterDirection.Output);
                var query = _connectionFactory.GetQueryForSIROS("PKG_SIROS.SP_MUNICIPALIDAD_GETALLBYFILTER");
                var result = await connection.QueryAsync<TM_MUNICIPALIDAD>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList();
            }*/
            var lst = new List<TM_MUNICIPALIDAD>();
            lst.Add(new TM_MUNICIPALIDAD { NFILA=1,NPAGINAS=1,NREGISTROS=10,NID=1,SDIRECCION="Direccion",SNOMBRE="Nombre"});
            lst.Add(new TM_MUNICIPALIDAD { NFILA = 2, NPAGINAS = 1, NREGISTROS = 10, NID = 2, SDIRECCION = "Direccion", SNOMBRE = "Nombre" });
            lst.Add(new TM_MUNICIPALIDAD { NFILA = 3, NPAGINAS = 1, NREGISTROS = 10, NID = 3, SDIRECCION = "Direccion", SNOMBRE = "Nombre" });
            return lst;
        }

        public async Task<List<TM_MUNICIPALIDAD>> GetCombo(TM_MUNICIPALIDAD input)
        {
            /*using (var connection = _connectionFactory.GetConnectionSIROS())
           {
               
               var dyParam = new OracleDynamicParameters();
              
               dyParam.Add("VAR_CURSOR_OUT", OracleDbType.RefCursor, ParameterDirection.Output);
               var query = _connectionFactory.GetQueryForSIROS("PKG_SIROS.SP_MUNICIPALIDAD_GETCOMBO");
               var result = await connection.QueryAsync<TM_MUNICIPALIDAD>(query, param: dyParam, commandType: CommandType.StoredProcedure);
               return result.AsList();
           }*/
            var lst = new List<TM_MUNICIPALIDAD>();
            lst.Add(new TM_MUNICIPALIDAD { NID = 1, SDIRECCION = "Direccion", SNOMBRE = "Nombre" });
            lst.Add(new TM_MUNICIPALIDAD { NID = 2, SDIRECCION = "Direccion", SNOMBRE = "Nombre" });
            lst.Add(new TM_MUNICIPALIDAD {NID = 3, SDIRECCION = "Direccion", SNOMBRE = "Nombre" });
            return lst;
        }

        public async Task<int> Insert(TM_MUNICIPALIDAD input)
        {
            return -1;
        }

        public async Task<int> Update(TM_MUNICIPALIDAD input)
        {
            return 1;
        }
    }
}
