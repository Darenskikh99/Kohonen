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

namespace Kohonen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KohonenAI myKohonenAI = new KohonenAI();
        CustomButton[] _buttons = new CustomButton [KohonenAI.MAXSIZE];
        private int _numberOfNeuron = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Создания сетки для ввода векторов
        /// </summary>
        private void NLbtn_Click(object sender, RoutedEventArgs e)
        {
            stack.Children.Clear();
            txtBlock.Text = "";
            txtBox.Text = "";

            for (var i = 0; i < _buttons.Length; i++)
            {
                var btn1 = new CustomButton
                {
                    Width = 50,
                    Height = 50,
                };
                _buttons[i] = btn1;
                stack.Children.Add(_buttons[i]);
            }
        }
        /// <summary>
        /// Вызов обучения нейрона
        /// </summary>
        private void SetNewLetter_Click(object sender, RoutedEventArgs e)
        {
            if(_numberOfNeuron != KohonenAI.SIZEALPHABET && txtBox.Text != "") // проверка условий
            {
                myKohonenAI.Study(_buttons, _numberOfNeuron, txtBox.Text); // обучение нейрона
                _numberOfNeuron++;
            }
            else
            {
                MessageBox.Show("Алфавит переполнен или не введен символ!");
            }
        }
        /// <summary>
        /// Проверка введенного вектора и определение значения
        /// </summary>
        private void TestedLetter_Click(object sender, RoutedEventArgs e)
        {
            var numberOfNeuron = myKohonenAI.LetterRecognition(_buttons); // Определение сильнейшего нейрона
            txtBlock.Text = myKohonenAI.Dictionary[numberOfNeuron].Char; // Вывод символа нейрона
            for (var i = 0; i < _buttons.Length; i++) // Визуализация
            {
                if (myKohonenAI.Dictionary[numberOfNeuron].Letter[i] < _buttons[i].Index) // если выбрано лишнее значение
                {
                    _buttons[i].CustomBtn.Background = Brushes.Red; // окрасить в красный
                }
                else if(myKohonenAI.Dictionary[numberOfNeuron].Letter[i] > _buttons[i].Index) // Если значения не хватает
                {
                    _buttons[i].CustomBtn.Background = Brushes.Orange; // окрасить в оранжевый
                }
                else // в остальных случаях оставить без изменений
                { }
            }
        }
        /// <summary>
        /// Удаление информации со всех нейронов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDictionaries_Click(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < myKohonenAI.Dictionary.Length; i++)
            {
                myKohonenAI.Dictionary[i].OnDeath();
            }
            NLbtn_Click(sender, e);
            MessageBox.Show("Словарь удален!");
        }
    }
}
