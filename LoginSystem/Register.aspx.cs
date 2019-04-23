using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginSystem {
    public partial class Register : System.Web.UI.Page {
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-2ST9BDB;Initial Catalog=peemasit1DB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnRegister_Click(object sender, EventArgs e) {
            if (txtUsername.Text == "" || txtPassword.Text == "") {
                Response.Write("Please enter username and password");
            } else {
                string query = "insert into LoginData values (@username, @password)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                sqlCommand.Parameters.AddWithValue("@password", txtPassword.Text);
                sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                Response.Redirect("Login.aspx");
            }
        }
    }
}