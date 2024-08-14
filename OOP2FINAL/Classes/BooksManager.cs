using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2FINAL.Classes
{
    public class BooksManager
    {
        internal List<Books>books=new List<Books>();

        //internal list of Books to iterate through and manage queries

        //Load data to list from database
               //idk this shit !!!!!!!!!!!!!!!!!!!!!!!!!!!!1


        //return list of found books from search
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

        //returns individual book from search

        //checkout book changing availability status

        //check in book, changing availability status

        //save books info to database
    }
}
