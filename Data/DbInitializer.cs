using JINI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JINI.Data
{
    public class DbInitializer
    {
        public static void Initialize(JINIContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Items.
            if (context.Items.Any())
            {
                return;   // DB has been seeded
            }

            var items = new Item[]
            {
                new Item{Supplier="中大",Address="",ContactNumber="34207027",ItemName="국제천"},
                new Item{Supplier="中大",Address="",ContactNumber="22039139",ItemName="스웨이드"},
                new Item{Supplier="中大",Address="",ContactNumber="89025092",ItemName="D452"},
                new Item{Supplier="YT 354",Address="",ContactNumber="29070977",ItemName="9760"}
            };

            context.Items.AddRange(items);
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{Name="에이치",Owner="김현준"},
                new Customer{Name="MIN",Owner="이민우"}
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();           
        }
    }
}
