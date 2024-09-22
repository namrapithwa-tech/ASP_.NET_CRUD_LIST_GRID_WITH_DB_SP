using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridVIew_Crud
{
    public partial class CountryAddEditWithoutSP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CountryID"] != null)
                {
                    lblTitle.Text = "Edit Country";
                    GetCountryById(Convert.ToInt32(Request.QueryString["CountryID"]));
                }
            }
        }
        // Save country
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();

                if (Request.QueryString["CountryID"] != null)
                {
                    int countryId = Convert.ToInt32(Request.QueryString["CountryID"]);
                    lblTitle.Text = countryId.ToString();
                    try
                    {
                        // Direct SQL query to update country by ID
                        string query = "UPDATE LOC_Country SET CountryName = @CountryName, CountryCode = @CountryCode WHERE CountryID = @CountryID";

                        using (SqlCommand objCommand = new SqlCommand(query, objConnection))
                        {
                            objCommand.Parameters.AddWithValue("@CountryID", countryId);
                            objCommand.Parameters.AddWithValue("@CountryName", txtCountryName.Text);
                            objCommand.Parameters.AddWithValue("@CountryCode", txtCountryCode.Text);
                            objCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    // Direct SQL query to insert a new country
                    string query = "INSERT INTO LOC_Country (CountryName, CountryCode) VALUES (@CountryName, @CountryCode)";

                    using (SqlCommand objCommand = new SqlCommand(query, objConnection))
                    {
                        objCommand.Parameters.AddWithValue("@CountryName", txtCountryName.Text);
                        objCommand.Parameters.AddWithValue("@CountryCode", txtCountryCode.Text);
                        objCommand.ExecuteNonQuery();
                    }
                }
            }

            Response.Redirect("CountryWithoutSP.aspx");
        }
        // Get country by ID
        public void GetCountryById(int countryId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();

                // Direct SQL query to get a country by ID
                string query = "SELECT CountryID, CountryName, CountryCode FROM LOC_Country WHERE CountryID = @CountryID";

                using (SqlCommand objCommand = new SqlCommand(query, objConnection))
                {
                    objCommand.Parameters.AddWithValue("@CountryID", countryId);

                    SqlDataReader dr = objCommand.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            txtCountryName.Text = row["CountryName"].ToString();
                            txtCountryCode.Text = row["CountryCode"].ToString();
                        }
                    }
                }
            }
        }
    }
}