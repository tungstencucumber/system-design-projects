namespace ZooERP;

public abstract class Animal : InventoryItem, IAlive
{
    public double FoodPerDayKg { get; }
    public int Kindness { get; }

    protected Animal(int number, string name, double foodPerDayKg, int kindness)
        : base(number, name)
    {
        if (foodPerDayKg < 0)
            throw new ArgumentOutOfRangeException(nameof(foodPerDayKg), "Количество еды не может быть отрицательным");

        if (kindness is < 0 or > 10)
            throw new ArgumentOutOfRangeException(nameof(kindness), "Уровень доброты должен быть в диапазоне от 0 до 10");

        FoodPerDayKg = foodPerDayKg;
        Kindness = kindness;
    }

    public override string ToString() =>
        $"{Name} (инв. номер {Number}, еда: {FoodPerDayKg} кг/день, доброта: {Kindness})";
}
