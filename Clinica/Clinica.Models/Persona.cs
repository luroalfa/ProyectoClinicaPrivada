using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public abstract class Persona
    {
        private int _id;
        private string _name; 
        private string _middleName;
        private string _lastName;
        private string _secondLastName;
        private string _email;
        private string _gender;
        private int _identificationNumber;
        private string _phone;
        private DateTime _birthDate;
        public Persona(string name, string middleName, string lastName, string secondLastName, string email,
                   string gender, int identificationNumber, string phone, DateTime birthDate)
        {
            _id = -1;
            _name = name;
            _middleName = middleName;
            _lastName = lastName;
            _secondLastName = secondLastName;
            _email = email;
            _gender = gender;
            _identificationNumber = identificationNumber;
            _phone = phone;
            _birthDate = birthDate;
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
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string SecondLastName
        {
            get { return _secondLastName; }
            set { _secondLastName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public int IdentificationNumber
        {
            get { return _identificationNumber; }
            set { _identificationNumber = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

    }
}
