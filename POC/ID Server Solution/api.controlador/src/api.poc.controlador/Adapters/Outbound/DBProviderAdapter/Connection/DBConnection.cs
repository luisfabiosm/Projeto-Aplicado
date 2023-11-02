using Domain.Core.Contracts;
using Domain.Core.Models.Settings;
using Npgsql;


namespace Adapters.DBProvider.Connection
{
    public class DBConnection : IDBConnection
    {
        private NpgsqlConnection _connection;


        public DBConnection(ConnectionSettings settings)
        {
            _connection = new NpgsqlConnection(settings.GetConnectionString());
        }

        public NpgsqlConnection Connection()
        {
            _connection.Open();
            return _connection;
        }



    }
}
