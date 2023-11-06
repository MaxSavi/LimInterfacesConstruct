using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimInterConstruct
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        void Delete(T item);
        T FindById(int id);
        IEnumerable<T> GetAll();
    }

    public interface IEntity
    {
        int Id { get; }
    }

    public class Product : IEntity
    {
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    public class User : IEntity
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Address { get; set; }

        public User(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }

    public class ProductRepository : IRepository<Product>
    {
        private List<Product> products = new List<Product>();

        public void Add(Product item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            products.Add(item);
        }

        public void Delete(Product item)
        {
            products.Remove(item);
        }

        public Product FindById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }
    }

    public class UserRepository : IRepository<User>
    {
        private List<User> customers = new List<User>();

        public void Add(User item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            customers.Add(item);
        }

        public void Delete(User item)
        {
            customers.Remove(item);
        }

        public User FindById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return customers;
        }
    }
}
