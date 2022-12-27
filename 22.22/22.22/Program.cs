using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace imitation
{
    class imitation
    {
        static void Main(string[] args)
        {
            imitation p = new imitation();
            p.Go();
        }
        public void Go()
        {
            double l = 0.1;
            double t = 10;
            double f = l * Math.Pow(Math.E, (-l * t));
            double[] result = new double[100];
            for (int i = 0; i < result.Length; i++)
            {
                Random rnd = new Random();
                result[i] = -(1 / l) * Math.Log(rnd.NextDouble());
            }
            double sum = 0;
            foreach (var item in result)
            {
                sum += item;
            }
            double xm = sum / result.Length;
            
            double DXsum = 0;
            for (int i = 0; i < result.Length; i++)
            {
                DXsum += Math.Pow(result[i] - xm, 2);
            }
            double DX = DXsum / result.Length;
            
            double Xmax = -100;
            double Xmin = 100;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] >= Xmax)
                    Xmax = result[i];
                if (result[i] <= Xmin)
                    Xmin = result[i];
            }
            
            double h = (Xmax - Xmin) / (1 + 3.3221 * Math.Log10(result.Length));
         
            List<int> interval = new List<int>();
            List<double> seredinyIntervalov = new List<double>();
            int k = 1;
            double[,] intervaly2 = new double[Convert.ToInt32(Xmax / h), 2];
            double srrr = 0;
            do
            {
                int count = 0;
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] >= Xmin + (k - 1) * h && result[i] < Xmin + k * h)
                    {
                        count++;
                    }
                }
                double sredInt = (((Xmin + (k - 1) * h) + (Xmin + k * h)) / 2);
                srrr += sredInt * count;
                intervaly2[k - 1, 0] = Xmin + (k - 1) * h;
                intervaly2[k - 1, 1] = Xmin + k * h;
                interval.Add(count);
                seredinyIntervalov.Add(((Xmin + (k - 1) * h) + (Xmin + k * h)) / 2);
                Console.WriteLine($"Интервал от {Math.Round(Xmin + (k - 1) * h,2)} до {Math.Round(Xmin + k * h,2)}");
                Console.WriteLine($"Середина интервала: {Math.Round(((Xmin + (k - 1) * h) + (Xmin + k * h)) / 2,2)}");
                Console.WriteLine($"Количество попаданий в интервал: {count}");
                k++;
            } while (Summa(interval) < 100);
            //Console.WriteLine($"кол-во интервалов: {interval.Count}");
            for (int i = 0; i < interval.Count; i++)
            {
                //Console.WriteLine($"n{i}: " + interval[i]);
            }
            var sredn = srrr / 100;
            Console.WriteLine("Дисперсия :" + DX);
            Console.WriteLine($"Выборочное среднее: {sredn}");
            double lamda = 1 / sredn;
            double[] pi = new double[interval.Count];
            double sumP = 0;
            for (int i = 0; i < intervaly2.GetLength(0); i++)
            {
                pi[i] = Math.Exp(-lamda * intervaly2[i, 0]) - Math.Exp(-lamda * intervaly2[i, 1]);
                sumP += pi[i];
                
            };
            Console.WriteLine("Показаль распределения :" + 1/ sredn);
            Console.WriteLine($"Сумма вероятности: {sumP}");
            double[] nis = new double[pi.Length];
            for (int i = 0; i < nis.Length; i++)
            {
                nis[i] = result.Length * pi[i];
                Console.WriteLine($"Вероятность попадания в интервал {Math.Round(intervaly2[i, 0],2)} - {Math.Round(intervaly2[i, 1],2)}: {Math.Round(nis[i],2)}% Pi = {Math.Round(pi[i],4)}");
            }
            double xi2 = 0;

            List<double> Chastota = new List<double>();
            List<double> newNis = new List<double>();
            for (int i = 0; i < interval.Count; i++)
            {
                Chastota.Add(interval[i]);
                newNis.Add(nis[i]);
            }
            for (int index = Chastota.Count - 1; index > 0; --index)
            {
                if (Chastota[index] < 5)
                {
                    Chastota[index - 1] += Chastota[index];
                    Chastota.Remove(Chastota[index]);
                    newNis[index - 1] += newNis[index];
                    newNis.Remove(newNis[index]);
                }
            }

            Console.WriteLine($"Объединение частот:");
            for (int i = 0; i < Chastota.Count; i++)
            {
                Console.WriteLine($"n{i}: {Chastota[i]} nP{i}: {newNis[i]}");
            }

            int ka = Chastota.Count - 2;
            double a = 0.05;
            Console.WriteLine($"Число степеней свободы: {ka}");
            for (int i = 0; i < ka; i++)
            {
                xi2 += Math.Pow((Chastota[i] - newNis[i]), 2) / newNis[i];
            }
            Console.WriteLine($"Наблюдаемый Хи^2: {xi2}");
            double XiKrit = 0;
            if (ka == 2)
            {
                XiKrit = 5.991;
            }
            if (ka == 3)
            {
                XiKrit = 6.251; 
            }
            if (ka == 4)
            {
                XiKrit = 6.251;
            }
            if (ka == 5)
            {
                XiKrit = 11.070;
            }
            if (ka == 6)
            {
                XiKrit = 12.592;
            }
                Console.WriteLine($"Критическое значение Хи^2: {XiKrit}");
                if (xi2 < XiKrit)
                {
                    Console.WriteLine($"Нет оснований отвергать гипотезу");
                }
                else
                {
                    Console.WriteLine($"Гипотезу отвергают");
                }
            
        }
       
        private int Summa(List<int> list)
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum;
        }

    }

}
