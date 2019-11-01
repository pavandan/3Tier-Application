using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace _3_tier
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DB_2Tier.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void display()
        {
            connection.Open();
            SqlCommand sqlcom = new SqlCommand();
            String query = "SELECT * FROM Student";
            sqlcom.CommandText = query;
            sqlcom.Connection = connection;
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            connection.Close();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into [Student] (Name, City) values ('" + txt_Name.Text + "','" + txt_City.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            display();
            txt_Name.Text = "";
            txt_City.Text = "";

        }

        protected void btn_Display_Click(object sender, EventArgs e)
        {
            display();
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "delete from [Student] where Name = '" + txt_Name.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            display();
            txt_Name.Text = "";
            txt_City.Text = "";
        }
    }
}