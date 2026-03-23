namespace ZooERP;

public class Employee: IAlive
{
    public string Name { get; }
    public double FoodPerDayKg { get; }

    public Employee(string name, double foodPerDayKg)
    {
        if (foodPerDayKg < 0)
            throw new ArgumentOutOfRangeException(nameof(foodPerDayKg), "Количество еды не может быть отрицательным");
        
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Наименование не может быть пустым", nameof(name));
        
        Name = name;
        FoodPerDayKg = foodPerDayKg;
    }

    public override string ToString() => $"{Name} (еда: {FoodPerDayKg} кг/день)";
}