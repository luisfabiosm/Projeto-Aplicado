﻿
using Domain.Core.Models.Settings;
using Domain.Core.Ports.Outbound;
using Npgsql;


namespace Adapters.Outbound.DBAdapter
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
