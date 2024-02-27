using BirthdayCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BirthdayCalculator.Views
{

    public partial class CaculateView : UserControl
    {
        private CalculateViewModel _viewModel;
        public CaculateView()
        {
            InitializeComponent();
            DataContext = _viewModel = new CalculateViewModel();
        }

        private void BCalculate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
