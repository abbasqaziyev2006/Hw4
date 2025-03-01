using System;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal price = 100.00m;
            decimal discount = 15.0m;
            decimal discountedPrice = ApplyDiscount(price, discount);

            Console.WriteLine($"Original price: {price}");
            Console.WriteLine($"Discount applied: {discount}");
            Console.WriteLine($"Discounted price: {discountedPrice}");
        }

        public static decimal ApplyDiscount(decimal price, decimal percentage)
        {
            decimal discountAmount = (price * percentage) / 100;
            return price - discountAmount;
        }
    }
}
