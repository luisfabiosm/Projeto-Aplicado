using Npgsql;
using System.Data;

namespace Domain.Core.Contracts
{
    public interface IDBConnection
    {
        NpgsqlConnection Connection();
    }
}
