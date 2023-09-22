using System.Data.SqlClient;

namespace CP.Data
{
    public interface IConnection
    {
        SqlConnection CreateConnection();
    }
}