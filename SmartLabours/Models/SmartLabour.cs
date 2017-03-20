using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartLabours.Models;
using System.Text;
using System.Data.Entity;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SmartLabours.Models
{

    #region Smart Labour DbContext

    public class SmartLabourEntities : DbContext
    {
        // Methods
        //public SmartLabourEntities();
        public SmartLabourEntities()
            : base("name=SmartLabourEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // throw new UnintentionalCodeFirstException();
        }
        // Properties

        public DbSet<TBL_OrganisationMaster> Organisation { get; set; }
        public DbSet<TBL_ABOUTUS_SMT> Aboutus { get; set; }
        public DbSet<TBL_AdminCONTACTUS_SMT> AdminContactus { get; set; }
        public DbSet<TBL_ADMINLOGIN_SMT> AdminLogin { get; set; }
        public DbSet<TBL_ANSWER_SMT> Answer { get; set; }
        public DbSet<TBL_Artical_SMT> Artical { get; set; }
        public DbSet<TBL_Banner_SMT> Banner { get; set; }
        public DbSet<TBL_COMMENTS_SMT> Comments { get; set; }
        public DbSet<TBL_CONTACTUS_SMT> Contactus { get; set; }
        public DbSet<CourseCompletionStatus> CourseCompletionStatus { get; set; }
        public DbSet<TBL_COURSEDTL_SMT> CourseDTLs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<TBL_DISBUTETRANSACTION_SMT> DisbuteTransaction { get; set; }
        public DbSet<DonatePhone> DonatePhone { get; set; }
        public DbSet<Labour> Labours { get; set; }
        public DbSet<TBL_MODULES_SMT> Modules { get; set; }
        public DbSet<TBL_PAGE_USER_MAP_SMT> PageMap { get; set; }
        public DbSet<PhoneAsssignedToLabour> phoneAssigntolabour { get; set; }
        public DbSet<TBL_QUESTION_SMT> Question { get; set; }
        public DbSet<TestResult> QuestionTest { get; set; }
        public DbSet<RequestPhone> RequestPhones { get; set; }
        public DbSet<TBL_REQUESTFAMILYSETTINGS_SMT> Requestsettings { get; set; }
        public DbSet<TBL_SERVICEPLAN_SMT> ServicePlan { get; set; }
        public DbSet<TBL_SERVICEPROVIDER_SMT> ServiceProvider { get; set; }
        public DbSet<TBL_SERVICETYPE_SMT> ServiceType { get; set; }
        public DbSet<Sponsor> Sponsor { get; set; }
        public DbSet<TBL_Sponsor_Notifications> SponsorNotification { get; set; }
        public DbSet<TBL_SPONSOROTHERDONATION_SMT> SponsorotherDonation { get; set; }
        public DbSet<TBL_TERMSANDCONDITION_SMT> Termsandcondition { get; set; }
        public DbSet<TBL_TESTIMONIAL_SMT> Testimonial { get; set; }
        public DbSet<TBL_VOUCHER_SMT> Voucher { get; set; }
        public DbSet<TBL_HealthAndSafety> HealthSafety { get; set; }
        public DbSet<TBL_CategoryMaster> Category { get; set; }
        public DbSet<TBL_SubCategoryMaster> SubCategory { get; set; }
        public DbSet<TBL_CountryMaster> Country { get; set; }
        public DbSet<TBL_RewardPointMaster> RewardPoint { get; set; }
        public DbSet<TBL_HostName> HostName { get; set; }
        public DbSet<TBL_PushNotficationMsg> NotificationMessage { get; set; }
        public DbSet<TBL_NotificationGroupMaster> NotificationGroupMaster { get; set; }
        public DbSet<TBL_NotificationGroupList> NotificationGroupList { get; set; }
        public DbSet<VoucherAssignedToLabour> VoucherAssigned { get; set; }
        public DbSet<TBL_Countries> Countries { get; set; }
        public DbSet<TBL_States> States { get; set; }
        public DbSet<TBL_Cities> Cities { get; set; }
        public DbSet<TBL_Temp> Temp { get; set; }
        public DbSet<TBL_CourseContentFolderMaster> CourseContentFolder { get; set; }
        public DbSet<TBL_CourseContentsFileMaster> CourseContentFile { get; set; }

        public DbSet<TBL_HelpDeskMaster> HelpDesk { get; set; }
        public DbSet<TBL_HelpDeskMasterLog> HelpDeskLog { get; set; }
        public DbSet<Tbl_HiddenSponsorDonateAmount> UserAEDAmount { get; set; }
        public DbSet<Tbl_PayTabDetails> PayTabDetails { get; set; }
        public DbSet<Tbl_UserAmount> UserAmount { get; set; }
    }

    #endregion

    #region Answer

    public class Answer
    {
        // Methods
        //public Answer();

        // Properties
        public string AnswerDesc { get; set; }
        [Key]
        public int AnswerID { get; set; }
        public bool IsCorrect { get; set; }
        public virtual Question ques { get; set; }
        public int QuestionID { get; set; }
    }

    #endregion

    #region ChangePasswordModel

    [NotMapped]
    public class ChangePasswordModel
    {
        // Methods
        //public ChangePasswordModel();

        // Properties
        [Required(ErrorMessage = "Please Enter Confirm Password"), DataType(DataType.Password), Display(Name = "Confirm password"), System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6), DataType(DataType.Password), Display(Name = "New password"), Required(ErrorMessage = "Please Enter New Password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password), Display(Name = "Current password"), Required(ErrorMessage = "Please Enter Old Password")]
        public string OldPassword { get; set; }
    }

    #endregion

    #region Course

    public class Course
    {
        // Methods
        //public Course();

        // Properties
        [Key]
        public int CourseID { get; set; }
        [Required(ErrorMessage = "Please Enter the Course")]
        public string CourseName { get; set; }
        public virtual CourseType coursetype { get; set; }
        [Required(ErrorMessage = "Please Select Course Level")]
        public int CourseTypeID { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        [NotMapped, AllowHtml]
        public string hdnKeywords { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFIEDDATE { get; set; }
        [AllowHtml]
        public string MutlticourseDesc { get; set; }

        [NotMapped]
        [AllowHtml]
        public string MutlticourseDescURL { get; set; }

        [NotMapped]
        public virtual TBL_QUESTION_SMT Questionanswer { get; set; }
        public bool? STATUS { get; set; }
        public string QuestionTitle { get; set; }
        [NotMapped]
        // [Required(ErrorMessage = "Please select Organization Name ")]
        public string OrganisationName { get; set; }

        public virtual TBL_OrganisationMaster Organizations { get; set; }
        [Required(ErrorMessage = "Please select Organization")]
        public int OrgId { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

        [NotMapped]
        public string SubCategoryName { get; set; }

        public virtual TBL_CategoryMaster Category { get; set; }
        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryId { get; set; }
        public virtual TBL_SubCategoryMaster SubCategory { get; set; }
        public int? SubCategoryId { get; set; }

        public bool ShowAllOrg { get; set; }

        public string AllOrgId { get; set; }

        public bool IsEmbededURL { get; set; }

        [Required(ErrorMessage = "Please Select Language")]
        public string Language { get; set; }

    }

    #endregion

    #region CourseCompletionStatus

    public class CourseCompletionStatus
    {
        // Methods
        //public CourseCompletionStatus();

        // Properties
        [Key]
        public int CourseCompletionStatusID { get; set; }
        public int CourseID { get; set; }
        public bool? ISFinished { get; set; }
        public bool? IsStarted { get; set; }
        public string LabourID { get; set; }
    }

    #endregion

    #region CourseType

    public class CourseType
    {
        // Methods
        //public CourseType();

        // Properties
        [Key]
        public int CourseTypeID { get; set; }
        public string CourseTypeName { get; set; }
    }
    #endregion

    #region DonatePhone

    public class DonatePhone
    {
        // Methods
        //public DonatePhone();

        // Properties
        [AllowHtml]
        public string Address { get; set; }
        public string AlternateAddress { get; set; }
        public string AlternatePhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter the Brand Name")]
        public string BrandName { get; set; }
        public string ContactDetail { get; set; }
        //[AllowHtml]
        public string CourierDetail { get; set; }
        [NotMapped]
        public string DisbuteReview { get; set; }
        [NotMapped]
        public long DisbuteReviewId { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DonatedDate { get; set; }
        [Key]
        public int DonateID { get; set; }
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Please Enter the IMEA number"), StringLength(0x19, MinimumLength = 15, ErrorMessage = "IMEA number minimum 15 characters required")]
        public string IMEANumber { get; set; }
        [DefaultValue(false)]
        public bool IsPhoneAcceptedByAdmin { get; set; }
        [DefaultValue(false)]
        public bool IsPhoneAssignedToLabour { get; set; }
        [DefaultValue(false)]
        public bool IsPhoneConfirmation { get; set; }
        [Required(ErrorMessage = "Please Enter the Mobile No")]
        public string ModelNo { get; set; }
        [NotMapped]
        public virtual PhoneAsssignedToLabour phoneAssignlabour { get; set; }
        [Required(ErrorMessage = "Please Enter the Phone Color")]
        public string PhoneColor { get; set; }
        [NotMapped]
        public virtual Labour PhoneLabour { get; set; }
        [Required(ErrorMessage = "Please Enter the PhoneOwnerName")]
        public string PhoneOwnerName { get; set; }
        [NotMapped]
        public virtual RequestPhone PhoneRequest { get; set; }
        public string Pincode { get; set; }
        public virtual Sponsor sponsors { get; set; }
        public int UserID { get; set; }
        [NotMapped]
        public string createdDate { get; set; }
        // [NotMapped]
        public string City { get; set; }
        // [NotMapped]
        public string State { get; set; }
        // [NotMapped]
        public string Country { get; set; }
        [NotMapped]
        public string OrgName { get; set; }

    }

    #endregion

    #region Labour

    public class Labour
    {
        // Methods
        //public Labour();

        // Properties
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The new password and confirmation password do not match."), DataType(DataType.Password), NotMapped, Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }

        [NotMapped]
        public string Day { get; set; }
        public string DeviceToken { get; set; }
        public string DeviceType { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [NotMapped]
        public string strDOB { get; set; }

        [MaxLength(50), DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct Email ID"), Required(ErrorMessage = "Please Enter Email ID"), RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Please enter correct Email")]
        public string EmailID { get; set; }
        [DefaultValue(false)]

        public bool IsDisplayNameAccepted { get; set; }
        public string LabourID { get; set; }
        public string LabourImage { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFIEDDATE { get; set; }
        [NotMapped]
        public string Month { get; set; }

        [Required(ErrorMessage = "Please Enter the Name")]
        public string Name { get; set; }

        [NotMapped]
        public string NotificationMsg { get; set; }

        [DataType(DataType.Password), StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6), Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Pincode { get; set; }
        public virtual TBL_SERVICEPROVIDER_SMT serviceprovider { get; set; }

        [Required(ErrorMessage = "Please select Service Provider")]
        [Range(0, 9999999, ErrorMessage = "Service Provider must be a valid number")]
        public int SERVICEPROVIDERID { get; set; }

        public string Sex { get; set; }

        [Required(ErrorMessage = "Please Accept terms And Condition")]
        public bool STATUS { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        [Key]
        public int UserID { get; set; }
        [NotMapped]
        public string Year { get; set; }
        public string SERVICETYPEID { get; set; }
        [NotMapped]
        public string UploadFile { get; set; }

        public virtual TBL_OrganisationMaster Organizations { get; set; }
        // [Required(ErrorMessage = "Please Enter Organization Name ")]
        public int OrgId { get; set; }

        [NotMapped]
        public string OrgName { get; set; }

        public bool CreatedFrom { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }


        public virtual TBL_CategoryMaster Category { get; set; }
        //  [Required(ErrorMessage = "Please Enter Category Name ")]
        public int? CategoryId { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public string SubCategoryName { get; set; }


        public virtual TBL_SubCategoryMaster SubCategory { get; set; }
        //  [Required(ErrorMessage = "Please Enter Category Name ")]
        public int? SubCategoryId { get; set; }
        [MaxLength(10)]
        public string CountryCode { get; set; }
        public bool Visibility { get; set; }
        public int OrgChangeStatus { get; set; }
        public bool IsOriginalEmirateId { get; set; }
    }

    #endregion

    #region Mailing

    public class Mailing
    {
        // Fields
        private string CC = string.Empty;
        private string Msg = string.Empty;

        // Methods
        public string Email_LoginWise(string mailid, string subject, string messageBody)
        {
            try
            {
                string host = ConfigurationSettings.AppSettings["LHost"].ToString();
                int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
                string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
                string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
                SmtpClient client = new SmtpClient(host, port);
                string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
                string password = ConfigurationSettings.AppSettings["LMailPassword"].ToString();

                client.Credentials = new NetworkCredential(userName, password);
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(address)
                };
                message.To.Add(new MailAddress(mailid));
                message.Subject = subject;
                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;
                message.Body = messageBody;
                //SmtpClient client2 = new SmtpClient {
                //    Host = host,
                //    EnableSsl = true
                //};
                SmtpClient client2 = new SmtpClient(host, port);
                NetworkCredential credential = new NetworkCredential(userName, password);
                client2.UseDefaultCredentials = true;
                client2.Credentials = credential;
                client2.EnableSsl = true;
                client2.Port = port;
                client2.Send(message);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return this.Msg;
        }

        public string Email_Wise(string useremail, string subject, string username, string password)
        {
            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
            SmtpClient client = new SmtpClient(host, port);
            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
            string str5 = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
            client.Credentials = new NetworkCredential(userName, str5);
            MailMessage message = new MailMessage
            {
                From = new MailAddress(address)
            };
            message.To.Add(new MailAddress(useremail));
            message.Subject = subject;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;
            message.Body = this.getbodyEmailForgetpassword(username, password, useremail).ToString();
            //SmtpClient client2 = new SmtpClient {
            //    Host = host,
            //    EnableSsl = true
            //};
            SmtpClient client2 = new SmtpClient(host, port);
            NetworkCredential credential = new NetworkCredential(userName, str5);
            client2.UseDefaultCredentials = true;
            client2.Credentials = credential;
            client2.EnableSsl = true;
            client2.Port = port;
            client2.Send(message);
            this.Msg = "true";
            return this.Msg;
        }
        public string SentEmail_Register(string useremail, string subject, bool isLabour)
        {
            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
            SmtpClient client = new SmtpClient(host, port);
            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
            string str5 = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
            client.Credentials = new NetworkCredential(userName, str5);
            MailMessage message = new MailMessage
            {
                From = new MailAddress(address)
            };
            message.To.Add(new MailAddress(useremail));
            message.Subject = subject;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;
            if (isLabour)
                message.Body = this.getbodyEmailLabourRegister().ToString();
            else
                message.Body = this.getbodyEmailSponserRegister().ToString();
            //SmtpClient client2 = new SmtpClient
            //{
            //    Host = host,
            //    EnableSsl = true
            //};
            SmtpClient client2 = new SmtpClient(host, port);
            NetworkCredential credential = new NetworkCredential(userName, str5);
            client2.UseDefaultCredentials = true;
            client2.Credentials = credential;
            client2.EnableSsl = true;
            client2.Port = port;
            client2.Send(message);
            this.Msg = "true";
            return this.Msg;
        }
        public string SentEmail_DonatePhone(string useremail, string subject, string name)
        {
            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
            SmtpClient client = new SmtpClient(host, port);
            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
            string str5 = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
            client.Credentials = new NetworkCredential(userName, str5);
            MailMessage message = new MailMessage
            {
                From = new MailAddress(address)
            };
            message.To.Add(new MailAddress(useremail));
            message.Subject = subject;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;
            message.Body = this.getbodyEmailSponserDonatePhone(name).ToString();

            //SmtpClient client2 = new SmtpClient
            //{
            //    Host = host,
            //    EnableSsl = true
            //};
            SmtpClient client2 = new SmtpClient(host, port);
            NetworkCredential credential = new NetworkCredential(userName, str5);
            client2.UseDefaultCredentials = true;
            client2.Credentials = credential;
            client2.EnableSsl = true;
            client2.Port = port;
            client2.Send(message);
            this.Msg = "true";
            return this.Msg;
        }
        public string SentEmail_PhoneRequest(string useremail, string subject, string name)
        {
            try
            {
                string host = ConfigurationSettings.AppSettings["LHost"].ToString();
                int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
                string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
                string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
                SmtpClient client = new SmtpClient(host, port);
                string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
                string str5 = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
                client.Credentials = new NetworkCredential(userName, str5);
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(address)
                };
                message.To.Add(new MailAddress(useremail));
                message.Subject = subject;
                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;
                message.Body = this.getbodyEmailLabourPhoneRequest(name).ToString();

                //SmtpClient client2 = new SmtpClient
                //{
                //    Host = host,
                //    EnableSsl = true
                //};
                SmtpClient client2 = new SmtpClient(host, port);
                NetworkCredential credential = new NetworkCredential(userName, str5);
                client2.UseDefaultCredentials = true;
                client2.Credentials = credential;
                client2.EnableSsl = true;
                client2.Port = port;
                client2.Send(message);
                this.Msg = "true";
                return this.Msg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SentEmail_PhoneAvailable(string useremail, string subject, string name)
        {
            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
            SmtpClient client = new SmtpClient(host, port);
            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
            string str5 = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
            client.Credentials = new NetworkCredential(userName, str5);
            MailMessage message = new MailMessage
            {
                From = new MailAddress(address)
            };
            message.To.Add(new MailAddress(useremail));
            message.Subject = subject;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;
            message.Body = this.getbodyEmailLabourPhoneAvailable(name).ToString();

            //SmtpClient client2 = new SmtpClient
            //{
            //    Host = host,
            //    EnableSsl = true
            //};
            SmtpClient client2 = new SmtpClient(host, port);
            NetworkCredential credential = new NetworkCredential(userName, str5);
            client2.UseDefaultCredentials = true;
            client2.Credentials = credential;
            client2.EnableSsl = true;
            client2.Port = port;
            client2.Send(message);
            this.Msg = "true";
            return this.Msg;
        }
        public string SentEmail_PhoneAccept(string useremail, string subject, string name, string IsAccepted)
        {
            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
            SmtpClient client = new SmtpClient(host, port);
            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
            string str5 = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
            client.Credentials = new NetworkCredential(userName, str5);
            MailMessage message = new MailMessage
            {
                From = new MailAddress(address)
            };
            message.To.Add(new MailAddress(useremail));
            message.Subject = subject;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;
            if (Convert.ToBoolean(IsAccepted))
                message.Body = this.getbodyEmailLabourPhoneAccepted(name).ToString();
            else
                message.Body = this.getbodyEmailLabourPhoneRejected(name).ToString();

            //SmtpClient client2 = new SmtpClient
            //{
            //    Host = host,
            //    EnableSsl = true
            //};
            SmtpClient client2 = new SmtpClient(host, port);
            NetworkCredential credential = new NetworkCredential(userName, str5);
            client2.UseDefaultCredentials = true;
            client2.Credentials = credential;
            client2.EnableSsl = true;
            client2.Port = port;
            client2.Send(message);
            this.Msg = "true";
            return this.Msg;
        }
        public string SentEmail_PhoneDelivered(string useremail, string subject, string name)
        {
            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
            SmtpClient client = new SmtpClient(host, port);
            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
            string str5 = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
            client.Credentials = new NetworkCredential(userName, str5);
            MailMessage message = new MailMessage
            {
                From = new MailAddress(address)
            };
            message.To.Add(new MailAddress(useremail));
            message.Subject = subject;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;
            message.Body = this.getbodyEmailLabourPhoneDelivered(name).ToString();

            //SmtpClient client2 = new SmtpClient
            //{
            //    Host = host,
            //    EnableSsl = true
            //};
            SmtpClient client2 = new SmtpClient(host, port);
            NetworkCredential credential = new NetworkCredential(userName, str5);
            client2.UseDefaultCredentials = true;
            client2.Credentials = credential;
            client2.EnableSsl = true;
            client2.EnableSsl = true;
            client2.Port = port;
            client2.Send(message);
            this.Msg = "true";
            return this.Msg;
        }


        public StringBuilder getbody(string subject, string username, string password, string emailid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationManager.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + username + ",</b></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("The following are the new login details of Smart Labour <br /><br />");
            builder.Append("<b>Username<b style=\"padding:0px 8px 0px 8px;\">:</b>" + emailid + "<br />");
            builder.Append(" Password<b style=\"padding:0px 8px 0px 9px;\">:</b>" + password + "<br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr><td colspan=\"2\" Style=\"height:40px\" style=\"padding: 0px 19px;\" ><a  style=\"padding: 0px 19px;\" href='" + ConfigurationManager.AppSettings["login"].ToString() + "'>Click here to login</a></td></tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:28px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Regards,<br/> " + ConfigurationManager.AppSettings["MailRegards"].ToString() + " <br /></td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }

        public StringBuilder getbodycontactus(string subject, string username)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationManager.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + username + ",</b></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("<b><b style=\"padding:0px 8px 0px 8px;\"></b>Thank you! Your message has been successfully sent. We will contact you very soon..<br />");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:28px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Regards,<br/> " + ConfigurationManager.AppSettings["MailRegards"].ToString() + " <br /></td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }

        public StringBuilder getbodyEmail(string Username, string EmailID, string pwd)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + Username + ",</b></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("Following details is your Smart Labour login accounts.<br /><br />");
            builder.Append("<b>Email Id<b style=\"padding:0px 12px 0px 9px;\">:</b>" + EmailID + "<br />");
            builder.Append("Password<b style=\"padding:0px 12px 0px 9px;\">:</b>" + pwd + "<br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Regards,<br />Smartlabours Team</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }

        public StringBuilder getbodyEmailForgetpassword(string Username, string pwd, string EmailID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + Username + ",</b></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            //builder.Append("Following details is your SmartLabours login accounts.<br /><br />");
            //builder.Append("<b>Email Id<b style=\"padding:0px 12px 0px 9px;\">:</b>" + EmailID + "<br /><br>");
            builder.Append("Your new password is :<b style=\"padding:0px 12px 0px 9px;\">:</b>" + pwd + "<br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Thank You,<br />Regards,<br />Smart Labour Team</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }

        public StringBuilder getbodyforLAbour(string subject, string Courrierdetails)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationManager.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + subject + ",</b></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("You phone request has been approved and we will be touch with you shortly.<br /><br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("<b>The following are the courrier related details.<b style=\"padding:0px 8px 0px 8px;\">:</b>" + Courrierdetails + "<br />");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Thank You,<br /> Kindest Regards,<br />Smart Labour Team</td>");
            builder.Append("</tr>");

            builder.Append("</table>");
            return builder;
        }

        public StringBuilder getbodyforsponsor(string subject, string Courrierdetails)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationManager.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("<b>The following are the courrier related details :<b style=\"padding:0px 8px 0px 8px;\">:</b>" + Courrierdetails + "<br />");
            builder.Append("</tr>");
            builder.Append("<tr><td colspan=\"2\" Style=\"height:40px\" style=\"padding: 0px 19px;\" ><a  style=\"padding: 0px 19px;\" href='" + ConfigurationManager.AppSettings["login"].ToString() + "'></a></td></tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:28px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Regards,<br/> " + ConfigurationManager.AppSettings["MailRegards"].ToString() + " <br /></td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }
        public StringBuilder getbodyEmailLabourRegister()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("Thank you for registering with Smart Labour, The only Smart platform for our labour brethren. Please encourage your friends to register too.<br /><br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Thank You,<br /> Kindest Regards,<br />Smart Labour Team</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }
        public StringBuilder getbodyEmailSponserRegister()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("Thank you for signing up and for being part of a ground breaking project to help our labour brethren to be part of the Smart revolution.<br /><br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Thank You,<br /> Kindest Regards,<br />Smart Labour Team</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }
        public StringBuilder getbodyEmailSponserDonatePhone(string Username)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("Thank you <b>" + Username + "</b> for your generosity and for helping in making our labourer brethren smarter.<br /><br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Thank You,<br /> Kindest Regards,<br />Smart Labour Team</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }
        public StringBuilder getbodyEmailLabourPhoneRequest(string Username)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + Username + ",</b></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("Thank you for requesting for a phone.We will get back to you based on the availability<br /><br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Thank You,<br /> Kindest Regards,<br />Smart Labour Team</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }
        public StringBuilder getbodyEmailLabourPhoneAvailable(string Username)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + Username + ",</b></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("Congratulations! You have been assigned a phone and we will be in touch with you shortly.<br /><br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Thank You,<br /> Kindest Regards,<br />Smart Labour Team</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }
        public StringBuilder getbodyEmailLabourPhoneAccepted(string Username)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + Username + ",</b></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("Thank you for accepting a phone. Hope you enjoy it and use it to connect to your family.<br /><br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Thank You,<br /> Kindest Regards,<br />Smart Labour Team</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }

        public StringBuilder getbodyEmailLabourPhoneRejected(string Username)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + Username + ",</b></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append(" You have rejected the phone offered by Smart Labour.<br /><br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Thank You,<br /> Kindest Regards,<br />Smart Labour Team</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }

        public StringBuilder getbodyEmailLabourPhoneDelivered(string Username)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("");
            string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
            builder.Append("<table width=\"680\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
            builder.Append("<tr>");
            builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + Username + ",</b></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
            builder.Append("Your phone request has been approved and we will be touch with you shortly. The following are the courrier related details<br /><br /></td>");
            builder.Append("</tr>");
            builder.Append("<tr>");
            builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Thank You,<br /> Kindest Regards,<br />Smart Labour Team</td>");
            builder.Append("</tr>");
            builder.Append("</table>");
            return builder;
        }

        public void SendMail(string Username, string emailID, string Passwrd)
        {
            try
            {
                string subject = "";
                string messageBody = "";
                subject = "Login Details - Smartlabours";
                messageBody = this.getbodyEmail(Username, emailID, Passwrd).ToString();
                if (this.Email_LoginWise(emailID, subject, messageBody) == "true")
                {
                }
            }
            catch
            {
            }
        }

        public string SendMailforchangepassword(string emailid, string subject, string username, string password)
        {
            try
            {
                string host = ConfigurationSettings.AppSettings["LHost"].ToString();
                int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
                string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
                string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
                SmtpClient client = new SmtpClient(host, port);
                string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
                string str5 = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
                client.Credentials = new NetworkCredential(userName, str5);
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(address)
                };
                message.To.Add(new MailAddress(emailid));
                message.Subject = subject;
                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;
                message.Body = this.getbody(subject, username, password, emailid).ToString();
                SmtpClient client2 = new SmtpClient
                {
                    Host = host,
                    EnableSsl = true
                };
                NetworkCredential credential = new NetworkCredential(userName, str5);
                client2.UseDefaultCredentials = true;
                client2.Credentials = credential;
                client2.EnableSsl = true;
                client2.Port = port;
                client2.Send(message);
                this.Msg = "true";
                return this.Msg;
            }
            catch
            {
                return null;
            }
        }

        public string SendMailforContactus(string emailid, string subject, string username)
        {
            try
            {
                string host = ConfigurationSettings.AppSettings["LHost"].ToString();
                int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
                string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
                string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
                SmtpClient client = new SmtpClient(host, port);
                string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
                string password = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
                client.Credentials = new NetworkCredential(userName, password);
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(address)
                };
                message.To.Add(new MailAddress(emailid));
                message.Subject = subject;
                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;
                message.Body = this.getbodycontactus(subject, username).ToString();
                SmtpClient client2 = new SmtpClient
                {
                    Host = host,
                    EnableSsl = true
                };
                NetworkCredential credential = new NetworkCredential(userName, password);
                client2.UseDefaultCredentials = true;
                client2.Credentials = credential;
                client2.EnableSsl = true;
                client2.Port = port;
                client2.Send(message);
                this.Msg = "true";
                return this.Msg;
            }
            catch
            {
                return null;
            }
        }

        public string SendMailforLabourcourrier(string emailid, string subject, string Courrierdetails, string name)
        {
            try
            {
                string host = ConfigurationSettings.AppSettings["LHost"].ToString();
                int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
                string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
                string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
                SmtpClient client = new SmtpClient(host, port);
                string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
                string password = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
                client.Credentials = new NetworkCredential(userName, password);
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(address)
                };
                message.To.Add(new MailAddress(emailid));
                message.Subject = subject;
                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;
                message.Body = this.getbodyforLAbour(name, Courrierdetails).ToString();
                SmtpClient client2 = new SmtpClient
                {
                    Host = host,
                    EnableSsl = true
                };
                NetworkCredential credential = new NetworkCredential(userName, password);
                client2.UseDefaultCredentials = true;
                client2.Credentials = credential;
                client2.EnableSsl = true;
                client2.Port = port;
                client2.Send(message);
                this.Msg = "true";
                return this.Msg;
            }
            catch
            {
                return null;
            }
        }

        public string SendMailforSponsorcourrier(string emailid, string subject, string Courrierdetails)
        {
            try
            {
                string host = ConfigurationSettings.AppSettings["LHost"].ToString();
                int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
                string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
                string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
                SmtpClient client = new SmtpClient(host, port);
                string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
                string password = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
                client.Credentials = new NetworkCredential(userName, password);
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(address)
                };
                message.To.Add(new MailAddress(emailid));
                message.Subject = subject;
                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;
                message.Body = this.getbodyforsponsor(subject, Courrierdetails).ToString();
                SmtpClient client2 = new SmtpClient
                {
                    Host = host,
                    EnableSsl = true
                };
                NetworkCredential credential = new NetworkCredential(userName, password);
                client2.UseDefaultCredentials = true;
                client2.Credentials = credential;
                client2.EnableSsl = true;
                client2.Port = port;
                client2.Send(message);
                this.Msg = "true";
                return this.Msg;
            }
            catch
            {
                return null;
            }
        }
    }

    #endregion

    #region PhoneAsssignedToLabour

    public class PhoneAsssignedToLabour
    {
        // Methods
        //public PhoneAsssignedToLabour();

        // Properties
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AssignedDate { get; set; }
        [AllowHtml]
        public string CourierDetail { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DeliveredDate { get; set; }
        [NotMapped]
        public string disbuteFeedBack { get; set; }
        public int DonateID { get; set; }
        public bool? IsExpiredPhoneAssigned { get; set; }
        public bool? IsLabourReceivedPhone { get; set; }
        [DefaultValue(false)]
        public bool? IsPhoneAccepted { get; set; }
        [DefaultValue(false)]
        public bool IsTimeExpired { get; set; }
        public string LabourID { get; set; }
        public virtual DonatePhone objdonate { get; set; }
        [NotMapped]
        public virtual Labour objlabour { get; set; }
        [Key]
        public int PhoneAssignedID { get; set; }
        [NotMapped]
        public string PhoneExpiryDays { get; set; }
        [NotMapped]
        public string PhoneImageURL { get; set; }
        public int RequestPhoneID { get; set; }
        [NotMapped]
        public string RequestStatus { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
    }

    #endregion

    #region Question

    public class Question
    {
        // Methods
        //public Question();

        // Properties
        public int CourseID { get; set; }
        public int CreditPoints { get; set; }
        public string QuestionDesc { get; set; }
        [Key]
        public int QuestionID { get; set; }

    }

    #endregion

    #region RequestPhone

    public class RequestPhone
    {
        // Methods
        //public RequestPhone();

        // Properties
        [Required(ErrorMessage = "Please Enter the Address")]
        public string Address { get; set; }
        public string AlternatePhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter the Emirates ID")]
        public string LabourID { get; set; }
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Please enter correct Email"), Required(ErrorMessage = "Please Enter Email ID"), DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct Email ID"), MaxLength(50)]
        public string MailId { get; set; }
        public string NewAddress { get; set; }
        [Required(ErrorMessage = "Please Enter the Phone No")]
        public string PhoneNumber { get; set; }
        [NotMapped]
        public int RequestCount { get; set; }
        public DateTime? RequestedDate { get; set; }
        [Key]
        public int RequestPhoneID { get; set; }
        [NotMapped]
        public bool Requestsettings { get; set; }
        public string RequestStatus { get; set; }
    }

    #endregion

    #region Sponsor

    public class Sponsor
    {
        // Methods
        //public Sponsor();

        // Properties
        [Required(ErrorMessage = "Please Enter the Address")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        [Display(Name = "Confirm password"), DataType(DataType.Password), System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        [NotMapped]
        public string Day { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [MaxLength(50), Required(ErrorMessage = "Please Enter Email ID"), DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct Email ID"), RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Please enter correct Email")]
        public string EmailID { get; set; }
        [StringLength(50, ErrorMessage = "Please Enter Atleast 15 Characters", MinimumLength = 15), Required(ErrorMessage = "Please Enter the Emirates Id")]
        public string EmiratesId { get; set; }
        public bool? Homecontent { get; set; }
        [DefaultValue(false)]
        public bool IsDisplayNameAccepted { get; set; }
        [NotMapped]
        public string Month { get; set; }
        [Required(ErrorMessage = "Please Enter the Name")]
        public string Name { get; set; }
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6), Required(ErrorMessage = "Please Enter Password"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter the Phone No")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter the Pincode")]
        public string Pincode { get; set; }
        [Required(ErrorMessage = "Please select Sex")]
        public string Sex { get; set; }
        public string sponsorImage { get; set; }
        public bool Status { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        [Key]
        public int UserID { get; set; }
        [NotMapped]
        public string Year { get; set; }

        public virtual TBL_OrganisationMaster Organizations { get; set; }

        public int OrgId { get; set; }
        [NotMapped]
        public string OrgName { get; set; }

        public bool CreatedFrom { get; set; }

        public int ChangeStatus { get; set; }

        [Required(ErrorMessage = "Please Enter the City")]
        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        [MaxLength(10)]
        public string CountryCode { get; set; }

    }

    #endregion

    #region TBL_ABOUTUS_SMT

    public class TBL_ABOUTUS_SMT
    {
        // Methods
        //public TBL_ABOUTUS_SMT();

        // Properties
        [Key]
        public long ABOUTUSID { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        [AllowHtml]
        public string FULLDESCRIPTION { get; set; }
        [Required(ErrorMessage = "Please Enter Short Description")]
        public string SHORTDESC { get; set; }
        public bool STATUS { get; set; }
    }

    #endregion

    #region TBL_AdminCONTACTUS_SMT

    public class TBL_AdminCONTACTUS_SMT
    {
        // Methods
        //public TBL_AdminCONTACTUS_SMT();

        // Properties
        [Required(ErrorMessage = "Please Enter Address ")]
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        [Required(ErrorMessage = "Please Enter City")]
        public string CITY { get; set; }
        [Key]
        public long CONTACTUSID { get; set; }
        [Required(ErrorMessage = "Please Enter Country")]
        public string COUNTRY { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        [MaxLength(50), DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct Email ID"), RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Please enter correct Email"), Required(ErrorMessage = "Please Enter Email ID")]
        public string EMAILID { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string PHONENO { get; set; }
        [Required(ErrorMessage = "Please Enter Post Box Number")]
        public string POBOXNO { get; set; }
        public bool STATUS { get; set; }

        public DateTime FinaceYear { get; set; }
        [Required(ErrorMessage = "Please Enter Host Name")]
        public string HostName { get; set; }
        [NotMapped]
        public string StrFinanceDate { get; set; }
    }

    #endregion

    #region TBL_ADMINLOGIN_SMT

    public class TBL_ADMINLOGIN_SMT
    {
        // Methods
        //public TBL_ADMINLOGIN_SMT();

        // Properties
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? LASTLOGIN { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFIEDDATE { get; set; }
        [DataType(DataType.Password), Required]
        public string PASSWORD { get; set; }
        public bool STATUS { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter Correct Email ID"), RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Please Enter Correct Email")]
        public string USEREMAIL { get; set; }
        [Key]
        public int USERID { get; set; }
        [Required(ErrorMessage = "Please Enter Name ")]
        public string USERNAME { get; set; }
        public int USERTYPE { get; set; }
        public virtual TBL_OrganisationMaster Organizations { get; set; }

        public int OrgId { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please Select Organization Name ")]
        public string Orgname { get; set; }

    }

    #endregion

    #region TBL_ANSWER_SMT

    public class TBL_ANSWER_SMT
    {
        // Methods
        //public TBL_ANSWER_SMT();

        // Properties
        public string AnswerDesc { get; set; }
        [Key]
        public int AnswerID { get; set; }
        public bool IsCorrect { get; set; }
        public virtual TBL_QUESTION_SMT question { get; set; }
        public int QuestionID { get; set; }
    }

    #endregion

    #region TBL_Artical_SMT

    public class TBL_Artical_SMT
    {
        // Methods
        //public TBL_Artical_SMT();

        // Properties
        //[Required(ErrorMessage = "Please Select Artical Date.")]
        public DateTime? ArticalDate { get; set; }
        [Key]
        public int ArticalID { get; set; }
        public string CreatedBy { get; set; }
        //  [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }
        [AllowHtml, Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
        public bool Homecontent { get; set; }
        [StringLength(0x7d0), Required(ErrorMessage = "Please Enter Short Description")]
        public string ShortDescription { get; set; }
        public bool Status { get; set; }
        [StringLength(300, ErrorMessage = "Maximum Character Limit is 50"), Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }

        [NotMapped]
        public string StrArticalDate { get; set; }
    }

    #endregion

    #region TBL_Banner_SMT

    public class TBL_Banner_SMT
    {
        // Methods
        //public TBL_Banner_SMT();

        // Properties
        [Key]
        public int BannerId { get; set; }
        public string BannerImage { get; set; }
        public string BannerTitle { get; set; }
        public bool Status { get; set; }
    }

    #endregion

    #region TBL_COMMENTS_SMT

    public class TBL_COMMENTS_SMT
    {
        // Methods
        //public TBL_COMMENTS_SMT();

        // Properties
        public bool APPROVED { get; set; }
        public int ARTICALID { get; set; }
        public virtual TBL_Artical_SMT Articals { get; set; }
        [Key]
        public int COMMENTSID { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        public string DESCRIPTION { get; set; }
        public virtual Labour labours { get; set; }
        public int UserID { get; set; }
    }

    #endregion

    #region TBL_CONTACTUS_SMT

    public class TBL_CONTACTUS_SMT
    {
        // Methods
        //public TBL_CONTACTUS_SMT();

        // Properties
        [Required(ErrorMessage = "Please Enter Comments")]
        public string COMMENTS { get; set; }
        [Key]
        public long CONTACTID { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        [MaxLength(50), DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct Email ID"), RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Please enter correct Email"), Required(ErrorMessage = "Please Enter Email ID")]
        public string EMAILID { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        [Required(ErrorMessage = "Please Enter Phone No")]
        public string PHONENO { get; set; }
        [StringLength(300)]
        public string REVIEW { get; set; }
    }

    #endregion

    #region TBL_Temp

    public class TBL_Temp
    {
        // Methods
        //public TBL_CONTACTUS_SMT();

        // Properties


        [Key]
        public long Id { get; set; }

        public string COMMENTS { get; set; }

        public DateTime? CREATEDDATE { get; set; }

        public string FIRSTNAME { get; set; }

        public string LASTNAME { get; set; }

        public bool STATUS { get; set; }

    }

    #endregion

    #region TBL_COURSEDTL_SMT

    public class TBL_COURSEDTL_SMT
    {
        // Methods
        //public TBL_COURSEDTL_SMT();

        // Properties
        [Key]
        public int COURSEDTLID { get; set; }
        public int COURSEID { get; set; }
        public virtual Course courses { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        [AllowHtml]
        public string DESCRIPTION { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFIEDDATE { get; set; }

        [NotMapped]
        public bool IsEmbededURL { get; set; }
    }

    #endregion

    #region TBL_DISBUTETRANSACTION_SMT

    public class TBL_DISBUTETRANSACTION_SMT
    {
        // Methods
        //public TBL_DISBUTETRANSACTION_SMT();

        // Properties
        public DateTime? Createddate { get; set; }
        [Key]
        public int DisbuteID { get; set; }
        [StringLength(300)]
        public string FeedBack { get; set; }
        [StringLength(300)]
        public string REVIEW { get; set; }
        public int TransactionId { get; set; }
    }

    #endregion

    #region TBL_MODULES_SMT

    public class TBL_MODULES_SMT
    {
        // Methods
        //public TBL_MODULES_SMT();

        // Properties
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        public string HMS_IMS { get; set; }
        [Key]
        public int IPAGEID { get; set; }
        public int? IPARENTID { get; set; }
        [DisplayName("IPRIORITY")]
        public int? IPRIORITY { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFIEDDATE { get; set; }
        [DisplayName("URL")]
        [MaxLength(250)]
        public string PAGENAME { get; set; }
        public bool? STATUS { get; set; }
        [DisplayName("Title")]
        public string VPAGELABEL { get; set; }
    }

    #endregion

    #region TBL_PAGE_USER_MAP_SMT

    public class TBL_PAGE_USER_MAP_SMT
    {
        // Methods
        //public TBL_PAGE_USER_MAP_SMT();

        // Properties
        public bool? BSTATUS { get; set; }
        [Key]
        public long id { get; set; }
        public int IMAPID { get; set; }
        public int IPAGEID { get; set; }
        public virtual TBL_MODULES_SMT PAGE { get; set; }
        public string VUSERTYPE { get; set; }
    }

    #endregion

    #region TBL_PLAN_SMT

    public class TBL_PLAN_SMT
    {
        // Methods
        //public TBL_PLAN_SMT();

        // Properties
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        public int CREDITPOINTS { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFIEDDATE { get; set; }
        [Key]
        public int PLANID { get; set; }
        [Required(ErrorMessage = "Please Enter Plan Name")]
        public string PLANNAEME { get; set; }
        [Required(ErrorMessage = "Please Select ServiceProvider Name")]
        public int SERVICEPROVIDERID { get; set; }
        [Required(ErrorMessage = "Please Select Service Type")]
        public int SERVICETYPEID { get; set; }
        public bool? STATUS { get; set; }
        public string VALUEOFPLAN { get; set; }
    }

    #endregion

    #region TBL_QUESTION_SMT

    public class TBL_QUESTION_SMT
    {
        // Methods
        //public TBL_QUESTION_SMT();

        // Properties
        public virtual Course cos { get; set; }

        [Required(ErrorMessage = "Please select Course")]
        public int CourseID { get; set; }

        public int CreditPoints { get; set; }

        [NotMapped]
        public string hdnQuestions { get; set; }

        public string QuestionDesc { get; set; }

        [Key]
        public int QuestionID { get; set; }

        public bool QuestionType { get; set; }

        [NotMapped]
        public string OrganisationName { get; set; }

        [NotMapped]
        public string CourseName { get; set; }

    }

    #endregion

    #region TBL_REQUESTFAMILYSETTINGS_SMT

    public class TBL_REQUESTFAMILYSETTINGS_SMT
    {
        // Methods
        //public TBL_REQUESTFAMILYSETTINGS_SMT();

        // Properties
        public bool REQUESTFAMILYSTATUS { get; set; }
        [Key]
        public int REQUESTPHONEFAMILID { get; set; }

        public virtual TBL_OrganisationMaster Organizations { get; set; }
        public int OrgId { get; set; }



    }

    #endregion

    #region TBL_RequestPhone_SMT

    public class TBL_RequestPhone_SMT
    {
        // Methods
        //public TBL_RequestPhone_SMT();

        // Properties
        public string Address { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string LabourID { get; set; }
        public string MailId { get; set; }
        public string NewAddress { get; set; }
        public string PhoneNumber { get; set; }
        [NotMapped]
        public int RequestCount { get; set; }
        [Key]
        public int RequestPhoneID { get; set; }
        public string RequestStatus { get; set; }
    }

    #endregion

    #region TBL_SERVICEPLAN_SMT

    public class TBL_SERVICEPLAN_SMT
    {
        // Methods
        //public TBL_SERVICEPLAN_SMT();

        // Properties
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        [Range(1, 0x7fffffff, ErrorMessage = "Please enter a value bigger than {0}"), Required(ErrorMessage = "Please Enter Credit Points")]
        public int? CREDITPOINTS { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFIEDDATE { get; set; }
        [Required(ErrorMessage = "Please Enter Service Plan ")]
        public string PLANNAEME { get; set; }
        [Key]
        public int SERVICEPLANID { get; set; }
        public virtual TBL_SERVICEPROVIDER_SMT serviceprovider { get; set; }
        [Required(ErrorMessage = "Please Select Service Provider")]
        public int SERVICEPROVIDERID { get; set; }
        public virtual TBL_SERVICETYPE_SMT servicetype { get; set; }
        [Required(ErrorMessage = "Please Select Service Type")]
        public int SERVICETYPEID { get; set; }
        public bool? STATUS { get; set; }
        public string VALIDITY { get; set; }
        public int VALUEOFPLAN { get; set; }
        [NotMapped]
        public string OrgName { get; set; }
        [NotMapped]
        public bool IsTelcomOperator { get; set; }
    }

    #endregion

    #region TBL_SERVICEPROVIDER_SMT

    public class TBL_SERVICEPROVIDER_SMT
    {
        // Methods
        //public TBL_SERVICEPROVIDER_SMT();

        // Properties
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFIEDDATE { get; set; }
        [Required(ErrorMessage = "Please Enter Service Provider")]
        public string SERVICEPROVIDER { get; set; }
        [Key]
        public int SERVICEPROVIDERID { get; set; }
        public bool STATUS { get; set; }
        public virtual TBL_OrganisationMaster Organizations { get; set; }
        public int OrgId { get; set; }
        public bool IsTelcomOperator { get; set; }
        [NotMapped]
        public string OrganisationName { get; set; }

    }

    #endregion

    #region TBL_SERVICETYPE_SMT

    public class TBL_SERVICETYPE_SMT
    {
        // Methods
        //public TBL_SERVICETYPE_SMT();

        // Properties
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFIEDDATE { get; set; }
        [Key]
        public int SERVICETYPEID { get; set; }
        [Required(ErrorMessage = "Please Enter Service type Name")]
        public string SERVICETYPENAME { get; set; }
        public bool? STATUS { get; set; }
    }

    #endregion

    #region TBL_Sponsor_Notifications

    public class TBL_Sponsor_Notifications
    {
        // Methods
        //public TBL_Sponsor_Notifications();

        // Properties
        [DisplayFormat(DataFormatString = "{dd-MMM-yyyy }", ApplyFormatInEditMode = true)]
        public DateTime? CREATEDDATE { get; set; }
        public int DonateID { get; set; }
        [DefaultValue(false)]
        public bool IsCourrierconfirmation { get; set; }
        [DefaultValue(false)]
        public bool IsPhoneAcceptedByAdmin { get; set; }
        [DefaultValue(false)]
        public bool IsPhoneAssignedToLabour { get; set; }
        [DefaultValue(false)]
        public bool IsPhoneConfirmation { get; set; }
        [Key]
        public long NotifyID { get; set; }
        public int UserID { get; set; }
    }


    #endregion

    #region TBL_SPONSOROTHERDONATION_SMT

    public class TBL_SPONSOROTHERDONATION_SMT
    {
        // Methods
        //public TBL_SPONSOROTHERDONATION_SMT();

        // Properties
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Required(ErrorMessage = "Please Enter Description"), StringLength(0x3e8, ErrorMessage = "Maximum Character Length is 1000")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter Amount")]
        public decimal DonateAmount { get; set; }
        [Required(ErrorMessage = "Please Select Donate Type")]
        public string DonateType { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Key]
        public long SponsorDonateId { get; set; }
        public int UserId { get; set; }

        public int NoofUsers { get; set; }
        public decimal TotalAmount { get; set; }
        public bool AutoReneval { get; set; }
        public string PaymentStatus { get; set; }
        public string p_id { get; set; }
    }


    #endregion

    #region TBL_TERMSANDCONDITION_SMT

    public class TBL_TERMSANDCONDITION_SMT
    {
        // Methods
        //public TBL_TERMSANDCONDITION_SMT();

        // Properties
        public string CREATEDBY { get; set; }
        public DateTime? CREATEDDATE { get; set; }
        [AllowHtml]
        public string FullDecription { get; set; }
        public string ShortDescription { get; set; }
        public bool STATUS { get; set; }
        [Key]
        public long TermsandConditionId { get; set; }
    }

    #endregion

    #region TBL_TESTIMONIAL_SMT

    public class TBL_TESTIMONIAL_SMT
    {
        // Methods
        //public TBL_TESTIMONIAL_SMT();

        // Properties
        [AllowHtml, Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter Designation")]
        public string Designation { get; set; }
        public bool Homecontent { get; set; }
        public string Image { get; set; }
        public string Mp4filename { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        public string Oggfilename { get; set; }
        public bool? Status { get; set; }
        [Key]
        public int TestimonialId { get; set; }
        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }
        public string videoFile { get; set; }
        public string Webmfilename { get; set; }
        public DateTime? PostedDate { get; set; }

    }


    #endregion

    #region TBL_VOUCHER_SMT

    public class TBL_VOUCHER_SMT
    {
        // Methods
        //public TBL_VOUCHER_SMT();

        // Properties
        [Required(ErrorMessage = "Please Enter Voucher Code")]
        public string CODES { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public string CREATEDBY { get; set; }
        public bool? IsVoucherAssigned { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFIEDDATE { get; set; }
        public virtual TBL_SERVICEPLAN_SMT serviceplan { get; set; }
        [Required(ErrorMessage = "Please select Service Plan")]
        public int SERVICEPLANID { get; set; }

        public virtual TBL_SERVICEPROVIDER_SMT serviceprovider { get; set; }
        [Required(ErrorMessage = "Please Select Service Provider")]
        public int SERVICEPROVIDERID { get; set; }

        public string VoucherImage { get; set; }

        [NotMapped]
        public string ServicePlanName { get; set; }

        [NotMapped]
        public string ProviderName { get; set; }

        [NotMapped]
        public string servicetype { get; set; }
        public bool STATUS { get; set; }
        [NotMapped]
        public string Totalvouchercount { get; set; }
        [NotMapped]
        public string Voucheravilablecount { get; set; }
        [Key]
        public int VOUCHERID { get; set; }
        [NotMapped]
        public string Voucherusedcount { get; set; }
        [NotMapped]
        public bool VoucherImageStatus { get; set; }
        [NotMapped]
        public string OrgName { get; set; }
        [NotMapped]
        public bool IsTelcomOperator { get; set; }
        [NotMapped]
        public string Description { get; set; }
        [NotMapped]
        public string DonateType { get; set; }
        [NotMapped]
        public int DonateAmount { get; set; }
        [NotMapped]
        public string LabourId { get; set; }
        [NotMapped]
        public int NoofUsers { get; set; }
        [NotMapped]
        public decimal TotalAmount { get; set; }
        [NotMapped]
        public bool AutoReneval { get; set; }
    }


    #endregion

    #region TestResult

    public class TestResult
    {
        // Methods
        //public TestResult();

        // Properties
        public int AnswerID { get; set; }
        public int CourseID { get; set; }
        public int? CreditPoints { get; set; }
        public bool? IsCorrect { get; set; }
        public bool? IsSubmitted { get; set; }
        public string LabourID { get; set; }
        public int QuestionID { get; set; }
        [Key]
        public int TestID { get; set; }
    }


    #endregion

    #region VoucherCount

    public class VoucherCount
    {
        public string SERVICEPROVIDER { get; set; }
        public string SERVICETYPENAME { get; set; }
        public string PointsLabourEarned { get; set; }
        public string PointsInVoucher { get; set; }
        public string PointsRequired { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public string OrgName { get; set; }

    }


    #endregion

    #region VoucherPoints

    public class VoucherPoints
    {
        public string LabourId { get; set; }
        public int Points { get; set; }
    }


    #endregion

    #region TBL_OrganisationMaster

    public class TBL_OrganisationMaster
    {
        // Methods
        //public TBL_PLAN_SMT();

        // Properties
        [Key]
        public int OrgId { get; set; }
        [Required(ErrorMessage = "Please Enter Organization"), MaxLength(250)]

        public string OrganisationName { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Number")]
        [MaxLength(15)]
        public string OrganisationContactno { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [MaxLength(250)]
        public string OrganisationAddress1 { get; set; }

        public string OrganisationAddress2 { get; set; }

        [Required(ErrorMessage = "Please Enter PinCode")]
        [MaxLength(15)]
        public string Organisationpincode { get; set; }

        [Required(ErrorMessage = "Please Enter Organization Code")]
        [MaxLength(30)]
        public string OrganisationCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required(ErrorMessage = "Please Select the City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Select the State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Select the Country")]
        public string Country { get; set; }
    }


    #endregion

    #region TBL_HealthAndSafety

    public class TBL_HealthAndSafety
    {
        // Methods
        //public TBL_PLAN_SMT();

        [Key]
        public int HSId { get; set; }

        [MaxLength(50)]
        public string LabourID { get; set; }

        [MaxLength(500)]
        public string ImagePath { get; set; }

        [MaxLength(500)]
        public string AudioPath { get; set; }

        [MaxLength(500)]
        public string Comments { get; set; }

        public int RewardPoint { get; set; }

        public DateTime PostedDate { get; set; }

        public bool Approve { get; set; }

        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public string ImageName { get; set; }
        [NotMapped]
        public string ReportParameterType { get; set; }

        
        [NotMapped]
        public string AudioName { get; set; }

        [NotMapped]
        public string OrgName { get; set; }

        [NotMapped]
        public int OrgId { get; set; }

        [NotMapped]
        public DateTime? PostedDateView { get; set; }
    }


    #endregion

    #region ExportLabours----- Not Mapped

    [NotMapped]
    public class ExportLabours
    {
        // [Required(ErrorMessage = "Please Select From Date")]
        public string StrFromDate { get; set; }
        public DateTime? FromDate { get; set; }
        // [Required(ErrorMessage = "Please Select To Date")]
        public string StrToDate { get; set; }
        public DateTime? ToDate { get; set; }
        //[Required(ErrorMessage = "Please Select Organization")]
        public string OrgName { get; set; }

    }

    #endregion

    #region TBL_CategoryMaster

    public class TBL_CategoryMaster
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Please Enter Category ")]
        public string CategoryName { get; set; }

        public virtual TBL_OrganisationMaster Organizations { get; set; }
        public int OrgId { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select Organization")]
        public string OrgName { get; set; }

    }


    #endregion

    #region TBL_SubCategoryMaster

    public class TBL_SubCategoryMaster
    {
        [Key]
        public int SubCategoryId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Please Enter Sub Category  ")]
        public string SubCategoryName { get; set; }

        public virtual TBL_CategoryMaster Category { get; set; }
        [Required(ErrorMessage = "Please Select Category  ")]
        public int CategoryId { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

        [NotMapped]
        //  [Required(ErrorMessage = "Please select Category")]
        public string CategoryName { get; set; }

        [NotMapped]
        public string OrgName { get; set; }

    }

    #endregion

    #region TBL_CountryMaster

    public class TBL_CountryMaster
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string CountryName { get; set; }
    }

    #endregion

    #region RewardPointMaster

    public class TBL_RewardPointMaster
    {
        [Key]
        public int RewardPointId { get; set; }

        [Required(ErrorMessage = "Please Enter Reward point value")]
        public int RewardPoint { get; set; }

        public char CountryName { get; set; }
    }

    #endregion

    #region Table Host Name

    public class TBL_HostName
    {
        [Key]
        public int HostId { get; set; }

        public string HostName { get; set; }
    }



    #endregion

    #region  Push Notification Message

    public class TBL_PushNotficationMsg
    {
        [Key]
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Please Enter Message Name")]
        public string MsgName { get; set; }

        [Required(ErrorMessage = "Please Enter Message")]
        public string PushMessage { get; set; }

        public virtual TBL_OrganisationMaster Organizations { get; set; }
        public int OrgId { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select Organization")]
        public string OrgName { get; set; }

        [MaxLength(30)]
        public string CreatedBy { get; set; }

        [MaxLength(30)]
        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

    }

    #endregion

    #region  Push Notification Group Master

    public class TBL_NotificationGroupMaster
    {
        [Key]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Please Enter Group ")]
        [MaxLength(200)]
        public string GroupName { get; set; }

        public virtual TBL_OrganisationMaster Organizations { get; set; }
        public int OrgId { get; set; }

        [NotMapped]
        public string OrgName { get; set; }

        [MaxLength(30)]
        public string CreatedBy { get; set; }

        [MaxLength(30)]
        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Members { get; set; }

        [NotMapped]
        public string MsgName { get; set; }
    }
    #endregion

    #region  Push Notification Group List

    public class TBL_NotificationGroupList
    {
        [Key]
        public int GroupListId { get; set; }

        public virtual TBL_NotificationGroupMaster NotificationGroupMaster { get; set; }
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Please select Emirates ID")]
        [MaxLength(30)]
        public string LabourId { get; set; }

        [NotMapped]
        public string OrgName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select Group Name")]
        public string GroupName { get; set; }

        [NotMapped]
        public string LabourName { get; set; }

    }

    #endregion

    #region Reports Model

    [NotMapped]
    public class ReportModel
    {
        public string ReportId { get; set; }
        public string LabourId { get; set; }
        public string LabourName { get; set; }
        public string Email { get; set; }
        public string CourseName { get; set; }
        public string CourseTypeId { get; set; }  //CourseTypeName
        public string CourseTypeName { get; set; }
        public string CourseId { get; set; }
        public string CourseAttended { get; set; }
        public string OrgName { get; set; }
        public string OrgId { get; set; }
        public string AnswerCorrect { get; set; }
        public string TotalCredit { get; set; }
    }

    #endregion

    #region VoucherAssignedToLabour

    //VoucherAssignedToLabou
    public class VoucherAssignedToLabour
    {
        [Key]
        public int VoucherAssignID { get; set; }

        public int VOUCHERID { get; set; }

        public string LabourID { get; set; }

        public DateTime AssignedDate { get; set; }
    }



    #endregion

    #region Table Country Master

    // TBL_Countries
    public class TBL_Countries
    {
        [Key]
        public int CountryId { get; set; }
        public string SortName { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }

    #endregion

    #region Table Satate Master


    public class TBL_States
    {
        [Key]
        public Int64 StateId { get; set; }
        public string StateName { get; set; }
        public Int64 CountryId { get; set; }
    }

    #endregion

    #region Table City Master

    public class TBL_Cities
    {
        [Key]
        public Int64 CityId { get; set; }
        public string CityName { get; set; }
        public Int64 StateId { get; set; }
    }

    #endregion

    #region TBL_CourseContentsMaster

    public class TBL_CourseContentsMaster
    {
        [Key]
        public int CourseContentId { get; set; }

        public string ImageName { get; set; }

        public string AudioName { get; set; }

        public virtual TBL_OrganisationMaster Organizations { get; set; }
        public int OrgId { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

        [NotMapped]
        public string FolderName { get; set; }

        [NotMapped]
        public string FolderNameExist { get; set; }


        [NotMapped]
        public string OrgName { get; set; }

        [NotMapped]
        public bool IsExist { get; set; }

    }


    #endregion

    #region TBL_HelpDeskMaster

    public class TBL_HelpDeskMaster
    {
        [Key]
        public Int64 HelpDeskId { get; set; }

        public int OrgId { get; set; }

        public string EmiratesID { get; set; }

        [Required(ErrorMessage = "Please Enter The Issue Type")]
        public string IssueType { get; set; }

        [Required(ErrorMessage = "Please Select The Priority")]
        public string IssuePriority { get; set; }

        public string UserType { get; set; }

        [Required(ErrorMessage = "Please Enter The Description")]
        public string Description { get; set; }

        public string FileName { get; set; }

        public string IssueStatus { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

        public string TokenID { get; set; }

        [NotMapped]
        public string Responsible { get; set; }

        [NotMapped]
        public string OrgName { get; set; }

        [NotMapped]
        public string StrEDC { get; set; }
        [NotMapped]
        public string StrCreteatedDate { get; set; }
    }

    public class TBL_HelpDeskMasterLog
    {
        [Key]
        public Int64 LogId { get; set; }

        public Int64 HelpDeskId { get; set; }

        public string Description { get; set; }

        public string IssueStatus { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

    }


    #endregion

    #region ZenHelpDesk Ticket

    public class Ticket1
    {
        public int id { get; set; }
        public string url { get; set; }
        public string external_id { get; set; }
        public string type { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public string recipient { get; set; }
        public int requester_id { get; set; }
        public int submitter_id { get; set; }
        public int assignee_id { get; set; }
        public int organization_id { get; set; }
        public int group_id { get; set; }
    }
    public class NewTicket
    {
        public Ticket ticket { get; set; }
    }


    public class Ticket
    {
        [Key]
        public Int64 Id { get; set; }

        [Required(ErrorMessage = "Please Enter Subject")]
        public string subject { get; set; }
        [Required(ErrorMessage = "Please Enter Comment")]
        public string comment { get; set; }
        [Required(ErrorMessage = "Please Select the Priority")]
        public string priority { get; set; }
        [Required(ErrorMessage = "Please Enter Type")]
        public string type { get; set; }
        //[Required(ErrorMessage = "Please Enter Status")]
        public string status { get; set; }
        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
    //public class Comment
    //{
    //    public string value { get; set; }
    //}

    #endregion

    #region PayTab


    public class PayTab
    {
        [Key]
        public Int64 Id { get; set; }

        public string subject { get; set; }

        public string comment { get; set; }

        public string priority { get; set; }

        public string type { get; set; }
        //[Required(ErrorMessage = "Please Enter Status")]
        public string status { get; set; }
        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }


    public class PayTabsMakePaymentResponse
    {
        public string message { get; set; }
        public string response { get; set; }
        public string error_code { get; set; }
        public string payment_url { get; set; }
        public string api_key { get; set; }
        //public string p_id { get; set; }
        //public string result { get; set; }
    }

    public class payTabReturnArray
    {
        public string result { get; set; }
        public string response_code { get; set; }
        public string payment_url { get; set; }
        public string p_id { get; set; }
    }

    public class payTabCompletionReturnArray
    {
        public string result { get; set; }
        public string response_code { get; set; }
        public string pt_invoice_id { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string reference_no { get; set; }
        public string transaction_id { get; set; }

    }

    #endregion

    #region User AED Amount 

    public class Tbl_HiddenSponsorDonateAmount
    {
        [Key]
        public int Id { get; set; }

        public Decimal Amount { get; set; }

    }
    public class Tbl_UserAmount
    {
        [Key]
        public int Id { get; set; }

        public Decimal Amount { get; set; }

        public string Currency { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool status { get; set; }

    }

    public class Tbl_PayTabDetails
    {
        [Key]
        public int Id { get; set; }

        public string merchant_email { get; set; }
        public string secret_key { get; set; }
        public string currency { get; set; }
        public string site_url { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string country_shipping { get; set; }
        public string cms_with_version { get; set; }
        public bool status { get; set; }
    }
    public class TBL_CourseContentsFileMaster
    {
        [Key]
        public int CourseContentId { get; set; }
         
        public string FileName { get; set; }
      
        public virtual TBL_CourseContentFolderMaster CourseContentFolder { get; set; }
        public int CourseContentFolderId { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }        

        [NotMapped]
        public string FolderNameExist { get; set; } 

        [NotMapped]
        public string OrgName { get; set; } 

        [NotMapped]
        public bool FileTypes { get; set; }

        [NotMapped]
        public string FolderName { get; set; }
          [NotMapped]
        public int OrgId { get; set; }

    }
    public class TBL_CourseContentFolderMaster
    {
        [Key]
        public int CourseContentFolderId { get; set; }

        public string FolderName { get; set; }

        public string FileType { get; set; }

        public virtual TBL_OrganisationMaster Organizations { get; set; }
        public int OrgId { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }
        [NotMapped]
        public string FolderNameExist { get; set; }
        [NotMapped]
        public string OrgName { get; set; }
        [NotMapped]
        public bool FileTypes { get; set; }
    }


    #endregion

    #region FancyBox Player

    public class Tbl_FancyBoxPlayer
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileFrom { get; set; }
    }

    #endregion

    public class QueueModel
    {
        public List<QueuePriorityOrder> queuePriorityOrder { get; set; }
    }
    public class QueuePriorityOrder
    {
        public string[] CourseID { get; set; }
        public string[] QueueOrder { get; set; }
    }
}
