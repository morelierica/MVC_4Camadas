using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Entidades
{
    public class UserEnt
    {
        private int id;
        private string name;
        private string user;
        private string senha;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string User { get => user; set => user = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}