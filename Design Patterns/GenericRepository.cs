using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
    }
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Voice { get; set; } = string.Empty;
    }
    public class GenericRepository<t> where t : class
    {
        public List<t> _myEntities = new List<t>();

        public List<t> getall() => _myEntities;
        public t getById(int id)
        {
            var y =  _myEntities.FirstOrDefault(e => ((dynamic)e).Id == id);
            if (y == null)
            {
                throw new Exception("Failed");
            }
            return y;
        }
        public t add(t ele)
        {
            _myEntities.Add(ele);
            return ele;
        }
        public t update(t ele)
        {
            var existing = getById(((dynamic)ele).Id);
            if (existing is not null)
            {
                var indexofExisting = _myEntities.IndexOf(existing);
                _myEntities[indexofExisting] = ele;
            }
            return ele;
        }
        public void delete(t ele)
        {
            var element = getById(((dynamic)ele).Id);
            if (element is not null)
            {
                _myEntities.Remove(element);
            }
        }
    }

    public class GenericExecMain
    {
        public void ExecMain()
        {
            var producRepo = new GenericRepository<Product>();
            producRepo.add(new Product { Id = 1, Name = "JON", Price = 20.20m });
            producRepo.add(new Product { Id = 2, Name = "RON", Price = 25.20m });
            producRepo.add(new Product { Id = 3, Name = "Show", Price = 80.20m });
            var tu = producRepo.getall();
            var t44 = producRepo.getById(2);
            producRepo.update(new Product { Id = 1, Name = "BRON", Price = 90.20m });
            producRepo.delete(new Product { Id = 3, Name = "Show", Price = 80.20m });
            var tu3 = producRepo.getall();



        }
    }

}
