using System;
using System.Linq;
using System.Web.UI;
using BITCollege_BG;
using BITCollege_BG.Models;

public partial class wfDrop : Page
{
    private readonly BITCollege_BGContext db = new BITCollege_BGContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        ////redirect to login page if user
        //if (!User.Identity.IsAuthenticated) Response.Redirect("~/Account/Login.aspx");

        long inputNumber;

        var courseNumber = Session["courseNumber"].ToString();
        var student = Session["student"] as Student;

        var registrationInfo = db.Registrations.Where(x => x.Course.CourseNumber == courseNumber && x.Student.StudentID == student.StudentID).ToList();

        dvCourseInfo.DataSource = registrationInfo;
        DataBind();
    }

    private void DisplayError(string message = "An error occured")
    {
        lblError.Visible = true;
        lblError.Text = message;
    }

    protected void lnkDrop_Click(object sender, EventArgs e)
    {

    }

    protected void dvCourseInfo_PageIndexChanging(object sender, System.Web.UI.WebControls.DetailsViewPageEventArgs e)
    {

    }

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        Server.Transfer("wfStudent.aspx");
    }
}