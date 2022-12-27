// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Net;
using System;


Random random = new Random();
int i = 0;
double l = 0.1;
double re = 2.7;
double n = 100;
double vcr = 0;
double k = 0;
double cn = 0;
double ck = 0;
double stk = 0;
double x2 = 0;
double x2k = 0;
List<double> lst = new List<double>();

double minlst = 100;
double maxlst = 0;
for (int v = 0; v <= 99; ++v)
{
    double randDigit = random.NextDouble();
    double addDigit = (-1 / l) * Math.Log((randDigit));
    lst.Add(addDigit);
    if (minlst > addDigit)
    {
        minlst = addDigit;
    }
    if (maxlst < addDigit)
    {
        maxlst = addDigit;
    }
}



double h = (maxlst - minlst) / (1 + 3.3221 * Math.Log10(n));
double inter = minlst;
double crkon = 0;
double ckx2 = 0;
double interprav = Math.Round(minlst + h, 2);
double new_list = 0;
//разбиение на интервалы
for (int index = 0; index < lst.Count; index++)
{
    if ((lst[index] <= h))
    {
        ++new_list;
    }
}

Console.WriteLine("Интервал: " + 0 + "-" + h);
Console.WriteLine(new_list);
double nvcr = h / 2 * new_list;

List<double> listPi = new List<double>();



while (interprav < maxlst)
{
    n = 0;
    inter = interprav + 0.01;
    interprav = h + inter;
    double cr = (inter + interprav) / 2;
    Console.WriteLine("Интервал: " + Math.Round(inter, 2) + "-" + Math.Round(interprav, 2));
    for (int index = 0; index < lst.Count; index++)
    {
        if ((inter <= lst[index]) && (lst[index] <= interprav))
        {
            ++n;

        }
    }
    vcr += cr * n;
    Console.WriteLine(n);
    if ((n + cn) < 5)
    {
        k += 0;
        cn += n;
    }
    else
    {
        double lstSum = lst.Sum();
        k += 1;
        cn = 0;
        x2 = Math.Pow((n + (lst.Sum() / 100)), 2) / (lst.Sum() / 100);
        x2k += Math.Round(x2, 2);
    }
}
ck = k + 1;
double kcr = Math.Round(lst.Sum() / 100, 2);
double lpok = Math.Round(1 / kcr, 4);
double t = 0;
double h1 = 0;
double e = 2.7182818284590451;
double pi = 0;
while (h1 < maxlst)
{
    pi = Math.Pow(e, ((-lpok * h1) - Math.Pow(e, (-lpok * (h1 + h)))));
    h1 += h + 0.01;
    t += 1;
    double ni = 100 * pi;
    Console.WriteLine("Pi: " + pi + " ni: " + ni + t);
    listPi.Add(pi);
}
//////////////////////////////////////////////////////
int N;
double sum = 0, sumd = 0, M, D;

N = 100;

for (i = 0; i < N; i++)
{
    sum = sum + lst[i];
}
M = sum / N;
//дисперсия
for (i = 0; i < N; i++)
{
    sumd = sumd + (Math.Round((lst[i] - M), 2) * Math.Round((lst[i] - M), 2));
}
double dis = (sumd / (N - 1));

/////////////////////////////////////////////////////





Console.WriteLine("Максимальное число: " + maxlst);
Console.WriteLine("Минимальное число: " + minlst);
Console.WriteLine("Выборочное среднее: " + kcr);
Console.WriteLine("Дисперсия: " + dis);
Console.WriteLine("Показатель распределения: " + lpok);
Console.WriteLine("Длина интервала: " + h);
Console.WriteLine("Конечное число распределений, где n>5: " + ck);
stk = ck - 2;
Console.WriteLine("Число степеней свободы: " + stk);

if (stk == 7)
    ckx2 = 18.475;
else
    ckx2 = 20.09;
Console.WriteLine("Критическая точка x2 = " + ckx2);
Console.WriteLine("Наблюдаемый x2 = " + x2k);
if (x2k < ckx2)
    Console.WriteLine("Результат: нет оснований отвергнуть гипотезу о равномерном распределении генеральной совокупности");
else
    Console.WriteLine("Результат: гипотезу отвергают");