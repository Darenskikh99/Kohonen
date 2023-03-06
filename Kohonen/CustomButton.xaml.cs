using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Kohonen
{
    /// <summary>
    /// Логика взаимодействия для CustomButton.xaml
    /// </summary>
    public partial class CustomButton : UserControl
    {
        private int _index = 0;
        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
            }
        }
        public CustomButton()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            if (Index == 1)
            {
                Index = 0;
                CustomBtn.Background = Brushes.White;
            }
            else
            {
                Index = 1;
                CustomBtn.Background = Brushes.Green;
            }
        }
    }
}
