using System;

namespace Clinica.Models
{
    public class Doctor : Funcionario
    {
        private string _specialty;
        private string _licenseNumber;
        private string _medicalCode;
        public Doctor(  string name,
                        string middleName,
                        string lastName,
                        string secondLastName,
                        string email,
                        string gender,
                        int identificationNumber,
                        string phone,
                        DateTime birthDate,
                        decimal salary,
                        string position,
                        string specialty,
                        string licenseNumber,
                        string medicalCode) : base( name,
                                                    middleName,
                                                    lastName,
                                                    secondLastName,
                                                    email,
                                                    gender,
                                                    identificationNumber,
                                                    phone,
                                                    birthDate,
                                                    salary,
                                                    position
                                                    )
        {
            _specialty = specialty;
            _licenseNumber = licenseNumber;
            _medicalCode = medicalCode;
        }
        public string Specialty
        {
            get { return _specialty; }
            set { _specialty = value; }
        }
        public string LicenseNumber
        {
            get { return _licenseNumber; }
            set { _licenseNumber = value; }
        }
        public string MedicalCode
        {
            get { return _medicalCode; }
            set { _medicalCode = value; }
        }
    }
}
