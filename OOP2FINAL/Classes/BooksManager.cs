using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace OOP2FINAL.Classes
{
    public class BooksManager
    {
        //internal list of Books to iterate through and manage queries
        internal List<Books> books = new List<Books>();




        //Load data to list from database
        internal void LoadBooks()
        {
            books.Clear();
            string csvFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../..", "resources", "data", "books.csv");
            try
            {
                using(var sr = new StreamReader(csvFile))
                using(var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        books.Add(new Books(csv.GetField(0), csv.GetField(1), csv.GetField(2), csv.GetField(3), bool.Parse(csv.GetField(4))));
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data: {ex.Message}");
            }
        }


        //return list of found books from search
        internal List<Books> FindBooks(string searchID, string searchName, string searchAuthor, string searchCategory)
        {
            searchName = searchName.ToLower();
            searchAuthor = searchAuthor.ToLower();
            searchCategory = searchCategory.ToLower();
            List<Books> bk = new List<Books>();
            foreach (Books book in books)
            {
                if(book.Isbn == searchID || searchID == "Any")
                {
                    if (book.BookName == searchName.ToLower() || searchName == "any")
                    {
                        if(book.Author == searchAuthor.ToLower() || searchAuthor == "any")
                        {
                            if(book.Genre == searchCategory.ToLower() || searchCategory == "any")
                            {
                                bk.Add(book);
                            } 
                        }
                    }
                }
            }
            return bk;
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
                }
            }
            if (checkedOut)
            {
                SaveBooks();
            }
        }

        //check in book, changing availability status
        internal void CheckinBook(string bookID)
        {
            bool checkedIn = false;
            foreach (Books book in books)
            {
                if (book.Isbn == bookID)
                {
                    if (!book.Available)
                    {
                        book.Available = true;
                        checkedIn = true;
                    }
                    else
                    {
                        throw new Exception("Book is already checked in");
                    }
                }
            }
            if(checkedIn)
            {
                SaveBooks();
            }
        }

        //save books info to database
        internal void SaveBooks()
        {
            try
            {
                List<string> savedBooks = new List<string>();
                string csvFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../..", "resources", "data", "books.csv");
                foreach (Books book in books)
                {
                    string[] items = [book.Isbn, book.BookName, book.Author, book.Genre, book.Available.ToString()];
                    savedBooks.Add(string.Join(",", items));
                }
                if(savedBooks.Count() > 0)
                {
                    File.WriteAllLines(csvFile, savedBooks);
                    LoadBooks();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data {ex.Message}");
                return;
            }
        }
    }
}
