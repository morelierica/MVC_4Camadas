using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Sistema.DAO;

namespace Sistema.Model
{
    public class ProductModel
    {
        public static int Insert(ProductEnt objTabela)
        {
            return new ProductDAO().Insert(objTabela);
        }

        public List<ProductEnt> Lista()
        {
            return new ProductDAO().Lista();
        }       

        public static int Delete(ProductEnt objTabela)
        {
            return new ProductDAO().Delete(objTabela);
        }

        public static int Update(ProductEnt objTabela)
        {
            return new ProductDAO().Update(objTabela);
        }

        public List<ProductEnt> Search(ProductEnt objTabela)
        {
            return new ProductDAO().Search(objTabela);
        }
    }
}
