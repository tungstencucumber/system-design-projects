namespace ZooERP;

public abstract class Predator : Animal
{
    protected Predator(int number, string name, double foodPerDayKg, int kindness)
        : base(number, name, foodPerDayKg, kindness)
    {
    }
}
