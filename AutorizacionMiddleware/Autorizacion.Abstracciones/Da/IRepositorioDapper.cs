using System.Data.SqlClient;

namespace Autorizacion.Abstracciones.Da
{
    public interface IRepositorioDapper
    {
        SqlConnection ObtenerRepositorioDapper();
    }
}
