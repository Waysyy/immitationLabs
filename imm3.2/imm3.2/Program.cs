
using System.Text.RegularExpressions;

Random random = new Random();
double call = 1.2;
double lenghtCall = 2;
double p = call/lenghtCall;
double p0 = 1 / (1 + p);
double p1 = 1 - p0;
double A = call * p0; 

double allcall = 0;
for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 8; j++)
    {
        for (int k = 0; k < 60; k++)
        {
            double colCall = -call * Math.Log(random.NextDouble());     
            allcall += colCall;
        }
    }
}
double average = 0.0;
int n = 60 * 8 * 100;
double T = 2; 
for (int i = 0; i < n; i++)
{
    double t = -T * Math.Log(random.NextDouble());
    average += t / n;
}
double resModel =allcall/(average * 60*8*100);
double p00 = 1 / (1 + resModel);
double p01 = 1 - p00;
double A1 = (allcall/(60 * 8 * 100)) * p00;
Console.WriteLine("Теоретические характеристики\n" + "Звонков в минуту: 1.2" + "\nСреднее число звонков:\n" + "Обслуженных: " + 
    p0*100 +"%"+ "\nНе обслуженных: " + p1 * 100 +"%"+ "\nСредняя пропусная способность СМО: \n" +"Обслуживание звонков в минуту: " + A);

Console.WriteLine("\nРезультаты имитации\n" + "Звонков в минуту: " + Math.Round(allcall / (60 * 8 * 100), 2) + "\nСреднее число звонков:\n" + "Обслуженных: " +
   Math.Round(p00 * 100, 2) + "%" + "\nНе обслуженных: " + Math.Round(p01 * 100, 2) + "%" + "\nСредняя пропусная способность СМО: \n" + "Обслуживание звонков в минуту: " + Math.Round(A1,2));
