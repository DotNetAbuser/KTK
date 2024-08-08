namespace Infrastructure.Extensions;


public static class ServicesCollectionExtensions
{
    public static void AddUnitOfWork(
        this IServiceCollection services)
    {
        services
            .AddTransient<IUnitOfWork, UnitOfWork>();
    }
    
    public static void AddRepositories(
        this IServiceCollection services)
    {
        services
            .AddTransient<IClassroomRepository, ClassroomRepository>();
    }

    public static void AddServices(
        this IServiceCollection services)
    {
        services
            .AddTransient<IClassroomService, ClassroomService>();
    }
}