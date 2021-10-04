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
    public partial class Transfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillAcc();
                FillddlTransfer();
            }
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static object Save(object[] data)
        {
            ArrayList arr = new ArrayList();
            string msg = "";

            try
            {
                Int64? accibn = Convert.ToInt64(data[0]); //1; //Convert.ToInt64(data[0]);
                Int64? transibn = Convert.ToInt64(data[1]); //1; //Convert.ToInt64(data[0]);
                decimal totalamount = Convert.ToDecimal(data[2]);                                           
                DateTime createdate = DateTime.Today;

                string queryBuilder = "  INSERT INTO [bnd_transfer_transaction] "
                                      + "([account_owner_id]  ,[transfer_to_acc_id] ,[transfer_amount] ,[transfer_date] )"
                                      + "VALUES  ( @accibn, @transibn , @totalamount  ,@createdate )";


                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                SqlCommand command = new SqlCommand(queryBuilder, connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                command.Parameters.Add("@accibn", System.Data.SqlDbType.BigInt);
                command.Parameters.Add("@transibn", System.Data.SqlDbType.BigInt);
                command.Parameters.Add("@totalamount", System.Data.SqlDbType.Decimal);             
                command.Parameters.Add("@createdate", System.Data.SqlDbType.DateTime);
               
                command.Parameters["@accibn"].Value = accibn;
                command.Parameters["@transibn"].Value = transibn;
                command.Parameters["@totalamount"].Value = totalamount;
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

        void fillAcc()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM  bnd_account; ");
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = connection;
            sda.SelectCommand = cmd;

            DataSet dt = new DataSet();
            sda.Fill(dt);

            ddlAcc.Items.Add(new ListItem("Select...", "0"));
            foreach (DataRow row in dt.Tables[0].Rows)
            {
                ddlAcc.Items.Add((new ListItem(row[1].ToString(), row[0].ToString())));
            }
        }

        void FillddlTransfer()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM  bnd_account; ");
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = connection;
            sda.SelectCommand = cmd;

            DataSet dt = new DataSet();
            sda.Fill(dt);

            ddlTansfer.Items.Add(new ListItem("Select...", "0"));
            foreach (DataRow row in dt.Tables[0].Rows)
            {
                ddlTansfer.Items.Add((new ListItem(row[1].ToString(), row[0].ToString())));
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void ddlAcc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}