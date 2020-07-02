using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Transversal.Common;

namespace Infrastructure.Data
{
    public class ConnectionFactory:IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IDbConnection GetConnectionSIROS()
        {
                var dbConnection = new OracleConnection();
                if (dbConnection == null) return null;
                dbConnection.ConnectionString = _configuration.GetSection("ConnectionStrings").GetSection("SIROSConnection").Value;
                dbConnection.Open();
                return dbConnection;
            
        }
        public string GetQueryForSIROS(string pProcedureName)
        {
            var esquema = _configuration.GetSection("schemaDB").GetSection("SIROS").Value;
            return string.Format("{0}.{1}", esquema, pProcedureName);
        }
    }
}
