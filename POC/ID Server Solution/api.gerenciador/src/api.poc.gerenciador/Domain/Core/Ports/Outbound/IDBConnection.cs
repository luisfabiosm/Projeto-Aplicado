using Npgsql;

namespace Domain.Core.Ports.Outbound
{
    public interface IDBConnection
    {
        NpgsqlConnection Connection();
    }
}
