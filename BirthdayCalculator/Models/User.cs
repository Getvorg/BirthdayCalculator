using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BirthdayCalculator.Models
{
    class User
    {
        private DateTime _birthDate;
        private int _age;
        private string _zodiacSign;
        private string _chineseZodiacSign;

        public DateTime BirthDate {
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
    }
}
