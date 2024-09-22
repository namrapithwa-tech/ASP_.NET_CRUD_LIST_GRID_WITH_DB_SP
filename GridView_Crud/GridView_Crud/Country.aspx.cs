using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BCA_Project
{
	public partial class Country : System.Web.UI.Page
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
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection objConnection = new SqlConnection(connectionString))
            {
                objConnection.Open();

                using (SqlCommand objCommand = new SqlCommand("PR_Country_SelectAll", objConnection))
                {
                    objCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = objCommand.ExecuteReader();

                    // Bind the data reader to the GridView control
                    gvCountry.DataSource = dr;
                    gvCountry.DataBind();

                    dr.Close();
                }
            }
        }

        private void DeleteCountry(int countryId)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

			SqlConnection objConnection = new SqlConnection(connectionString);
			objConnection.Open();

			SqlCommand objCommand = new SqlCommand("PR_Country_DeleteByPK", objConnection);
			objCommand.CommandType = CommandType.StoredProcedure;
			objCommand.Parameters.AddWithValue("@CountryID", countryId);

			SqlDataReader dr = objCommand.ExecuteReader();

			// Redirect to refresh the list and remove the deleted item
			Response.Redirect("Country.aspx");
		}
	}
}