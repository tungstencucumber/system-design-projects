using ZooERP;

namespace ZooERP.Tests.Fakes;

public sealed class AlwaysHealthyVeterinaryClinic : IVeterinaryClinic
{
    public bool IsHealthy(Animal animal) => true;
}

public sealed class AlwaysUnhealthyVeterinaryClinic : IVeterinaryClinic
{
    public bool IsHealthy(Animal animal) => false;
}