using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridVIew_Crud
{
    public partial class CountryWithoutSP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getAllCountry();

            if (Request.QueryString["CountryID"] != null)
            {
                DeleteCountry(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
        }
        public void getAllCountry()
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();

                // Direct SQL query to get all countries
                string query = "SELECT CountryID, CountryName, CountryCode FROM LOC_Country";

                using (SqlCommand objCommand = new SqlCommand(query, objConnection))
                {
                    SqlDataReader dr = objCommand.ExecuteReader();

                    // Bind the data reader to the ListView control
                    gvCountry.DataSource = dr;
                    gvCountry.DataBind();

                    dr.Close();
                }
            }
        }
        private void DeleteCountry(int countryId)
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();

                string query = "DELETE FROM LOC_Country WHERE CountryID = @CountryID";

                using (SqlCommand objCommand = new SqlCommand(query, objConnection))
                {
                    objCommand.Parameters.AddWithValue("@CountryID", countryId);
                    objCommand.ExecuteNonQuery();
                }

                // Redirect to refresh the list and remove the deleted item
                Response.Redirect("CountryWithoutSP.aspx");
            }
        }
    }
}