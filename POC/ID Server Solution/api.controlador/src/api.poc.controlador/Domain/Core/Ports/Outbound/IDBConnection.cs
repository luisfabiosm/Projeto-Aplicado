using Npgsql;
using System.Data;

namespace Domain.Core.Ports.Outbound
{
    public interface IDBConnection
    {
        NpgsqlConnection Connection();
    }
}
