

using System.ComponentModel.DataAnnotations;

namespace PetStore.Data;

public class ProductEntity(string name, decimal price, int quantity, string description)
{
    [Key]
    public int ProductId { get; set; }
    public string Name { get; set; } = name.ToLower();

    public decimal Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;
    public string Description { get; set; } = description;
    public override string ToString() => $"Name: {Name}\nPrice: {Price:C2}\nQuantity: {Quantity}\nDescription: {Description}";
}
