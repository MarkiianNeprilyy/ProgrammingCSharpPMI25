using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

[Serializable]
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book() { }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Book> books = DeserializeBooks();
        SortBooksByYearUsingLINQ(books);
        SerializeBooks(books);
        WriteBooksToTextFile(books);
    }

    static List<Book> DeserializeBooks()
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<Book>));
        using (FileStream stream = new FileStream("input.xml", FileMode.Open))
        {
            List<Book> desBooks = deserializer.Deserialize(stream) as List<Book>;
            return desBooks;
        }
    }

    static void SerializeBooks(List<Book> books)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
        using (FileStream stream = new FileStream("sorted_books.xml", FileMode.Create))
        {
            serializer.Serialize(stream, books);
        }
    }

    static void SortBooksByYearUsingLINQ(List<Book> books)
    {
        books = books.OrderBy(book => book.Year).ToList();
    }

    static void WriteBooksToTextFile(List<Book> books)
    {
        using (StreamWriter writer = new StreamWriter("books.txt"))
        {
            foreach (Book book in books)
            {
                writer.WriteLine($"Title: {book.Title} Author: {book.Author} Year: {book.Year}");
            }
        }
    }
}
