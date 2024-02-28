using BirthdayCalculator.Models;
using BirthdayCalculator.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BirthdayCalculator.ViewModels
{
    class CalculateViewModel : INotifyPropertyChanged
    {
        private User _user = new User();

        private CalculateCommand<object> _calculateCommand;

        public event PropertyChangedEventHandler? PropertyChanged;

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

        public string ZodiacSign
        {
            get { return _user.ZodiacSign; }
            set { _user.ZodiacSign = value; }
        }

        public string ChineseZodiacSign
        {
            get { return _user.ChineseZodiacSign; }
            set { _user.ChineseZodiacSign = value; }
        }

        public CalculateCommand<object> CalculateCommand
        {
            get
            {
                return _calculateCommand ??= new CalculateCommand<object>(_ => Calculate(), CanExecute);
            }
        }

        private void Calculate()
        {
            Age = CalculateAge(BirthDate);
            OnPropertyChanged(nameof(Age));

            if (Age < 0 || Age > 135)
            {
                MessageBox.Show("Некоректний вік");
                return;
            }

            if (BirthDate.Month == DateTime.Today.Month && BirthDate.Day == DateTime.Today.Day)
            {
                MessageBox.Show("З Днем Народження!");
            }       

            ZodiacSign = CalculateZodiacSign(BirthDate);
            OnPropertyChanged(nameof(ZodiacSign));

            ChineseZodiacSign = CalculateChineseZodiacSign(BirthDate);
            OnPropertyChanged(nameof(ChineseZodiacSign));

        }

        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        private string CalculateZodiacSign(DateTime birthDate)
        {
            int day = birthDate.Day;
            int month = birthDate.Month;

            string[] zodiacSigns = new string[]{"Козеріг", "Водолій", "Риби", "Овен", "Телець", "Близнюки", "Рак", "Лев", "Діва", "Терези", "Скорпіон", "Стрілець"};

            int[] lastDayOfSign = new int[]{20, 19, 20, 20, 21, 21, 22, 22, 23, 22, 22, 21};

            if (day <= lastDayOfSign[month - 1])
            {
                return "Західний знак зодіаку: " + zodiacSigns[month - 1];
            }
            else
            {
                return "Західний знак зодіаку: " + zodiacSigns[month % 12];
            }
        }

        private string CalculateChineseZodiacSign(DateTime birthDate)
        {
            string[] chineseZodiacSigns = new string[]{"Мавпа", "Півень", "Собака", "Свиня", "Щур", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза"};

            int startYear = 1900; // Початковий рік циклу китайських знаків зодіаку
            int year = birthDate.Year;
            int index = (year - startYear) % 12;

            return "Китайський знак зодіаку: " + chineseZodiacSigns[index];
        }

        private bool CanExecute(object obj)
        {
            return BirthDate != DateTime.MinValue;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
