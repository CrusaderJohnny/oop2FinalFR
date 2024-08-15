using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2FINAL.Classes
{
    public class Books
    {
        // getters and setters
        private string isbn;
        private string author;
        private string genre;
        private string bookName;
        private bool available;
        private string borrow_book;
        private string return_book;


        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
        public bool Available
        {
            get { return available; }
            set { available = value; }
        }
        public string BorrowBook
        {
            get { return borrow_book; }
            set { borrow_book = value; }
        }
        public string ReturnBook
        {
            get { return return_book; }
            set { return_book = value; }
        }
        //constructor with inputs
        public Books(string isbn, string title, string author, string genre, bool available)
        {
            this.Isbn = isbn;
            this.Author = author;
            this.Genre = genre;
            this.BookName = title;
            this.Available = available;
        }

        //null constructor no inputs
        public Books()   
        {

        }

        public override string ToString()
        {
            if(isbn == null)
            {
                return "";
            }
            return $"{Isbn},{Author},{Genre},{BookName},{Available}";
        }
     
    }
}
