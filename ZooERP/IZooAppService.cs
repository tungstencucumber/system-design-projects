namespace ZooERP;

public interface IZooAppService
{
    bool AcceptAnimal(Animal animal);
    void RegisterItem(InventoryItem item);
    void HireEmployee(Employee employee);

    IReadOnlyCollection<Animal> GetAnimals();
    IReadOnlyCollection<Animal> GetAnimalsForPettingZoo();
    IReadOnlyCollection<IInventory> GetInventoryItems();
    IReadOnlyCollection<Employee> GetEmployees();

    double GetTotalFoodPerDayKg();
    int GetAnimalsCount();
    int GetEmployeesCount();
}
