using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oleo
{
    public class ClienteDAO
    {
        public List<Oleo> Carregar()
        {
            using (SqlConnection conn = new
            SqlConnection(Properties.Settings.Default.conn))
            {
                string srtSQL = "select * from cliente";
                DataTable dt = new DataTable();
                conn.Open();
                using (SqlCommand cmdo = new SqlCommand())
                {
                    cmdo.CommandType = CommandType.Text;

                    cmdo.Connection = conn;
                    cmdo.CommandText = srtSQL;
                    SqlDataReader dataReader;

                    dataReader = cmdo.ExecuteReader();
                    dt.Load(dataReader);

                    if (!(dt != null && dt.Rows.Count > 0))
                        return null;
                    List<Oleo> lstCliente = new List<Oleo>();
                    
                    foreach (DataRow linha in dt.Rows)
                    {
                        var clente = new Oleo();
                        clente.Nome = Convert.ToString(linha["nome"]);
                        lstCliente.Add(clente);
                    }
                    conn.Close();
                    return lstCliente;

                }
            }
        }
    }
}
