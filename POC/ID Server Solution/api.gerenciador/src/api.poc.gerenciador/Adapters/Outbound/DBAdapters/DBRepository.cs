using Dapper;
using Domain.Core.Models.Entities;
using Domain.Core.Ports.Outbound;
using Newtonsoft.Json;
using Npgsql;

namespace Adapters.Outbound.DBAdapters
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

     
        public async ValueTask<LogTransaction> SaveLogTransaction(LogTransaction log)
        {
            string commandSQL = @"INSERT INTO LogTransaction (TranRealDate, TranLogID, TranCode, TranSourceApp, TranRequestInfo, TranDetailInfo, TranResponseInfo, TranStatus)
                                VALUES (@TranRealDate, @TranLogID, @TranCode, @TranSourceApp, @TranRequestInfo, @TranDetailInfo, @TranResponseInfo, @TranStatus)";

            var _insertargs = new
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
