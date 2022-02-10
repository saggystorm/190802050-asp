using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString);   

      protected void Page_Load(object sender, EventArgs e)
       {
             //DeleteCommand="DELETE FROM [users] WHERE [id] = @id" 
            //InsertCommand="INSERT INTO [users] ([fullname], [email], [password]) VALUES (@fullname, @email, @password)" 
           //SelectCommand="SELECT [id], [fullname], [email], [password] FROM [users]" 
          //UpdateCommand="UPDATE [users] SET [fullname] = @fullname, [email] = @email, [password] = @password WHERE [id] = @id">
       }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SELECT [id], [fullname], [email], [password]FROM [users]  WHERE [email] = @email AND [password] = @password", con);
        cmd.Parameters.AddWithValue("@email", TextBox1.Text);
        cmd.Parameters.AddWithValue("@password", TextBox1.Text);
        con.Open();
        int s = (int)cmd.ExecuteScalar();
        if (s == 1)
        {
            Session["email"] = TextBox1.Text;
            TextBox1.Text = string.Empty;
            TextBox1.Text = string.Empty;
            Response.Redirect("~/Dashboard.aspx");

        }
        else
        {
            TextBox1.Text = string.Empty;
            TextBox1.Text = string.Empty;
            Literal1.Text = "Email and password invalid!";
        }
        con.Close();
    }
}