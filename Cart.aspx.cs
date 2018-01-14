using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cartList"] != null)
        {
            
            List<Book> cartList = (List<Book>)Session["cartList"];
            int count = cartList.Count;
            

            if(count != 0)
            {

                List<Book> books = new List<Book>();
                if (Session["BookList"] != null)
                {
                    books = (List<Book>)Session["BookList"];
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }

                List<Panel> bookContainer = new List<Panel>();
                List<Panel> leftRight = new List<Panel>();
                List<Label> bookInfo = new List<Label>();
                List<Image> covers = new List<Image>();
                List<LinkButton> toBook = new List<LinkButton>();
                

                for (int i = 0; i < count; i++)
                {
                    bookContainer.Add(new Panel());
                    leftRight.Add(new Panel());
                    leftRight.Add(new Panel());
                    bookInfo.Add(new Label());
                    bookInfo.Add(new Label());
                    bookInfo.Add(new Label());
                    covers.Add(new Image());
                    toBook.Add(new LinkButton());
                    

                    leftRight[2 * i].Style.Add("float", "left");
                    leftRight[(2 * i) + 1].Style.Add("float", "left");

                    bookInfo[3 * i].Text = "Author: " + cartList[i].Author;                     
                    bookInfo[(3 * i) + 1].Text = "Publisher: " + cartList[i].Publisher;         
                    bookInfo[(3 * i) + 2].Text = "Pages: " + cartList[i].PageNumber.ToString(); 

                    covers[i].ImageUrl = cartList[i].ImageUrl;                                  
                    covers[i].Width = 200;

                    toBook[i].Text = "Go To Page";
                    toBook[i].PostBackUrl = "BookInfo.aspx?id=" + books[i].BookID.ToString();
                    
                    leftRight[2 * i].Controls.Add(covers[i]);


                    leftRight[(2 * i) + 1].Controls.Add(bookInfo[3 * i]);
                    leftRight[(2 * i) + 1].Controls.Add(new LiteralControl("<br /><br />"));
                    leftRight[(2 * i) + 1].Controls.Add(bookInfo[(3 * i) + 1]);
                    leftRight[(2 * i) + 1].Controls.Add(new LiteralControl("<br /><br />"));
                    leftRight[(2 * i) + 1].Controls.Add(bookInfo[(3 * i) + 2]);
                    leftRight[(2 * i) + 1].Controls.Add(new LiteralControl("<br /><br />"));
                    leftRight[(2 * i) + 1].Controls.Add(toBook[i]);
                    leftRight[(2 * i) + 1].Style.Add("margin-left", "50px");
                   

                    bookContainer[i].Controls.Add(leftRight[2 * i]);
                    bookContainer[i].Controls.Add(leftRight[(2 * i) + 1]);
                    bookContainer[i].Controls.Add(new LiteralControl(
                        "<br /><br /><br /><br /><br /><br /><br /><br /><br />" +
                        "<br /><br /><br /><br /><br /><br /><br /><br />"));

                    bookContainer[i].Height = covers[i].Height;
                    
                    cartContainer.Controls.Add(bookContainer[i]);
                }      
            }

            else
            {
                Label error = new Label();
                error.Text = "No such items found.";
                cartContainer.Controls.Add(error);
            }
        }

        else
        {
            Label error = new Label();
            error.Text = "No such items found.";
            cartContainer.Controls.Add(error);
        }
        cartContainer.Controls.Add(new LiteralControl("<br /><br />"));
        LinkButton lbtn = new LinkButton();

        lbtn.Text = "Return to HomePage";
        lbtn.PostBackUrl = "Default.aspx";
        cartContainer.Controls.Add(lbtn);
    }
}
