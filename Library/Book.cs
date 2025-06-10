using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int CopiesAvaliable { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public Book(string title, string author, int copies)
        {
            Title = title;
            Author = author;
            CopiesAvaliable = copies;
        }
        public void AddOrder(string readername, DateTime returndate)
        {
            if (CopiesAvaliable > 0)
            {
                Orders.Add(new Order(readername, returndate));
                CopiesAvaliable--;
            }
        }

        public bool NeedsReminder()
        {
            return Orders.Any(o => o.ReturnDate <= DateTime.Now.AddDays(2));
        }
    }
}
