using Dapper;
using Domain.Core.Base;
using Domain.Core.Models.Entities;
using Domain.Core.Models.KeycloakAdminAPI;
using Domain.Core.Ports.Outbound;
using Domain.UseCases.Users.CreateUser;
using Newtonsoft.Json;
using Npgsql;

namespace Adapters.Outbund.DBAdapter
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


        public async ValueTask<Client> AddNewClient(Client client)
        {
            string commandSQL = $@"INSERT INTO public.client (realm, id, clientid, name, publicclient, createdat, isactive, email, appidentityconfiguration)
                                                    VALUES (@realm, @id, @clientid, @name, @publicclient, @createdat, @isactive,  @email, @appidentityconfiguration)";


            var _insertArgs = new Client
            {
                realm = client.realm,
                id = client.id,
                clientid = client.clientid,
                name = client.name,
                publicclient = client.publicclient,
                createdat = DateTime.UtcNow,
                isactive = true,
                appidentityconfiguration = client.appidentityconfiguration,
                email = client.email,
            };

            var ret = await _session.ExecuteAsync(commandSQL, _insertArgs);
            if (ret <= 0) throw new Exception("Erro gravação do client.");


            commandSQL = $"SELECT * FROM public.client where clientid = '{_insertArgs.clientid}'";

            return await _session.QueryFirstOrDefaultAsync<Client>(commandSQL);
        }

        public async ValueTask<User> AddNewUser(TransactionCreateUser transaction, UserRepresentation user)
        {

            string commandSQL = $@"INSERT INTO public.users (realm, clientid, sysusername, syspassword, createdat, isactive , email,  identityuserinfo)
                                                    VALUES (@realm, @clientid, @sysusername, @syspassword, @createdat, @isactive,  @email, @identityuserinfo)";


            var _insertArgs = new User
            {
                realm = transaction.UserInfo.Realm,
                clientid = transaction.UserInfo.ClientId,
                sysusername = transaction.UserInfo.Username,
                syspassword = transaction.UserInfo.Password,
                createdat = DateTime.UtcNow,
                isactive = true,
                identityuserinfo = JsonConvert.SerializeObject(user),
                email = transaction.UserInfo.Email,
            };

            var ret = await _session.ExecuteAsync(commandSQL, _insertArgs);
            if (ret <= 0) throw new Exception("Erro gravação do usuario.");


            commandSQL = $"SELECT * FROM public.users where clientid = '{_insertArgs.clientid}'";

            return await _session.QueryFirstOrDefaultAsync<User>(commandSQL);
        }


        public async ValueTask<Client> GetClient(string realm, string clientid)
        {


            string commandSQL = "SELECT * FROM Client WHERE realm = @realm AND clientid = @clientid AND IsActive = true";

            var queryArgs = new
            {
                realm,
                clientid,
            };

            var client = await _session.QueryFirstOrDefaultAsync<Client>(commandSQL, queryArgs);

            return client;

        }


    }


}
