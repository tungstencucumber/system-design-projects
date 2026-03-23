namespace ZooERP;

public abstract class Thing : InventoryItem
{
    public Thing(int number, string name)
        : base(number, name)
    {
    }
}
