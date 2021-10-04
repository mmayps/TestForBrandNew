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
    public partial class addAccount : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadddl();
            }
        }

        void loadddl()
        {
            ddl.Items.Add(new ListItem("select...", "0"));
            ddl.Items.Add(new ListItem("Men", "1"));
            ddl.Items.Add(new ListItem("women", "2"));
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static object Save(object[] data)
        {
            ArrayList arr = new ArrayList();
            string msg = "";

            try
            {
                string ibn = Convert.ToString(data[0]);
                string firstname = Convert.ToString(data[1]);
                string lastname = Convert.ToString(data[2]);
                string phone = Convert.ToString(data[3]);
                int gender = Convert.ToInt32(data[4]); ;
                int age = Convert.ToInt32(data[5]);
                string adress = Convert.ToString(data[6]);
                decimal amount = Convert.ToDecimal(data[7]);
                int create = 1;
                DateTime createdate = DateTime.Today;

                string queryBuilder = "  INSERT INTO bnd_account "
                                      + "(iban,firatname ,lastname ,telephone,gender ,age ,address ,first_amount_deposit "
                                      + " ,creatdate ,createuser )"
                                      + "VALUES  ( @ibn, @firstname , @lastname , @phone , @gender , @age , @adress , @amount"
                                      + ", @createdate,@create)";


                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                
                SqlCommand command = new SqlCommand(queryBuilder, connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                command.Parameters.Add("@ibn", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@firstname", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@lastname", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@phone", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@gender", System.Data.SqlDbType.SmallInt);
                command.Parameters.Add("@age", System.Data.SqlDbType.Int);
                command.Parameters.Add("@adress", System.Data.SqlDbType.NText);
                command.Parameters.Add("@amount", System.Data.SqlDbType.Decimal);
                command.Parameters.Add("@createdate", System.Data.SqlDbType.DateTime);
                command.Parameters.Add("@create", System.Data.SqlDbType.BigInt);              
                //command.Parameters.Add("@update", System.Data.SqlDbType.DateTime);
                //command.Parameters.Add("@updateuser", System.Data.SqlDbType.BigInt);

                command.Parameters["@ibn"].Value = ibn;
                command.Parameters["@firstname"].Value = firstname;
                command.Parameters["@lastname"].Value = lastname;
                command.Parameters["@phone"].Value = phone;
                command.Parameters["@gender"].Value = gender;
                command.Parameters["@age"].Value = age;
                command.Parameters["@adress"].Value = adress;
                command.Parameters["@amount"].Value = amount;
                command.Parameters["@createdate"].Value = createdate;
                command.Parameters["@create"].Value = create;
                //command.Parameters["@update"].Value = null;
                //command.Parameters["@updateuser"].Value = 0;
                
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    msg = "Cpmpleted!!";

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
    }
}