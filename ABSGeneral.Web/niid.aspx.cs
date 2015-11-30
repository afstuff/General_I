using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSGeneral.Model;
using ABSGeneral.Repository;

namespace ABSGeneral.Web
{
    public partial class niid : System.Web.UI.Page
    {
        private readonly NiidModule niidModule = new NiidModule();
        //object gvMotorDetails = null;
        DateTime? startDate = null;
        DateTime? endDate = null;
        string sValue = string.Empty;
        int fOption = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check connection
                GetSession();

                int r = niidModule.NetworkStatus();
                if (r == 0)
                {
                    onlineLbl.Text = "Offline";
                    statusImg.ImageUrl = "~/Content/images/redlight.fw.png";
                    statusImg.Height = 60;
                }
                else
                {
                    onlineLbl.Text = "Online";
                    statusImg.ImageUrl = "~/Content/images/greenlight.fw.png";
                    statusImg.Height = 60;
                }

                GetAllVehicleDateails();

            }
        }


        private void GetSession()
        {
            if (Session["absuser"] == null)
            {
                Response.Redirect("LogOut.aspx");
            }
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void DoSearch()
        {
            fOption = filterDdw.SelectedIndex;

            if (txtStartDate.Text == "" && txtEndDate.Text == "")
            {
                startDate = Convert.ToDateTime("1/1/1700");
                endDate = Convert.ToDateTime("1/1/3000");
            }
            else
            {
                startDate = Convert.ToDateTime(CheckDate(txtStartDate.Text));
                endDate = Convert.ToDateTime(CheckDate(txtEndDate.Text));
            }

            sValue = txtSvalue.Text == "" ? "*" : txtSvalue.Text;

            IQueryable<NIID_MotorDetails_Online> searchMotor = niidModule.GetMotorDetailsOnlineByDate(startDate, endDate, fOption, sValue);
            var gvMotorDetails = from c in searchMotor orderby c.NIID_ProcessDate descending select c;

            var countUploaded = (from c in gvMotorDetails where c.NIID_Status == "P" select c).Count();
            var countPost = (from c in gvMotorDetails where c.NIID_Status == "A" select c).Count() + countUploaded;
            lblUploaded.Text = countUploaded.ToString();
            lblPosted.Text = countPost.ToString();


            GridView1.DataSource = gvMotorDetails;
            GridView1.DataBind();

        }


        public void DoUpdate(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cbx = GridView1.Rows[i].Cells[1].FindControl("chkSel") as CheckBox;

                HiddenField hd = GridView1.Rows[i].FindControl("Id_No") as HiddenField;
                //var rVal = GridView1.Rows[i].Cells[1].Text;
                var rVal = Convert.ToInt16(hd.Value.ToString());
                if (cbx.Enabled && !cbx.Checked)
                {
                    //update db
                    niidModule.Update(rVal);
                }

                if (cbx.Enabled && cbx.Checked)
                {
                    //update db
                    niidModule.Update1(rVal);
                }

            }
            DoSearch();

        }


        protected void DoSearch(object sender, EventArgs e)
        {
            fOption = filterDdw.SelectedIndex;

            if (txtStartDate.Text == "" && txtEndDate.Text == "")
            {
                startDate = Convert.ToDateTime("1/1/1700");
                endDate = Convert.ToDateTime("1/1/3000");
            }
            else
            {
                startDate = Convert.ToDateTime(CheckDate(txtStartDate.Text));
                endDate = Convert.ToDateTime(CheckDate(txtEndDate.Text));
            }

            sValue = txtSvalue.Text == "" ? "*" : txtSvalue.Text;

            IQueryable<NIID_MotorDetails_Online> searchMotor = niidModule.GetMotorDetailsOnlineByDate(startDate, endDate, fOption, sValue);
            var gvMotorDetails = from c in searchMotor orderby c.NIID_ProcessDate descending select c;

            //do counut
            var countUploaded = (from c in gvMotorDetails where c.NIID_Status == "P" select c).Count();
            var countPost = (from c in gvMotorDetails where c.NIID_Status == "A" select c).Count() + countUploaded;
            lblUploaded.Text = countUploaded.ToString();
            lblPosted.Text = countPost.ToString();


            GridView1.DataSource = gvMotorDetails;
            GridView1.DataBind();
        }

        public string CheckDate(string dDate)
        {

            DateTime? newDate = null;
            string[] dateString = dDate.Split(new Char[] { '/' });
            newDate = Convert.ToDateTime(dateString[2] + "-" + dateString[1] + "-" + dateString[0]);
            return newDate.ToString();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DoSearch();
        }

        protected void GetAllVehicleDateails()
        {
            IQueryable<NIID_MotorDetails_Online> AllMotor = niidModule.GetVehicleDateailsAll();

            //do counut
            var countUploaded = (from c in AllMotor where c.NIID_Status == "P" select c).Count();
            var countPost = (from c in AllMotor where c.NIID_Status == "A" select c).Count() + countUploaded;

            lblUploaded.Text = countUploaded.ToString();
            lblPosted.Text = countPost.ToString();

            var gvMotorDetails = from c in AllMotor orderby c.NIID_ProcessDate descending select c;

            GridView1.DataSource = gvMotorDetails;
            GridView1.DataBind();

        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cbx = GridView1.Rows[i].Cells[1].FindControl("chkSel") as CheckBox;
                var vr = GridView1.Rows[i].Cells[8].Text;
                if (vr == "P")
                {
                    cbx.Checked = true;
                    cbx.Enabled = false;
                }

                if (vr == "A")
                {
                    cbx.Checked = true;
                    //cbx.Enabled = false;
                }

            }
        }



    }
}