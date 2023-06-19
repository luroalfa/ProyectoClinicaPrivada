using Clinica.DataAccess;
using Clinica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Business
{
    public class AdminBusiness
    {
        private Doctor _doctor;
        private AdminDataAccess _dataBase;
        public AdminBusiness()
        {
            _dataBase = new AdminDataAccess();
        }

        public Doctor FillDataAdmin(string user)
        {
            try
            {
                _doctor = _dataBase.getDoctor(user);
            }
            catch (Exception)
            {
                throw;
            }
            return _doctor;
        }

        public void saveEmployeeAsDoctor(Doctor doctor, Usuario usuario)
        {
            try
            {
                usuario.Id = _dataBase.SaveDoctor(doctor);
                _dataBase.SaveUser(usuario);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
