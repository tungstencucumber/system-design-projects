namespace ZooERP;

public class Zoo
{
    private readonly IVeterinaryClinic _veterinaryClinic;
    private readonly List<Animal> _animals = new();
    private readonly List<InventoryItem> _items = new();
    private readonly List<Employee> _employees = new();

    public Zoo(IVeterinaryClinic veterinaryClinic)
    {
        _veterinaryClinic = veterinaryClinic;
    }

    public IReadOnlyCollection<Animal> Animals => _animals.AsReadOnly();
    public IReadOnlyCollection<InventoryItem> Items => _items.AsReadOnly();
    public IReadOnlyCollection<Employee> Employees => _employees.AsReadOnly();

    public bool AddAnimal(Animal animal)
    {
        if (!_veterinaryClinic.IsHealthy(animal))
            return false;

        _animals.Add(animal);
        return true;
    }

    public void AddItem(InventoryItem item)
    {
        _items.Add(item);
    }

    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    public IReadOnlyCollection<Animal> GetAnimalsForPettingZoo()
    {
        return _animals
            .OfType<IPetted>()
            .Where(x => x.IsSuitableForPettingZoo)
            .Cast<Animal>()
            .ToList()
            .AsReadOnly();
    }

    public double GetTotalFoodPerDayKg()
    {
        return _animals.Sum(a => a.FoodPerDayKg) + _employees.Sum(a => a.FoodPerDayKg);
    }

    public IReadOnlyCollection<IInventory> GetAllInventoryItems()
    {
        return _animals.Cast<IInventory>()
            .Concat(_items)
            .ToList()
            .AsReadOnly();
    }
}
