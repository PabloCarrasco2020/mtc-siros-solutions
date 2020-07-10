using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using Transversal.Common;
using Transversal.Common.Helper;

namespace Infrastructure.Data
{
    public class ConnectionFactory:IConnectionFactory
    {
        private readonly AppSettings.ConnectionStrings _settings;

        public ConnectionFactory(IOptions<AppSettings.ConnectionStrings> settings)
        {
            this._settings = settings.Value;
        }

        public IDbConnection GetConnectionSIROS()
        {
                var dbConnection = new OracleConnection();
                if (dbConnection == null) return null;
                dbConnection.ConnectionString = this._settings.SIROSConnection;
                dbConnection.Open();
                return dbConnection;
            
        }
        public string GetQueryForSIROS(string pProcedureName)
        {
            var esquema = this._settings.SchemaDB;
            return string.Format("{0}.{1}", esquema, pProcedureName);
        }
    }
}
