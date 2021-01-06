using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Acceso_Datos
{
    public class PersonaDAO
    {
        private static String cadenaConexion = @"LAPTOP-ACMMVUIM\SQLEXPRESS; database=estudiante; integrated security=true";
        public static int crear(Personas personas)
        {
            string cadenaConexion = @"Server=LAPTOP-ACMMVUIM\SQLEXPRESS; database=estudiante; integrated security=true";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            string sql = "insert into Personas(cedula, apellidos, nombre, sexo, F_Nacimiento, correo, Estatura, peso) values(@cedula, @apellidos, @nombre, @sexo, @F_Nacimiento, @correo, @Estatura, @peso)";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@cedula",personas.cedula);
            comando.Parameters.AddWithValue("@apellidos", personas.apellidos);
            comando.Parameters.AddWithValue("@nombre", personas.nombres);
            comando.Parameters.AddWithValue("@sexo", personas.sexo);
            comando.Parameters.AddWithValue("@F_Nacimiento", personas.F_Nacimiento);
            comando.Parameters.AddWithValue("@correo", personas.correo);
            comando.Parameters.AddWithValue("@Estatura", personas.estatura);
            comando.Parameters.AddWithValue("@peso", personas.peso);
            conexion.Open();
            int x = comando.ExecuteNonQuery();
            conexion.Close();
            return x;
        }
        public static int actualizar(Personas personas)
        {
            string cadenaConexion = @"Server=LAPTOP-ACMMVUIM\SQLEXPRESS; database=estudiante; integrated security=true";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            string sql = "update Personas set  apellidos=@apellidos, nombre=@nombre, sexo=@sexo, F_Nacimiento=@F_Nacimiento, " +
                 "correo=@correo, Estatura=@Estatura, peso=@peso " + " where cedula=@cedula";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@cedula", personas.cedula);
            comando.Parameters.AddWithValue("@apellidos", personas.apellidos);
            comando.Parameters.AddWithValue("@nombre", personas.nombres);
            comando.Parameters.AddWithValue("@sexo", personas.sexo);
            comando.Parameters.AddWithValue("@F_Nacimiento", personas.F_Nacimiento);
            comando.Parameters.AddWithValue("@correo", personas.correo);
            comando.Parameters.AddWithValue("@Estatura", personas.estatura);
            comando.Parameters.AddWithValue("@peso", personas.peso);
            conexion.Open();
            int X = comando.ExecuteNonQuery();

            conexion.Close();

            return X;
        }
        public static int eliminar(string Cedula)
        {
            string cadenaConexion = @"Server=LAPTOP-ACMMVUIM\SQLEXPRESS; database=estudiante; integrated security=true";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            string sql = "delete from Personas"  + " where cedula=@cedula";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@cedula", Cedula);
            conexion.Open();
            int X = comando.ExecuteNonQuery();

            conexion.Close();

            return X;
        }
        public static DataTable getAll()
        {
            string cadenaConexion = @"Server=LAPTOP-ACMMVUIM\SQLEXPRESS; database=estudiante; integrated security=true";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            string sql = "select cedula, apellidos, nombre,upper(apellidos +' '+ nombre) as estudiante , case when sexo='M' then 'Masculino' else 'Femenino' end as sexo, F_Nacimiento, correo, Estatura, peso" + " from Personas order by apellidos, nombre";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conexion);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public static Personas GetPersona(String cedula)
        {
            string cadenaConexion = @"Server=LAPTOP-ACMMVUIM\SQLEXPRESS; database=estudiante; integrated security=true";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            string sql = "select cedula, apellidos, nombre, sexo, F_Nacimiento , correo, Estatura, peso " +
                "from Personas " +
                "where cedula=@cedula";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conexion);
            ad.SelectCommand.Parameters.AddWithValue("@cedula", cedula);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            Personas p = new Personas();
            p.cedula = "";
            p.apellidos = "";
            p.nombres = "";
            p.sexo = "";
            p.estatura = 0;
            p.peso = 0;
            p.correo = "";
            foreach (DataRow fila in dt.Rows)
            {
                p.cedula = fila["cedula"].ToString();
                p.apellidos = fila["apellidos"].ToString();
                p.nombres = fila["nombre"].ToString();
                p.sexo = fila["sexo"].ToString();
                p.correo = fila["correo"].ToString();
                p.estatura = int.Parse(fila["Estatura"].ToString());
                p.peso = decimal.Parse(fila["peso"].ToString());
                p.F_Nacimiento = Convert.ToDateTime(fila["F_Nacimiento"].ToString());
                break; //abandonar el for
            }

            return p;
        }

    }
}
