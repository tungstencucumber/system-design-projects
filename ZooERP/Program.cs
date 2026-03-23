using Microsoft.Extensions.DependencyInjection;
using ZooERP;

var services = CompositionRoot.Services;

var zooApp = services.GetRequiredService<IZooAppService>();

// Привозим животных
var monkey = new Monkey(1, "Чичичи", 2.5, 8);
var rabbit = new Rabbit(2, "Русак", 1.0, 1);
var wolf = new Wolf(3, "Серый", 6.0, 4);

TryAcceptAnimal(zooApp, monkey);
TryAcceptAnimal(zooApp, rabbit);
TryAcceptAnimal(zooApp, wolf);

// Ставим инвентарь на баланс
zooApp.RegisterItem(new Table(1001, "Стол ветеринара"));
zooApp.RegisterItem(new Computer(1002, "Компьютер администратора"));
zooApp.RegisterItem(new Table(1003, "Стол в бухгалтерии"));
// нанимаем смотрителя
zooApp.HireEmployee(new Employee("Василий", 1.5));

Console.WriteLine();
Console.WriteLine($"Итого в зоопарк вошли: ");
foreach (var animal in zooApp.GetAnimals())
{
    Console.WriteLine($"- {animal}");
}

// общая статистика
Console.WriteLine();
Console.WriteLine($"Всего животных: {zooApp.GetAnimalsCount()}");
Console.WriteLine($"Всего сотрудников: {zooApp.GetEmployeesCount()}");
Console.WriteLine($"Общее потребление еды в сутки: {zooApp.GetTotalFoodPerDayKg()} кг");

// посмотрим на состав контактного зоопарка
var pettingZooAnimals = zooApp.GetAnimalsForPettingZoo();

Console.WriteLine();
Console.WriteLine($"Животные в контактном зоопарке:");

if (pettingZooAnimals.Count == 0)
{
    Console.WriteLine("Нет животных, подходящих для контактного зоопарка.");
}
else
{
    foreach (var animal in pettingZooAnimals)
    {
        Console.WriteLine($"- {animal.Name} (доброта: {animal.Kindness})");
    }
}

// приемка животного
// статиковая, потому что не должна менять состояние сервиса или животного
static void TryAcceptAnimal(IZooAppService zooApp, Animal animal)
{
    bool accepted = zooApp.AcceptAnimal(animal);

    if (accepted)
    {
        Console.WriteLine($"Животное принято: {animal.Name} (инв. номер {animal.Number})");
    }
    else
    {
        Console.WriteLine($"Животное не принято после медосмотра: {animal.Name} (инв. номер {animal.Number})");
    }
}
