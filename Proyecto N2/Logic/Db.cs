using System.Configuration;
using System.Data.SqlClient;

namespace Proyecto_N2.Logic
{
    public static class Db
    {
        public static SqlConnection Connection()
        {
            var setting = ConfigurationManager.ConnectionStrings["ConexionBD"];
            if (setting == null) throw new ConfigurationErrorsException("No existe la cadena ConexionBD.");
            return new SqlConnection(setting.ConnectionString);
        }
    }
}