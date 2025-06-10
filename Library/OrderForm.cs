using Library;
using System;
using System.Windows.Forms;

namespace LibraryOrderSystem
{
    public partial class OrderForm : Form
    {
        private readonly Book _book;

        public OrderForm(Book book)
        {
            InitializeComponent();
            _book = book ?? throw new ArgumentNullException(nameof(book));
            InitializeForm();
        }

        private void InitializeForm()
        {
            lblBookTitle.Text = _book.Title;
            lblBookAuthor.Text = _book.Author;
            dtpReturnDate.MinDate = DateTime.Now.AddDays(1);
            dtpReturnDate.Value = DateTime.Now.AddDays(7);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReaderName.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя читателя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReaderName.Focus();
                return;
            }

            if (dtpReturnDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Дата возврата должна быть в будущем", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpReturnDate.Focus();
                return;
            }

            if (!_book.AddOrder(txtReaderName.Text, dtpReturnDate.Value))
            {
                MessageBox.Show("Не удалось оформить заказ. Возможно, книга больше не доступна.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}