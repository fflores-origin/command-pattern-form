using System.Data.SqlClient;

namespace CP.Data
{
    public class OrdenesRepository
    {
        private readonly IConnection _connection;

        public OrdenesRepository(IConnection connection)
        {
            _connection = connection;
        }

        public void SaveOrUpdate(string accion, string valor)
        {
            using (var conn = _connection.CreateConnection())
            {
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    var query = $"INSERT INTO LogOrdenesRealizadas(Orden, Valor) values('{accion}', '{valor}')";
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}