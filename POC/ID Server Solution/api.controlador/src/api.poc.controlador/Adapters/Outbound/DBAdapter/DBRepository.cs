using Dapper;
using Domain.Core.Models.Entities;
using Domain.Core.Models.VO;
using Domain.Core.Ports.Outbound;
using Keycloak.AuthServices.Sdk.Admin.Models;
using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Net.Sockets;

namespace Adapters.Outbound.DBAdapter
{
    public class DBRepository : IDBRepositoryPort
    {

        private readonly IDBConnection _connection;
        private readonly NpgsqlConnection _session;


        public DBRepository(IServiceProvider serviceProvider)
        {
            _connection = serviceProvider.GetRequiredService<IDBConnection>();
            _session = _connection.Connection();
        }

        public async ValueTask<Operator> GetAuthenticationInfo(string user, string secret)
        {
            string commandSQL = $"SELECT * FROM Operator where User = '{user}' AND Password = '{secret}'";
            return await _session.QueryFirstOrDefaultAsync<Operator>(commandSQL);
        }

      
        public async ValueTask<bool> UpdateAuthenticationInfo(TokenInfo token, string user, string secret)
        {

                string commandSQL = $@" UPDATE Operator SET ExpirationSeconds       = @ExpirationSeconds, 
                                                                KeycloakSerializedInfo  = @KeycloakSerializedInfo,
                                                                ForceChange             = {false},
                                                                LastUpdate              = @LastUpdate
                                                          WHERE User                    = @User 
                                                            AND Secret                  = @Secret ";

                var _updateArgs = new
                {
                    ExpirationSeconds = token.ExpiresIn,
                    KeycloakSerializedInfo = JsonConvert.SerializeObject(token),
                    ForceChange = false,
                    LastUpdate = DateTime.UtcNow,
                    // RefreshToken = game.AverageDuration,
                    User = user,
                    Secret = secret
                };

                var ret = await _session.ExecuteAsync(commandSQL, _updateArgs);
                return ret > 0 ? true : false;
            
 
        }


        public async ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log)
        {
            string commandSQL = @"INSERT INTO LogTransaction (TranRealDate, TranLogID, TranCode, TranSourceApp, TranRequestInfo, TranDetailInfo, TranResponseInfo, TranStatus)
                                VALUES (@TranRealDate, @TranLogID, @TranCode, @TranSourceApp, @TranRequestInfo, @TranDetailInfo, @TranResponseInfo, @TranStatus)";

            var _insertargs =  new
            {
                TranRealDate = log.TranRealDate,
                TranLogID = log.TranLogID,
                TranCode = log.TranCode,
                TranSourceApp = log.TranSourceApp,
                TranRequestInfo = log.TranRequestInfo,
                TranDetailInfo = log.TranDetailInfo,
                TranResponseInfo = log.TranResponseInfo,
                TranStatus = log.TranStatus
            };

            var ret = await _session.ExecuteAsync(commandSQL, _insertargs);
            if (ret <= 0) throw new Exception("Erro gravação do LogTransaction.");

            commandSQL = $"SELECT * FROM LogTransaction where TranLogID = '{_insertargs.TranLogID}'";

            return await _session.QueryFirstOrDefaultAsync<LogTransaction>(commandSQL);
        }

        public async ValueTask<LogTransaction> UpdateLogTransaction(LogTransaction log)
        {

            string commandSQL = $@" UPDATE LogTransaction SET  TranStatus         = @TranStatus, 
                                                               TranResponseInfo   = @TranResponseInfo
                                                          WHERE TranLogID         = @TranLogID ";

            var _updateArgs = new
            {
                TranStatus = log.TranStatus,
                TranResponseInfo = log.TranResponseInfo,
                TranLogID = log.TranLogID
            };

            var ret = await _session.ExecuteAsync(commandSQL, _updateArgs);

            if (ret <= 0) throw new Exception("Erro atualização do LogTransaction.");

            commandSQL = $"SELECT * FROM LogTransaction where TranLogID = '{_updateArgs.TranLogID}'";

            return await _session.QueryFirstOrDefaultAsync<LogTransaction>(commandSQL);

        }
    }


}
