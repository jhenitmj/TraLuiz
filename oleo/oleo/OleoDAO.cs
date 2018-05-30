using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oleo
{
    public class OleoDAO
    {
        #region Carregar Oleo
        public List<Oleo> CarregarOleo()
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
                    List<Oleo> lstOleo = new List<Oleo>();
                    foreach (DataRow linha in dt.Rows)
                    {
                        Oleo oleo = new Oleo();
                        oleo.Nome = Convert.ToString(linha["NOME_PECA"]);
                        lstOleo.Add(oleo);
                    }
                    conn.Close();
                    return lstOleo;
                }
            }
        }
        #endregion

        #region Carregar Categoria Oleo
        public List<Oleo> CarregarCat()
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
                    List<Oleo> lstOleo = new List<Oleo>();
                    foreach (DataRow linha in dt.Rows)
                    {
                        Oleo oleo = new Oleo();
                        oleo.Nome = Convert.ToString(linha["categoria"]);
                        lstOleo.Add(oleo);
                    }
                    conn.Close();
                    return lstOleo;
                }
            }
        }
        #endregion
    }
}
