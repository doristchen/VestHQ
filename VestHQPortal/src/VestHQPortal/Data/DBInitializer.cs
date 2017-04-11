using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using VestHQModel;

namespace VestHQPortal.Data
{
    public class DBInitializer
    {
        public static void Initialize(VestHQDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var stocks = new Stock[]
            {
                new Stock {
                    Name ="Microsoft",
                    Symbol ="MSFT"
                },
                new Stock {
                    Name ="Apple",
                    Symbol ="AAPL"
                },
                new Stock {
                    Name ="General Motors",
                    Symbol ="GM"
                },
            };

            foreach (Stock s in stocks)
            {
                context.Stocks.Add(s);
            }
            context.SaveChanges();

            var stockpricehistory = new StockPriceHistory[]
            {
                new StockPriceHistory {
                    StockId =1,
                    Date = DateTime.Parse("2017-04-07 T17:30:00"),
                    Price = 65.73
                },

                new StockPriceHistory {
                    StockId =2,
                    Date = DateTime.Parse("2017-04-07 T17:30:00"),
                    Price = 143.66
                },

                new StockPriceHistory {
                    StockId =3,
                    Date = DateTime.Parse("2017-04-07 T17:30:00"),
                    Price = 40.60
                },

                new StockPriceHistory {
                    StockId =1,
                    Date = DateTime.Parse("2017-04-08 T17:30:00"),
                    Price = 66
                },

                new StockPriceHistory {
                    StockId =2,
                    Date = DateTime.Parse("2017-04-08 T17:30:00"),
                    Price = 140
                },

                new StockPriceHistory {
                    StockId =3,
                    Date = DateTime.Parse("2017-04-08 T17:30:00"),
                    Price = 41
                },
            };
            
            foreach (StockPriceHistory sph in stockpricehistory)
            {
                context.StockPriceHistories.Add(sph);
            }

            context.SaveChanges();

            var Employer = new Employer[]
            {
                new Employer {
                    EmployerName ="VestHQ No1"
                },

                new Employer {
                    EmployerName = "VestHQ No2"
                },
            };

            foreach (Employer e in Employer)
            {
                context.Employers.Add(e);
            }

            context.SaveChanges();

            var Customer = new Customer[]
            {
                new Customer {
                    FirstName ="Doris",
                    LastName = "Chen",
                    TwitterAccount ="dchen",
                    EmployerId = 1
                },

                new Customer {
                    FirstName = "David",
                    LastName ="Giard",
                    TwitterAccount ="dgiard",
                    EmployerId = 2
                },
            };

            foreach (Customer c in Customer)
            {
                context.Customers.Add(c);
            }

            context.SaveChanges();

            var Holding = new Holding[]
            {
                new Holding {
                    StockId = 1,
                    CustomerId = 1,
                    Share = 2000
                },

                new Holding {
                    StockId = 1,
                    CustomerId = 2,
                    Share = 2500
                },

                new Holding {
                    StockId = 2,
                    CustomerId = 1,
                    Share = 1000
                },

                new Holding {
                    StockId = 3,
                    CustomerId = 2,
                    Share = 500
                }
            };

            foreach (Holding h in Holding)
            {
                context.Holdings.Add(h);
            }

            context.SaveChanges();
        }
    }
}
