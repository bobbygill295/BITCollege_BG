using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using BITCollege_BG;
using BITCollege_BG.Models;
using CollegeRegistrationClient = CollegeRegistration.CollegeRegistrationClient;

public partial class wfDrop : Page
{
    private readonly BITCollege_BGContext db = new BITCollege_BGContext();
    private readonly CollegeRegistrationClient courseService = new CollegeRegistrationClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        ////redirect to login page if user
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        if (Session["student"] == null)
        {
            Server.Transfer("wfStudent.aspx");
        }

        if (!IsPostBack)
        {
            PopulateDetailsView();
        }
    }


    protected void PopulateDetailsView()
    {
        try
        {
        
            var courseNum = Session["courseNumber"].ToString();
            var sessionStudent = Session["student"] as Student;


            
            var studentId = sessionStudent.StudentID;

            // get records for registration from course and studentID 
            
            List<Registration> registration =
                db.Registrations.Where(r => r.Course.CourseNumber == courseNum && r.StudentId == studentId).ToList();

            // bind 
            dvCourseInfo.DataSource = registration;
            DataBind();

            // if the grade is null then able to drop course
            if (dvCourseInfo.Rows[4].Cells[1].Text == "&nbsp")
            {
                lnkDrop.Enabled = false;
            }
            else
            {
                lnkDrop.Enabled = true;
            }

        }
        catch
        {
            lblError.Visible = true;
            lblError.Text = "An error occured";
        }
    }
    private void DisplayError(string message = "An error occured")
    {
        lblError.Visible = true;
        lblError.Text = message;
    }

    protected void lnkDrop_Click(object sender, EventArgs e)
    {
        try
        {
            int courseId = int.Parse(dvCourseInfo.Rows[0].Cells[1].Text);

            bool isDropped = courseService.dropCourse(courseId);

            Server.Transfer("wfStudent.aspx");
        }
        catch (Exception exception)
        {
            lblError.Text = "An error occured";
        }

        
    }

    protected void dvCourseInfo_PageIndexChanging(object sender, System.Web.UI.WebControls.DetailsViewPageEventArgs e)
    {

    }

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        Server.Transfer("wfStudent.aspx");
    }

    protected void dvCourseInfo_SelectedIndexChanging(object sender, EventArgs e)
    {
        PopulateDetailsView();
    }
}