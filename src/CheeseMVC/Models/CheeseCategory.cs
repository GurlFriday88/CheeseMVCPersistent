using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseCategory{

        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Cheese> Cheese { get; set; }
    }
    //this represents a table and every instance of this class will represent a row in this table  

}
