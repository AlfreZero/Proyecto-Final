using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Proyecto_N2.Models;

namespace Proyecto_N2.Logic
{
    public class UsuarioLogica
    {
        public List<Usuario> Listar() { var r = new List<Usuario>(); using (var c=Db.Connection()) using(var q=new SqlCommand("EXEC dbo.Usuarios_Listar",c)){c.Open();using(var d=q.ExecuteReader()){while(d.Read())r.Add(Map(d));}} return r; }
        public Usuario ObtenerPorId(int id) { using(var c=Db.Connection()) using(var q=new SqlCommand("EXEC dbo.Usuarios_Obtener @UsuarioID=@id",c)){q.Parameters.Add("@id",SqlDbType.Int).Value=id;c.Open();using(var d=q.ExecuteReader())return d.Read()?Map(d):null;} }
        public void Guardar(Usuario x) { using(var c=Db.Connection()) using(var q=new SqlCommand("EXEC dbo.Usuarios_Guardar @Nombre=@n,@CorreoElectronico=@e,@Telefono=@t",c)){Add(q,x);c.Open();q.ExecuteNonQuery();} }
        public void Editar(Usuario x) { using(var c=Db.Connection()) using(var q=new SqlCommand("EXEC dbo.Usuarios_Editar @UsuarioID=@id,@Nombre=@n,@CorreoElectronico=@e,@Telefono=@t",c)){q.Parameters.Add("@id",SqlDbType.Int).Value=x.UsuarioID;Add(q,x);c.Open();q.ExecuteNonQuery();} }
        public void Eliminar(int id) { using(var c=Db.Connection()) using(var q=new SqlCommand("EXEC dbo.Usuarios_Eliminar @UsuarioID=@id",c)){q.Parameters.Add("@id",SqlDbType.Int).Value=id;c.Open();q.ExecuteNonQuery();} }
        private static Usuario Map(IDataRecord d) { return new Usuario { UsuarioID=Convert.ToInt32(d["UsuarioID"]),Nombre=d["Nombre"].ToString(),CorreoElectronico=d["CorreoElectronico"].ToString(),Telefono=d["Telefono"]==DBNull.Value?null:d["Telefono"].ToString() }; }
        private static void Add(SqlCommand q, Usuario x) { q.Parameters.Add("@n",SqlDbType.NVarChar,100).Value=x.Nombre; q.Parameters.Add("@e",SqlDbType.NVarChar,150).Value=x.CorreoElectronico; q.Parameters.Add("@t",SqlDbType.NVarChar,30).Value=(object)x.Telefono??DBNull.Value; }
    }
}