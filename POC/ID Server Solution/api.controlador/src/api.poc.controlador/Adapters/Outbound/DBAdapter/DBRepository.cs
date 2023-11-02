using Dapper;
using Domain.Core.Models.Entities;
using Domain.Core.Models.VO;
using Domain.Core.Ports.Outbound;
using Newtonsoft.Json;
using Npgsql;

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
    }
}
