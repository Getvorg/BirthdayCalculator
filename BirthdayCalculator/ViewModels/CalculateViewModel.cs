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
        private Person _user = new Person();

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

        public string FirstName
        {
            get { return _user.FirstName; }
            set { _user.FirstName = value; }
        }

        public string LastName
        {
            get { return _user.LastName; }
            set { _user.LastName = value; }
        }

        public string Email
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }

        public bool IsAdult
        {
            get { return _user.IsAdult; }
            set { _user.IsAdult = value; }
        }
        public bool IsBirthday
        {
            get { return _user.IsBirthday; }
            set { _user.IsBirthday = value; }
        }

        public string IsAdultString
        {
            get { return IsAdult ? "Менше 18" : "Повнолітній"; }
        }

        public string IsBirthdayString
        {
            get { return IsBirthday ? "Сьогодні ваш день народження!" : "Сьогодні не ваш день народження("; }
        }

        public CalculateCommand<object> CalculateCommand
        {
            get
            {
                return _calculateCommand ??= new CalculateCommand<object>(_ => Proceed(), CanExecute);
            }
        }

        private void Proceed()
        {
            Age = CalculateAge(BirthDate);
            OnPropertyChanged(nameof(Age));

            if (Age < 0 || Age > 135)
            {
                MessageBox.Show("Некоректний вік");
                return;
            }

            ZodiacSign = CalculateZodiacSign(BirthDate);
            OnPropertyChanged(nameof(ZodiacSign));

            ChineseZodiacSign = CalculateChineseZodiacSign(BirthDate);
            OnPropertyChanged(nameof(ChineseZodiacSign));

            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(Email));

            IsAdult = CalculateIsAdult(Age);
            OnPropertyChanged(nameof(IsAdultString));

            IsBirthday = CalculateIsBirthday(BirthDate);
            OnPropertyChanged(nameof(IsBirthdayString));
        }

        public int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        public string CalculateZodiacSign(DateTime birthDate)
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

        public string CalculateChineseZodiacSign(DateTime birthDate)
        {
            string[] chineseZodiacSigns = new string[]{"Щур", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза", "Мавпа", "Півень", "Собака", "Свиня"};

            int year = birthDate.Year;
            int index = (year + 8) % 12;

            return "Китайський знак зодіаку: " + chineseZodiacSigns[index];
        }

        public bool CalculateIsAdult(int age)
        {
            if(age >= 18)
            {
                return false;
            }
            return true;
        }

        public bool CalculateIsBirthday(DateTime birthDate)
        {
            if(birthDate.Month == DateTime.Today.Month && birthDate.Day == DateTime.Today.Day)
            {
                MessageBox.Show("З Днем Народження!");
                return true;
            }
            return false;
        }

        private bool CanExecute(object obj)
        {
            return !string.IsNullOrEmpty(FirstName) &&
                   !string.IsNullOrEmpty(LastName) &&
                   !string.IsNullOrEmpty(Email) &&
                   BirthDate != DateTime.MinValue;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
