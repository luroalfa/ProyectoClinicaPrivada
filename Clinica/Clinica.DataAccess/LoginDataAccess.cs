using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.DataAccess
{
    public class LoginDataAccess
    {
        private string _cadenaConexion;
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
        public LoginDataAccess() { 
            _mensaje = string.Empty;
            _cadenaConexion = Configuracion.getConnectionString;
        }
        public bool ValidateUserCredentials(string user, string pass)
        {
            bool result;
            SqlConnection conn = new SqlConnection(_cadenaConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.LOGIN_USER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@username", user);
            cmd.Parameters.AddWithValue("@password", pass);
            cmd.Parameters.Add("@isSuccessful", SqlDbType.Bit).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@msj", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@rol", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();//Ejecutamos el SP y llenamos las variables de retorno
                //Convert.ToInt32(cmd.Parameters["@retorno"].Value);
                result = (bool) cmd.Parameters["@isSuccessful"].Value;
                _mensaje = cmd.Parameters["@msj"].Value.ToString();
                _rol = cmd.Parameters["@rol"].Value.ToString();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        
    }
}
