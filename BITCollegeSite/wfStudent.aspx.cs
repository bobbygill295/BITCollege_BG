using System;
using System.Linq;
using System.Web.UI;
using BITCollege_BG;

public partial class wfStudent : Page
{
    BITCollege_BGContext db = new BITCollege_BGContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        //redirect to login page if user
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }

        if (!IsPostBack)
        {
            long inputNumber = 10010800;

            //check that user is a valid number
            com.dataaccess.www.NumberConversion externalRefrence = new com.dataaccess.www.NumberConversion();
            string returnValue = externalRefrence.NumberToWords((ulong)DateTime.Now.Ticks);
            lblResults.Visible = true;
            lblResults.Text = "Number of clock ticks today: " +returnValue;
            try
            {
                var student = db.Students.FirstOrDefault(x => x.StudentNumber == inputNumber);

                if (student != null)
                {
                    Session["student"] = student;


                    lblName.Text = student.FullName;

                    gvCourses.DataSource = student.Registration.Select(registration => registration.Course).ToList();

                    DataBind();
                }
            }
            catch
            {
                lblError.Visible = true;
                lblError.Text = "An error occured";
            }
        }
    }

    protected void gvCourses_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["courseNumber"] = gvCourses.SelectedRow.Cells[1].Text;
        Server.Transfer("wfDrop.aspx");
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Server.Transfer("wfRegister.aspx");
    }
}