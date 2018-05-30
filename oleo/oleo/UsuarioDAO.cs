using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oleo
{
    public class UsuarioDAO
    {
        public Usuario Logar(string email, string senha)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.conn))
            /*"Data Source = localhost; Initial Catalog = oil; Integrated Security = True"*/
            {
                string str = @"select email, senha from usuario where email = @email or senha = @senha";
                using (SqlCommand cmd = new SqlCommand(str))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
                    cmd.CommandText = str;

                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);

                    if (!(dt != null && dt.Rows.Count > 0))
                        return null;

                    var row = dt.Rows[0];
                    var usuario = new Usuario()
                    {
                        Email = row["email"].ToString(),
                        Senha = row["senha"].ToString()
                    };
                    conn.Close();
                    return usuario;
                }
            }
        }
    }
}
