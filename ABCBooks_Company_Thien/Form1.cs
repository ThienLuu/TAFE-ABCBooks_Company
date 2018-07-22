using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCBooks_Company_Thien
{
    public partial class Form1 : Form
    {
        Book[] books = new Book[10];
        public Form1()
        {
            InitializeComponent();
        }
        //Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTextbookType.DataSource = Enum.GetValues(typeof(BookTypeEnum));
        }
        //Hide/Show selection of book type
        private void cmbBookType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bookType = cmbBookType.Text;
            if (bookType == "E-Book")
            {
                //book type type
                cmbTextbookType.Visible = false;
                label9.Visible = false;
                //filesize
                txtFileSize.Visible = true;
                label8.Visible = true;
            }
            else if (bookType == "Textbook")
            {
                //filesize
                txtFileSize.Visible = false;
                label8.Visible = false;
                txtFileSize.Clear();
                //book type type
                cmbTextbookType.Visible = true;
                label9.Visible = true;
            }
        }
        //Exit Application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Add Book
        //Add Book
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string bookType = cmbBookType.Text;
            string title = txtTitle.Text;
            double price = double.Parse(txtPrice.Text);
            string publisher = txtPublisher.Text;
            int yearPublished = int.Parse(txtYearPublished.Text);
            int isbn = int.Parse(txtISBN.Text);
            int numberOfPages = int.Parse(txtNumberOfPages.Text);

            if (bookType == "E-Book")
            {
                int fileSize = int.Parse(txtFileSize.Text);

                EBook newEbook = new EBook(title, price, publisher, yearPublished, isbn, numberOfPages, fileSize);
                if (AddNewBook(newEbook))
                {
                    MessageBox.Show("Successful Insertion");
                }
                else
                {
                    MessageBox.Show("Fail Insertion");
                }
            }
            else if (bookType == "Textbook")
            {
                BookTypeEnum textBookType = (BookTypeEnum)cmbTextbookType.SelectedItem;

                Textbook newTextbook = new Textbook(title, price, publisher, yearPublished, isbn, numberOfPages, textBookType);
                if (AddNewBook(newTextbook))
                {
                    MessageBox.Show("Successful Insertion");
                }
                else
                {
                    MessageBox.Show("Fail Insertion");
                }
            }

            txtTitle.Clear();
            txtPrice.Clear();
            txtPublisher.Clear();
            txtYearPublished.Clear();
            txtISBN.Clear();
            txtNumberOfPages.Clear();
            txtFileSize.Clear();

            #region Manual Data Input Test
            //Test - input sample date manually first
            //EBook eb = new EBook(title, price, publisher, yearPublished, isbn, numberOfPages, fileSize);

            //eb.Title = "Book1";
            //eb.Price = 6.50;
            //eb.Publisher = "Thien";
            //eb.YearPublished = 1999;
            //eb.ISBN = 1234;
            //eb.NumberOfPages = 50;
            //eb.FileSize = 1000;

            //MessageBox.Show(eb.ToString());
            #endregion
        }
        //Add Book - Add New Book Method
        public bool AddNewBook(Book newBook)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] == null)
                {
                    books[i] = newBook;
                    return true;
                }
                else if (i == books.Length - 1)
                {
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region Display Books
        //Display Books
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg = BookInfo();
            if (msg == "")
            {
                msg = "No books in memory (Array)";
            }
            MessageBox.Show(msg);
        }
        //Display Books - Display Books Method
        public string BookInfo()
        {
            string msg = "";

            foreach (Book book in books)
            {
                if (book != null)
                {
                    msg += book.ToString();
                }
            }
            return msg;
        }
        #endregion

        #region Search Book
        //Search Book
        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            string isbn = txtISBNSD.Text;
            MessageBox.Show(Search(isbn));
        }
        //Search Book = ISBN Return Method
        public string Search(string isbn)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null && int.Parse(isbn) == books[i].ISBN)
                {
                    return isbn = books[i].ToString();
                }
            }
            return isbn = "Not found";
        }
        #endregion

        #region Update Book
        //Update Book *** NOT WORKING - Don't know what to do ***
        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            string bookType = cmbBookType.Text;
            string title = txtTitle.Text;
            double price = double.Parse(txtPrice.Text);
            string publisher = txtPublisher.Text;
            int yearPublished = int.Parse(txtYearPublished.Text);
            int isbn = int.Parse(txtISBN.Text);
            int numberOfPages = int.Parse(txtNumberOfPages.Text);
            int fileSize = int.Parse(txtFileSize.Text);
            string textbookType = cmbTextbookType.Text;

            EBook newEbook = new EBook(title, price, publisher, yearPublished, isbn, numberOfPages, fileSize);
            Textbook newTextbook = new Textbook(title, price, publisher, yearPublished, isbn, numberOfPages);

            int isbnSearch = int.Parse(txtISBN.Text);
            if (UpdateBook(newEbook, isbnSearch) || UpdateBook(newTextbook, isbnSearch))
            {
                MessageBox.Show("Update Completed");
            }
            else
            {
                MessageBox.Show("Update Failed");
            }
        }

        public bool UpdateBook(Book newBook, int isbn)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null && isbn == books[i].ISBN)
                {
                    books[i] = newBook;
                    return true;
                }

                else if (i == books.Length - 1)
                {
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region Delete Book
        //Delete Book
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            int isbn = int.Parse(txtISBNSD.Text);
            MessageBox.Show(deleteBook(isbn));
        }
        //Delete Book - Delete Book Method
        public string deleteBook(int isbn)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null && isbn == books[i].ISBN)
                {
                    books[i] = null;
                    return "Delete Completed";
                }
            }
            return "Delete Failed";
        }
        #endregion

        #region Additional - Display All Textbooks
        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "";
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null && books[i] is Textbook)
                {
                    msg += books[i].ToString();
                }
            }
            MessageBox.Show("Textbooks: \n" + msg);
        }
        #endregion

        #region Additional - Total Delivery Fee of Textbooks
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total delivery fee: $" + CalculateTotalFee());
        }
        public double CalculateTotalFee()
        {
            double total = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null && books[i] is Textbook)
                {
                    total += ((Textbook)books[i]).CalculateDeliveryFee();
                }
            }
            return total;
        }
        #endregion
    }
}
