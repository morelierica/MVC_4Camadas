using System;
using System.Collections.Generic;
using System.Text;
using Sistema.DAO;
using Sistema.Entidades;

namespace Sistema.Model
{
    public class UserModel
    {
        public static int Insert(UserEnt objTabela)
        {
            return new UserDAO().Insert(objTabela);
        }

        public List<UserEnt> Lista()
        {
            return new UserDAO().Lista();
        }

        public UserEnt Login(UserEnt obj)
        {
            return new UserDAO().Login(obj);
        }
    }
}
