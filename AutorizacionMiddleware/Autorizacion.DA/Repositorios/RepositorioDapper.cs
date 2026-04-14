using Autorizacion.Abstracciones.Da;

using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Autorizacion.DA.Repositorios
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configuracion;
        private SqlConnection _connection;

        public RepositorioDapper(IConfiguration configuracion, SqlConnection connection)
        {
            _configuracion = configuracion;
            _connection = new SqlConnection(_configuracion.GetConnectionString("Productos"));
        }

        public SqlConnection ObtenerRepositorioDapper()
        {
            return _connection;
        }
    }
}
