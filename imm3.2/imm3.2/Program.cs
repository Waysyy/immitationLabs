using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Random rnd = new Random();

double call_v_min = 1.2; double prodolgit_Call = 2;
double p = call_v_min / prodolgit_Call;
double p0 = 1 / (1 + p); //вероятность обслуживания 
double p1 = 1 - p0; //вероятность отказа 
double A = call_v_min * p0; //Абсолютная пропускная способность 
double allCall = 0;
double kolvo_Call = 0;

for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 8; j++)
    {
        for (int k = 0; k < 60; k++)
        {
            kolvo_Call = (-1 / call_v_min) * Math.Log(rnd.NextDouble());
            allCall += kolvo_Call;
        }
    }
}

double time = 2;
double avg = 0;
double n = 10000;
double t = 0;

for (int i = 0; i < n; i++)
{
    t = (-1 / time) * Math.Log(rnd.NextDouble());
    avg += t / n;
}

double result = allCall / (avg * 60 * 8 * 100);
double p00 = 1 / (1 + result);
double p01 = (1 - p00);
double A1 = ((allCall / (60 * 8 * 100)) * p00);

Console.WriteLine($"Теоретические значения:");
Console.WriteLine($"Кол-во звонков в минуту: {call_v_min}");
Console.WriteLine($"Сч обслуженных звонков: {p0 * 100}");
Console.WriteLine($"Сч не обслуженных звонков: {p1 * 100}");
Console.WriteLine($"СМО: {A}");
Console.WriteLine($"\n");
Console.WriteLine($"Смоделированные значения:"); Console.WriteLine($"Кол-во звонков в минуту: {allCall / (60 * 8 * 100)}");
Console.WriteLine($"Сч обслуженных звонков: {p00 * 100}");
Console.WriteLine($"Сч не обслуженных звонков: {p01 * 100}");
Console.WriteLine($"СМО: {A1}");