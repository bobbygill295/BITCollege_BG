using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BITCollege_BG.Migrations;

namespace BITCollege_BG.Models
{
    public abstract class GPAState
    {
        protected static BITCollege_BGContext context = new BITCollege_BGContext();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GPAStateId { get; set; }

        [Required]
        [Display(Name = "Lower\nLimit")]
        public double LowerLimit { get; set; }

        [Required]
        [Display(Name = "Uppper\nLimit")]
        public double UpperLimit { get; set; }

        [Required]
        [Display(Name = "Tuition\nRate\nFactor")]
        public double TuitionRateFactor { get; set; }

        [Display(Name = "GPAState")]
        public string Description
        {
            get { return Utility.BusinessRules.RemoveTrailer(GetType().Name, "State"); }
        }

        public virtual double tuitionRateAdjustment(Student student)
        {
            return 0;
        }

        public virtual void stateChangeCheck(Student student)
        {
        }


        //navigational properties
        public virtual ICollection<Student> Student { get; set; }

    }

    public class ProbationState : GPAState
    {
        private static ProbationState probationState;

        private ProbationState()
        {
            LowerLimit = 1.00;
            UpperLimit = 2.00;
            TuitionRateFactor = 1.075;
        }

        /// <summary>
        /// Returns the state of gpa based on its limits
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// gets an instance of RegularState and populates it if it is null
        /// </summary>
        /// <returns></returns>
        public static ProbationState GetInstance()
        {
            if (probationState == null)
            {

                if (context.ProbationStates.SingleOrDefault() != null)
                {
                    probationState = context.ProbationStates.SingleOrDefault();
                }
                else
                {
                    context.ProbationStates.Add(new ProbationState());
                    context.SaveChanges();
                }
            }

            return probationState;
        }

        public double tuitionRateAdjustment(Student student)
        {
            double coursesPassed = 0;

            foreach (Registration reg in student.Registration)
            {
                if (!(reg.Grade == null))
                {
                    coursesPassed++;
                }
            }

            if (coursesPassed >= 5)
            {
                TuitionRateFactor = 1.035;
            }
            else
            {
                TuitionRateFactor = 1.075;
            }

            return TuitionRateFactor;
        }

        public override void stateChangeCheck(Student student)
        {
            if (student.GradePointAverage > UpperLimit)
            {
                student.GPAStateId = RegularState.getInstance().GPAStateId;
                student.changeState();
            }
            else if (student.GradePointAverage < LowerLimit)
            {
                student.GPAStateId = SuspendedState.getInstance().GPAStateId;
                student.changeState();
            }
          
        }


    }

    public class HonoursState : GPAState
    {
        private static HonoursState honoursState;

        private HonoursState()
        {
            LowerLimit = 3.7;
            UpperLimit = 4.5;
            TuitionRateFactor = 0.9;
        }

        /// <summary>
        /// gets an instance of Honourstate and populates it if it is null
        /// </summary>
        /// <returns></returns>
        public static HonoursState getInstance()
        {
            if (honoursState == null)
            {

                if (context.HonoursStates.SingleOrDefault() != null)
                {
                    honoursState = context.HonoursStates.SingleOrDefault();
                }
                else
                {
                    context.HonoursStates.Add(new HonoursState());
                    context.SaveChanges();
                }
            }

            return honoursState;
        }

        public double tuitionRateAdjustment(Student student)
        {
            double counter = 0;

            foreach (Registration course in student.Registration)
            {
                if (!(course.Grade == null))
                {
                    counter++;
                }
            }

            if (counter >= 5)
            {
                TuitionRateFactor = 0.75;
            }
            else
            {
                TuitionRateFactor = 0.9;
            }

            if (student.GradePointAverage > 4.25)
            {
                TuitionRateFactor -= .02;
            }



            return TuitionRateFactor;
        }

        public override void stateChangeCheck(Student student)
        {
            if (student.GradePointAverage < LowerLimit)
            {
                student.GPAStateId = RegularState.getInstance().GPAStateId;
                student.changeState();
            }
        }


    }

    public class SuspendedState : GPAState
    {
        private static SuspendedState suspendedState;

        private SuspendedState()
        {
            LowerLimit = 0;
            UpperLimit = 1.00;
            TuitionRateFactor = 1.1;
        }

        /// <summary>
        /// gets an instance of RegularState and populates it if it is null
        /// </summary>
        /// <returns></returns>
        public static SuspendedState getInstance()
        {
            if (suspendedState == null)
            {

                if (context.SuspendedStates.SingleOrDefault() != null)
                {
                    suspendedState = context.SuspendedStates.SingleOrDefault();
                }
                else
                {
                    context.SuspendedStates.Add(new SuspendedState());
                    context.SaveChanges();
                }
            }

            return suspendedState;
        }

        public double tuitionRateAdjustment(Student student)
        {
            if (student.GradePointAverage < 0.50)
            {
                TuitionRateFactor = 1.15;
            }
            else if ((student.GradePointAverage >= 0.50) && (student.GradePointAverage < 0.75))
            {
                TuitionRateFactor = 1.12;
            }
            else
            {
                TuitionRateFactor = 1.10;
            }

            return TuitionRateFactor;

        }

        public override void stateChangeCheck(Student student)
        {
            //int s = this.GPAStateId;

            //if (student.GradePointAverage > UpperLimit)
            //{
            //    //set the student state to Probation
            //    GPAStateId +=1;
            //}

            if (student.GradePointAverage > UpperLimit)
            {
                //set the student state to Probation
                student.GPAStateId = ProbationState.GetInstance().GPAStateId;
                student.changeState();
            }
        }
    }

    public class RegularState : GPAState
    {
        private static RegularState regularState;

        private RegularState()
        {
            LowerLimit = 2;
            UpperLimit = 3.70;
            TuitionRateFactor = 1;

        }

        /// <summary>
        /// gets an instance of RegularState and populates it if it is null
        /// </summary>
        /// <returns></returns>
        public static RegularState getInstance()
        {
            if (regularState == null)
            {

                if (context.RegularStates.SingleOrDefault() != null)
                {
                    regularState = context.RegularStates.SingleOrDefault();
                }
                else
                {
                    context.RegularStates.Add(new RegularState());
                    context.SaveChanges();
                }
            }

            return regularState;
        }


        public double tuitionRateAdjustment(Student student)
        {
            return TuitionRateFactor;
        }

        public override void stateChangeCheck(Student student)
        {
            if (student.GradePointAverage > UpperLimit)
            {
                student.GPAStateId = HonoursState.getInstance().GPAStateId;
                student.changeState();
            }
            else if (student.GradePointAverage < LowerLimit)
            {
                student.GPAStateId = ProbationState.GetInstance().GPAStateId;
                student.changeState();
            }
        }


    }


    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Required] [ForeignKey("GPAState")] public int GPAStateId { get; set; }

        [ForeignKey("Program")] public int? ProgramId { get; set; }

        //[Range(10000000, 99999999)]
        [Display(Name = "Student\nNumber")]
        public long StudentNumber { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string Address { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [RegularExpression("^(?:AB|BC|MB|N[BLTSU]|ON|PE|QC|SK|YT)*$", ErrorMessage =
            "Please Enter a Valid Canadian Province")]
        public string Province { get; set; }

        [Required]
        [RegularExpression(
            "^(?=[^DdFfIiOoQqUu\\d\\s])[A-Za-z]\\d(?=[^DdFfIiOoQqUu\\d\\s])[A-Za-z]\\s{0,1}\\d(?=[^DdFfIiOoQqUu\\d\\s])[A-Za-z]\\d$")]
        [Display(Name = "Postal\nCode")]
        public string PostalCode { get; set; }

        public DateTime DateCreated { get; set; }

        [Display(Name = "Grade Point Average")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double? GradePointAverage { get; set; }

        [Display(Name = "Outstanding Fees")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double OutstandingFees { get; set; }

        [Display(Name = "Program")] public string ProgramAcronym { get; set; }

        public string Notes { get; set; }

        //returns the client's full name
        [Display(Name = "Name")]
        public string FullName
        {
            //concatenates the first and last name into a full name
            get { return FirstName + " " + LastName; }

        }

        //returns the client's full address
        [Display(Name = "Address")]
        public string FullAddress
        {
            //concatenates the address
            get { return Address + " " + City + " " + Province + " " + PostalCode; }
        }


        public void setNextStudentNumber()
        {
            this.StudentNumber = (long) StoredProcedures.NextNumber("NextStudentNumbers");
        }

        public void changeState()
        {
            //BITCollege_BGContext db = new BITCollege_BGContext();
            //int startState;
            //GPAState currentState = db.GPAStates.Find(this.GPAStateId);

            //do
            //{
            //    currentState.stateChangeCheck(this);
            //} while (currentState != startState);


            BITCollege_BGContext db = new BITCollege_BGContext();
            int initialState;
            //int finalState;
            
            
               
                initialState = this.GPAStateId;

                //this.GPAState.stateChangeCheck(this);

     
                db.GPAStates.Find(this.GPAStateId).stateChangeCheck(this);

      
                //finalState = db.GPAStates.Find(this.GPAStateId).GPAStateId

        }
        //navigational properties

        public virtual GPAState GPAState { get; set; }

        public virtual Program Program { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }

        public virtual ICollection<StudentCard> StudentCard { get; set; }



    }

    public class Program
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramID { get; set; }

        [Display(Name = "Program")] public string ProgramAcronym { get; set; }
        [Display(Name = "Program Name")] public string Description { get; set; }

        //navigational properties

        public virtual ICollection<Student> Student { get; set; }

        public virtual ICollection<Course> Course { get; set; }


    }

    public class Registration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }

        public long RegistrationNumber { get; set; }

        [Required] [ForeignKey("Student")] public int StudentId { get; set; }

        [Required] [ForeignKey("Course")] public int CourseId { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Range(0, 100)] public double? Grade { get; set; }

        public string Notes { get; set; }

        public Registration()
        {
           
        }

        public void setNextRegistrationNumber()
        {
            this.RegistrationNumber = (long) StoredProcedures.NextNumber("NextRegistrationNumbers");
        }

        //navigational properties
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }

    public abstract class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [ForeignKey("Program")] public int? ProgramId { get; set; }

        [Display(Name = "Course Number")] public String CourseNumber { get; set; }
        [Required] public string Title { get; set; }

        [Required]
        [Display(Name = "Credit Hours")]
        public double CreditHours { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Tuition Amount")]
        public double TuitionAmount { get; set; }

        public string CourseType
        {
            get { return Utility.BusinessRules.RemoveTrailer(GetType().Name, "Course"); }
        }

        public string Notes { get; set; }

        public void setNextCourseNumber()
        {
            throw new NotImplementedException();
        }

        //navigational properties
        public virtual Program Program { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }

    }

    public class GradedCourse : Course
    {
        [Required]
        [DisplayFormat(DataFormatString = "{0:00.00}%")]
        [Display(Name = "Assignment Weight")]
        public double AssignmnetWeight { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:00.00}%")]
        [Display(Name = "Midterm Weight")]
        public double MidtermWeight { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:00.00}%")]
        [Display(Name = "Final Weight")]
        public double FinalWeight { get; set; }

        public void setNextCourseNumber()
        {
            this.CourseNumber = "G-" + StoredProcedures.NextNumber("NextGradedCourses").ToString();
        }
    }

    public class AuditCourse : Course
    {
        public void setNextCourseNumber()
        {
            this.CourseNumber = "A-" + StoredProcedures.NextNumber("NextAuditCourses").ToString();
        }
    }

    public class MasteryCourse : Course
    {
        [Required]
        [Display(Name = "Maximum Attempts")]
        public int MaximumAttempts { get; set; }

        public void setNextCourseNumber()
        {
            this.CourseNumber = "M-" + StoredProcedures.NextNumber("NextMasteryCourses").ToString();
        }
    }

    public class StudentCard
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentCardId { get; set; }

        public long CardNumber { get; set; }

        [Required] [ForeignKey("Student")] public int StudentId { get; set; }


        //navigational properties
        public virtual Student Student { get; set; }



    }

    public class NextStudentNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextStudentNumberId { get; set; }

        public long NextAvailableNumber { get; set; }

        private static NextStudentNumber nextStudentNumber;

        private NextStudentNumber()
        {
            NextAvailableNumber = 20000000;
        }

        public static NextStudentNumber GetInstance()
        {
            if (nextStudentNumber == null)
            {
                BITCollege_BGContext context = new BITCollege_BGContext();
                if (context.NextStudentNumbers.SingleOrDefault() != null)
                {
                    nextStudentNumber = context.NextStudentNumbers.SingleOrDefault();
                }
                else
                {
                    nextStudentNumber = context.NextStudentNumbers.Add(new NextStudentNumber());
                    context.SaveChanges();
                }
            }

            return nextStudentNumber;
        }
    }

    public class NextRegistrationNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextRegistrationNumberId { get; set; }

        public long NextAvailableNumber { get; set; }

        private static NextRegistrationNumber nextRegistrationNumber;

        private NextRegistrationNumber()
        {
            NextAvailableNumber = 700;
        }

        public static NextRegistrationNumber GetInstance()
        {
            if (nextRegistrationNumber == null)
            {
                BITCollege_BGContext context = new BITCollege_BGContext();
                if (context.NextRegistrationNumbers.SingleOrDefault() != null)
                {
                    nextRegistrationNumber = context.NextRegistrationNumbers.SingleOrDefault();
                }
                else
                {
                    nextRegistrationNumber = context.NextRegistrationNumbers.Add(new NextRegistrationNumber());
                    context.SaveChanges();
                }
            }

            return nextRegistrationNumber;
        }
    }

    public class NextGradedCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextGradedCourseId { get; set; }

        public long NextAvailableNumber { get; set; }

        private static NextGradedCourse nextGradedCourse;

        private NextGradedCourse()
        {
            NextAvailableNumber = 200000;
        }

        public static NextGradedCourse GetInstance()
        {
            if (nextGradedCourse == null)
            {
                BITCollege_BGContext context = new BITCollege_BGContext();
                if (context.NextGradedCourses.SingleOrDefault() != null)
                {
                    nextGradedCourse = context.NextGradedCourses.SingleOrDefault();
                }
                else
                {
                    nextGradedCourse = context.NextGradedCourses.Add(new NextGradedCourse());
                    context.SaveChanges();
                }
            }

            return nextGradedCourse;
        }
    }

    public class NextAuditCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextAuditCourseId { get; set; }

        public long NextAvailableNumber { get; set; }

        private static NextAuditCourse nextAuditCourse;

        private NextAuditCourse()
        {
            NextAvailableNumber = 2000;
        }

        public static NextAuditCourse GetInstance()
        {
            if (nextAuditCourse == null)
            {
                BITCollege_BGContext context = new BITCollege_BGContext();
                if (context.NextAuditCourses.SingleOrDefault() != null)
                {
                    nextAuditCourse = context.NextAuditCourses.SingleOrDefault();
                }
                else
                {
                    nextAuditCourse = context.NextAuditCourses.Add(new NextAuditCourse());
                    context.SaveChanges();
                }
            }

            return nextAuditCourse;
        }
    }

    public class NextMasteryCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NextMasteryCourseId { get; set; }

        public long NextAvailableNumber { get; set; }

        private static NextMasteryCourse nextMasteryCourse;

        private NextMasteryCourse()
        {
            NextAvailableNumber = 20000;
        }

        public static NextMasteryCourse GetInstance()
        {
            if (nextMasteryCourse == null)
            {
                BITCollege_BGContext context = new BITCollege_BGContext();
                if (context.NextMasteryCourses.SingleOrDefault() != null)
                {
                    nextMasteryCourse = context.NextMasteryCourses.SingleOrDefault();
                }
                else
                {
                    nextMasteryCourse = context.NextMasteryCourses.Add(new NextMasteryCourse());
                    context.SaveChanges();
                }
            }


            return nextMasteryCourse;
        }

    }



    public static class StoredProcedures
    {
        /// <summary>
        /// This method accepts a table name and returns the next number insequnece
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static long? NextNumber(string tableName)
        {
            try
            {
                //creates a new connection to our database
                SqlConnection connection =
                    new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BITCollege_BGContext; Integrated Security=True; MultipleActiveResultSets=True");

                //sets the return value to a default of zero
                long? returnValue = 0;

                //creates a local sql commaand using the connection, calling it next_number
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);

                //sets the command type as a storedprocedure
                storedProcedure.CommandType = CommandType.StoredProcedure;

                //requires a value for table name to be input
                storedProcedure.Parameters.AddWithValue("@TableName", tableName);

                //creates an output parameter for the storedprocedure
                SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                //adds the output parameter to the store procedure
                storedProcedure.Parameters.Add(outputParameter);

                //opens a database connection
                connection.Open();

                //executes the parameter and returns the number of rows affected
                storedProcedure.ExecuteNonQuery();

                //closes the database connection
                connection.Close();
                //sets the return values to the output parameter after ca
                returnValue = (long?)outputParameter.Value;
                return returnValue;
            }
            catch (Exception)
            {

                throw;
                //return null?
            }
        }
    }


}






