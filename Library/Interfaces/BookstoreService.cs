using Data;
using Models;
using BookstoreApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApp.Services 
{
    public class BookstoreService : IBookstoreService
    {
        private readonly AppDbContext _context;

        public BookstoreService(AppDbContext context)
        {
            _context = context;
        }

      
        public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBookById(int id) => _context.Books.Find(id);

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public List<Book> SearchBooks(string searchTerm)
        {
            return _context.Books.Where(b => b.Title.Contains(searchTerm) ||
                                             b.Author.Contains(searchTerm) ||
                                             b.Genre.Contains(searchTerm)).ToList();
        }

      

        public List<Customer> GetAllCustomers() => _context.Customers.ToList();
        public Customer GetCustomerById(int id) => _context.Customers.Find(id);
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public List<Order> GetAllOrders() => _context.Orders.ToList();

        public Order GetOrderById(int id) => _context.Orders.Find(id);

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public List<Book> GetPopularBooks(int count)
        {
            return _context.Books.OrderByDescending(b => b.Orders.Count).Take(count).ToList();
        }

        public List<Customer> GetActiveCustomers(int months)
        {
            var cutoffDate = DateTime.Now.AddMonths(-months);
            return _context.Customers.Where(c => c.Orders.Any(o => o.OrderDate >= cutoffDate)).ToList();
        }

        public decimal CalculateTotalSales(DateTime startDate, DateTime endDate)
        {
            return _context.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).Sum(o => o.Book.SalePrice);
        }

        public List<Order> GetOrdersByCustomer(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return _context.Books.Where(b => b.Author == author).ToList();
        }
    }
}