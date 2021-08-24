using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProductApp
{
    public class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; } // this should be decimal
        public int Weight { get; private set; } // this should be decimal

        public Product(string name, int price, int weight)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.");
            var regex = new Regex("^[a-z]+$");
            if (name.Length > 10 || !regex.IsMatch(name))
                throw new ApplicationException("Name should not exceed 10 or it should contain only a to z");
            if (price < 1)
                throw new ApplicationException("Price cannot be less than 1.");
            if (weight > 1000)
                throw new ApplicationException("Weight cannot be greater than 1000.");

            Name = name;
            Price = price;
            Weight = weight;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", Name, Price, Weight);
        }
    }
    
    class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product p1, Product p2)
        {
            if (p2 == null && p1 == null)
                return true;
            else if (p1 == null || p2 == null)
                return false;
            else if(p1.Name == p2.Name && p1.Price == p2.Price
                                           && p1.Weight == p2.Weight)
                return true;
            else
                return false;
        }

        public int GetHashCode(Product p)
        {
            return p.ToString().GetHashCode();
        }
    }
}