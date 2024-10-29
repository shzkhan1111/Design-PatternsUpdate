using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    internal class IteratorDesignPattern
    {
    }

    public class Book
    {
        public string Title { get; set; }
        public Book(string title)
        {
            Title = title;
        }
    }

    public class BookCollection
    {
        private List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            _books.Add(book);
        }
        public IEnumerable<Book> GetForwardEnumerator()
        {
            return new ForwardIterator(_books);
        }

        public IEnumerable<Book> GetReverseEnumerator()
        {
            return new ReverseIterator(_books);
        }
    }

    public class ForwardIterator : IEnumerable<Book>
    {

        private readonly List<Book> _books;

        public ForwardIterator(List<Book> books)
        {
            _books = books;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in _books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ReverseIterator : IEnumerable<Book>
    {
        private readonly List<Book> _books;

        public ReverseIterator(List<Book> books)
        {
            _books = books;
        }


        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = _books.Count - 1; i >= 0; i--)
            {
                yield return _books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MainInterator
    {
        public void ExecMain()
        {

            var library = new BookCollection();
            library.AddBook(new Book("C# Basics"));
            library.AddBook(new Book("Advanced C# Patterns"));
            library.AddBook(new Book("Mastering .NET"));

            Console.WriteLine("Forward Iteration:");
            foreach (var book in library.GetForwardEnumerator())
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine("\nReverse Iteration:");
            foreach (var book in library.GetReverseEnumerator())
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
