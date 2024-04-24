namespace ProductCollection;

public static class DecimalExtensions
{
    const decimal DISCOUNTED_RATE = 0.9M;
    public static decimal DiscountPrice(decimal value)
    {
       
        return value * DISCOUNTED_RATE;
    }


    public static decimal DiscountThisPrice(this decimal value)
    {
        return value * DISCOUNTED_RATE;
    }
}
