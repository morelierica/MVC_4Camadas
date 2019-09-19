using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Sistema.Entidades;
using Sistema.DAO;
using System.Data.SqlTypes;
using System.Data;

namespace Sistema.DAO
{
    public class UserDAO
    {
        public int Insert(UserEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();            
                cn.CommandText = "INSERT INTO USERS ([name], [login], [password]) VALUES (@name, @login, @password)";
                cn.Parameters.Add("name", SqlDbType.VarChar).Value = objTabela.Name;
                cn.Parameters.Add("login", SqlDbType.VarChar).Value = objTabela.Login;
                cn.Parameters.Add("password", SqlDbType.VarChar).Value = objTabela.Password;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();                
                return qtd;
            }           
        }

        public List<UserEnt> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * from users ORDER BY id DESC";               
                cn.Connection = con;

                SqlDataReader dr;
                List<UserEnt> lista = new List<UserEnt>();

                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserEnt dado = new UserEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.Name = Convert.ToString(dr["name"]);
                        dado.Login = Convert.ToString(dr["login"]);
                        dado.Password = Convert.ToString(dr["password"]);

                        lista.Add(dado);
                    }
                }

                return lista;
            }
        }
    }
}
