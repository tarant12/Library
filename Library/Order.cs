using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Order
    {
        public string ReaderName { get; set; }
        public DateTime ReturnDate { get; set; }

        public Order(string readername, DateTime returndate)
        {
            ReaderName = readername;
            ReturnDate = returndate;
        }
    }
}
