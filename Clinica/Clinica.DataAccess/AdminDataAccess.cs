using Clinica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.DataAccess
{
    public class AdminDataAccess
    {
        private string _cadenaConexion;
        public AdminDataAccess()
        {
            _cadenaConexion = Configuracion.getConnectionString;
        }

        public Doctor getDoctor(string user)
        {
            Doctor doctor = null;
            SqlConnection connection = new SqlConnection(_cadenaConexion);
            SqlCommand command = new SqlCommand("GETDOCTOR", connection);
            SqlDataReader dataReader;

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = user;

            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    //Data of doctor constructor
                    string firstName = dataReader.GetString(1);
                    string middleName = dataReader.GetString(2);
                    string lastName = dataReader.GetString(3);
                    string secondLastName = dataReader.GetString(4);
                    string email = dataReader.GetString(5);
                    string gender = dataReader.GetString(6);
                    int identificationNumber = dataReader.GetInt32(7);
                    string phone = dataReader.GetString(8);
                    DateTime birthDate = dataReader.GetDateTime(9);
                    decimal salary = dataReader.GetDecimal(10);
                    string position = dataReader.GetString(11);
                    string specialty = dataReader.GetString(18);
                    string licenseNumber = dataReader.GetString(19);
                    string medicalCode = dataReader.GetString(20);
                    //Data secondary
                    int id = dataReader.GetInt32(0);
                    string employeeStatus = dataReader.GetString(12);
                    DateTime hireDate = dataReader.GetDateTime(13);
                    int availableVacationDays = dataReader.GetInt32(14);
                    int takenVacationDays = dataReader.GetInt32(15);
                    DateTime lastVacationDate = dataReader.GetDateTime(16);
                    bool isDeleted = dataReader.GetBoolean(17);

                    doctor = new Doctor(firstName,
                                            middleName,
                                            lastName,
                                            secondLastName,
                                            email,
                                            gender,
                                            identificationNumber,
                                            phone,
                                            birthDate,
                                            salary,
                                            position,
                                            specialty,
                                            licenseNumber,
                                            medicalCode);
                    doctor.Id = id;
                    doctor.EmployeeStatus = employeeStatus;
                    doctor.HireDate = hireDate;
                    doctor.AvailableVacationDays = availableVacationDays; 
                    doctor.TakenVacationDays= takenVacationDays;
                    doctor.LastVacationDate= lastVacationDate;
                    doctor.IsDeleted = isDeleted;
                }
                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return doctor;
        }

        public int SaveDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
