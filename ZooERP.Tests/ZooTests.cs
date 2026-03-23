using System.Linq;
using ZooERP;
using ZooERP.Tests.Fakes;
using Xunit;

namespace ZooERP.Tests;

public class ZooTests
{
    [Fact]
    public void AddAnimal_ShouldAddAnimal_WhenVeterinaryClinicApproves()
    {
        var zoo = new Zoo(new AlwaysHealthyVeterinaryClinic());
        var rabbit = new Rabbit(1, "Игорь", 1.2, 8);

        var result = zoo.AddAnimal(rabbit);

        Assert.True(result);
        Assert.Single(zoo.Animals);
        Assert.Contains(rabbit, zoo.Animals);
    }

    [Fact]
    public void AddAnimal_ShouldNotAddAnimal_WhenVeterinaryClinicRejects()
    {
        var zoo = new Zoo(new AlwaysUnhealthyVeterinaryClinic());
        var rabbit = new Rabbit(1, "Игорь (болен)", 1.2, 8);

        var result = zoo.AddAnimal(rabbit);

        Assert.False(result);
        Assert.Empty(zoo.Animals);
    }

    [Fact]
    public void GetTotalFoodPerDayKg_ShouldReturnSumOfAllAnimalsFood()
    {
        var zoo = new Zoo(new AlwaysHealthyVeterinaryClinic());
        zoo.AddAnimal(new Rabbit(1, "Игорь", 1.2, 8));
        zoo.AddAnimal(new Monkey(2, "Чичичи", 2.5, 7));
        zoo.AddAnimal(new Tiger(3, "Клаус", 8.5, 3));

        var totalFood = zoo.GetTotalFoodPerDayKg();

        Assert.Equal(12.2, totalFood, precision: 1);
    }

    [Fact]
    public void GetAnimalsForPettingZoo_ShouldReturnOnlySuitableAnimals()
    {
        var zoo = new Zoo(new AlwaysHealthyVeterinaryClinic());

        var rabbit = new Rabbit(1, "Игорь", 1.2, 8);
        var monkey = new Monkey(2, "Чичичи", 2.5, 6);
        var rabbitBad = new Rabbit(3, "Игорь (болен)", 1.0, 4);
        var tiger = new Tiger(4, "Клаус", 8.5, 3);

        zoo.AddAnimal(rabbit);
        zoo.AddAnimal(monkey);
        zoo.AddAnimal(rabbitBad);
        zoo.AddAnimal(tiger);

        var result = zoo.GetAnimalsForPettingZoo();

        Assert.Equal(2, result.Count);
        Assert.Contains(rabbit, result);
        Assert.Contains(monkey, result);
        Assert.DoesNotContain(rabbitBad, result);
        Assert.DoesNotContain(tiger, result);
    }

    [Fact]
    public void GetAllInventoryItems_ShouldReturnAnimalsAndThings()
    {
        var zoo = new Zoo(new AlwaysHealthyVeterinaryClinic());

        var rabbit = new Rabbit(1, "Игорь", 1.2, 8);
        var table = new Table(1001, "Стол ветеринара");
        var computer = new Computer(1002, "Компьютер администратора");

        zoo.AddAnimal(rabbit);
        zoo.AddItem(table);
        zoo.AddItem(computer);

        var items = zoo.GetAllInventoryItems();

        Assert.Equal(3, items.Count);
        Assert.Contains(rabbit, items);
        Assert.Contains(table, items);
        Assert.Contains(computer, items);
    }
}