using Dapper;
using Domain.Core.Base;
using Domain.Core.Models.Entities;
using Domain.Core.Ports.Outbound;
using Keycloak.AuthServices.Sdk.Admin.Models;
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

        public async ValueTask<Operator> GetAuthenticationInfo(string clientid, string user, string secret)
        {
            string commandSQL = $"SELECT * FROM userauthentication where User = '{user}' AND Password = '{secret}'";
            return await _session.QueryFirstOrDefaultAsync<Operator>(commandSQL);
        }


        //public async ValueTask<bool> UpdateAuthenticationInfo(TokenInfo token, string user, string secret)
        //{

        //    string commandSQL = $@" UPDATE Operator SET ExpirationSeconds       = @ExpirationSeconds, 
        //                                                        KeycloakSerializedInfo  = @KeycloakSerializedInfo,
        //                                                        ForceChange             = {false},
        //                                                        LastUpdate              = @LastUpdate
        //                                                  WHERE User                    = @User 
        //                                                    AND Secret                  = @Secret ";

        //    var _updateArgs = new
        //    {
        //        ExpirationSeconds = token.ExpiresIn,
        //        KeycloakSerializedInfo = JsonConvert.SerializeObject(token),
        //        ForceChange = false,
        //        LastUpdate = DateTime.UtcNow,
        //        // RefreshToken = game.AverageDuration,
        //        User = user,
        //        Secret = secret
        //    };

        //    var ret = await _session.ExecuteAsync(commandSQL, _updateArgs);
        //    return ret > 0 ? true : false;


        //}


        public async ValueTask<User> GetUser(string realm, string clientid, string username)
        {

            string commandSQL = "SELECT * FROM users WHERE realm = @Realm AND clientid = @ClientId AND sysusername = @SysUsername AND isactive = true";

            var queryArgs = new
            {
                Realm = realm,
                ClientId = clientid,
                SysUsername = username
            };

            var user = await _session.QueryFirstOrDefaultAsync<User>(commandSQL, queryArgs);

            return user;
        }


        public async ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log, BaseTransaction transaction = null)
        {
            string commandSQL = @"INSERT INTO public.logtransaction (tranrealdate, tranlogid, trancode, transourceapp, tranrequestinfo, trandetailinfo, tranresponseinfo, transtatus)
                                VALUES (@tranrealdate, @tranlogid, @trancode, @transourceapp, @tranrequestinfo, @trandetailinfo, @tranresponseinfo, @transtatus)";

            var _insertargs = new
            {
                log.tranrealdate,
                log.tranlogid,
                log.trancode,
                transourceapp = log.transourceapp ?? "",
                tranrequestinfo = JsonConvert.SerializeObject(transaction),
                trandetailinfo = log.trandetailinfo ?? "",
                tranresponseinfo = log.tranresponseinfo ?? "",
                transtatus = (int)log.transtatus
            };


            var ret = await _session.ExecuteAsync(commandSQL, _insertargs);
            if (ret <= 0) throw new Exception("Erro gravação do LogTransaction.");

            commandSQL = $"SELECT * FROM public.logtransaction where tranlogid = '{_insertargs.tranlogid}'";

            return await _session.QueryFirstOrDefaultAsync<LogTransaction>(commandSQL);

        }

        public async ValueTask<LogTransaction> UpdateLogTransaction(BaseTransaction transaction)
        {

            string commandSQL = $@" UPDATE public.logtransaction SET  transtatus         = @transtatus, 
                                                                      tranresponseinfo   = @tranresponseinfo
                                                                WHERE tranlogid          = @TranLogID ";

            var _updateArgs = new
            {
                transtatus = (int)transaction.TransactionLog.transtatus,
                transaction.TransactionLog.tranresponseinfo,
                transaction.TransactionLog.tranlogid
            };

            var ret = await _session.ExecuteAsync(commandSQL, _updateArgs);

            if (ret <= 0) throw new Exception("Erro atualização do LogTransaction.");

            commandSQL = $"SELECT * FROM public.logtransaction where tranlogid = '{_updateArgs.tranlogid}'";

            return await _session.QueryFirstOrDefaultAsync<LogTransaction>(commandSQL);

        }
    }


}
