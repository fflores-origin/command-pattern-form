using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CP.Data
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;
        private string _coonectionString;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _coonectionString = _configuration.GetConnectionString("default").ToString();
        }

        // TODO: crear factory
        public SqlConnection CreateConnection() => new(_coonectionString);
    }
}