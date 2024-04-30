using ProductCollection.ProductModel;
using ProductCollection.UI;


ProductLogic productLogic = new ProductLogic();
UserOptionFactory.Create(productLogic);
PrintGoodByeMessage();

static void PrintGoodByeMessage()
{
    Console.WriteLine(@"
        Thank you for visiting Pet Store.
        Bye bye!
        ");

}
