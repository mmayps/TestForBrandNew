using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace TestForBrandNew
{
    public partial class Form_deposit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadAccount();
                FillDdl();
            }
        }

        void loadAccount()
        {
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static object Save(object[] data)
        {
            ArrayList arr = new ArrayList();
            string msg = "";

            try
            {
                Int64? ibn = Convert.ToInt64(data[0]); //1; //Convert.ToInt64(data[0]);
                decimal totalamount = Convert.ToDecimal(data[1]);
                decimal deposit = Convert.ToDecimal(data[2]);
                decimal fee = Convert.ToDecimal(data[3]);
                string type = "D";                
                DateTime createdate = DateTime.Today;

                string queryBuilder = "  INSERT INTO bnd_deposit "
                                      + "([account_id] ,[total_amount] ,[deposit_amount] ,[fee]  ,[type] ,[deposit_date])"
                                      + "VALUES  ( @ibn, @totalamount , @deposit , @fee , @type ,@createdate)";


                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                SqlCommand command = new SqlCommand(queryBuilder, connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                command.Parameters.Add("@ibn", System.Data.SqlDbType.BigInt);
                command.Parameters.Add("@totalamount", System.Data.SqlDbType.Decimal);
                command.Parameters.Add("@deposit", System.Data.SqlDbType.Decimal);
                command.Parameters.Add("@fee", System.Data.SqlDbType.Decimal);
                command.Parameters.Add("@type", System.Data.SqlDbType.VarChar);              
                command.Parameters.Add("@createdate", System.Data.SqlDbType.DateTime);
             


                command.Parameters["@ibn"].Value = ibn;
                command.Parameters["@totalamount"].Value = totalamount;
                command.Parameters["@deposit"].Value = deposit;
                command.Parameters["@fee"].Value = fee;
                command.Parameters["@type"].Value = type;                
                command.Parameters["@createdate"].Value = createdate;

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    msg = "Completed!!";

                    arr.Add(new object[] 
                    { 
                        msg 
                    });
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }    

        private void FillDdl()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM  bnd_account; ");
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = connection;
            sda.SelectCommand = cmd;

            DataSet dt = new DataSet();
            sda.Fill(dt);

            ddl.Items.Add(new ListItem("Select...", "0"));
            foreach (DataRow row in dt.Tables[0].Rows)
            {
                ddl.Items.Add((new ListItem(row[1].ToString(), row[0].ToString())));
            }
        }
    }
}