using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["UserDetailsForOurProject"];
        if (cookie == null)
        {
            booksPanel.Visible = false;
            Label1.Text = "You are not logged in. <br /> <br /> Please log in ";

            LinkButton1.Text = "here";

            LinkButton1.PostBackUrl = "Login.aspx";
        }
        else
        {
            if(Session["BookList"] == null)
            {
                Book book1 = new Book(0, "ASP.NET 3.5 Unleashed", "Stephen Walther", "SAMS", 1920, "~/Images/1.jpg");
                Book book2 = new Book(1, " ASP.NET Evolution ", "Dan Kent", "SAMS", 384, "~/Images/2.jpg");
                Book book3 = new Book(2, "Mastering Web Development ", "John Paul Mueller", "SAMS", 848, "~/Images/3.jpg");
                Book book4 = new Book(3, "Beginning ASP.NET 2.0", "Chris Hart, John Kauffman,Dave Sussman, and Chris Ullman", "WROX", 792, "~/Images/4.jpg");
                Book book5 = new Book(4, "Beginning ASP.NET 3.5 in C# 2008 ", "Matthew MacDonald", "APRESS", 954, "~/Images/5.jpg");

                List<Book> books = new List<Book> { book1, book2, book3, book4, book5 };

                Session["BookList"] = books;
            }
            
            if(Session["cartList"] == null)
            {
                List<Book> booksInCart = new List<Book> {
                };

                Session["cartList"] = booksInCart;
            }
            
            Label1.Text = "Welcome " + cookie["Name"] + " " + cookie["LastName"];
            LinkButton1.PostBackUrl = "Cart.aspx";
            LinkButton1.Text = "<br /><br/>  Display Shopping Cart  <br />";
            Button1.Visible = true;

            List<LinkButton> links = new List<LinkButton> { }; 

            List<Book> addedBooks = (List<Book>)Session["BookList"];

            for (int i = 0; i < addedBooks.Count; i++)
            {
                LinkButton linkButton = new LinkButton();
                linkButton.Text = addedBooks[i].Title;

                linkButton.PostBackUrl = "BookInfo.aspx?id=" + addedBooks[i].BookID;
                links.Add(linkButton);
            }

            foreach(LinkButton lnkbtn in links)
            {
                Books.Controls.Add(new LiteralControl("<br /> <br />"));

                Books.Controls.Add(lnkbtn);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Visible = false;
        
        if (Response.Cookies["UserDetailsForOurProject"] != null)
        {
            Response.Cookies["UserDetailsForOurProject"].Expires = DateTime.Now.AddDays(-1);
        }
        if (Session["cartList"] != null)
        {
            Session["cartList"] = null;
        }
        Response.Redirect("Default.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}