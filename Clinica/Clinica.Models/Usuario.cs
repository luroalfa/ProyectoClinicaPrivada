using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Models
{

    public class Usuario
    {
        private int _id;
        private string _name;
        private string _pass;
        private string _rol;
        public Usuario() { }
        public Usuario(string name, string pass, string rol) {
            _name = name;
            _pass = pass;
            _rol = rol;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Password
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public string Role
        {
            get { return _rol; }
            set { _rol = value; }
        }
    }
}
