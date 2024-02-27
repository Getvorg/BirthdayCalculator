using BirthdayCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BirthdayCalculator.ViewModels
{
    class CalculateViewModel
    {
        private User _user = new User();

        public DateTime BirthDate
        {
            get { return _user.BirthDate; }
            set { _user.BirthDate = value; }
        }

        public int Age
        {
            get { return _user.Age; }
            set { _user.Age = value; }
        }

        public string ZodiacSind
        {
            get { return _user.ZodiacSing; }
            set { _user.ZodiacSing = value; }
        }

        public string ChineseZodiacSign
        {
            get { return _user.ChineseZodiacSign; }
            set { _user.ChineseZodiacSign = value; }
        }

    }
}
