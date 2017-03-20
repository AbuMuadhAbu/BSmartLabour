using SmartLabours.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace SmartLabours.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
//    public class Answer
//{
//    // Properties
//    public string AnswerDesc { get; set; }

//    [Key]
//    public int AnswerID { get; set; }

//    public bool IsCorrect { get; set; }

//    public virtual Question ques { get; set; }

//    public int QuestionID { get; set; }
//}
////    [NotMapped]
////public class ChangePasswordModel
////{
////    // Properties
////    [Required(ErrorMessage="Please Enter Confirm Password"), DataType(DataType.Password), Display(Name="Confirm password"), Compare("NewPassword", ErrorMessage="The new password and confirmation password do not match.")]
////    public string ConfirmPassword { get; set; }

////    [StringLength(15, ErrorMessage="The {0} must be at least {2} characters long.", MinimumLength=6), DataType(DataType.Password), Display(Name="New password"), Required(ErrorMessage="Please Enter New Password")]
////    public string NewPassword { get; set; }

////    [DataType(DataType.Password), Display(Name="Current password"), Required(ErrorMessage="Please Enter Old Password")]
////    public string OldPassword { get; set; }
////}
//    public class Mailing
//{
//    // Fields
//    private string CC = string.Empty;
//    private string Msg = string.Empty;

//    // Methods
//    public string Email_LoginWise(string mailid, string subject, string messageBody)
//    {
//        try
//        {
//            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
//            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
//            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
//            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
//            SmtpClient client = new SmtpClient(host, port);
//            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
//            string password = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
//            client.Credentials = new NetworkCredential(userName, password);
//            MailMessage message = new MailMessage {
//                From = new MailAddress(address)
//            };
//            message.To.Add(new MailAddress(mailid));
//            message.Subject = subject;
//            message.Priority = MailPriority.Normal;
//            message.IsBodyHtml = true;
//            message.Body = messageBody;
//            SmtpClient client2 = new SmtpClient {
//                Host = host,
//                EnableSsl = true
//            };
//            NetworkCredential credential = new NetworkCredential(userName, password);
//            client2.UseDefaultCredentials = true;
//            client2.Credentials = credential;
//            client2.Port = port;
//            client2.Send(message);
//        }
//        catch (Exception exception)
//        {
//            throw exception;
//        }
//        return this.Msg;
//    }

//    public string Email_Wise(string useremail, string subject, string username, string password)
//    {
//        string host = ConfigurationSettings.AppSettings["LHost"].ToString();
//        int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
//        string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
//        string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
//        SmtpClient client = new SmtpClient(host, port);
//        string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
//        string str5 = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
//        client.Credentials = new NetworkCredential(userName, str5);
//        MailMessage message = new MailMessage {
//            From = new MailAddress(address)
//        };
//        message.To.Add(new MailAddress(useremail));
//        message.Subject = subject;
//        message.Priority = MailPriority.Normal;
//        message.IsBodyHtml = true;
//        message.Body = this.getbodyEmailForgetpassword(username, password, useremail).ToString();
//        SmtpClient client2 = new SmtpClient {
//            Host = host,
//            EnableSsl = true
//        };
//        NetworkCredential credential = new NetworkCredential(userName, str5);
//        client2.UseDefaultCredentials = true;
//        client2.Credentials = credential;
//        client2.Port = port;
//        client2.Send(message);
//        this.Msg = "true";
//        return this.Msg;
//    }

//    public StringBuilder getbody(string subject, string username, string password, string emailid)
//    {
//        StringBuilder builder = new StringBuilder();
//        builder.Append("");
//        string str = ConfigurationManager.AppSettings["MailLogo"].ToString();
//        builder.Append("<table width=\"550\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
//        builder.Append("<tr>");
//        builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + username + ",</b></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
//        builder.Append("The following are the new login details of Smart Labour <br /><br />");
//        builder.Append("<b>Username<b style=\"padding:0px 8px 0px 8px;\">:</b>" + emailid + "<br />");
//        builder.Append(" Password<b style=\"padding:0px 8px 0px 9px;\">:</b>" + password + "<br /></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr><td colspan=\"2\" Style=\"height:40px\" style=\"padding: 0px 19px;\" ><a  style=\"padding: 0px 19px;\" href='" + ConfigurationManager.AppSettings["login"].ToString() + "'>Click here to login</a></td></tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:28px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Regards,<br/> " + ConfigurationManager.AppSettings["MailRegards"].ToString() + " <br /></td>");
//        builder.Append("</tr>");
//        builder.Append("</table>");
//        return builder;
//    }

//    public StringBuilder getbodycontactus(string subject, string username)
//    {
//        StringBuilder builder = new StringBuilder();
//        builder.Append("");
//        string str = ConfigurationManager.AppSettings["MailLogo"].ToString();
//        builder.Append("<table width=\"550\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
//        builder.Append("<tr>");
//        builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + username + ",</b></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
//        builder.Append("<b><b style=\"padding:0px 8px 0px 8px;\"></b>Thank you! Your message has been successfully sent. We will contact you very soon..<br />");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:28px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Regards,<br/> " + ConfigurationManager.AppSettings["MailRegards"].ToString() + " <br /></td>");
//        builder.Append("</tr>");
//        builder.Append("</table>");
//        return builder;
//    }

//    public StringBuilder getbodyEmail(string Username, string EmailID, string pwd)
//    {
//        StringBuilder builder = new StringBuilder();
//        builder.Append("");
//        string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
//        builder.Append("<table width=\"550\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
//        builder.Append("<tr>");
//        builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + Username + ",</b></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
//        builder.Append("Following details is your Smart Labour login accounts.<br /><br />");
//        builder.Append("<b>Email Id<b style=\"padding:0px 12px 0px 9px;\">:</b>" + EmailID + "<br />");
//        builder.Append("Password<b style=\"padding:0px 12px 0px 9px;\">:</b>" + pwd + "<br /></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Regards,<br />Smartlabours Team</td>");
//        builder.Append("</tr>");
//        builder.Append("</table>");
//        return builder;
//    }

//    public StringBuilder getbodyEmailForgetpassword(string Username, string pwd, string EmailID)
//    {
//        StringBuilder builder = new StringBuilder();
//        builder.Append("");
//        string str = ConfigurationSettings.AppSettings["MailLogo"].ToString();
//        builder.Append("<table width=\"550\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
//        builder.Append("<tr>");
//        builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:15px 0px 5px 10px;font:normal 12px Arial;color:#000;\"><b>Dear " + Username + ",</b></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
//        builder.Append("Following details is your SmartLabours login accounts.<br /><br />");
//        builder.Append("<b>Email Id<b style=\"padding:0px 12px 0px 9px;\">:</b>" + EmailID + "<br /><br>");
//        builder.Append("Password<b style=\"padding:0px 12px 0px 9px;\">:</b>" + pwd + "<br /></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Regards,<br />Smartlabours Team</td>");
//        builder.Append("</tr>");
//        builder.Append("</table>");
//        return builder;
//    }

//    public StringBuilder getbodyforLAbour(string subject, string Courrierdetails)
//    {
//        StringBuilder builder = new StringBuilder();
//        builder.Append("");
//        string str = ConfigurationManager.AppSettings["MailLogo"].ToString();
//        builder.Append("<table width=\"550\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
//        builder.Append("<tr>");
//        builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
//        builder.Append("<b>Courrier Details<b style=\"padding:0px 8px 0px 8px;\">:</b>" + Courrierdetails + "<br />");
//        builder.Append("</tr>");
//        builder.Append("<tr><td colspan=\"2\" Style=\"height:40px\" style=\"padding: 0px 19px;\" ><a  style=\"padding: 0px 19px;\" href='" + ConfigurationManager.AppSettings["login"].ToString() + "'>Click here to login</a></td></tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:28px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Regards,<br/> " + ConfigurationManager.AppSettings["MailRegards"].ToString() + " <br /></td>");
//        builder.Append("</tr>");
//        builder.Append("</table>");
//        return builder;
//    }

//    public StringBuilder getbodyforsponsor(string subject, string Courrierdetails)
//    {
//        StringBuilder builder = new StringBuilder();
//        builder.Append("");
//        string str = ConfigurationManager.AppSettings["MailLogo"].ToString();
//        builder.Append("<table width=\"550\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"border:#064669 1px solid;font:normal 12px Arial; color:#000;\">");
//        builder.Append("<tr>");
//        builder.Append("<td style=\"padding:15px 0 15px 20px;background:#FFFFFF;\"><p align=\"left\" style=\"width:200px; float:left; margin:0px; padding:0px 2px 2px;\"><img src=" + str + "></p></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" height=\"15\" bgcolor=\"#043550\" align=\"center\" style=\"padding:5px 10px 5px 7px;\"></td>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("</tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:5px 0px 0px 20px;font:normal 12px Arial;color:#000;\">");
//        builder.Append("<b>Courrier Details<b style=\"padding:0px 8px 0px 8px;\">:</b>" + Courrierdetails + "<br />");
//        builder.Append("</tr>");
//        builder.Append("<tr><td colspan=\"2\" Style=\"height:40px\" style=\"padding: 0px 19px;\" ><a  style=\"padding: 0px 19px;\" href='" + ConfigurationManager.AppSettings["login"].ToString() + "'></a></td></tr>");
//        builder.Append("<tr>");
//        builder.Append("<td colspan=\"2\" style=\"padding:28px 0px 20px 10px;font:normal 12px Arial;color:#000;\">Regards,<br/> " + ConfigurationManager.AppSettings["MailRegards"].ToString() + " <br /></td>");
//        builder.Append("</tr>");
//        builder.Append("</table>");
//        return builder;
//    }

//    public void SendMail(string Username, string emailID, string Passwrd)
//    {
//        try
//        {
//            string subject = "";
//            string messageBody = "";
//            subject = "Login Details - Smartlabours";
//            messageBody = this.getbodyEmail(Username, emailID, Passwrd).ToString();
//            if (this.Email_LoginWise(emailID, subject, messageBody) == "true")
//            {
//            }
//        }
//        catch
//        {
//        }
//    }

//    public string SendMailforchangepassword(string emailid, string subject, string username, string password)
//    {
//        try
//        {
//            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
//            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
//            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
//            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
//            SmtpClient client = new SmtpClient(host, port);
//            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
//            string str5 = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
//            client.Credentials = new NetworkCredential(userName, str5);
//            MailMessage message = new MailMessage {
//                From = new MailAddress(address)
//            };
//            message.To.Add(new MailAddress(emailid));
//            message.Subject = subject;
//            message.Priority = MailPriority.Normal;
//            message.IsBodyHtml = true;
//            message.Body = this.getbody(subject, username, password, emailid).ToString();
//            SmtpClient client2 = new SmtpClient {
//                Host = host,
//                EnableSsl = true
//            };
//            NetworkCredential credential = new NetworkCredential(userName, str5);
//            client2.UseDefaultCredentials = true;
//            client2.Credentials = credential;
//            client2.Port = port;
//            client2.Send(message);
//            this.Msg = "true";
//            return this.Msg;
//        }
//        catch
//        {
//            return null;
//        }
//    }

//    public string SendMailforContactus(string emailid, string subject, string username)
//    {
//        try
//        {
//            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
//            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
//            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
//            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
//            SmtpClient client = new SmtpClient(host, port);
//            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
//            string password = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
//            client.Credentials = new NetworkCredential(userName, password);
//            MailMessage message = new MailMessage {
//                From = new MailAddress(address)
//            };
//            message.To.Add(new MailAddress(emailid));
//            message.Subject = subject;
//            message.Priority = MailPriority.Normal;
//            message.IsBodyHtml = true;
//            message.Body = this.getbodycontactus(subject, username).ToString();
//            SmtpClient client2 = new SmtpClient {
//                Host = host,
//                EnableSsl = true
//            };
//            NetworkCredential credential = new NetworkCredential(userName, password);
//            client2.UseDefaultCredentials = true;
//            client2.Credentials = credential;
//            client2.Port = port;
//            client2.Send(message);
//            this.Msg = "true";
//            return this.Msg;
//        }
//        catch
//        {
//            return null;
//        }
//    }

//    public string SendMailforLabourcourrier(string emailid, string subject, string Courrierdetails)
//    {
//        try
//        {
//            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
//            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
//            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
//            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
//            SmtpClient client = new SmtpClient(host, port);
//            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
//            string password = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
//            client.Credentials = new NetworkCredential(userName, password);
//            MailMessage message = new MailMessage {
//                From = new MailAddress(address)
//            };
//            message.To.Add(new MailAddress(emailid));
//            message.Subject = subject;
//            message.Priority = MailPriority.Normal;
//            message.IsBodyHtml = true;
//            message.Body = this.getbodyforLAbour(subject, Courrierdetails).ToString();
//            SmtpClient client2 = new SmtpClient {
//                Host = host,
//                EnableSsl = true
//            };
//            NetworkCredential credential = new NetworkCredential(userName, password);
//            client2.UseDefaultCredentials = true;
//            client2.Credentials = credential;
//            client2.Port = port;
//            client2.Send(message);
//            this.Msg = "true";
//            return this.Msg;
//        }
//        catch
//        {
//            return null;
//        }
//    }

//    public string SendMailforSponsorcourrier(string emailid, string subject, string Courrierdetails)
//    {
//        try
//        {
//            string host = ConfigurationSettings.AppSettings["LHost"].ToString();
//            int port = Convert.ToInt32(ConfigurationSettings.AppSettings["LPort"].ToString());
//            string str2 = ConfigurationSettings.AppSettings["LToMailId"].ToString();
//            string address = ConfigurationSettings.AppSettings["LMailId"].ToString();
//            SmtpClient client = new SmtpClient(host, port);
//            string userName = ConfigurationSettings.AppSettings["LMailId"].ToString();
//            string password = ConfigurationSettings.AppSettings["LMailPassword"].ToString();
//            client.Credentials = new NetworkCredential(userName, password);
//            MailMessage message = new MailMessage {
//                From = new MailAddress(address)
//            };
//            message.To.Add(new MailAddress(emailid));
//            message.Subject = subject;
//            message.Priority = MailPriority.Normal;
//            message.IsBodyHtml = true;
//            message.Body = this.getbodyforsponsor(subject, Courrierdetails).ToString();
//            SmtpClient client2 = new SmtpClient {
//                Host = host,
//                EnableSsl = true
//            };
//            NetworkCredential credential = new NetworkCredential(userName, password);
//            client2.UseDefaultCredentials = true;
//            client2.Credentials = credential;
//            client2.Port = port;
//            client2.Send(message);
//            this.Msg = "true";
//            return this.Msg;
//        }
//        catch
//        {
//            return null;
//        }
//    }
//        public class PhoneAsssignedToLabour
//{
//    // Properties
//    [DisplayFormat(DataFormatString="{0:MMMM dd, yyyy}", ApplyFormatInEditMode=true)]
//    public DateTime? AssignedDate { get; set; }

//    [AllowHtml]
//    public string CourierDetail { get; set; }

//    [DisplayFormat(DataFormatString="{0:MMMM dd, yyyy}", ApplyFormatInEditMode=true)]
//    public DateTime? DeliveredDate { get; set; }

//    [NotMapped]
//    public string disbuteFeedBack { get; set; }

//    public int DonateID { get; set; }

//    public bool? IsExpiredPhoneAssigned { get; set; }

//    public bool? IsLabourReceivedPhone { get; set; }

//    [DefaultValue(false)]
//    public bool? IsPhoneAccepted { get; set; }

//    [DefaultValue(false)]
//    public bool IsTimeExpired { get; set; }

//    public string LabourID { get; set; }

//    public virtual DonatePhone objdonate { get; set; }

//    [NotMapped]
//    public virtual Labour objlabour { get; set; }

//    [Key]
//    public int PhoneAssignedID { get; set; }

//    [NotMapped]
//    public string PhoneExpiryDays { get; set; }

//    [NotMapped]
//    public string PhoneImageURL { get; set; }

//    public int RequestPhoneID { get; set; }

//    [NotMapped]
//    public string RequestStatus { get; set; }
//}
//        public class Question
//{
//    // Properties
//    public int CourseID { get; set; }

//    public int CreditPoints { get; set; }

//    public string QuestionDesc { get; set; }

//    [Key]
//    public int QuestionID { get; set; }
//}
//public class RequestPhone
//{
//    // Properties
//    [Required(ErrorMessage="Please Enter the Address")]
//    public string Address { get; set; }

//    public string AlternatePhoneNumber { get; set; }

//    [Required(ErrorMessage="Please Enter the Emirates ID")]
//    public string LabourID { get; set; }

//    [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage="Please enter correct Email"), Required(ErrorMessage="Please Enter Email ID"), DataType(DataType.EmailAddress, ErrorMessage="Please enter correct Email ID"), MaxLength(50)]
//    public string MailId { get; set; }

//    public string NewAddress { get; set; }

//    [Required(ErrorMessage="Please Enter the Phone No")]
//    public string PhoneNumber { get; set; }

//    [NotMapped]
//    public int RequestCount { get; set; }

//    public DateTime? RequestedDate { get; set; }

//    [Key]
//    public int RequestPhoneID { get; set; }

//    [NotMapped]
//    public bool Requestsettings { get; set; }

//    public string RequestStatus { get; set; }
//}


//} 

}
