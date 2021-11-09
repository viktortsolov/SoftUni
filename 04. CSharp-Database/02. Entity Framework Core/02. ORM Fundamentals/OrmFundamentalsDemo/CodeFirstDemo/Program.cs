using CodeFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            var news = db.News.Select(x => new
            {
                Name = x.Title,
                CategoryName = x.Category.Title
            });

            foreach (var singleNews in news)
            {
                Console.WriteLine(singleNews.CategoryName);
            }
            db.SaveChanges();
        }
    }
}
