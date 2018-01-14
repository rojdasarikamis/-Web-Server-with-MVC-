using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HttpCookie cookie = Request.Cookies["UserDetailsForOurProject"];

        if (cookie != null)                            

        {
            if (Session["BookList"] != null)            
            {

                List<Book> books = (List<Book>)Session["BookList"];

                if (Request.QueryString["id"] != null)      
                {
                    bool included = false;
                    foreach (Book book in books)
                    {
                        if (book.BookID == int.Parse(Request.QueryString["id"]))
                        {
                            included = true;
                        }
                    }

                    if (included)                       
                    {
                        Book selected = books[int.Parse(Request.QueryString["id"])];

                        LabelAuthor.Text = "Author: " + selected.Author;
                        LabelPages.Text = "Pages: " + selected.PageNumber.ToString();
                        LabelPublisher.Text = "Publisher: " + selected.Publisher;
                        LabelTitle.Text = selected.Title;
                        Image1.ImageUrl = selected.ImageUrl;

                        if (thisBookAlreadyInCart())
                        {
                            Button1.Text = "Remove From Cart";
                        }
                        else
                        {
                            Button1.Text = "Add to Cart";
                        }
                       
                    }
                    else  
                    {
                        rightBook.Visible = false;
                        rightNull.Visible = true;
                        Label2.Text = "Invalid Book ID";
                    }
                }
                else  
                {
                    rightBook.Visible = false;
                    rightNull.Visible = true;
                    Label2.Text = "Please Specify a Book ID";
                }
            }
            else   
            {
                Response.Redirect("Default.aspx");
            }
        }
        else   
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {   

        List<Book> cart = (List<Book>)Session["cartList"];
        List<Book> books = (List<Book>)Session["BookList"];
        int id = int.Parse(Request.QueryString["id"]);

        if (thisBookAlreadyInCart())
        {
            if(cart != null)
            {
                for(int i = cart.Count - 1; i >= 0; i--)
                {
                    if(cart[i].BookID == id)
                    {
                        cart.RemoveAt(i);
                    }
                }
                Session["cartList"] = cart;
                Response.Redirect("BookInfo.aspx?id=" + Request.QueryString["id"]);
            }
        }
        else
        {
            cart.Add(books[id]);
            Session["cartList"] = cart;
            Response.Redirect("BookInfo.aspx?id=" + Request.QueryString["id"]);
        }
    }

    protected bool thisBookAlreadyInCart()
    {
        bool value = false;

        int id = int.Parse(Request.QueryString["id"]);
        List<Book> cart = (List<Book>)Session["cartList"];
        foreach(Book book in cart)
        {
            if(book.BookID == id)
            {
                value = true;
            }
        }
        return value;
    }


    protected void LinkButtonReturn2_Click(object sender, EventArgs e)
    {

    }

    protected void LinkButtonReturn_Click(object sender, EventArgs e)
    {

    }
}