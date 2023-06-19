using Clinica.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Business
{
    public class LoginBusiness
    {
        private string _mensaje;
        private string _rol;

        public string getRol()
        {
            return _rol;
        }

        public void setRol(string rol)
        {
            _rol = rol;
        }

        public string getMensaje()
        {
            return _mensaje;
        }

        public void setMensaje(string mensaje)
        {
            _mensaje = mensaje;
        }
        public LoginBusiness()
        {
            _mensaje = string.Empty;
            _rol = string.Empty;
        }

        public bool ValidateUserCredentials(string user, string pass)
        {
            bool result;
            LoginDataAccess loginDataAccess = new LoginDataAccess();
            try
            {
                result = loginDataAccess.ValidateUserCredentials(user, pass);
                _mensaje = loginDataAccess.getMensaje();
                _rol = loginDataAccess.getRol();
            }
            catch (Exception) { throw; }
            return result;
        }
    }
}
