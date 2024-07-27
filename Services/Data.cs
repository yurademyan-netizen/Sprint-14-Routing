using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsWithRouting.Models;

namespace ProductsWithRouting.Services
{
    public class Data
    {
        public List<Product> Products = new List<Product>
        {
            new Product() {Id = 1, Name = "Product2", Description = "ProductDescription"},
            new Product() {Id = 2, Name = "Product3", Description = "ProductDescription"},
            new Product() {Id = 3, Name = "Product4", Description = "ProductDescription"},
            new Product() {Id = 4, Name = "Product5", Description = "ProductDescription"},
            new Product() {Id = 5, Name = "Product6", Description = "ProductDescription"},
            new Product() {Id = 6, Name = "Product1", Description = "ProductDescription"},
        };

        public List<User> Users = new List<User>
        {
            new User() {Id = 0, Name = "UserAdmin", Email = "admin@gmail.com", Role = "admin"},
            new User() {Id = 0, Name = "Guest", Email = "guest@gmail.com", Role = "guest"},
            new User() {Id = 0, Name = "User", Email = "user1@gmail.com", Role = "user"},
            new User() {Id = 0, Name = "User2", Email = "user2@gmail.com", Role = "user"},

        };
    }
}
