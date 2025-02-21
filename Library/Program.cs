using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Data;
using Models;
using Services;
using System.Linq;

namespace BookstoreApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=bookstore.db"));
            services.AddScoped<BookService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<OrderService>();

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();


                if (!dbContext.Books.Any())
                {
                    dbContext.Books.AddRange(
                        new Book { Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Publisher = "Allen & Unwin", Pages = 1178, Genre = "Fantasy", Year = 1954, CostPrice = 10, SalePrice = 20 },
                        new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Publisher = "Penguin Classics", Pages = 432, Genre = "Romance", Year = 1813, CostPrice = 8, SalePrice = 18 }
                    );
                    dbContext.SaveChanges();
                }

                if (!dbContext.Customers.Any())
                {
                    dbContext.Customers.AddRange(
                        new Customer { Name = "John Doe", Email = "john.doe@example.com" },
                        new Customer { Name = "Jane Smith", Email = "jane.smith@example.com" }
                    );
                    dbContext.SaveChanges();
                }

                bool running = true;
                while (running)
                {
                    Console.WriteLine("\nBookstore Application Menu:");
                    Console.WriteLine("1. Add Book");
                    Console.WriteLine("2. List All Books");
                    Console.WriteLine("3. Add Customer");
                    Console.WriteLine("4. List All Customers");
                    Console.WriteLine("5. Create Order");
                    Console.WriteLine("6. List All Orders");
                    Console.WriteLine("7. Exit");

                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    using (var innerScope = serviceProvider.CreateScope())
                    {
                        var bookService = innerScope.ServiceProvider.GetRequiredService<BookService>();
                        var customerService = innerScope.ServiceProvider.GetRequiredService<CustomerService>();
                        var orderService = innerScope.ServiceProvider.GetRequiredService<OrderService>();

                        switch (choice)
                        {
                            case "1":
                                AddBook(bookService);
                                break;
                            case "2":
                                ListBooks(bookService);
                                break;
                            case "3":
                                AddCustomer(customerService);
                                break;
                            case "4":
                                ListCustomers(customerService);
                                break;
                            case "5":
                                CreateOrder(orderService, customerService, bookService);
                                break;
                            case "6":
                                ListOrders(orderService);
                                break;
                            case "7":
                                running = false;
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                }

                Console.WriteLine("Exiting application.");
            }
        }


        static void AddBook(BookService bookService)
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter Publisher: ");
            string publisher = Console.ReadLine();

            int pages = GetIntFromConsole("Enter Pages: ");
            string genre = GetStringFromConsole("Enter Genre: ");
            int year = GetIntFromConsole("Enter Year: ");
            decimal costPrice = GetDecimalFromConsole("Enter Cost Price: ");
            decimal salePrice = GetDecimalFromConsole("Enter Sale Price: ");

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(publisher) || string.IsNullOrEmpty(genre))
            {
                Console.WriteLine("Some book details are missing.");
                return;
            }

            var book = new Book { Title = title, Author = author, Publisher = publisher, Pages = pages, Genre = genre, Year = year, CostPrice = costPrice, SalePrice = salePrice };
            bookService.AddBook(book);
            Console.WriteLine("Book added successfully!");
        }

        static int GetIntFromConsole(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }

        static decimal GetDecimalFromConsole(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a decimal number.");
            }
        }

        static string GetStringFromConsole(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void ListBooks(BookService bookService)
        {
            var books = bookService.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}. {book.Title} - {book.Author}");
            }
        }

        static void AddCustomer(CustomerService customerService)
        {
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Customer Email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Name or email cannot be empty.");
                return;
            }

            var customer = new Customer { Name = name, Email = email };
            customerService.AddCustomer(customer);
            Console.WriteLine("Customer added successfully!");
        }

        static void ListCustomers(CustomerService customerService)
        {
            var customers = customerService.GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id}. {customer.Name} - {customer.Email}");
            }
        }

        static void CreateOrder(OrderService orderService, CustomerService customerService, BookService bookService)
        {
            Console.WriteLine("Available Customers:");
            ListCustomers(customerService);
            int customerId = GetIntFromConsole("Enter Customer ID: ");

            Console.WriteLine("Available Books:");
            ListBooks(bookService);
            int bookId = GetIntFromConsole("Enter Book ID: ");

            var order = new Order { CustomerId = customerId, BookId = bookId, OrderDate = DateTime.Now };
            orderService.CreateOrder(order);
            Console.WriteLine("Order created successfully!");

        }

        static void ListOrders(OrderService orderService)
        {
            var orders = orderService.GetAllOrders();
            foreach (var order in orders)
            {
                if (order != null && order.Customer != null && order.Book != null)
                {
                    Console.WriteLine($"{order.Id}. Customer: {order.Customer.Name}, Book: {order.Book.Title}, Date: {order.OrderDate}");
                }
                else
                {
                    Console.WriteLine($"{order.Id}. Order details not available.");
                }
            }
        }
    }
}