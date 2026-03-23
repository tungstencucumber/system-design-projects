using ZooERP;
using Xunit;

namespace ZooERP.Tests;

public class VeterinaryClinicTests
{
    private readonly VeterinaryClinic _clinic = new();

    [Fact]
    public void IsHealthy_ShouldReturnFalse_ForHerboWithLowKindness()
    {
        var rabbit = new Rabbit(2, "Русак", 1.0, 1);

        var result = _clinic.IsHealthy(rabbit);

        Assert.False(result);
    }

    [Fact]
    public void IsHealthy_ShouldReturnTrue_ForHerboWithNormalKindness()
    {
        var rabbit = new Rabbit(3, "Синдзи", 1.0, 8);

        var result = _clinic.IsHealthy(rabbit);

        Assert.True(result);
    }

    [Fact]
    public void IsHealthy_ShouldReturnTrue_ForPredator()
    {
        var tiger = new Tiger(4, "Клаус", 8.0, 2);

        var result = _clinic.IsHealthy(tiger);

        Assert.True(result);
    }
}