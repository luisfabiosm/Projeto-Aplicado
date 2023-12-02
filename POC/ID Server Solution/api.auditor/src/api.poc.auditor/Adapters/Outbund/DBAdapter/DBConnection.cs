using Domain.Core.Models.Settings;
using Domain.Core.Ports.Outbound;
using Npgsql;


namespace Adapters.Outbund.DBAdapter
{
    public class DBConnection : IDBConnection
    {
        private NpgsqlConnection _connection;


        public DBConnection(ConnectionSettings settings)
        {
            _connection = new NpgsqlConnection(settings.GetConnectionString());
            _connection.Open();
        }

        public NpgsqlConnection Connection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();

            return _connection;
        }



    }
}
