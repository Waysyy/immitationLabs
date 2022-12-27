 

double normalDetail = 0;
Random random = new Random();
double profit = 0;

for(int i = 0; i < 100000; ++i)
{
    double R1 = random.NextDouble();
    if (R1 >= 0.2)
    {
        profit -= 25;
        double R21 = random.NextDouble();
        double R22 = random.NextDouble();
        if (R21 > 0.03 && R22 >0.06)
        {
            profit -= 4;
            profit += 35;
            ++normalDetail;
        }
        if ((R21 < 0.03 && R22 > 0.06) || (R22 < 0.06 && R21 > 0.03))
        {
            profit -= 6;
            profit += 35;
            ++normalDetail;
        }
        if (R21 < 0.03 && R22 < 0.06)
        {
            profit -= 4;
        }
    }
    if (R1 >= 0.08 && R1 < 0.2)
    {
        profit -= 28;
        double R21 = random.NextDouble();
        double R22 = random.NextDouble();
        if (R21 > 0.03 && R22 > 0.06)
        {
            profit -= 4;
            profit += 35;
            ++normalDetail;
        }
        if ((R21 < 0.03 && R22 > 0.06) || (R22 < 0.06 && R21 > 0.03))
        {
            profit -= 6;
            profit += 35;
            ++normalDetail;
        }
        if (R21 < 0.03 && R22 < 0.06)
        {
            profit -= 4;
        }
    }
    if (R1 < 0.08)
    {
        profit -= 25;
    }
}
double fullProfit = profit / 100000;
double probability = normalDetail / 100000;
Console.WriteLine("Вероятность изготовления годной детали "+ probability + "\n"+ "Средняя прибыль за одну деталь = "+ fullProfit);
