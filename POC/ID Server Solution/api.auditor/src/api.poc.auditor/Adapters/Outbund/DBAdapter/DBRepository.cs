using Dapper;
using Domain.Core.Base;
using Domain.Core.Models.Entities;
using Domain.Core.Ports.Outbound;

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

     

         


       

      


    }


}
