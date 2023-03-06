using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kohonen
{
    class KohonenAI : INotifyPropertyChanged
    {
        public const int MAXSIZE = 25; //для создания вектора
        public const int SIZEALPHABET = 4; //количество нейронов

        private Neuron[] _dictionary = new Neuron[SIZEALPHABET];
        public Neuron[] Dictionary
        {
            get { return _dictionary; }
            set { _dictionary = value; }
        }

        public KohonenAI()
        {
            for (var i = 0; i < SIZEALPHABET; i++)
            {
                Dictionary[i] = new Neuron();
                for (var j = 0; j < Neuron.MAXSIZE; j++)
                {
                    Dictionary[i].Weight[j] = 0.5;
                }
            }
        }
        /// <summary>
        /// Обучение отдельного нейрона
        /// </summary>
        /// <param name="newLetter"> Вхоное воздействие </param>
        /// <param name="numberOfNeuron"> Номер обучаемого нейрона </param>
        /// <param name="letter"> Значение вектора </param>
        public void Study(CustomButton[] newLetter, int numberOfNeuron, string letter)
        {
            Dictionary[numberOfNeuron].Char = letter;
            for (var i = 0; i < Dictionary[numberOfNeuron].Weight.Length; i++)
            {
                Dictionary[numberOfNeuron].Weight[i] = Dictionary[numberOfNeuron].Weight[i] + 0.5 * (newLetter[i].Index - Dictionary[numberOfNeuron].Weight[i]);
                Dictionary[numberOfNeuron].Letter[i] = newLetter[i].Index;
            }
        }
        /// <summary>
        /// Распознавание буквы
        /// </summary>
        /// <param name="recognitionLetter"> Вектор, проверяемый на корректность </param>
        /// <returns> Номер нейрона наиболее схожего с вводом </returns>
        public int LetterRecognition(CustomButton[] recognitionLetter)
        {
            var PowerestNeuron = 0;
            for (var i = 0; i < Neuron.MAXSIZE; i++)
            {
                for (var j = 0; j < Dictionary.Length; j++)
                {
                    Dictionary[j].Power += Dictionary[j].Weight[i] * recognitionLetter[i].Index;
                }
            }
            for (var i = 1; i < Dictionary.Length; i++)
            {
                if (Dictionary[i].Power > Dictionary[PowerestNeuron].Power)
                {
                    PowerestNeuron = i;
                }
            }
            for(var i = 0; i < Dictionary.Length; i++)
            {
                Dictionary[i].Power = 0;
            }
            return PowerestNeuron;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
