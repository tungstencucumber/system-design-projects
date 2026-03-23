namespace ZooERP;

public abstract class InventoryItem : IInventory
{
    public int Number { get; }
    public string Name { get; }

    protected InventoryItem(int number, string name)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(nameof(number), "Инвентарный номер должен быть больше 0");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Наименование не может быть пустым", nameof(name));

        Number = number;
        Name = name;
    }

    public override string ToString() => $"{Name} (инв. номер {Number})";
}
