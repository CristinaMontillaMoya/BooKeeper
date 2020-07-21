
namespace BooKeeper.Web.Data
{
    using BooKeeper.Web.Helpers;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public IUserHelper UserHelper { get; }

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            UserHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = this.UserHelper.FindUsers();
            if (user == null)
            {
                var user1 = new User
                {
                    Name = "Cristina",
                    Surname = "MontillaMoya",
                    Email = "cristinamontilla.90@gmail.com",
                    UserName = "cristinamontilla.90@gmail.com"
                };

                var user2 = new User
                {
                    Name = "Daniel",
                    Surname = "CuencaSantamaría",
                    Email = "daniel.c.santamaria@gmail.com",
                    UserName = "daniel.c.santamaria@gmail.com"
                };

                var result1 = await this.UserHelper.AddUserAsync(user1, "123456");

                if (result1 != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user" + user1.Name + " in seeder");
                }

                var result2 = await this.UserHelper.AddUserAsync(user2, "654321");

                if (result2 != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user" + user2.Name + " in seeder");
                }
            }

            if (!this.context.Categories.Any())
            {
                this.AddCategory("Aventuras");
                this.AddCategory("Fantasía");
                this.AddCategory("Terror");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Books.Any())
            {
                Category fCategory = context.Categories
                            .Where(c => c.Name == "Fantasía")
                            .FirstOrDefault();

                if (fCategory != null)
                {
                    this.AddBook("9788434894396", "La llamada de los muertos", "Laura Gallego García", new DateTime(2003, 3, 12),
                   "Tras la llegada a la torre de Saevin de un muchacho con unos poderes excepcionales, Dana siente que algo" +
                   "extraño está a punto de suceder...", "~/images/Books/9788434894396.jpg", this.random.Next(50), fCategory, 3);
                }

                Category tCategory = context.Categories
                            .Where(c => c.Name == "Terror")
                            .FirstOrDefault();

                if (tCategory != null)
                {
                    this.AddBook("8466201130", "Cuentos", "Edgar Allan Poe", new DateTime(2000, 1, 1), "Relatos de terror",
                    "~/images/Books/CUENTOS-E-A-POE-ISLA-MISTERIOSA-i1n42735.jpg", this.random.Next(50), tCategory, 26);
                    this.AddBook("8423927687", "Si quieres pasar miedo", "Angela Sommer-Bodenburg", new DateTime(1987, 1, 21),
                    "¿Hay algo peor que estar enfermo en la cama y aburrirse? Para evitarlo, Florián pide a sus padres y a su" +
                    "abuela que le cuenten historias de miedo", "~/ images / Books / libro01.jfif", this.random.Next(50), tCategory, 17);
                }
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Sales.Any())
            {
                User salesUser = await this.UserHelper.GetUserByEmailAsync("cristinamontilla.90@gmail.com");
                if (salesUser != null)
                {
                    this.AddSale(new DateTime(2020, 6, 18), "España", "Málaga", "679880055", null, salesUser);
                    this.AddSale(new DateTime(2020, 6, 18), "Portugal", "Lisboa", "675554432", "Llamar por teléfono en el" +
                        "momento de la entrega", salesUser);
                }

                await this.context.SaveChangesAsync();
            }

            if (!this.context.SaleDetails.Any())
            {
                Sale sale = context.Sales
                    .Where(s => s.Id == 1)
                    .FirstOrDefault();
                Book book = context.Books
                    .Where(b => b.Isbn == "8423927687")
                    .FirstOrDefault();
                if(sale != null && book != null)
                {
                    this.AddSaleDetail(sale, book);
                }

                Sale sale2 = context.Sales
                    .Where(s => s.Id == 2)
                    .FirstOrDefault();
                Book book2 = context.Books
                    .Where(b => b.Isbn == "8423927687")
                    .FirstOrDefault();
                Book book3 = context.Books
                    .Where(b => b.Isbn == "9788434894396")
                    .FirstOrDefault();
                if (sale2 != null && book2 != null && book3 != null)
                {
                    this.AddSaleDetail(sale2, book2);
                    this.AddSaleDetail(sale2, book3);
                }

                await this.context.SaveChangesAsync();
            }
        }

        private void AddSaleDetail(Sale sale, Book book)
        {
            this.context.SaleDetails.Add(new SaleDetail
            {
                Sale = sale,
                Isbn = book
            });
        }

        private void AddSale(DateTime date, string country, string province, string telephone, string data, User user)
        {
            this.context.Sales.Add(new Sale
            {
                Date = date,
                Country = country,
                Province = province,
                Telephone = telephone,
                DeliveryData = data,
                User = user
            });
        }

        private void AddCategory(string name)
        {
            this.context.Categories.Add(new Category
            {
                Name = name
            });
        }

        private void AddBook(string isbn, string title, string author, DateTime date,
            string synopsis, string image, float price, Category category, int stock)
        {
            this.context.Books.Add(new Book
            {
                Isbn = isbn,
                Title = title,
                Author = author,
                Date = date,
                Synopsis = synopsis,
                Image = image,
                Price = price,
                Category = category,
                Stock = stock
            });
        }

    }
}
