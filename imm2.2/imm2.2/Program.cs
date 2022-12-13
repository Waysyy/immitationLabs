// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Net;
using System;

Console.WriteLine("Hello, World!");
Random random = new Random();
double i = 0;
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
for (int v = 0; v <= 100; ++v)
{
    double randDigit = random.Next(1, 100);
    
    lst.Add((-1 / l) * Math.Log(randDigit));
    if(minlst < randDigit)
    {
        minlst = randDigit;
    }
    if(maxlst > randDigit)
    {
        maxlst = randDigit;
    }
}
    


double h = (maxlst - minlst) / (1 + 3.3221 * Math.Log(n));
double inter = minlst;
double crkon = 0;
double ckx2 = 0;
double interprav = Math.Round(minlst + h, 2);
List<double> new_list = new List<double>();
//разбиение на интервалы
new_list.(from x in lst
            where x <= h
            select x).ToList().Count;)

print("Интервал: {} - {}".format(0, h));
print(new_list);
nvcr = h / 2 * new_list;
while (interprav < maxlst):
    inter = interprav + 0.01
    interprav = h + inter
    cr = (inter + interprav) / 2
    print("Интервал: {} - {}".format(round(inter, 2), round(interprav, 2)))
    n = ((inter <= lst) & (lst <= interprav)).sum()
    vcr += cr * n
    print(n)
    if ((n + cn) < 5) {
    k += 0
        cn += n}
else
{
    k += 1;
    cn = 0;
    x2 = round((((n + (sum(lst) / 100)) * *2) / (sum(lst) / 100)), 2);
    x2k += round(x2, 2);
}
        
ck = k + 1;
kcr = round(sum(lst) / 100, 2)
lpok = round(1 / kcr, 4)
t = 0
h1 = 0
dis = np.var(lst)

while (h1 < maxlst):
    pi = math.e * *(-lpok * h1) - math.e * *(-lpok * (h1 + h))
    h1 += h + 0.01
    t += 1;
ni = 100 * pi
    print("Pi{}: {}  ni: {}".format(t, pi, ni))
print("Максимальное число:", maxlst)
print("Минимальное число:", minlst)
print("Выборочное среднее:", kcr)
print("Дисперсия:", dis)
print("Показатель распределения :", lpok)
print("Длина интервала:", h)
print("Конечное число распределений, где n>5:", ck)
stk = ck - 2
print("Число степеней свободы:", stk)
tst = [1, 2, 3, 4, 5, 6, 7]
dis2 = np.var(tst)
print("Дисперсия2:", dis2)
if (stk == 7):
    ckx2 = 18.475
else:
    ckx2 = 20.09
print("Критическая точка x2=", ckx2)
print("Наблюдаемый x2=", x2k)
if (x2k < ckx2):
    print("Результа: нет оснований отвергнуть гипотезу о равномерном распределении генеральной совокупности")
else:
    print("Результат: гипотезу отвергают")