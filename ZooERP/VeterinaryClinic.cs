namespace ZooERP;

public sealed class VeterinaryClinic : IVeterinaryClinic
{
    public bool IsHealthy(Animal animal)
    {

        if (animal is Herbo && animal.Kindness < 2)
            return false;

        return true;
    }
}
