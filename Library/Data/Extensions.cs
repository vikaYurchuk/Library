using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public static class Extensions
{
    public static void SeedInitialData(this ModelBuilder modelBuilder)
    {
        // Книги
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Publisher = "Allen & Unwin", Pages = 1178, Genre = "Fantasy", Year = 1954, CostPrice = 10, SalePrice = 20 },
            new Book { Id = 2, Title = "Pride and Prejudice", Author = "Jane Austen", Publisher = "Penguin Classics", Pages = 432, Genre = "Romance", Year = 1813, CostPrice = 8, SalePrice = 18 },
            new Book { Id = 3, Title = "1984", Author = "George Orwell", Publisher = "Secker & Warburg", Pages = 328, Genre = "Dystopian", Year = 1949, CostPrice = 7, SalePrice = 15 },
            new Book { Id = 4, Title = "To Kill a Mockingbird", Author = "Harper Lee", Publisher = "J. B. Lippincott & Co.", Pages = 281, Genre = "Southern Gothic", Year = 1960, CostPrice = 9, SalePrice = 19 },
            new Book { Id = 5, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Publisher = "Charles Scribner's Sons", Pages = 180, Genre = "Tragedy", Year = 1925, CostPrice = 6, SalePrice = 14 },
            new Book { Id = 6, Title = "The Catcher in the Rye", Author = "J. D. Salinger", Publisher = "Little, Brown and Company", Pages = 234, Genre = "Coming-of-age", Year = 1951, CostPrice = 8, SalePrice = 16 },
            new Book { Id = 7, Title = "The Hobbit", Author = "J.R.R. Tolkien", Publisher = "George Allen & Unwin", Pages = 310, Genre = "Fantasy", Year = 1937, CostPrice = 11, SalePrice = 22 },
            new Book { Id = 8, Title = "And Then There Were None", Author = "Agatha Christie", Publisher = "Collins Crime Club", Pages = 264, Genre = "Mystery", Year = 1939, CostPrice = 7, SalePrice = 15 },
            new Book { Id = 9, Title = "The Da Vinci Code", Author = "Dan Brown", Publisher = "Doubleday", Pages = 454, Genre = "Mystery thriller", Year = 2003, CostPrice = 10, SalePrice = 20 },
            new Book { Id = 10, Title = "The Hunger Games", Author = "Suzanne Collins", Publisher = "Scholastic Press", Pages = 374, Genre = "Dystopian", Year = 2008, CostPrice = 9, SalePrice = 18 }
        );

        // Клієнти
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" },
            new Customer { Id = 3, Name = "Peter Jones", Email = "peter.jones@example.com" },
            new Customer { Id = 4, Name = "Mary Brown", Email = "mary.brown@example.com" },
            new Customer { Id = 5, Name = "David Lee", Email = "david.lee@example.com" },
            new Customer { Id = 6, Name = "Sarah Wilson", Email = "sarah.wilson@example.com" },
            new Customer { Id = 7, Name = "Michael Garcia", Email = "michael.garcia@example.com" },
            new Customer { Id = 8, Name = "Linda Rodriguez", Email = "linda.rodriguez@example.com" },
            new Customer { Id = 9, Name = "James Williams", Email = "james.williams@example.com" },
            new Customer { Id = 10, Name = "Patricia Martinez", Email = "patricia.martinez@example.com" }
        );

        // Замовлення
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, CustomerId = 1, BookId = 1, OrderDate = new DateTime(2024, 1, 15) },
            new Order { Id = 2, CustomerId = 2, BookId = 3, OrderDate = new DateTime(2024, 1, 20) },
            new Order { Id = 3, CustomerId = 3, BookId = 5, OrderDate = new DateTime(2024, 1, 25) },
            new Order { Id = 4, CustomerId = 4, BookId = 7, OrderDate = new DateTime(2024, 1, 30) },
            new Order { Id = 5, CustomerId = 5, BookId = 9, OrderDate = new DateTime(2024, 2, 5) },
            new Order { Id = 6, CustomerId = 6, BookId = 2, OrderDate = new DateTime(2024, 2, 10) },
            new Order { Id = 7, CustomerId = 7, BookId = 4, OrderDate = new DateTime(2024, 2, 15) },
            new Order { Id = 8, CustomerId = 8, BookId = 6, OrderDate = new DateTime(2024, 2, 20) },
            new Order { Id = 9, CustomerId = 9, BookId = 8, OrderDate = new DateTime(2024, 2, 25) },
            new Order { Id = 10, CustomerId = 10, BookId = 10, OrderDate = new DateTime(2024, 3, 1) }
        );
    }
}