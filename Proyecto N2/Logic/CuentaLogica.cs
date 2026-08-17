using System;
using System.Data;
using System.Data.SqlClient;
using Proyecto_N2.Models;

namespace Proyecto_N2.Logic
{
    public class CuentaLogica
    {
        public Usuario Validar(LoginViewModel modelo)
        {
            using (var conexion = Db.Connection())
            using (var comando = new SqlCommand("dbo.Login_Validar", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@CorreoElectronico", SqlDbType.NVarChar, 150).Value = modelo.CorreoElectronico;
                comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 200).Value = modelo.Clave;
                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    if (!lector.Read()) return null;
                    return new Usuario
                    {
                        UsuarioID = Convert.ToInt32(lector["UsuarioID"]),
                        Nombre = lector["Nombre"].ToString(),
                        CorreoElectronico = lector["CorreoElectronico"].ToString()
                    };
                }
            }
        }
    }
}
