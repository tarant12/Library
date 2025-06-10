using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    
    

    public partial class MainForm : Form
    {
        private List<Book> books = new List<Book>();

        public MainForm()
        {
            InitializeComponent();
            InitializeBooks();
            RefreshBookList();
        }

        private void InitializeBooks()
        {
            books.Add(new Book("Война и мир", "Лев Толстой", 5));
            books.Add(new Book("Преступление и наказание", "Федор Достоевский", 3));
            books.Add(new Book("1984", "Джордж Оруэлл", 2));
        }

        private void RefreshBookList()
        {
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = books.Select(b => new {
                Название = b.Title,
                Автор = b.Author,
                Доступно = b.CopiesAvailable
            }).ToList();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewBooks.SelectedRows[0].Index;
                OrderForm orderForm = new OrderForm(books[selectedIndex]);
                orderForm.ShowDialog();
                RefreshBookList();
            }
        }

        private void btnCheckReminders_Click(object sender, EventArgs e)
        {
            var booksNeedingReminder = books.Where(b => b.NeedsReminder()).ToList();
            dataGridViewBooks.DataSource = null;
            dataGridViewBooks.DataSource = booksNeedingReminder.Select(b => new {
                Название = b.Title,
                Автор = b.Author,
                Доступно = b.CopiesAvailable
            }).ToList();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            RefreshBookList();
        }
}
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
