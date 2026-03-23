using Microsoft.Extensions.DependencyInjection;

namespace ZooERP;

public static class CompositionRoot

{
    private static IServiceProvider? _services;

    public static IServiceProvider Services => _services ??= CreateServiceProvider();

    private static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();

        // регистрируем интерфейсы клиники и зоопарка в качестве сервисов со своими имплементациями и сервис зоопарка
        services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
        services.AddSingleton<Zoo>();
        services.AddSingleton<IZooAppService, ZooAppService>();

        return services.BuildServiceProvider(); // строим контейнер зависимостей
    }
}