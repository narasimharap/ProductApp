using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new[] { "ball", "bat", "glove", "glove", "glove" };
            var prices = new[] { 2, 3, 1, 2, 1 };
            var weights = new[] { 2, 5, 1, 1, 1 };
            var duplicates = FindDuplicates(names, prices, weights);
            Console.WriteLine($"Total duplicates: {duplicates}");
            Console.ReadLine();
        }

        private static int FindDuplicates(string[] names, int[] prices, int[] weights)
        {
            const int totalAllowedItems = 100000;
            var inputLength = names.Length;
            if (inputLength < 1 || inputLength > totalAllowedItems)
                throw new ApplicationException($"Total items should be 1 or less than {totalAllowedItems}");
            
            var products = new List<Product>();
            if (!(inputLength == prices.Length && prices.Length == weights.Length))
                throw new ApplicationException("All the input data should contian same number of elements");
            for (int i = 0; i < inputLength; ++i)
            {
                products.Add(new Product(names[i], prices[i], weights[i]));
            }

            return inputLength - products.Distinct(new ProductEqualityComparer()).Count();
        }
    }
}