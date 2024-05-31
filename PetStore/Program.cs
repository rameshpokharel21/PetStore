using Microsoft.Extensions.DependencyInjection;
using PetStore.Data;
using ProductCollection.Logic;
using ProductCollection.UI;

var services = CreateServiceCollection();

IProductLogic? productLogic = services.GetService<IProductLogic>();

ArgumentNullException.ThrowIfNull(productLogic);

UserOptionFactory.Create(productLogic);
PrintGoodByeMessage();

static IServiceProvider CreateServiceCollection()
{
    return new ServiceCollection()
        .AddDbContext<ProductContext>()
        .AddScoped<IProductLogic, ProductLogic>()
        .AddScoped<IProductRepository, ProductRepository>()
        .BuildServiceProvider();
}

static void PrintGoodByeMessage()
{
    Console.WriteLine(@"
        Thank you for visiting Pet Store.
        Bye bye!
        ");

}
