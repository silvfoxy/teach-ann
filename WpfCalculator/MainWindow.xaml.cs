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
using UnitTestProject1;

namespace WpfCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator _calc;
        public MainWindow()
        {
            InitializeComponent();
            _calc = new Calculator();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = "";
        }
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            _calc.Press1();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            _calc.Press2();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void Button3Click(object sender, RoutedEventArgs e)
        {
            _calc.Press3();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void Button4Click(object sender, RoutedEventArgs e)
        {
            _calc.Press4();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void Button5Click(object sender, RoutedEventArgs e)
        {
            _calc.Press5();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void Button6Click(object sender, RoutedEventArgs e)
        {
            _calc.Press6();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void Button7Click(object sender, RoutedEventArgs e)
        {
            _calc.Press7();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void Button8Click(object sender, RoutedEventArgs e)
        {
            _calc.Press8();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void Button9Click(object sender, RoutedEventArgs e)
        {
            _calc.Press9();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void Button0Click(object sender, RoutedEventArgs e)
        {
            _calc.Press0();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void ButtonPlusClick(object sender, RoutedEventArgs e)
        {
            _calc.PressPlus();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void ButtonMinusClick(object sender, RoutedEventArgs e) //hw
        {
            _calc.PressMinus();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
            _indicator.Text = _calc.DisplayValue.ToString();
        }
        private void ButtonDivisionClick(object sender, RoutedEventArgs e) //hw
        {
            _calc.PressDivision();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
            _indicator.Text = _calc.DisplayValue.ToString();
        }
        private void ButtonMultiplyClick(object sender, RoutedEventArgs e) //hw
        {
            _calc.PressMultiply();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
            _indicator.Text = _calc.DisplayValue.ToString();
        }
        private void ButtonEqualsClick(object sender, RoutedEventArgs e)
        {
            _calc.PressEqual();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
            _indicator.Text = _calc.DisplayValue.ToString();
        }
        private void ButtonCClick(object sender, RoutedEventArgs e)
        {
            _calc.PressC();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void ButtonCEClick(object sender, RoutedEventArgs e)
        {
            _calc.PressCE();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
        private void ButtonBackspaceClick(object sender, RoutedEventArgs e)
        {
            _calc.PressBackspace();
            _indicator.Text = _calc.DisplayValue.ToString();
            _previousIndicator.Text = _calc.PreviousValue.ToString() + _calc.CurrentOperation;
        }
    }
}
