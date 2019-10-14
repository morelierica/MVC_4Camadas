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

        public List<UserEnt> Search(UserEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * from users WHERE name LIKE @name";
                cn.Parameters.Add("name", SqlDbType.VarChar).Value = objTabela.Name + "%";

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

        public int Update(UserEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "UPDATE users SET name = @name, login = @login, password = @password WHERE id = @id";
                cn.Parameters.Add("name", SqlDbType.VarChar).Value = objTabela.Name;
                cn.Parameters.Add("login", SqlDbType.VarChar).Value = objTabela.Login;
                cn.Parameters.Add("password", SqlDbType.VarChar).Value = objTabela.Password;
                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }

        public int Delete(UserEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "DELETE FROM USERS WHERE id = @id";
                cn.Parameters.Add("id", SqlDbType.Int).Value = objTabela.Id;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }

        public UserEnt Login(UserEnt obj)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "SELECT * FROM users WHERE login = @login AND password = @password";

                cn.Connection = con;

                cn.Parameters.Add("login", SqlDbType.VarChar).Value = obj.Login;
                cn.Parameters.Add("password", SqlDbType.VarChar).Value = obj.Password;

                SqlDataReader dr;                
                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserEnt dado = new UserEnt();                        
                        dado.Login = Convert.ToString(dr["login"]);
                        dado.Password = Convert.ToString(dr["password"]);                        
                    }
                }
                else
                {
                    obj.Login = null;
                    obj.Password = null;
                }

                return obj;
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
