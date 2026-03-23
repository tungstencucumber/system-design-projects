namespace ZooERP;

public class ZooAppService : IZooAppService
{
    private readonly Zoo _zoo;

    public ZooAppService(Zoo zoo)
    {
        _zoo = zoo;
    }

    public bool AcceptAnimal(Animal animal) => _zoo.AddAnimal(animal);

    public void RegisterItem(InventoryItem item) => _zoo.AddItem(item);
    public void HireEmployee(Employee employee) => _zoo.AddEmployee(employee);

    public IReadOnlyCollection<Animal> GetAnimals() => _zoo.Animals;

    public IReadOnlyCollection<Animal> GetAnimalsForPettingZoo() => _zoo.GetAnimalsForPettingZoo();

    public IReadOnlyCollection<IInventory> GetInventoryItems() => _zoo.GetAllInventoryItems();

    public IReadOnlyCollection<Employee> GetEmployees() => _zoo.Employees;

    public double GetTotalFoodPerDayKg() => _zoo.GetTotalFoodPerDayKg();

    public int GetAnimalsCount() => _zoo.Animals.Count;

    public int GetEmployeesCount() => _zoo.Employees.Count;
}
