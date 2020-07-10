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
    public class AdminRepository : IAdminRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public AdminRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }

        public async Task<ADMIN.TM_SESION> RegistrarSesion(ADMIN.TM_SESION oItem)
        {
            using (var connection = _connectionFactory.GetConnectionSIROS())
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("str_usuario_", OracleDbType.Varchar2, ParameterDirection.Input, oItem.STR_USUARIO);
                dyParam.Add("str_userso_", OracleDbType.Varchar2, ParameterDirection.Input, oItem.STR_USERSO);
                dyParam.Add("str_numeroip_", OracleDbType.Varchar2, ParameterDirection.Input, oItem.STR_NUMEROIP);
                dyParam.Add("str_flagcr_", OracleDbType.Varchar2, ParameterDirection.Input, oItem.STR_FLAGCR);
                dyParam.Add("num_idsesionsso_", OracleDbType.Int32, ParameterDirection.Input, oItem.NUM_IDSESIONSSO);
                dyParam.Add("p_cursor_", OracleDbType.RefCursor, ParameterDirection.Output);

                var query = _connectionFactory.GetQueryForSIROS("PKG_ADMIN.SP_RegistrarSesion");
                var result = await connection.QueryFirstOrDefaultAsync<ADMIN.TM_SESION>(query, param: dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
