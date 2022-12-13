import random
import numpy as np
import math
i = 0
l = 0.1
re = 2.7
n = 100
vcr = 0
k = 0
cn = 0
ck = 0
stk = 0
x2 = 0
x2k = 0
lst = [(-1/l)*np.log(random.random()) for i in range(n)]
maxlst = max(lst)
minlst = min(lst)
h = (maxlst - minlst)/(1+3.3221*np.log(n))
inter = minlst
crkon = 0
ckx2 = 0 
interprav = round(minlst + h, 2)
new_list =len([x for x in lst if x <= h ])
print("Интервал: {} - {}".format(0, h))
print(new_list)
nvcr = h/2*new_list
while (interprav < maxlst):
    inter =interprav + 0.01
    interprav = h + inter
    cr = (inter + interprav)/2   
    print("Интервал: {} - {}".format(round(inter,2), round(interprav,2)))
    n = ((inter <= lst) & (lst <= interprav)).sum()
    vcr += cr * n
    print(n)
    if((n+cn)<5):
        k+=0
        cn += n
    else:
        k+=1
        cn = 0
        x2 = round((((n+(sum(lst)/100))**2)/(sum(lst)/100)), 2)
        x2k += round(x2, 2)
ck = k + 1
kcr = round(sum(lst)/100, 2)
lpok = round(1/kcr, 4)
t = 0
h1 = 0

def calc_var(population, is_sample = False):
    mean = (sum(population) /len(population))
    diff = {(v-mean) for v in population}
    sqr_diff = [d**2 for d  in diff]
    sum_sqr = sum(sqr_diff)
    if is_sample == True :
        variance = sum_sqr/(len(population)-1)
    else:
        variance = sum_sqr/(len(population))
    
    return variance




dis = calc_var(lst)

while (h1 < maxlst):
    pi = math.e**(-lpok * h1)-math.e**(-lpok * (h1+h))
    h1 += h +0.01
    t += 1;
    ni = 100*pi
    print("Pi{}: {}  ni: {}".format(t, pi, ni))
print("Максимальное число:",maxlst)
print("Минимальное число:",minlst)
print("Выборочное среднее:", kcr)
print("Дисперсия:", dis)
print("Показатель распределения :", lpok)
print("Длина интервала:",h)
print("Конечное число распределений, где n>5:",ck)
stk = ck -2
print("Число степеней свободы:", stk)
tst = [1,2,3,4,5,6,7]
dis2 =calc_var(tst)
print("Дисперсия2:",dis2)
if(stk == 7):
    ckx2 = 18.475
else:
    ckx2 = 20.09
print("Критическая точка x2=", ckx2)    
print("Наблюдаемый x2=", x2k)
if(x2k<ckx2):
    print("Результа: нет оснований отвергнуть гипотезу о равномерном распределении генеральной совокупности")
else:
    print("Результат: гипотезу отвергают")


