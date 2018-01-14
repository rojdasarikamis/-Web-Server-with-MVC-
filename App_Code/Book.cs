using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary
/// </summary>
public class Book
{
    public int BookID;
    public string Title;
    public string Author;
    public string Publisher;
    public int PageNumber;
    public string ImageUrl;

    public Book(int BookID, string Title, string Author,
        string Publisher, int PageNumber, string ImageUrl)
    {
        this.BookID = BookID;
        this.Title = Title;
        this.Author = Author;
        this.Publisher = Publisher;
        this.PageNumber = PageNumber;
        this.ImageUrl = ImageUrl;
    }
}