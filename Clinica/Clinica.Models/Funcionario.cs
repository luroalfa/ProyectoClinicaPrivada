using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public abstract class Funcionario : Persona
    {
        private decimal _salary;
        private string _position;
        private string _employeeStatus;
        private DateTime _hireDate;
        private int _availableVacationDays;
        private int _takenVacationDays;
        private DateTime _lastVacationDate;
        private bool _isDeleted;

        public Funcionario(
                            string name,
                            string middleName,
                            string lastName,
                            string secondLastName,
                            string email,
                            string gender,
                            int identificationNumber,
                            string phone,
                            DateTime birthDate,
                            decimal salary,
                            string position)
     : base(name, middleName, lastName, secondLastName, email, gender, identificationNumber, phone, birthDate)
        {
            _salary = salary;
            _position = position;
            _employeeStatus = string.Empty;
            _hireDate = DateTime.MinValue;
            _availableVacationDays = 0;
            _takenVacationDays = 0;
            _lastVacationDate = DateTime.MinValue;
            _isDeleted = false;
        }
        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public string EmployeeStatus
        {
            get { return _employeeStatus; }
            set { _employeeStatus = value; }
        }

        public DateTime HireDate
        {
            get { return _hireDate; }
            set { _hireDate = value; }
        }

        public int AvailableVacationDays
        {
            get { return _availableVacationDays; }
            set { _availableVacationDays = value; }
        }

        public int TakenVacationDays
        {
            get { return _takenVacationDays; }
            set { _takenVacationDays = value; }
        }

        public DateTime LastVacationDate
        {
            get { return _lastVacationDate; }
            set { _lastVacationDate = value; }
        }

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }


    }
}
