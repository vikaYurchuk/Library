using Models;

using Models; 
using System.Collections.Generic;

namespace BookstoreApp.Interfaces 
{
    public interface IBookstoreService
    {
        
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        List<Book> SearchBooks(string searchTerm);

        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);

        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);

      
        List<Book> GetPopularBooks(int count);
        List<Customer> GetActiveCustomers(int months);
        decimal CalculateTotalSales(DateTime startDate, DateTime endDate);
        List<Order> GetOrdersByCustomer(int customerId);
        List<Book> GetBooksByAuthor(string author);
    }
}