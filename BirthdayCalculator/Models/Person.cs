using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BirthdayCalculator.Models
{
    class Person
    {
        private DateTime _birthDate;
        private int _age;
        private string _zodiacSign;
        private string _chineseZodiacSign;
        private string _firstName;
        private string _lastName;
        private string _email;
        private bool _isAdult;
        private bool _isBirthday;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string ZodiacSign
        {
            get { return _zodiacSign; }
            set { _zodiacSign = value; }
        }

        public string ChineseZodiacSign
        {
            get { return _chineseZodiacSign; }
            set { _chineseZodiacSign = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
        }

        public Person(string firstName, string lastName, string email, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Person()
        {          
        }
    }
}