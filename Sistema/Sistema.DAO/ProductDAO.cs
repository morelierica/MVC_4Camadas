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
    public class ProductDAO
    {
        public int Insert(ProductEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "INSERT INTO products ([pro_name], [pro_description], [pro_price]) VALUES (@pro_name, @pro_description, @pro_price)";                                 
                cn.Parameters.Add("pro_name", SqlDbType.VarChar).Value = objTabela.Pro_name;
                cn.Parameters.Add("pro_description", SqlDbType.VarChar).Value = objTabela.Pro_description;
                cn.Parameters.Add("pro_price", SqlDbType.VarChar).Value = objTabela.Pro_price;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }

        public List<ProductEnt> Search(ProductEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * FROM products WHERE pro_name LIKE @pro_name";
                cn.Parameters.Add("pro_name", SqlDbType.VarChar).Value = objTabela.Pro_name + "%";

                cn.Connection = con;

                SqlDataReader dr;
                List<ProductEnt> lista = new List<ProductEnt>();

                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProductEnt dado = new ProductEnt();
                        dado.Pro_id = Convert.ToInt32(dr["pro_id"]);
                        dado.Pro_name = Convert.ToString(dr["pro_name"]);
                        dado.Pro_description = Convert.ToString(dr["pro_description"]);
                        dado.Pro_price = Convert.ToDouble(dr["pro_price"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }

        public int Update(ProductEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "UPDATE products SET pro_name = @pro_name, pro_description = @pro_description, pro_price = @pro_price WHERE pro_id = @pro_id";
                cn.Parameters.Add("pro_name", SqlDbType.VarChar).Value = objTabela.Pro_name;
                cn.Parameters.Add("pro_description", SqlDbType.VarChar).Value = objTabela.Pro_description;
                cn.Parameters.Add("pro_price", SqlDbType.VarChar).Value = objTabela.Pro_price;
                cn.Parameters.Add("pro_id", SqlDbType.Int).Value = objTabela.Pro_id;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }

        public int Delete(ProductEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "DELETE FROM products WHERE pro_id = @pro_id";
                cn.Parameters.Add("pro_id", SqlDbType.Int).Value = objTabela.Pro_id;
                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                return qtd;
            }
        }        

        public List<ProductEnt> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * from products ORDER BY pro_id DESC";
                cn.Connection = con;

                SqlDataReader dr;
                List<ProductEnt> lista = new List<ProductEnt>();

                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProductEnt dado = new ProductEnt();
                        dado.Pro_id = Convert.ToInt32(dr["pro_id"]);
                        dado.Pro_name = Convert.ToString(dr["pro_name"]);
                        dado.Pro_description = Convert.ToString(dr["pro_description"]);
                        dado.Pro_price = Convert.ToDouble(dr["pro_price"]);

                        lista.Add(dado);
                    }
                }
                return lista;
            }
        }
    }
}
