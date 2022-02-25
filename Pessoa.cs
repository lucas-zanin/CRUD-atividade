using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace atividade
{
    class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string datanasc { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string cidade { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aluno\\source\\repos\\atividade\\atividade\\Pessoa.mdf;Integrated Security=True");

        public List <Pessoa> listapessoa()
        {
            List<Pessoa> li = new List<Pessoa>();
            string sql = "SELECT * FROM Pessoa";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pessoa p = new Pessoa();
                p.id = (int)dr["id"];
                p.nome = dr["nome"].ToString();
                p.datanasc = dr["datanasc"].ToString();
                p.email = dr["email"].ToString();
                p.celular = dr["celular"].ToString();
                p.cidade = dr["cidade"].ToString();
                li.Add(p);
            }
            return li;
        }

        public void Inserir(string nome, string datanasc, string email, string celular, string cidade)
        {
            string sql = "INSERT INTO Pessoa(nome,datanasc,email,celular,cidade) VALUES ('" + nome + "','" + datanasc + "','" + email + "','" + celular + "','" + cidade + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localiza(int id)
        {
            string sql = "SELECT * FROM Pessoa WHERE Id = '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                datanasc = dr["datanasc"].ToString();
                email = dr["email"].ToString();
                celular = dr["celular"].ToString();
                cidade = dr["cidade"].ToString();
            }
        }

        public void Atualizar(int id, string nome, string datanasc, string email, string celular, string cidade)
        {
            string sql = "UPDATE Pessoa SET nome='" + nome + "',datanasc='" + datanasc + "',email='" + email + "',celular='" + celular + "',cidade='"+cidade+"' WHERE Id='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Exclui(int id)
        {
            string sql = "DELETE FROM Pessoa WHERE id='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
