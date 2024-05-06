using Microsoft.Extensions.DependencyInjection;
using ProductCollection.Logic;
using ProductCollection.UI;

var services = CreateServiceCollection();

IProductLogic? productLogic = services.GetService<IProductLogic>();



UserOptionFactory.Create(productLogic);
PrintGoodByeMessage();

static IServiceProvider CreateServiceCollection()
{
    return new ServiceCollection()
        .AddTransient<IProductLogic, ProductLogic>()
        .BuildServiceProvider();
}

static void PrintGoodByeMessage()
{
    Console.WriteLine(@"
        Thank you for visiting Pet Store.
        Bye bye!
        ");

}
