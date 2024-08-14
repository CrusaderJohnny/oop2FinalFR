using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2FINAL.Classes
{
    internal class Books
    {
        // getters and setters
        private string isbn;
        private string author;
        private string genre;
        private string title;
        private string avaibility;
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
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Avaibility
        {
            get { return avaibility; }
            set { avaibility = value; }
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
        public Books(string isbn, string author, string genre, string title, string available, string borrow_book, string return_book)
        {
            this.Isbn = isbn;
            this.Author = author;
            this.Genre = genre;
            this.Title = title;
            this.Avaibility = available;
            this.BorrowBook = borrow_book;
            this.ReturnBook = return_book;
        }
        public Books()   
        {

        }

        public override string ToString()
        {
            if(isbn == null)
            {
                return "";
            }
            return $"{Isbn},{Author},{Genre},{Title},{Avaibility},{BorrowBook},{ReturnBook}";
        }
        //null constructor no inputs
    }
}
