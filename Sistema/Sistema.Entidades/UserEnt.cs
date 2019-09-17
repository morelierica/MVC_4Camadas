using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Entidades
{
    public class UserEnt
    {
        private int id;
        private string name;
        private string login;
        private string password;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
    }
}