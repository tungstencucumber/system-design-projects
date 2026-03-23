namespace ZooERP;

public abstract class Herbo : Animal, IPetted
{
    protected Herbo(int number, string name, double foodPerDayKg, int kindness)
        : base(number, name, foodPerDayKg, kindness)
    {
    }

    public bool IsSuitableForPettingZoo => Kindness > 5;
}
