using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCBooks_Company_Thien
{
    public class EBook : Book
    {
        //fields & props
        public int FileSize { get; set; }

        //constructors
        public EBook(string title, double price, string publisher, int yearPublished, int iSBN, int numberOfPages) :
            base(title, price, publisher, yearPublished, iSBN, numberOfPages)
        {

        }
        public EBook(string title, double price, string publisher, int yearPublished, int iSBN, int numberOfPages, int fileSize) :
            base(title, price, publisher, yearPublished, iSBN, numberOfPages)
        {
            this.FileSize = fileSize;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + "\nFile Size: " + FileSize + "\n\n";
        }
    }
}
