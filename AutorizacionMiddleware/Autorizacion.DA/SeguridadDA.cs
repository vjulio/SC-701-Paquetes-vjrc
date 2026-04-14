using Autorizacion.Abstracciones.Da;
using Autorizacion.Abstracciones.Modelos;
using System.Data.SqlClient;
using Dapper;
using Helpers;

namespace Autorizacion.DA
{
    public class SeguridadDA : ISeguridadDA
    {
        IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public SeguridadDA(IRepositorioDapper repositorioDapper, SqlConnection sqlConnection)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<IEnumerable<Perfil>> ObtenerPerfilesxUsuario(Usuario usuario)
        {
            string sql = @"[ObtenerPerfilesxUsuario]";
            var consulta = await _sqlConnection.QueryAsync<Abstracciones.Entidades.Perfil>(sql,new 
            {CorreoElectronico = usuario.CorreoElectronico, NombreUsuario = usuario.NombreUsuario});

            return Convertidor.ConvertirLista<Abstracciones.Entidades.Perfil, Abstracciones.Modelos.Perfil>(consulta);

        }

        public async Task<Usuario> ObtenerUsuario(Usuario usuario)
        {
            string sql = @"[ObtenerUsuario]";
            var consulta = await _sqlConnection.QueryAsync<Abstracciones.Entidades.Usuario>(sql, new
            { CorreoElectronico = usuario.CorreoElectronico, NombreUsuario = usuario.NombreUsuario });

            return Convertidor.Convertir<Abstracciones.Entidades.Usuario, Abstracciones.Modelos.Usuario>(consulta.FirstOrDefault() );
        }
    }
}
