using System;
using System.Globalization;
using Enumerator.Entities;
using Enumereator.Entities;
using Enumereator.Entities.Enums;

namespace Enumereator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.WriteLine("-------------------------- ");
            Console.WriteLine("Lista de status: \n");

            foreach (OrderStatus val in Enum.GetValues(typeof(OrderStatus)))
            {
                Console.WriteLine(string.Format("{0}: {1}", Enum.GetName(typeof(OrderStatus), val), val.GetHashCode()));
            }

            Console.WriteLine("-------------------------- ");
            Console.Write("Status: ");
            Enum.TryParse(Console.ReadLine(), out OrderStatus status);

            Client client = new Client(clientName, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine($"Order Moment: {order.Moment}");
            Console.WriteLine($"Order Status: {order.Status}");
            Console.WriteLine($"Client: {order.Client.Nome} ({order.Client.BirthDate:MM/dd/yyyy}) - {order.Client.Email}");
            Console.WriteLine("Order items:");

            foreach (OrderItem item in order.Items)
            {
                Console.WriteLine($"{item.Product.Name}, R${item.Price}, Quantity: {item.Quantity}, Subtotal: R$ {item.SubTotal()}");
            }

            Console.WriteLine($"Total price: ${order.Total()}");
            Console.Read();
        }
    }
}
