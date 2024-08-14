using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2FINAL.Classes
{
    public class BooksManager
    {
        //internal list of Books to iterate through and manage queries
        internal List<Books> books = new List<Books>();




        //Load data to list from database
        internal void LoadBooks()
        {

        }


        //return list of found books from search
        internal List<Books> FindBooks(string searchID, string searchName, string searchAuthor, string searchCategory)
        {
            searchName = searchName.ToLower();
            searchAuthor = searchAuthor.ToLower();
            searchCategory = searchCategory.ToLower();
            List<Books> books = new List<Books>();
            foreach (Books book in books)
            {
                if(book.Isbn == searchID || searchID == "any")
                {
                    if(book.BookName == searchName || searchName == "any")
                    {
                        if(book.Author == searchAuthor || searchAuthor == "any")
                        {
                            books.Add(book);
                        }
                    }
                }
            }
            return books;
        }

        //returns individual book from search
        internal Books FindBooks(string isbn)
        {
            isbn = isbn.ToUpper();
            foreach (Books book in books)
            {
                if (book.Isbn == isbn)
                {
                    return book;
                }
            }
            return new Books();
        }


        //checkout book changing availability status
        internal void CheckoutBook(string bookID)
        {
            bool checkedOut = false;
            foreach (Books book in books)
            {
                if(book.Isbn == bookID)
                {
                    if (book.Available == true)
                    {
                        book.Available = false;
                        checkedOut = true;
                    }
                    else
                    {
                        throw new Exception("Books is not available for checkout");
                    }
                }
            }
            if (checkedOut)
            {
                SaveBooks();
            }
        }

        //check in book, changing availability status

        //save books info to database
        internal void SaveBooks()
        {

        }
    }
}
