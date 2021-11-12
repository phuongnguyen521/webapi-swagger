using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace MySQLForwardEngineering
{
    public class Program
    {
        static void Main(string[] args)
        {
            //https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-example.html
            InserData();
            PrintData();
        }

        private static void InserData()
        {
            using (var context = new MyLibraryContext())
            {
                context.Database.EnsureCreated();

                var publisher = new Publisher
                {
                    name = "Mariner Books"
                };

                context.Publishers.Add(publisher);

                context.Books.Add(new Book
                {
                    ISBN = "978-0544003415",
                    Title = "The Lord of the Rings",
                    Author = "J.R.R. Tolkien",
                    Language = "English",
                    Pages = 1216,
                    Publisher = publisher
                });
                context.Books.Add(new Book
                {
                    ISBN = "978-0547247762",
                    Title = "The Sealed Letter",
                    Author = "Emma Donoghue",
                    Language = "English",
                    Pages = 416,
                    Publisher = publisher
                });

                // Saves changes
                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            using (var context = new MyLibraryContext())
            {
                var Books = context.Books.Include(p => p.Publisher);
                foreach(var book in Books)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ISBN: {book.ISBN}");
                    data.AppendLine($"Title: {book.Title}");
                    data.AppendLine($"Publisher: {book.Publisher.name}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
