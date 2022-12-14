



using System.Collections.Generic;
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
List<double> ZList = new List<double>();
double z = 0;
Random random = new Random();
int Spros = random.Next(30,50);
double randDigit;
double minlst = 100;
double maxlst = 0;
for (int i = 0; i < 100; ++i)
{
    randDigit = ((random.NextDouble() * (10 - 40) + 40) - 6) * 12;
    ZList.Add(randDigit);
    if (minlst > randDigit)
    {
        minlst = randDigit;
    }
    if (maxlst < randDigit)
    {
        maxlst = randDigit;
    }
}

int N;
double sum = 0, sumd = 0, M, D;

N = 100;

for (int i = 0; i < N; i++)
{
    sum = sum + ZList[i];
}
//мат ожидание
M = sum / N;
//дисперсия
for (int i = 0; i < N; i++)
{
    sumd = sumd + (Math.Round((ZList[i] - M), 2) * Math.Round((ZList[i] - M), 2));
}
double dis = (sumd / (N - 1));
double otklonenie = Math.Sqrt(dis);

double h = (maxlst - minlst) / (1 + 3.3221 * Math.Log10(100));

double inter = minlst;
double crkon = 0;
double ckx2 = 0;
double interprav = Math.Round(minlst + h, 2);
double new_list = 0;
//разбиение на интервалы

double kcr = Math.Round(ZList.Sum() / 100, 2);
double cr1 = (inter + interprav) / 2;
double u1 = (cr1 - kcr) / 10;
double fu1 = (1 / Math.Sqrt(2 * Math.PI)) * Math.Pow(Math.E, (Math.Pow(-u1, 2) / 2));
double ni1 = (100 * h) / fu1;
Console.WriteLine("Интервал: " + 0 + "-" + h);
Console.WriteLine(ni1);
double nvcr = h / 2 * new_list;

List<double> listPi = new List<double>();



while (interprav < maxlst)
{
    n = 0;
    inter = interprav + 0.01;
    interprav = h + inter;
    double cr = (inter + interprav) / 2;
    double u = (cr - kcr) / 10;
    double fu = (1/Math.Sqrt(2*Math.PI))*Math.Pow(Math.E,(Math.Pow(-u,2)/2));
    
    Console.WriteLine("Интервал: " + Math.Round(inter, 2) + "-" + Math.Round(interprav, 2));
    for (int index = 0; index < ZList.Count; index++)
    {
        if ((inter <= ZList[index]) && (ZList[index] <= interprav))
        {
            ++n;

        }
    }
    double ni = (100 * h) / fu;
    vcr += cr * n;
    Console.WriteLine(ni);
    if ((n + cn) < 5)
    {
        k += 0;
        cn += n;
    }
    else
    {
        double lstSum = ZList.Sum();
        k += 1;
        cn = 0;
        x2 = Math.Pow((n + (ZList.Sum() / 100)), 2) / (ZList.Sum() / 100);
        x2k += Math.Round(x2, 2);
    }
}
ck = k + 1;
stk = ck - 3;
Console.WriteLine("Наблюдаемый x2 = " + x2k);
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