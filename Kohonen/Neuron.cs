using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kohonen
{
    class Neuron
    {
        public const int MAXSIZE = 25;

        public int[] Letter = new int[MAXSIZE]; // Вектор для отображения 
        public double[] Weight = new double[MAXSIZE]; // Массив весов
        public double Power; // Сила нейрона
        public string Char; // Значение вектора

        public Neuron()
        {
            for (var i = 0; i < MAXSIZE; i++)
            {
                Weight[i] = 0.5;
                Letter[i] = 0;
            }
            Power = 0;
        }

        public void OnDeath()
        {
            Char = null;
            Power = 0;
            for(var i = 0; i < MAXSIZE; i++)
            {
                Weight[i] = 0.5;
                Letter[i] = 0;
            }
        }
    }
}
