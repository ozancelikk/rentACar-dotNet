using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI {
    public class Program {
        public static void Main(string[] args) {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach(var car in productManager.GetAll()) {
                Console.WriteLine(car.ModelYear);
            }
        }
    }
}
