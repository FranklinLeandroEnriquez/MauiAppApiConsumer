using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppApiConsumer.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double IVA { get; set; }
        public double Price { get; set; }
        public double CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
