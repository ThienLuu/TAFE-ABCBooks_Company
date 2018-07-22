using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCBooks_Company_Thien
{
    enum BookTypeEnum
    {
        Hardcover,
        Paperback
    }
    class Textbook : Book, IDelivery
    {
        //fields & props
        public BookTypeEnum BookType { get; set; }

        //constructors
        public Textbook(string title, double price, string publisher, int yearPublished, int iSBN, int numberOfPages) :
            base(title, price, publisher, yearPublished, iSBN, numberOfPages)
        {

        }
        public Textbook(string title, double price, string publisher, int yearPublished, int iSBN, int numberOfPages, BookTypeEnum bookType) :
            base(title, price, publisher, yearPublished, iSBN, numberOfPages)
        {
            this.BookType = bookType;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + "\nBook Type: " + BookType + "\n\n";
        }

        public double CalculateDeliveryFee()
        {
            if (BookType == BookTypeEnum.Hardcover)
            {
                return Price = 5;
            }
            else if (BookType == BookTypeEnum.Paperback)
            {
                return Price = 2;
            }
            return 0;
        }
    }
}
