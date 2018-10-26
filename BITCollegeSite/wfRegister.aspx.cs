using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BITCollege_BG;
using BITCollege_BG.Models;
using CollegeRegistration;
using Utility;

public partial class wfRegister : System.Web.UI.Page
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
            try
            {
                var student = Session["student"] as Student;

                lblName.Text = student.FullName;

                var courses = db.Courses.Where(x => x.ProgramId == student.ProgramId).ToList();
                ddlCourses.DataSource = courses;
                ddlCourses.DataTextField = "Title";
                ddlCourses.DataValueField = "CourseId";
                DataBind();

            }
            catch (Exception exception)
            {
                lblError.Text = "An error occured";
            }
            
        }
    }

    protected void lnkRegister_Click(object sender, EventArgs e)
    {
        var student = Session["student"] as Student;
        var courseId = int.Parse(ddlCourses.SelectedValue);
        var notes = txtNotes.Text;
        var studentId = student.StudentID;
        var result = courseService.registerCourse(studentId, courseId, notes);

        if (result < 0)
        {
            lblError.Text = BusinessRules.registerError(result);
            lblError.Visible = true;
        }
        else 
        {
            Server.Transfer("wfStudent.aspx");
        }
    }

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        Server.Transfer("wfStudent.aspx");
    }
}