using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCBooks_Company_Thien
{
    public abstract class Book
    {
        //fields & props
        public string Title { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }
        public int ISBN { get; set; }
        public int NumberOfPages { get; set; }

        //constructors
        public Book()
        {

        }
        public Book(string title, double price, string publisher, int yearPublished, int iSBN, int numberOfPages)
        {
            this.Title = title;
            this.Price = price;
            this.Publisher = publisher;
            this.YearPublished = yearPublished;
            this.ISBN = iSBN;
            this.NumberOfPages = numberOfPages;
        }

        //methods
        public override string ToString()
        {
            return "Title: " + Title +
                "\nPrice: " + Price + 
                "\nPublisher: " + Publisher +
                "\nYear Published: " + YearPublished +
                "\nISBN Number: " + ISBN +
                "\nNumber of Pages " + NumberOfPages;
        }
    }
}
