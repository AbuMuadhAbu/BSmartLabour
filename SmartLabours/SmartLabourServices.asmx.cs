using Microsoft.Practices.EnterpriseLibrary.Data;
using SmartLabours.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Services;
using System.Data.Entity.Validation;
using SmartLabours.Common;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using SmartLabours.Controllers;
using System.Security.Policy;
using System.Web.Mvc;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

//namespace SmartLabours
//{
/// <summary>
/// Summary description for SmartLabourServices
/// </summary>
//[WebService(Namespace = "http://tempuri.org/")]
//[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
//public class SmartLabourServices : System.Web.Services.WebService
//{

//    [WebMethod]
//    public string HelloWorld()
//    {
//        return "Hello World";
//    }
//}
//}

namespace SmartLabours
{
    [ServiceContract]
    public interface ISmartLabourServices
    {
        // Methods
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "IsPhoneAvailable/{LabourID}/{IsAccepted}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string AcceptPhone(string LabourID, string IsAccepted);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ChangePassword/{LabourID}/{OldPassword}/{Password}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string ChangePassword(string LabourID, string OldPassword, string Password);

        [OperationContract, WebGet(UriTemplate = "CheckLabourEmailId/{EmailID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string CheckLabourEmailID(string EmailID);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CheckLabourID/{LabourID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string CheckLabourID(string LabourID);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CheckRequestAvailability/{LabourID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string CheckRequestAvailability(string LabourID);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CoursePages/{CourseID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ServiceCourse> CoursePages(string CourseID);

        [WebGet(UriTemplate = "DisbuteTransaction/{TransactionID}/{Disbutefeedback}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string DisbuteTransaction(string TransactionID, string Disbutefeedback);

        [OperationContract, WebInvoke(Method = "GET", UriTemplate = "dowork/{LabourID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string DoWork(string LabourID);

        [WebInvoke(Method = "GET", UriTemplate = "dowork1", BodyStyle = WebMessageBodyStyle.WrappedRequest), OperationContract]
        string DoWork1();

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ForgotPassword/{LabourID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string ForgotPassword(string LabourID);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllCourses/{CourseTypeID}/{LabourID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        CourseDetail GetAllCourses(string CourseTypeID, string LabourID);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetLangPreference/{CourseTypeID}/{LabourID}/{LangPreference}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        List<ServiceCourse> GetLangPreference(string CourseTypeID, string LabourID, string LangPreference);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllCourseTypes", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<CourseType> GetAllCourseTypes();

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAnswerID/{LabourID}/{QuestionID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        int GetAnswerID(string LabourID, string QuestionID);

        [OperationContract, WebGet(UriTemplate = "GetRequestUserDetail/{LabourID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<LabourContract> GetRequestPhoneuserDetail(string LabourId);

        [OperationContract, WebGet(UriTemplate = "Transactionstatus/{LabourID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<NotificationList> GetTransactionstatus(string LabourID);

        [OperationContract, WebGet(UriTemplate = "UserDetail/{LabourID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<LabourContract> GetUserDetail(string LabourID);

        [OperationContract, WebGet(UriTemplate = "CheckRequestStatus/{LabourID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<Requestcount> GetuserRequestcount(string LabourID);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetVoucherKitty/{LabourID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ServiceVoucherKitty GetVoucherKitty(string LabourID);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Login/{LabourIDorEmail}/{Password}/{DeviceToken}/{DeviceType}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string Login(string LabourIDorEmail, string Password, string DeviceToken, string DeviceType);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "PhoneAvailableNotification/{LabourID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<PhoneAvailable> PhoneAvailableNotification(string LabourID);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "QuestionAndAnswer/{CourseID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ServiceCourse> QuestionAndAnswer(string CourseID);


        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RegisterLabour/{Name}/{Password}/{EmailID}/{PhoneNumber}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string RegisterLabour(string Name, string Password, string EmailID, string PhoneNumber);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RegisterLabourSocialMedia/{Name}/{EmailID}/{SocialType}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        String RegisterLabourSocialMedia(string Name, String EmailID, string SocialType);

        //[OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RegisterLabour/{LabourId}/{Name}/{Password}/{EmailID}/{PhoneNumber}/{DOB}/{Sex}/{Address1}/{Address2}/{Address3}/{Pincode}/{IsDisplayNameAccepted}/{TelecomOperatorID}/{OrgId}/{City}/{State}/{Country}/{CategoryId}/{SubCategoryId}/{CountryCode}/{IsOriginalEmirateId}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        //string RegisterLabour(string LabourId, string Name, string Password, string EmailID, string PhoneNumber, string DOB, string Sex, string Address1, string Address2, string Address3, string Pincode, string IsDisplayNameAccepted, string TelecomOperatorID, string OrgId, string City, string State, string Country, string CategoryId, string SubCategoryId, string CountryCode, string IsOriginalEmirateId);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateEmiratesId/{OldLabourId}/{NewEmiratesID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string UpdateEmiratesId(string OldLabourId, string NewEmiratesID);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RequestHistory/{LabourID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        List<RequestHistory> RequestHistory(string LabourID);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RequestPhone/{RequestPhoneID}/{PhoneNumber}/{AlternatePhoneNumber}/{MailId}/{LabourID}/{Address}/{NewAddress}/{RequestType}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string RequestPhone(string RequestPhoneID, string PhoneNumber, string AlternatePhoneNumber, string MailId, string LabourID, string Address, string NewAddress, string RequestType);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SetCourseFinished/{LabourID}/{CourseID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string SetCourseFinished(string LabourID, string CourseID);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SetCourseStarted/{LabourID}/{CourseID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string SetCourseStarted(string LabourID, string CourseID);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ShowAllVourchers/{LabourID}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        List<ServiceVoucher> ShowAllVourchers(string LabourID);

        [WebGet(UriTemplate = "UpdateNotificationIsRead/{LabourID}/{Type}/{TransactionID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string UpdateNotificationIsRead(string LabourID, string Type, string TransactionID);

        [OperationContract, WebGet(UriTemplate = "Signout/{LabourID}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string Signout(string LabourID);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SubmitQuestionAndAnswer/{LabourID}/{QuestionID}/{AnswerID}/{IsSubmitted}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string[] SubmitQuestionAndAnswer(string LabourID, string QuestionID, string AnswerID, string IsSubmitted);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateLabour/{LabourId}/{Name}/{EmailID}/{PhoneNumber}/{DOB}/{Sex}/{Address1}/{Address2}/{Address3}/{Pincode}/{IsDisplayNameAccepted}/{TelecomOperatorID}/{ServiceType}/{OrgId}/{City}/{State}/{Country}/{CategoryId}/{SubCategoryId}/{CountryCode}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare), OperationContract]
        string UpdateLabour(string LabourId, string Name, string EmailID, string PhoneNumber, string DOB, string Sex, string Address1, string Address2, string Address3, string Pincode, string IsDisplayNameAccepted, string TelecomOperatorID, string ServiceType, string OrgId, string City, string State, string Country, string CategoryId, string SubCategoryId, string CountryCode);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "TermsAndConditions", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<TermsCondition> TermsAndConditions();

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SubmitHealthAndSafety/{LabourId}/{Image}/{Audio}/{Comments}/", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string SubmitHealthAndSafety(string LabourId, string Image, string Audio = null, string Comments = null);


        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SubmitHealthAndSafetyReport/{LabourId}/{Image}/{Audio}/{Comments}/{ReportParamterType}/", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string SubmitHealthAndSafetyReport(string LabourId, string Image, string Audio = null, string Comments = null, string ReportParamterType = null);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetArticleList", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<TBL_Artical_SMT> GetArticleList();

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetContactUs", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<TBL_AdminCONTACTUS_SMT> GetContactUs();

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetTelecomOperators/{OrgId}/", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ServiceProvider> GetTelecomOperators(string OrgId);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SaveContactus/{FirstName}/{LastName}/{Email}/{PhoneNo}/{Comments}/", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string SaveContactus(string FirstName, string LastName, string Email, string PhoneNo, string Comments);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetOrganizationList", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<TBL_OrganisationMaster> GetOrganizationList();

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetTestimonalVideoList", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<TestimonalVideoList> GetTestimonalVideoList();

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetTestimonalVideoList1", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string GetTestimonalVideoList1();

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCategoryList/{OrgId}/", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<Category> GetCategoryList(string OrgId);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetSubCategoryList/{CategoryId}/", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<SubCategory> GetSubCategoryList(string CategoryId);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCountryList", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<Country> GetCountryList();

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "PostTestimonial/{Title}/{Name}/{Designation}/{Desccription}/{UserId}/{strImage}/{strVideo}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string PostTestimonial(string Title, string Name, string Designation, string Desccription, string UserId, string strImage, string strVideo);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "PostTestimonial1/{Title}/{Name}/{Designation}/{Desccription}/{UserId}/{strImage}/{strVideo}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string PostTestimonial1(string Title, string Name, string Designation, string Desccription, string UserId, string strImage, string strVideo);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetQuestionList/{QuestionId}/", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<QuestionList> GetQuestionList(string QuestionId);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllQuestionList/{CourseId}/{LabourId}/", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ServiceQuestionList> GetAllQuestionList(string CourseId, string LabourId);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetPushNotification/{LabourId}/", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string GetPushNotification(string LabourId);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetServiceTypeList", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<ServicePlanTypeList> GetServiceTypeList();

        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AttachFiles", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string AttachFiles();

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "AttachHealthFiles", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string AttachHealthFiles();


        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "AttachFilesTest/{LabourId}/{Comments}/", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string AttachFilesTest(string LabourId, string Comments);
        //GetServiceTypeList
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/UploadImage/{filename}")]
        void UploadImage(string filename, Stream image);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ReadMessageNotification", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        string ReadMessageNotification(ReadMessageNotification _ReadMessageNotification);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetStateList/{CountryName}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<State> GetStateList(string CountryName);

        [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCityList/{StateName}", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<City> GetCityList(string StateName);

    }

    [DataContract]
    public class ReadMessageNotification
    {
        [DataMember]
        public string LabourID { get; set; }
        [DataMember]
        public string TransactionType { get; set; }

        public List<MNotificationTransaction> MNotificationTransaction { get; set; }
    }


    [DataContract]
    public class MNotificationTransaction
    {
        [DataMember]
        public Int32 TransactionID { get; set; }
    }


    [DataContract]
    public class LabourContract
    {
        // Methods
        //public LabourContract();

        // Properties
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string Address3 { get; set; }
        [DataMember]
        public string Day { get; set; }
        [DataMember]
        public DateTime? DOB { get; set; }
        [DataMember]
        public string EmailID { get; set; }
        [DataMember]
        public bool IsDisplayNameAccepted { get; set; }
        [DataMember]
        public string LabourID { get; set; }
        [DataMember]
        public string Month { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Pincode { get; set; }
        [DataMember]
        public int SERVICEPROVIDERID { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string planType { get; set; }

        [DataMember]
        public int OrgId { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public int? CategoryId { get; set; }
        [DataMember]
        public int? SubCategoryId { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string IsOriginalEmirateId { get; set; }

        // OrgId,string City, string State, string Country, string CategoryId, string SubCategoryId, string CountryCode

    }

    //public class MvcApplication : HttpApplication
    //{
    //    // Methods
    //    public MvcApplication();
    //    protected void Application_BeginRequest(object sender, EventArgs e);
    //    protected void Application_Start();
    //    public static void RegisterGlobalFilters(GlobalFilterCollection filters);
    //    public static void RegisterRoutes(RouteCollection routes);
    //}

    [DataContract]
    public class NotificationList
    {
        // Methods
        //public NotificationList();

        // Properties
        [DataMember]
        public string BrandName { get; set; }
        [DataMember]
        public string LabourId { get; set; }
        [DataMember]
        public string IsRead { get; set; }
        [DataMember]
        public string ModelNumber { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Phonecolor { get; set; }
        [DataMember]
        public DateTime RequestDate { get; set; }
        [DataMember]
        public string Status { get; set; }
    }


    public class PhoneAvailable
    {
        // Methods
        //public PhoneAvailable();

        // Properties
        public string ModelNo { get; set; }
        public string IsRead { get; set; }
        public string PhoneImageURL { get; set; }
        public string PhoneName { get; set; }
        public string PhoneNotifiedDate { get; set; }
        public string TimeLeftinDays { get; set; }
    }


    [DataContract]
    public class Requestcount
    {
        // Methods
        //public Requestcount();

        // Properties
        [DataMember]
        public int RequestCount { get; set; }
        [DataMember]
        public bool Requestsettings { get; set; }
        [DataMember]
        public string Requeststatus { get; set; }
    }

    public class RequestHistory
    {
        // Methods
        //public RequestHistory();

        // Properties
        public string CourierDetails { get; set; }
        public string DeliveryDate { get; set; }
        public string IMEA { get; set; }
        public bool IsLabourReceivedPhone { get; set; }
        public bool IsPhoneAccepted { get; set; }
        public bool IsTimeExpired { get; set; }
        public string ModelNo { get; set; }
        public string PhoneName { get; set; }
        public string TransactionID { get; set; }
        public string TransactionStatus { get; set; }
    }

    public class ServiceCourse
    {
        // Methods
        //public ServiceCourse();

        // Properties
        public string AnswerDesc { get; set; }
        public int AnswerID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Title { get; set; }
        public string CourseStatus { get; set; }
        public string PageContent { get; set; }
        public string QuestionDesc { get; set; }
        public int QuestionID { get; set; }
        public bool IsEmbededURL { get; set; }
        public string Language { get; set; }
        public string LangPreference { get; set; }
    }

    public class CourseDetail
    {
        public string levelCompletedStatus { get; set; }
        public List<ServiceCourse> Courses { get; set; }

    }

    public class TermsCondition
    {
        // Methods
        //public TermsCondition();

        // Properties
        public string FullDecription { get; set; }
        public string ShortDescription { get; set; }
    }

    public class ServiceVoucher
    {
        // Methods
        //public ServiceVoucher();

        // Properties
        public string TalkTime { get; set; }
        public string Validity { get; set; }
        public string IsRead { get; set; }
        public string VoucherCode { get; set; }
        public string VoucherID { get; set; }
        public string IsImage { get; set; }
        public string VoucherImageURL { get; set; }

    }

    public class ServiceVoucherKitty
    {
        // Methods
        //public ServiceVoucherKitty();

        // Properties
        public string TotalCoursesStudied { get; set; }
        public string TotalfirstLevelcount { get; set; }
        public string TotalPointsEarned { get; set; }
        public string TotalPointToBeRedeemed { get; set; }
        public string VouchersEarned { get; set; }
    }

    public class ServiceProvider
    {
        public int SERVICEPROVIDERID { get; set; }
        public string SERVICEPROVIDER { get; set; }
        public bool STATUS { get; set; }
        public string CREATEDBY { get; set; }
        public string CREATEDDATE { get; set; }
        public string MODIFIEDBY { get; set; }
        public string MODIFIEDDATE { get; set; }
        public int OrgId { get; set; }
    }

    public class TestimonalVideoList
    {
        public string VideoUrl { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int OrgId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public bool Status { get; set; }
    }

    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public bool Status { get; set; }
    }

    public class Country
    {
        //  public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }

    public class State
    {
        //  public int CountryId { get; set; }
        public Int64 StateId { get; set; }
        public string StateName { get; set; }
    }

    public class City
    {
        //  public int CountryId { get; set; }
        public Int64 CityId { get; set; }
        public string CityName { get; set; }
    }

    public class QuestionList
    {
        public string CourseID { get; set; }
        public string CreditPoints { get; set; }
        public string QuestionID { get; set; }
        public string QuestionType { get; set; }
        public string QustionDesc { get; set; }
        public string AnswerDesc { get; set; }
        public int AnswerID { get; set; }
        public string Title { get; set; }
    }


    public class ServiceQuestionList
    {
        public string CourseID { get; set; }
        public string CreditPoints { get; set; }
        public string QuestionID { get; set; }
        public string QuestionType { get; set; }
        public string QustionDesc { get; set; }
        public string AnswerDesc { get; set; }
        public int AnswerID { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
    }

    public class ServicePlanTypeList
    {
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
    }


    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class SmartLabourServices : ISmartLabourServices
    {
        // Fields
        private static string connString = ConfigurationManager.ConnectionStrings["SmartLabourEntities"].ToString();
        private Database objTransDB = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(connString);

        // Methods
        public string AcceptPhone(string LabourID, string IsAccepted)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                SqlCommand command = new SqlCommand("Pro_AcceptPhone", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@LabourId", LabourID));
                command.Parameters.Add(new SqlParameter("@IsPhoneAccepted", Convert.ToBoolean(IsAccepted)));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                command.Dispose();
                connection.Dispose();
                SmartLabourEntities entities = new SmartLabourEntities();

                var labour = entities.Labours.Where(a => a.LabourID == LabourID).FirstOrDefault();
                string str4 = string.Empty;
                if (Convert.ToBoolean(IsAccepted))
                    str4 = new Mailing().SentEmail_PhoneAccept(labour.EmailID, "Smart Labour-Phone Accepted", labour.Name, IsAccepted);
                else
                    str4 = new Mailing().SentEmail_PhoneAccept(labour.EmailID, "Smart Labour-Not Accepted Phone", labour.Name, IsAccepted);

                return "Sucess";
            }
            catch
            {
                return "Failure";
            }
        }

        public string ChangePassword(string LabourID, string OldPassword, string Password)
        {
            try
            {
                if (Password.Length < 6)
                {
                    return "Enter atleast 6 charcter in password";
                }
                SmartLabourEntities entities = new SmartLabourEntities();
                Labour labour = entities.Labours.SingleOrDefault<Labour>(n => n.LabourID == LabourID);
                if (labour.Password == OldPassword)
                {
                    labour.Password = Password;
                    labour.ConfirmPassword = Password;
                    labour.OrgName = "Dummy";
                    entities.SaveChanges();
                    return "SUCCESS";
                }
                //else
                //{
                return "Incorrect Old Password.";
                //}
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                return "Incorrect format of Passwords.";
            }
        }

        public string CheckLabourEmailID(string EmailID)
        {
            SmartLabourEntities entities = new SmartLabourEntities();
            if ((from n in entities.Labours
                 where n.EmailID == EmailID.Trim()
                 select n).Count<Labour>() > 0)
            {
                return "Email ID already exist";
            }
            return "Email ID Available";
        }

        public string CheckLabourID(string LabourID)
        {
            List<string> list = new List<string> { "12345", "11111", "99999", "12121", "32415" };
            SmartLabourEntities entities = new SmartLabourEntities();
            if ((from n in entities.Labours
                 where n.LabourID == LabourID.Trim()
                 select n).Count<Labour>() > 0)
            {
                return "Emirates ID Not Available";
            }
            return "Emirates ID  Available";
        }

        public string CheckRequestAvailability(string LabourID)
        {
            try
            {
                SmartLabourEntities entities = new SmartLabourEntities();
                List<RequestPhone> list = (from n in entities.RequestPhones
                                           where n.LabourID.Trim() == LabourID.Trim()
                                           select n).ToList<RequestPhone>();
                if (list.Count == 1)
                {
                    return "1";
                }
                if (list.Count == 2)
                {
                    return "0";
                }
                if (list.Count >= 2)
                {
                    return "0";
                }
                return "2";
            }
            catch
            {
                return "0";
            }
        }

        #region Course Methods

        /// <summary>
        /// Get Course Details
        /// </summary>
        /// <param name="CourseID">Unique Course ID</param>
        /// <returns>Course details with Description/Embeded URL</returns>
        public List<ServiceCourse> CoursePages(string CourseID)
        {
            try
            {
                int id = Convert.ToInt32(CourseID);
                SmartLabourEntities entities = new SmartLabourEntities();
                List<TBL_COURSEDTL_SMT> list = (from n in entities.CourseDTLs.Include("courses")
                                                orderby n.COURSEDTLID ascending
                                                where n.COURSEID == id
                                                select n).ToList<TBL_COURSEDTL_SMT>();
                List<ServiceCourse> list2 = new List<ServiceCourse>();
                //List<TBL_QUESTION_SMT> list3 = new List<TBL_QUESTION_SMT>();
                foreach (TBL_COURSEDTL_SMT tbl_coursedtl_smt in list)
                {
                    ServiceCourse item = new ServiceCourse
                    {
                        CourseID = tbl_coursedtl_smt.courses.CourseID,
                        CourseName = tbl_coursedtl_smt.courses.CourseName,
                        PageContent = tbl_coursedtl_smt.DESCRIPTION,
                        IsEmbededURL = tbl_coursedtl_smt.courses.IsEmbededURL
                    };
                    list2.Add(item);
                }
                return list2;
            }
            catch
            {
                return null;
            }
        }

        public string UpdateNotificationIsRead(string LabourID, string Type, string TransactionID)
        {
            DataAccess ObjDa = new DataAccess();
            DataTable ds = new DataTable();
            ds = ObjDa.UpdateNotificationIsRead(LabourID, Type,TransactionID);
            return "Success";
        }

        /// <summary>
        /// to get the list of courses 
        /// </summary>
        /// <param name="CourseTypeID">Type of Course</param>
        /// <param name="LabourID"> Labour indivdual ID </param>
        /// <returns>List of Courses </returns>
        public CourseDetail GetAllCourses(string CourseTypeID, string LabourID)
        {
            try
            {
                CourseDetail _Coursedetails = null;

                List<ServiceCourse> list2 = new List<ServiceCourse>();
                DataAccess ObjDa = new DataAccess();
                DataSet ds = new DataSet();
                ds = ObjDa.GetAllCourseList(CourseTypeID, LabourID);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        ServiceCourse item = new ServiceCourse
                        {
                            CourseID = Convert.ToInt32(row["CourseId"].ToString()),
                            CourseName = row["CourseName"].ToString(),
                            CourseStatus = row["CourseStatus"].ToString(),
                            Language = row["Language"].ToString(),
                            LangPreference = row["LangPreference"].ToString()
                        };
                        list2.Add(item);
                    }
                }
                _Coursedetails = new CourseDetail
                {
                    levelCompletedStatus = ds.Tables[0].Rows[0][0].ToString(),
                    Courses = list2
                };
                return _Coursedetails;
            }
            catch
            {
                return null;
            }
        }

        public List<ServiceCourse> GetLangPreference(string CourseTypeID, string LabourID, string LangPreference)
        {
            try
            {
                List<ServiceCourse> list2 = new List<ServiceCourse>();
                DataAccess ObjDa = new DataAccess();
                DataSet ds = new DataSet();
                ds = ObjDa.GetLangPreference(CourseTypeID, LabourID, LangPreference);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ServiceCourse item = new ServiceCourse
                        {
                            CourseID = Convert.ToInt32(row["CourseId"].ToString()),
                            CourseName = row["CourseName"].ToString(),
                            CourseStatus = row["CourseStatus"].ToString(),
                            Language = row["Language"].ToString(),
                            LangPreference = row["LangPreference"].ToString()
                        };
                        list2.Add(item);
                    }
                }

                return list2;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get the Course Types
        /// </summary>
        /// <returns></returns>
        public List<CourseType> GetAllCourseTypes()
        {
            try
            {
                SmartLabourEntities entities = new SmartLabourEntities();
                return entities.CourseTypes.ToList<CourseType>();
            }
            catch
            {
                return null;
            }
        }

        public string SetCourseFinished(string LabourID, string CourseID)
        {
            SmartLabourEntities entities = new SmartLabourEntities();
            int strCourseID = Convert.ToInt32(CourseID);
            try
            {
                List<CourseCompletionStatus> list = (from i in entities.CourseCompletionStatus
                                                     where (i.LabourID == LabourID) && (i.CourseID == strCourseID)
                                                     select i).ToList<CourseCompletionStatus>();
                if (list.Count > 0)
                {
                    list[0].ISFinished = true;
                    entities.SaveChanges();
                    return "SUCCESS";
                }
                CourseCompletionStatus entity = new CourseCompletionStatus
                {
                    LabourID = LabourID,
                    CourseID = Convert.ToInt32(CourseID),
                    ISFinished = true
                };
                CourseCompletionStatus status = entities.CourseCompletionStatus.Add(entity);
                entities.SaveChanges();
                return "FAILURE";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string SetCourseStarted(string LabourID, string CourseID)
        {
            SmartLabourEntities entities = new SmartLabourEntities();
            int strCourseID = Convert.ToInt32(CourseID);
            try
            {
                List<CourseCompletionStatus> list = (from i in entities.CourseCompletionStatus
                                                     where (i.LabourID == LabourID) && (i.CourseID == strCourseID)
                                                     select i).ToList<CourseCompletionStatus>();
                if (list.Count > 0)
                {
                    list[0].IsStarted = true;
                    entities.SaveChanges();
                    return "SUCCESS";
                }
                CourseCompletionStatus entity = new CourseCompletionStatus
                {
                    LabourID = LabourID,
                    CourseID = Convert.ToInt32(CourseID),
                    IsStarted = true
                };
                CourseCompletionStatus status = entities.CourseCompletionStatus.Add(entity);
                entities.SaveChanges();
                return "SUCCESS";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        #endregion

        public string DisbuteTransaction(string id, string Disbutefeedback)
        {
            SmartLabourEntities entities = new SmartLabourEntities();
            try
            {
                TBL_DISBUTETRANSACTION_SMT tbl_disbutetransaction_smt = new TBL_DISBUTETRANSACTION_SMT();
                int Transactionsis = Convert.ToInt32(id);
                if (entities.DisbuteTransaction.SingleOrDefault<TBL_DISBUTETRANSACTION_SMT>(n => (n.TransactionId == Transactionsis)) != null)
                {
                    return "This Transaction Already Disbuted Please try another transaction...";
                }
                int num = Convert.ToInt32(id);
                TBL_DISBUTETRANSACTION_SMT entity = new TBL_DISBUTETRANSACTION_SMT
                {
                    TransactionId = num,
                    FeedBack = Disbutefeedback,
                    Createddate = new DateTime?(DateTime.Now)
                };
                entities.DisbuteTransaction.Add(entity);
                entities.SaveChanges();
                return "success";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string DoWork(string LabourID)
        {
            return "Sucess";
        }

        public string DoWork1()
        {
            return "hi Sucess";
        }

        public string ForgotPassword(string LabourID)
        {
            try
            {
                CommonClass objmail = new CommonClass();
                string password = string.Empty;
                string username = string.Empty;
                string useremail = string.Empty;
                SmartLabourEntities entities = new SmartLabourEntities();
                Labour labour = (from n in entities.Labours where n.LabourID == LabourID || n.EmailID == LabourID select n).SingleOrDefault<Labour>(); //entities.Labours.SingleOrDefault<Labour>(n => n.LabourID == LabourID |);
                if (labour != null)
                {
                    if ((((labour.Password != null) && (labour.Password != "")) && (labour.Name != null)) && (labour.Name != ""))
                    {
                        password = labour.Password.ToString();
                        username = labour.EmailID.ToString();
                        useremail = labour.EmailID.ToString();
                        //  string str4 = new Mailing().Email_Wise(useremail, "Smartlabours-Forgot Password", username, password);
                        objmail.SendingMail(useremail, "Smartlabours-Forgot Password", useremail, password, "Your password is :", "");
                        return "Password Sent to the Registered Email ID";
                    }
                    return "InCorrect Emirates ID";
                }
                return "InCorrect Emirates ID";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public int GetAnswerID(string LabourID, string QuestionID)
        {
            try
            {
                SmartLabourEntities entities = new SmartLabourEntities();
                string lid = LabourID;
                int qid = Convert.ToInt32(QuestionID);
                List<TestResult> list = (from n in entities.QuestionTest
                                         where (n.LabourID == lid) && (n.QuestionID == qid)
                                         select n).ToList<TestResult>();
                if (list.Count > 0)
                {
                    return list[0].AnswerID;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<LabourContract> GetRequestPhoneuserDetail(string LabourId)
        {
            SmartLabourEntities entities = new SmartLabourEntities();
            Labour labour = entities.Labours.SingleOrDefault<Labour>(n => n.LabourID == LabourId);
            List<LabourContract> source = new List<LabourContract>();
            if (labour != null)
            {
                LabourContract item = new LabourContract
                {
                    Address1 = labour.Address1,
                    EmailID = labour.EmailID,
                    LabourID = labour.LabourID,
                    PhoneNumber = labour.PhoneNumber,
                    IsOriginalEmirateId = labour.IsOriginalEmirateId == false ? "temporary" : "original"
                };
                source.Add(item);
            }
            return source.ToList<LabourContract>();
        }

        #region GetTelecom Operators

        //public List<TBL_SERVICEPROVIDER_SMT> GetTelecomOperators(string OrgId)
        //{
        //    try
        //    {

        //        SmartLabourEntities entities = new SmartLabourEntities();
        //        List<TBL_SERVICEPROVIDER_SMT> lisst = new List<TBL_SERVICEPROVIDER_SMT>();
        //        lisst = (from n in entities.ServiceProvider where n.OrgId == Convert.ToInt32(OrgId) select n).ToList<TBL_SERVICEPROVIDER_SMT>();
        //        return lisst;
        //        // return entities.ServiceProvider.ToList<TBL_SERVICEPROVIDER_SMT>();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}


        //#endregion



        /// <summary>
        /// Get Telecom Operator for selectd Organization
        /// </summary>
        /// <param name="OrgId">Selected Organization Id </param>
        /// <returns></returns>
        public List<ServiceProvider> GetTelecomOperators(string OrgId)
        {
            try
            {
                int intOrgId = Convert.ToInt32(OrgId);
                SmartLabourEntities entities = new SmartLabourEntities();
                List<TBL_SERVICEPROVIDER_SMT> lisst = new List<TBL_SERVICEPROVIDER_SMT>();
                lisst = (from n in entities.ServiceProvider where n.OrgId == intOrgId && n.IsTelcomOperator == true && n.STATUS == true select n).ToList<TBL_SERVICEPROVIDER_SMT>();

                List<ServiceProvider> source = new List<ServiceProvider>();
                if (lisst != null)
                {
                    foreach (var item in lisst)
                    {
                        ServiceProvider item1 = new ServiceProvider
                        {
                            SERVICEPROVIDERID = item.SERVICEPROVIDERID,
                            SERVICEPROVIDER = item.SERVICEPROVIDER,
                            STATUS = item.STATUS,
                            CREATEDBY = item.CREATEDBY,
                            CREATEDDATE = Convert.ToString(item.CREATEDDATE),
                            MODIFIEDBY = item.MODIFIEDBY,
                            MODIFIEDDATE = Convert.ToString(item.MODIFIEDDATE),
                            OrgId = item.OrgId,
                        };
                        source.Add(item1);
                    }

                }
                return source.ToList<ServiceProvider>();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                //string str = ex.ToString() + "|||";
                return null;
            }
        }
        #endregion

        public List<NotificationList> GetTransactionstatus(string LabourID)
        {
            try
            {
                // Database database = DatabaseFactory.CreateDatabase("DefaultConnection");
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database database = factory.Create("DefaultConnection");
                string storedProcedureName = "pro_LabourNotificationPhone_List";
                DbCommand storedProcCommand = database.GetStoredProcCommand(storedProcedureName);
                database.AddInParameter(storedProcCommand, "@LabourId", DbType.String, LabourID);
                List<NotificationList> source = new List<NotificationList>();
                using (IDataReader reader = database.ExecuteReader(storedProcCommand))
                {
                    while (reader.Read())
                    {
                        NotificationList item = new NotificationList();
                        if (reader["Name"] != DBNull.Value)
                        {
                            item.Name = reader["Name"].ToString();
                        }
                        if (reader["BrandName"] != DBNull.Value)
                        {
                            item.BrandName = reader["BrandName"].ToString();
                        }
                        if (reader["PhoneColor"] != DBNull.Value)
                        {
                            item.Phonecolor = reader["PhoneColor"].ToString();
                        }
                        if (reader["ModelNo"] != DBNull.Value)
                        {
                            item.ModelNumber = reader["ModelNo"].ToString();
                        }
                        if (reader["Status"] != DBNull.Value)
                        {
                            item.Status = reader["Status"].ToString();
                        }
                        if (reader["RequestedDate"] != DBNull.Value)
                        {
                            item.RequestDate = Convert.ToDateTime(reader["RequestedDate"]);
                        }
                        if (reader["IsRead"] != DBNull.Value)
                        {
                            item.IsRead = reader["IsRead"].ToString();
                        }
                        source.Add(item);
                    }
                }
                return source.ToList<NotificationList>();
            }
            catch
            {
                return null;
            }
        }

        #region Register Labour

        /// <summary>
        /// Registering a New Labour to  Smart Labour 
        /// </summary>
        /// <param name="LabourId"></param>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        /// <param name="EmailID"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="DOB"></param>
        /// <param name="Sex"></param>
        /// <param name="Address1"></param>
        /// <param name="Address2"></param>
        /// <param name="Address3"></param>
        /// <param name="Pincode"></param>
        /// <param name="IsDisplayNameAccepted"></param>
        /// <param name="TelecomOperatorID"></param>
        /// <param name="OrgId"></param>
        /// <returns></returns>
        /// 
        //public string RegisterLabour(string LabourId, string Name, string Password, string EmailID, string PhoneNumber, string DOB, string Sex, string Address1, string Address2, string Address3, string Pincode, string IsDisplayNameAccepted, string TelecomOperatorID, string OrgId, string City, string State, string Country, string CategoryId, string SubCategoryId, string CountryCode,string IsOriginalEmiratesId)
        //{
        //    try
        //    {
        //        SmartLabourEntities entities = new SmartLabourEntities();
        //        bool IsEmirates = true;
        //        string TempEmiratesId = string.Empty;
        //        int? intCategoryId = 1;
        //        int? intSubCategoryId = 1;

        //        if (IsOriginalEmiratesId.ToLower().Trim() == "false" || LabourId.ToString().Trim() == "empty")
        //        {
        //            Int64 Count = (from n in entities.Labours orderby n.UserID descending select n.UserID).FirstOrDefault();
        //            Count = 100000000 + Count + 1;
        //            TempEmiratesId = "SLMAPP" + Count.ToString();
        //            IsEmirates = false;
        //            LabourId = TempEmiratesId;
        //        }

        //        DataSet d1s = objTransDB.ExecuteDataSet("SP_LogFile", (DateTime.Now).ToString(), "Before_" + LabourId);
        //        string ServiceTypeList = string.Empty;
        //        var ServiceTypes = (from n in entities.ServiceType select n).ToList();

        //        foreach (var ServiceType in ServiceTypes)
        //        {
        //            ServiceTypeList = ServiceTypeList + Convert.ToString(ServiceType.SERVICETYPEID) + ",";
        //        }

        //        MailModel objSendMailTask = new Models.MailModel();
        //        DataSet ds = objTransDB.ExecuteDataSet("SMT_SP_ValidateLabourDetails", LabourId, EmailID, PhoneNumber, CategoryId, SubCategoryId, 1);

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows[0][0].ToString().Trim().ToLower() != "OK".ToLower())
        //            {
        //                return ds.Tables[0].Rows[0][0].ToString();
        //            }
        //        }

        //        //int Catid = Convert.ToInt32(CategoryId);

        //        //Catid = Convert.ToInt32(SubCategoryId);
        //        //if (Catid !=0)
        //        //{
        //        //    string subCategory = (from n in entities.SubCategory where n.SubCategoryId == Catid && n.Status == true select n.SubCategoryName).SingleOrDefault();

        //        //    if (subCategory == string.Empty || subCategory == null)
        //        //    {
        //        //        return "Sub Category does not exist ";
        //        //    }
        //        //}               

        //        int Orgid = Convert.ToInt32(OrgId);

        //        if (Sex.ToLower().Trim() == "male")
        //        {
        //            Sex = "1";
        //        }
        //        else if (Sex.ToLower().Trim() == "female")
        //        {
        //            Sex = "2";
        //        }
        //        else if (Sex.ToLower().Trim() == "empty")
        //        {
        //            Sex = "0";
        //        }

        //        if (DOB.Trim().ToLower() == "empty")
        //        {
        //            DOB = "01-01-1900";
        //        }

        //        if (CategoryId != "0" && CategoryId != "empty")
        //        {
        //            intCategoryId = Convert.ToInt32(CategoryId);
        //        }

        //        if (SubCategoryId != "0" && SubCategoryId != "empty")
        //        {
        //            intSubCategoryId = Convert.ToInt32(SubCategoryId); ;
        //        }

        //        Labour entity = new Labour
        //        {
        //            Name = Name,
        //            EmailID = EmailID,
        //            PhoneNumber = PhoneNumber,
        //            DOB = Convert.ToDateTime(DOB),
        //            Sex = Sex,
        //            Address1 = Address1,
        //            Address2 = Address2,
        //            Address3 = Address3,
        //            Pincode = Pincode,
        //            CREATEDDATE = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString())),
        //            LabourID = LabourId,
        //            IsDisplayNameAccepted = Convert.ToBoolean(IsDisplayNameAccepted),
        //            Password = Password,
        //            ConfirmPassword = Password,
        //            STATUS = false,
        //            CreatedFrom = false,
        //            SERVICEPROVIDERID = Convert.ToInt32(TelecomOperatorID),
        //            SERVICETYPEID = ServiceTypeList,
        //            OrgId = Orgid,
        //            OrgChangeStatus=0,
        //            Visibility=true,
        //            City = City,
        //            State = State,
        //            OrgName = "Dummy",
        //            CategoryId = CategoryId == "0" ? null : intCategoryId,
        //            SubCategoryId = SubCategoryId == "0" ? null : intSubCategoryId,
        //            CountryCode = CountryCode,
        //            MODIFIEDDATE = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString())),
        //            IsOriginalEmirateId = IsEmirates
        //        };
        //        if (Orgid == 1)
        //        {
        //            entity.STATUS = true;
        //        }
        //        entities.Labours.Add(entity);
        //        entities.SaveChanges();

        //        objSendMailTask.SendMailToSubAdmin(Orgid, LabourId, EmailID);
        //        //List<TBL_ADMINLOGIN_SMT> Oid = (from m in entities.AdminLogin where m.OrgId == Orgid && m.STATUS == true select m).ToList<TBL_ADMINLOGIN_SMT>();
        //        //foreach (TBL_ADMINLOGIN_SMT org in Oid)
        //        //{
        //        //    objmail.SendingMail(org.USEREMAIL, "  Smart Labour  - New Labour", org.USEREMAIL, "", "", "New User with Emirates ID ( " + LabourId + " )   has been created successfully in your organisation !.");
        //        //}
        //        //objmail.SendingMail(EmailID, "Welcome To  Smart Labour ", EmailID, "", "", "Your account has been created successfully !.");

        //        return "SUCCESS";

        //    }

        //    catch (Exception Ex)
        //    {  
        //        DataSet ds = objTransDB.ExecuteDataSet("SMT_SP_LogCreation",1,Ex.InnerException.ToString(),Ex.StackTrace.ToString(),"Exception","",0,0,"","");
        //        //return "NOT SUCCESS";         
        //        return Ex.InnerException.ToString() + "_____" + Ex.StackTrace.ToString();
        //    }
        //}

        public string RegisterLabour(string Name, string Password, string EmailID, string PhoneNumber)
        {
            try
            {
                DataSet ds = objTransDB.ExecuteDataSet("SMT_SP_ValidateLabourDetails", EmailID, PhoneNumber);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString().Trim().ToLower() != "OK".ToLower())
                    {
                        return ds.Tables[0].Rows[0][0].ToString();
                    }
                }
                SmartLabourEntities entities = new SmartLabourEntities();
                MailModel objSendMailTask = new Models.MailModel();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartLabourEntities"].ConnectionString);
                connection.Open();
                string cmdText = "spSL_InsertLabourRegistration";
                SqlCommand command = new SqlCommand(cmdText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pEmailID", EmailID);
                command.Parameters.AddWithValue("@pName", Name);
                command.Parameters.AddWithValue("@pPassword", Password);
                command.Parameters.AddWithValue("@pPhoneNumber", PhoneNumber);
                command.ExecuteNonQuery();
                connection.Close();
                objSendMailTask.mSendMailToSubAdmin(EmailID);
                return "SUCCESS";

            }

            catch (Exception Ex)
            {
                DataSet ds = objTransDB.ExecuteDataSet("SMT_SP_LogCreation", 1, Ex.InnerException.ToString(), Ex.StackTrace.ToString(), "Exception", "", 0, 0, "", "");
                //return "NOT SUCCESS";         
                return Ex.InnerException.ToString() + "_____" + Ex.StackTrace.ToString();
            }
        }


        public String RegisterLabourSocialMedia(string Name, String EmailID, string SocialType)
        {
            try
            {
                DataSet dataSet = objTransDB.ExecuteDataSet("spSL_InsertRegisterLabourSocialMedia", EmailID, Name, SocialType);
                //objSendMailTask.mSendMailToSubAdmin(EmailID);

                return dataSet.Tables[0].Rows[0][0].ToString();
            }

            catch (Exception Ex)
            {
                DataSet ds = objTransDB.ExecuteDataSet("SMT_SP_LogCreation", 1, Ex.InnerException.ToString(), Ex.StackTrace.ToString(), "Exception", "", 0, 0, "", "");
                //return "NOT SUCCESS";         
                return Ex.InnerException.ToString() + "_____" + Ex.StackTrace.ToString();
            }
        }

        #endregion

        #region Update Labour

        /// <summary>
        /// UpdateEmiratesId From Temp Id to Original Labour
        /// </summary>
        /// <param name="LabourId">OldLabourId</param>
        /// <param name="NewEmiratesID">NewEmiratesID</param>
        /// <returns></returns>
        public string UpdateEmiratesId(string OldLabourId, string NewEmiratesID)
        {
            string Str = string.Empty;
            try
            {
                DataSet dataSet = objTransDB.ExecuteDataSet("SMT_SP_UpdateEmiratesId", 1, OldLabourId, NewEmiratesID);
                return dataSet.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception Ex)
            {
                DataSet dataSet = objTransDB.ExecuteDataSet("SP_LogFile", "UpdateEmiratesId_" + Str, Ex.Message);
                return Ex.Message;
            }
        }

        /// <summary>
        /// To Update The Labour Details
        /// </summary>
        /// <param name="LabourId"></param>
        /// <param name="Name"></param>
        /// <param name="EmailID"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="DOB"></param>
        /// <param name="Sex"></param>
        /// <param name="Address1"></param>
        /// <param name="Address2"></param>
        /// <param name="Address3"></param>
        /// <param name="Pincode"></param>
        /// <param name="IsDisplayNameAccepted"></param>
        /// <param name="TelecomOperatorID"></param>
        /// <param name="ServiceType"></param>
        /// <param name="OrgId"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Country"></param>
        /// <param name="CategoryId"></param>
        /// <param name="SubCategoryId"></param>
        /// <param name="CountryCode"></param>
        /// <returns></returns>
        public string UpdateLabour(string LabourId, string Name, string EmailID, string PhoneNumber, string DOB, string Sex, string Address1, string Address2, string Address3, string Pincode, string IsDisplayNameAccepted, string TelecomOperatorID, string ServiceType, string OrgId, string City, string State, string Country, string CategoryId, string SubCategoryId, string CountryCode)
        {
            try
            {
                DataSet ds = objTransDB.ExecuteDataSet("SMT_SP_LogCreation", 1, LabourId+"~"+Name+"~"+EmailID+"~"+PhoneNumber+"~"+DOB+"~"+Sex+"~"+Address1+"~"+Address2+"~"+Address3+"~"+Pincode+"~"+IsDisplayNameAccepted+"~"+TelecomOperatorID+"~"+ ServiceType+"~"+ OrgId+"~"+City+"~"+State+"~"+Country+"~"+CategoryId+"~"+SubCategoryId+"~"+ CountryCode, "Profile", "Update", "", 0, 0, "", "");
                int? intCategoryId = 1;
                int? intSubCategoryId = 1;
                CommonClass objCommon = new CommonClass();
                int Temp = 0;
                SmartLabourEntities entities = new SmartLabourEntities();
                List<Labour> list = new List<Labour>();
                List<Labour> list2 = new List<Labour>();
                list = (from n in entities.Labours
                        where (n.EmailID.ToLower().Trim() == EmailID.ToLower().Trim()) && (n.LabourID != LabourId) && n.STATUS == true
                        select n).ToList<Labour>();
                list2 = (from n in entities.Labours
                         where n.LabourID != LabourId && n.STATUS == true
                         select n).ToList<Labour>();
                if (list.Count > 0)
                {
                    return "Email ID already exist";
                }

                /* Labour Validations */
                if (Sex.ToLower().Trim() == "male")
                {
                    Sex = "1";
                }
                else if (Sex.ToLower().Trim() == "female")
                {
                    Sex = "2";
                }
                else if (Sex.ToLower().Trim() == "empty")
                {
                    Sex = "0";
                }

                if (DOB.Trim().ToLower() == "empty")
                {
                    DOB = "01-01-1900";
                }

                if (CategoryId != "0" && CategoryId != "empty")
                {
                    intCategoryId = Convert.ToInt32(CategoryId);
                }

                if (SubCategoryId != "0" && SubCategoryId != "empty")
                {
                    intSubCategoryId = Convert.ToInt32(SubCategoryId); ;
                }
                /* End HEre  */


                Labour labour = entities.Labours.SingleOrDefault<Labour>(n => n.LabourID == LabourId);

                int OrganizationId = (from n in entities.Labours where n.LabourID == LabourId select n.OrgId).SingleOrDefault();
                if (OrganizationId != 0 && OrganizationId != Convert.ToInt32(OrgId))
                {
                    labour.OrgId = Convert.ToInt32(OrgId);
                    labour.OrgChangeStatus = 1;
                    labour.STATUS = false;
                    Temp = 1;
                }
                labour.Name = Name;
                labour.EmailID = EmailID;
                labour.PhoneNumber = PhoneNumber;
                labour.DOB = Convert.ToDateTime(DOB);
                labour.Sex = Sex;
                labour.Address1 = Address1;
                labour.Password = labour.Password;
                labour.ConfirmPassword = labour.Password;
                labour.Address2 = Address2;
                labour.Address3 = Address3;
                labour.Pincode = Pincode;
                if (Temp == 1)
                {
                    labour.OrgId = Convert.ToInt32(OrgId);
                    labour.OrgChangeStatus = 1;
                }
                labour.CategoryId = CategoryId == "0" ? null : intCategoryId; ;
                labour.SubCategoryId = SubCategoryId == "0" ? null : intSubCategoryId;
                labour.SERVICEPROVIDERID = Convert.ToInt32(TelecomOperatorID);
                labour.State = State;
                labour.City = City;
                labour.Country = Country;
                labour.CountryCode = CountryCode;
                labour.CreatedFrom = false;
                labour.MODIFIEDDATE = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString()));
                labour.MODIFIEDBY = Name;
                labour.IsDisplayNameAccepted = Convert.ToBoolean(IsDisplayNameAccepted);
                labour.SERVICETYPEID = ServiceType;
                //entities.ServiceType.Where(a => a.SERVICETYPENAME.Replace(" ", "").ToUpper().Trim() == ServiceType.Replace(" ", "").Trim().ToUpper()).Select(a => a.SERVICETYPEID).FirstOrDefault();
                entities.SaveChanges();

                if (Temp == 1)
                {
                    string OrgNamee = (from n in entities.Organisation where n.OrgId == labour.OrgId select n.OrganisationName).SingleOrDefault();
                    objCommon.SendingMail(labour.EmailID, "  Smart Labour  - Organization Change", labour.EmailID, OrgNamee, "New Organization :", "Your Organisation has been changed successfully");
                    List<TBL_ADMINLOGIN_SMT> OrgEmail = (from n in entities.AdminLogin where n.OrgId == labour.OrgId select n).ToList<TBL_ADMINLOGIN_SMT>();
                    foreach (TBL_ADMINLOGIN_SMT org in OrgEmail)
                    {
                        objCommon.SendingMail(org.USEREMAIL, "  Smart Labour  - New Labour", org.USEREMAIL, "", "", "New Labour ( " + labour.LabourID + " ) added in your Organization.");
                    }
                }
                return "SUCCESS";
            }
            catch (Exception Ex)
            {
                DataSet ds = objTransDB.ExecuteDataSet("SMT_SP_LogCreation", 1, Ex.InnerException.ToString(), Ex.StackTrace.ToString(), "Exception", "", 0, 0, "", "");
                //return "NOT SUCCESS";
                return Ex.InnerException.ToString() + "_____" + Ex.StackTrace.ToString();
            }
        }

        #endregion

        #region GetLabourDetails

        /// <summary>
        /// Get the Details of Users
        /// </summary>
        /// <param name="LabourID"></param>
        /// <returns>Labour Details List</returns>
        public List<LabourContract> GetUserDetail(string LabourID)
        {
            List<LabourContract> list3;
            try
            {
                SmartLabourEntities entities = new SmartLabourEntities();
                List<Labour> list = new List<Labour>();
                List<LabourContract> source = new List<LabourContract>();
                list = (from n in entities.Labours
                        where n.LabourID == LabourID && n.STATUS == true
                        select n).ToList<Labour>();
                if (list.Count > 0)
                {
                    foreach (Labour labour in list)
                    {
                        //  string serviceType = "";
                        //if (labour.SERVICETYPEID != "0")
                        //{

                        //    serviceType = entities.ServiceType.Where(a => a.SERVICETYPEID == labour.SERVICETYPEID).Select(x => x.SERVICETYPENAME).FirstOrDefault();
                        //    if (serviceType != null)
                        //        serviceType = serviceType.Replace(" ", "").ToLower();
                        //    else serviceType = "talktime";
                        //}
                        //else
                        //    serviceType = "talktime";
                        LabourContract item = new LabourContract
                        {
                            LabourID = labour.LabourID,
                            Name = labour.Name,
                            Password = labour.Password,
                            PhoneNumber = labour.PhoneNumber,
                            Pincode = labour.Pincode,
                            Sex = labour.Sex,
                            SERVICEPROVIDERID = labour.SERVICEPROVIDERID,
                            EmailID = labour.EmailID,
                            Address1 = labour.Address1,
                            Address2 = labour.Address2,
                            Day = list[0].DOB.Day.ToString(),
                            Month = list[0].DOB.Month.ToString(),
                            Year = list[0].DOB.Year.ToString(),
                            DOB = new DateTime?(labour.DOB),
                            planType = labour.SERVICETYPEID,
                            IsDisplayNameAccepted = labour.IsDisplayNameAccepted,
                            OrgId = labour.OrgId,
                            City = labour.City,
                            State = labour.State,
                            Country = labour.Country,
                            CategoryId = labour.CategoryId,
                            SubCategoryId = labour.SubCategoryId,
                            CountryCode = labour.CountryCode
                        };
                        source.Add(item);
                    }
                }
                list3 = source.ToList<LabourContract>();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
            return list3;
        }

        #endregion

        #region Get Request Count and Settings

        /// <summary>
        /// Get User Request Count
        /// </summary>
        /// <param name="LabourID"></param>
        /// <returns></returns>
        public List<Requestcount> GetuserRequestcount(string LabourID)
        {
            bool rEQUESTFAMILYSTATUS = false;
            SmartLabourEntities entities = new SmartLabourEntities();
            List<Requestcount> source = new List<Requestcount>();
            Requestcount item = new Requestcount();
            TBL_REQUESTFAMILYSETTINGS_SMT tbl_requestfamilysettings_smt = new TBL_REQUESTFAMILYSETTINGS_SMT();
            int OrgId = 0;
            OrgId = (from n in entities.Labours where n.LabourID == LabourID && n.STATUS == true select n.OrgId).SingleOrDefault();
            tbl_requestfamilysettings_smt = entities.Requestsettings.SingleOrDefault<TBL_REQUESTFAMILYSETTINGS_SMT>(n => n.OrgId == OrgId);
            if (tbl_requestfamilysettings_smt != null)
            {
                rEQUESTFAMILYSTATUS = tbl_requestfamilysettings_smt.REQUESTFAMILYSTATUS;
            }
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database database = factory.Create("DefaultConnection");
            //Database database = DatabaseFactory.CreateDatabase("DefaultConnection");
            string storedProcedureName = "pro_LabourPhoneRequestcount";
            DbCommand storedProcCommand = database.GetStoredProcCommand(storedProcedureName);
            database.AddInParameter(storedProcCommand, "@Labourid", DbType.String, LabourID);
            using (IDataReader reader = database.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    if (reader["count"] != DBNull.Value)
                    {
                        item.RequestCount = Convert.ToInt32(reader["count"].ToString());
                    }
                    if (reader["RequestStatus"] != DBNull.Value)
                    {
                        item.Requeststatus = reader["RequestStatus"].ToString();
                    }
                    item.Requestsettings = rEQUESTFAMILYSTATUS;
                    source.Add(item);
                }
            }
            return source.ToList<Requestcount>();
        }

        #endregion

        public ServiceVoucherKitty GetVoucherKitty(string LabourID)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            string str = "";
            SmartLabourEntities entities = new SmartLabourEntities();
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand selectCommand = new SqlCommand("pro_VoucherKitty", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            selectCommand.Parameters.Add(new SqlParameter("@LabourId", LabourID));
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            adapter.Dispose();
            selectCommand.Dispose();
            connection.Dispose();
            List<Course> list = new List<Course>();
            List<Course> list2 = new List<Course>();
            List<Course> list3 = new List<Course>();
            List<TBL_QUESTION_SMT> list4 = new List<TBL_QUESTION_SMT>();
            list = (from n in entities.Courses
                    where n.STATUS == true
                    select n).ToList<Course>();
            list2 = (from n in entities.Courses
                     where n.STATUS == true
                     select n).ToList<Course>();
            list3 = (from n in entities.Courses
                     where n.STATUS == true
                     select n).ToList<Course>();
            if (list.Count > 0)
            {
                foreach (Course course in (from n in list
                                           where n.CourseTypeID == 1
                                           select n).ToList<Course>())
                {
                    int courseid = Convert.ToInt16(course.CourseID);
                    if ((from n in entities.Question
                         where n.CourseID == courseid
                         select n).ToList<TBL_QUESTION_SMT>().Count > 0)
                    {
                        num++;
                    }
                }
                if (list2.Count > 0)
                {
                    foreach (Course course in (from n in list2
                                               where n.CourseTypeID == 2
                                               select n).ToList<Course>())
                    {
                        int courseid = Convert.ToInt16(course.CourseID);
                        if ((from n in entities.Question
                             where n.CourseID == courseid
                             select n).ToList<TBL_QUESTION_SMT>().Count > 0)
                        {
                            num2++;
                        }
                    }
                }
                if (list3.Count > 0)
                {
                    foreach (Course course in (from n in list3
                                               where n.CourseTypeID == 3
                                               select n).ToList<Course>())
                    {
                        int courseid = Convert.ToInt16(course.CourseID);
                        if ((from n in entities.Question
                             where n.CourseID == courseid
                             select n).ToList<TBL_QUESTION_SMT>().Count > 0)
                        {
                            num3++;
                        }
                    }
                }
            }
            ServiceVoucherKitty kitty = new ServiceVoucherKitty
            {
                TotalCoursesStudied = dataSet.Tables[0].Rows[0]["CompletedCourse"].ToString()
            };
            if ((kitty.TotalCoursesStudied != null) && (kitty.TotalCoursesStudied != ""))
            {
                num4 = Convert.ToInt16(kitty.TotalCoursesStudied);
            }
            if (num4 != 0)
            {
                if (num4 >= num)
                {
                    str = "1";
                }
                if (num4 >= (num + num2))
                {
                    str = "2";
                }
                if (num4 >= ((num + num2) + num3))
                {
                    str = "3";
                }
            }
            if (str == "")
            {
                str = "0";
            }
            kitty.TotalfirstLevelcount = str.ToString();
            kitty.TotalPointsEarned = dataSet.Tables[0].Rows[0]["TotalPoints"].ToString();
            kitty.TotalPointToBeRedeemed = dataSet.Tables[0].Rows[0]["PointsToRedeemed"].ToString();
            kitty.VouchersEarned = dataSet.Tables[0].Rows[0]["VoucherEarned"].ToString();
            return kitty;
        }

        /// <summary>
        /// Login Method 
        /// </summary>
        /// <param name="LabourIDorEmail"></param>
        /// <param name="Password"></param>
        /// <param name="DeviceToken"></param>
        /// <param name="DeviceType"></param>
        /// <returns></returns>
        public string Login(string LabourIDorEmail, string Password, string DeviceToken, string DeviceType)
        {
            try
            {
                int CheckOrgId = 0;
                string base64Decoded = string.Empty;
                SmartLabourEntities entities = new SmartLabourEntities();
                Labour objLabour = new Labour();
                objLabour = (from n in entities.Labours
                             where (((n.LabourID == LabourIDorEmail) || (n.EmailID == LabourIDorEmail) || (n.PhoneNumber == LabourIDorEmail)) && (n.Password == Password))
                             select n).FirstOrDefault();

                if (objLabour != null)
                {
                    CheckOrgId = (from m in entities.Organisation where m.OrgId == objLabour.OrgId && m.IsActive == true select m.OrgId).FirstOrDefault();
                    if (CheckOrgId == 0)
                    {
                        return "Your Organization is Inactive";
                    }
                    else if (objLabour.STATUS == false)
                    {
                        return "Your account status is Inactive";
                    }
                    Labour labour;
                    labour = entities.Labours.SingleOrDefault<Labour>(n => n.LabourID == objLabour.LabourID);
                    byte[] data = System.Convert.FromBase64String(DeviceToken);
                    base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
                    if (labour != null)
                    {
                        objLabour.Name = labour.Name;
                        objLabour.EmailID = labour.EmailID;
                        objLabour.PhoneNumber = labour.PhoneNumber;
                        objLabour.DOB = Convert.ToDateTime(labour.DOB);
                        objLabour.Sex = labour.Sex;
                        objLabour.Address1 = labour.Address1;
                        objLabour.Password = objLabour.Password;
                        objLabour.ConfirmPassword = objLabour.Password;
                        objLabour.Address2 = labour.Address2;
                        objLabour.Address3 = labour.Address3;
                        objLabour.Pincode = labour.Pincode;
                        objLabour.MODIFIEDDATE = new DateTime?(DateTime.Now);
                        objLabour.IsDisplayNameAccepted = Convert.ToBoolean(labour.IsDisplayNameAccepted);
                        objLabour.SERVICEPROVIDERID = Convert.ToInt32(labour.SERVICEPROVIDERID);
                        labour.DeviceToken = base64Decoded;
                        labour.DeviceType = DeviceType;
                        entities.SaveChanges();
                    }
                    return objLabour.LabourID;
                }
                return "Invalid Credentials";
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                //string str = ex.ToString() + "|||";
                return "0";
            }
        }

        //public List<PhoneAvailable> PhoneAvailableNotification(string LabourID)
        //{
        //    List<PhoneAvailable> list = new List<PhoneAvailable>();
        //    try
        //    {
        //        // Database database = DatabaseFactory.CreateDatabase("DefaultConnection");
        //        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //        Database database = factory.Create("DefaultConnection");
        //        string storedProcedureName = "pro_PhoneAvailable";
        //        DbCommand storedProcCommand = database.GetStoredProcCommand(storedProcedureName);
        //        database.AddInParameter(storedProcCommand, "@Labourid", DbType.String, LabourID);
        //        List<DonatePhone> list2 = new List<DonatePhone>();
        //        using (IDataReader reader = database.ExecuteReader(storedProcCommand))
        //        {
        //            while (reader.Read())
        //            {
        //                PhoneAvailable item = new PhoneAvailable();
        //                if (reader["BrandName"] != DBNull.Value)
        //                {
        //                    item.PhoneName = reader["BrandName"].ToString();
        //                }
        //                if (reader["ModelNo"] != DBNull.Value)
        //                {
        //                    item.ModelNo = reader["ModelNo"].ToString();
        //                }
        //                if (reader["AssignedDate"] != DBNull.Value)
        //                {
        //                    item.PhoneNotifiedDate = Convert.ToString(reader["AssignedDate"]);
        //                    string str2 = Convert.ToString(DateTime.Parse(item.PhoneNotifiedDate).ToString("MM-dd-yyyy", CultureInfo.InvariantCulture));
        //                    item.PhoneNotifiedDate = str2;
        //                }
        //                if (reader["DaysLeft"] != DBNull.Value)
        //                {
        //                    item.TimeLeftinDays = reader["DaysLeft"].ToString();
        //                }
        //                item.PhoneImageURL = "http://192.169.236.190/Lumia%20535.jpg";
        //                list.Add(item);
        //            }
        //        }
        //        return list;
        //    }
        //    catch
        //    {
        //        return list;
        //    }
        //}


        public List<PhoneAvailable> PhoneAvailableNotification(string LabourID)
        {
            List<PhoneAvailable> list = new List<PhoneAvailable>();
            try
            {
                // Database database = DatabaseFactory.CreateDatabase("DefaultConnection");
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database database = factory.Create("DefaultConnection");
                string storedProcedureName = "pro_PhoneAvailable";
                DbCommand storedProcCommand = database.GetStoredProcCommand(storedProcedureName);
                database.AddInParameter(storedProcCommand, "@Labourid", DbType.String, LabourID);
                List<DonatePhone> list2 = new List<DonatePhone>();
                using (IDataReader reader = database.ExecuteReader(storedProcCommand))
                {
                    while (reader.Read())
                    {
                        PhoneAvailable item = new PhoneAvailable();
                        if (reader["BrandName"] != DBNull.Value)
                        {
                            item.PhoneName = reader["BrandName"].ToString();
                        }
                        if (reader["ModelNo"] != DBNull.Value)
                        {
                            item.ModelNo = reader["ModelNo"].ToString();
                        }
                        if (reader["AssignedDate"] != DBNull.Value)
                        {
                            item.PhoneNotifiedDate = Convert.ToString(reader["AssignedDate"]);
                            string str2 = Convert.ToString(DateTime.Parse(item.PhoneNotifiedDate).ToString("MM-dd-yyyy", CultureInfo.InvariantCulture));
                            item.PhoneNotifiedDate = str2;
                        }
                        if (reader["DaysLeft"] != DBNull.Value)
                        {
                            item.TimeLeftinDays = reader["DaysLeft"].ToString();
                        }
                        if (reader["IsRead"] != DBNull.Value)
                        {
                            item.IsRead = reader["IsRead"].ToString();
                        }
                        item.PhoneImageURL = "http://192.169.236.190/Lumia%20535.jpg";
                        list.Add(item);
                    }
                }
                return list;
            }
            catch
            {
                return list;
            }
        }


        public List<ServiceCourse> QuestionAndAnswer(string CourseID)
        {
            try
            {
                int id = Convert.ToInt32(CourseID);
                SmartLabourEntities entities = new SmartLabourEntities();
                Course course = entities.Courses.SingleOrDefault<Course>(n => n.CourseID == id);
                List<TBL_ANSWER_SMT> list = (from n in entities.Answer.Include("question")
                                             where n.question.CourseID == id
                                             select n).ToList<TBL_ANSWER_SMT>();
                List<ServiceCourse> list2 = new List<ServiceCourse>();
                foreach (TBL_ANSWER_SMT tbl_answer_smt in list)
                {
                    ServiceCourse item = new ServiceCourse
                    {
                        CourseID = course.CourseID,
                        CourseName = course.CourseName,
                        Title = course.QuestionTitle,
                        QuestionID = tbl_answer_smt.question.QuestionID,
                        QuestionDesc = tbl_answer_smt.question.QuestionDesc,
                        AnswerID = tbl_answer_smt.AnswerID,
                        AnswerDesc = tbl_answer_smt.AnswerDesc
                    };
                    list2.Add(item);
                }
                return list2;
            }
            catch
            {
                return null;
            }
        }

        public List<RequestHistory> RequestHistory(string LabourID)
        {
            List<RequestHistory> list = new List<RequestHistory>();
            try
            {
                // Database database = DatabaseFactory.CreateDatabase("DefaultConnection");
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database database = factory.Create("DefaultConnection");
                string storedProcedureName = "pro_PhoneAcceptedLabourHistory";
                DbCommand storedProcCommand = database.GetStoredProcCommand(storedProcedureName);
                database.AddInParameter(storedProcCommand, "@Labourid", DbType.String, LabourID);
                using (IDataReader reader = database.ExecuteReader(storedProcCommand))
                {
                    while (reader.Read())
                    {
                        RequestHistory item = new RequestHistory();
                        if (reader["BrandName"] != DBNull.Value)
                        {
                            item.PhoneName = reader["BrandName"].ToString();
                        }
                        if (reader["IMEANumber"] != DBNull.Value)
                        {
                            item.IMEA = reader["IMEANumber"].ToString();
                        }
                        if (reader["ModelNo"] != DBNull.Value)
                        {
                            item.ModelNo = reader["ModelNo"].ToString();
                        }
                        if (reader["CourierDetail"] != DBNull.Value)
                        {
                            item.CourierDetails = reader["CourierDetail"].ToString();
                        }
                        if (reader["DeliveredDate"] != DBNull.Value)
                        {
                            DateTime time = DateTime.ParseExact(reader["DeliveredDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            time.ToString("dd/MM/yyyy");
                            item.DeliveryDate = Convert.ToString(time.ToShortDateString());
                        }
                        if (reader["TransactionID"] != DBNull.Value)
                        {
                            string str2 = "";
                            string str3 = "";
                            str3 = Convert.ToString(reader["TransactionID"].ToString());
                            //str2 = "TRAN000".PadRight(6) + str3;
                            str2 = str3;
                            item.TransactionID = str2;
                        }
                        if (reader["PhoneStatus"] != DBNull.Value)
                        {
                            item.IsPhoneAccepted = Convert.ToBoolean(reader["PhoneStatus"].ToString());
                        }
                        if (reader["IsLabourReceivedPhone"] != DBNull.Value)
                        {
                            item.IsLabourReceivedPhone = Convert.ToBoolean(reader["IsLabourReceivedPhone"].ToString());
                        }
                        if (reader["IsTimeExpired"] != DBNull.Value)
                        {
                            item.IsTimeExpired = Convert.ToBoolean(reader["IsTimeExpired"].ToString());
                        }
                        if (item.IsLabourReceivedPhone)
                        {
                            item.TransactionStatus = "Received";
                        }
                        else if ((item.IsPhoneAccepted && (item.CourierDetails != null)) && (item.CourierDetails != ""))
                        {
                            item.TransactionStatus = "In transit";
                        }
                        else if (item.IsPhoneAccepted && (item.CourierDetails == null))
                        {
                            item.TransactionStatus = "Awaiting for Admin Approval";
                        }
                        else if (!(item.IsPhoneAccepted || !item.IsTimeExpired))
                        {
                            item.TransactionStatus = "Rejected";
                        }
                        else if (!item.IsPhoneAccepted)
                        {
                            item.TransactionStatus = "Awaiting for Your Approval";
                        }
                        list.Add(item);
                    }
                }
                return list;
            }
            catch
            {
                return list;
            }
        }

        public string RequestPhone(string RequestPhoneID, string PhoneNumber, string AlternatePhoneNumber, string MailId, string LabourID, string Address, string NewAddress, string Requeststatus)
        {
            try
            {
                SmartLabourEntities entities = new SmartLabourEntities();
                SqlConnection connection = new SqlConnection(connString);
                SqlCommand selectCommand = new SqlCommand("pro_RequestPending", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                selectCommand.Parameters.Add(new SqlParameter("@LabourId", LabourID));
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                adapter.Dispose();
                selectCommand.Dispose();
                connection.Dispose();
                if (Convert.ToInt32(dataSet.Tables[0].Rows[0][0]) == 0)
                {
                    return "You already have a pending request";
                }

                /* To Check The Temp Eirates Id */
                int Count = 0;
                Count = (from n in entities.Labours where n.LabourID.Trim() == LabourID && n.IsOriginalEmirateId == false select n).Count();
                if (Count > 0)
                {
                    return "Your EmiratesId is Temporary";
                }
                /* End Here */

                RequestPhone entity = new RequestPhone
                {
                    PhoneNumber = PhoneNumber,
                    AlternatePhoneNumber = AlternatePhoneNumber,
                    MailId = MailId,
                    LabourID = LabourID,
                    Address = Address,
                    NewAddress = NewAddress,
                    RequestStatus = Requeststatus,
                    RequestedDate = new DateTime?(DateTime.Now)
                };
                entities.RequestPhones.Add(entity);
                entities.SaveChanges();
                var labour = entities.RequestPhones.Where(a => a.LabourID == LabourID).FirstOrDefault();

                string strName = string.Empty;
                string strEmailId = string.Empty;
                if (dataSet != null && dataSet.Tables.Count > 1 && dataSet.Tables[1].Rows.Count > 0)
                {
                    strName = dataSet.Tables[1].Rows[0]["UserName"].ToString();
                    strEmailId = dataSet.Tables[1].Rows[0]["EmailID"].ToString();
                }
                string str4 = new Mailing().SentEmail_PhoneRequest(strEmailId, "Smartlabours-Phone Request", strName).ToString();
                return "SUCCESS";
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }

        public List<ServiceVoucher> ShowAllVourchers(string LabourID)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connString);
                SqlCommand selectCommand = new SqlCommand("pro_Voucher_Labour", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                selectCommand.Parameters.Add(new SqlParameter("@LabourId", LabourID));
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                adapter.Dispose();
                selectCommand.Dispose();
                connection.Dispose();
                List<ServiceVoucher> list = new List<ServiceVoucher>();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ServiceVoucher item = new ServiceVoucher
                    {
                        VoucherID = dataSet.Tables[0].Rows[i]["VoucherID"].ToString(),
                        VoucherCode = dataSet.Tables[0].Rows[i]["Codes"].ToString(),
                        TalkTime = dataSet.Tables[0].Rows[i]["VALUEOFPLAN"].ToString(),
                        Validity = dataSet.Tables[0].Rows[i]["VALIDITY"].ToString(),
                        VoucherImageURL = dataSet.Tables[0].Rows[i]["VoucherImage"].ToString(),
                        IsRead = dataSet.Tables[0].Rows[i]["IsRead"].ToString()
                    };
                    list.Add(item);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public string Signout(string LabourID)
        {
            return "sucess";
        }

        #region Submit Question Answer

        /// <summary>
        /// Submit Question And Answer
        /// </summary>
        /// <param name="LabourID"></param>
        /// <param name="QuestionID"></param>
        /// <param name="AnswerID"></param>
        /// <param name="IsSubmitted"></param>
        /// <returns></returns>
        public string[] SubmitQuestionAndAnswer(string LabourID, string QuestionID, string AnswerID, string IsSubmitted)
        {
            string[] strArray = new string[2];
            try
            {
                string lid = LabourID;
                int qid = Convert.ToInt32(QuestionID);
                int ansid = Convert.ToInt32(AnswerID);
                bool flag = Convert.ToBoolean(IsSubmitted);
                DataSet dsResults = objTransDB.ExecuteDataSet("spSL_SubmitQuestionAndAnswer", lid, qid, ansid);
                strArray[0] = "Correct Answers = " + dsResults.Tables[0].Rows[0][0].ToString();
                strArray[1] = "In-Correct Answers = " + dsResults.Tables[1].Rows[0][0].ToString();
                return strArray;
            }
            catch (Exception exception)
            {
                strArray[0] = exception.Message;
                return strArray;
            }
        }

        #endregion

        #region Terms And Conditions

        /// <summary>
        /// To Get Terms And Conditions
        /// </summary>
        /// <returns></returns>
        public List<TermsCondition> TermsAndConditions()
        {
            try
            {
                SmartLabourEntities entities = new SmartLabourEntities();
                List<TBL_TERMSANDCONDITION_SMT> list = entities.Termsandcondition.Where(a => a.STATUS == true).ToList();
                List<TermsCondition> temp = new List<TermsCondition>();
                if (list.Count() > 0)
                    temp = list.Select(x => new TermsCondition { FullDecription = x.FullDecription, ShortDescription = x.ShortDescription }).ToList();
                return temp;
            }
            catch
            {
                return null;
            }
        }

        #endregion


        public string SubmitHealthAndSafetyReport(string LabourId, string strImage, string strAudio = null, string Comments = null, string ReportParamterType = null)
        {
            CommonFunctions objCommon = new CommonFunctions();
            //byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(strImage);
            //  byte[] toEncodeAsBytes = System.Convert.FromBase64String(strImage);
            // string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            if (Comments == "undefined")
            {
                Comments = "";
            }
            if (strAudio == "undefined")
            {
                strAudio = "";
            }
            SmartLabourEntities entities = new SmartLabourEntities();
            CommonClass objmail = new CommonClass();
            DataAccess ObjDa = new DataAccess();
            DataTable ds = new DataTable();
            //byte[] Image = Convert.FromBase64String(strImage);
            //byte[] Audio;
            //// bool exists = System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Image"));
            //if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Image")))
            //{
            //    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Image"));
            //}
            //if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Audio")))
            //{
            //    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Audio"));
            //}

            //string ImageFileName = "A" + LabourId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //string AudioFileName = "I" + LabourId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //string ImagePath = HttpContext.Current.Server.MapPath("/Upload_Files/Image/") + ImageFileName + ".jpg";
            //string ImagePath2 = HttpContext.Current.Server.MapPath("/Upload_Files/Image/") + ImageFileName + ".png";
            //var bytes = Convert.FromBase64String(strImage);
            //File.WriteAllBytes(ImagePath, Image);
            //File.WriteAllBytes(ImagePath, toEncodeAsBytes);
            ////File.WriteAllBytes(ImagePath2, toEncodeAsBytes);
            //if (strAudio != null && strAudio != "undefined")
            //{
            //    string AudioPath = HttpContext.Current.Server.MapPath("/Upload_Files/Audio/") + AudioFileName + ".mp3";
            //    Audio = Convert.FromBase64String(strAudio);
            //    File.WriteAllBytes(AudioPath, Audio);
            //}
            //else
            //{
            //    AudioFileName = null;
            //}

            ds = ObjDa.InsertHealthAndSafetyReport(LabourId, strImage, strAudio, Comments, ReportParamterType);
            if (ds.Rows[0][0].ToString() == "Duplicate")
            {
                return "Duplicate comments not allowed";
            }

            int HsId = (from n in entities.HealthSafety where n.LabourID == LabourId && n.ImagePath == strImage orderby n.HSId descending select n.HSId).FirstOrDefault();
            if (ds.Rows.Count > 0)
            {
                string Email = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.EmailID).SingleOrDefault();
                int orgId = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.OrgId).SingleOrDefault();

                string EmailOrg = (from n in entities.AdminLogin where n.USERID == orgId && n.STATUS == true select n.USEREMAIL).SingleOrDefault();
                string HostName = (from n in entities.AdminContactus where n.STATUS == true select n.HostName).FirstOrDefault();

                // Common.Encryption.Encrypt(logindtls.USEREMAIL, "SmartLabourAdmin");
                List<TBL_ADMINLOGIN_SMT> Oid = (from m in entities.AdminLogin where m.OrgId == orgId && m.STATUS == true select m).ToList<TBL_ADMINLOGIN_SMT>();
                foreach (TBL_ADMINLOGIN_SMT org in Oid)
                {
                    //string strEmail = Common.Encryption.Encrypt(org.USEREMAIL, "SmartLabourAdmin");
                    //string strLabour = Common.Encryption.Encrypt(org.USEREMAIL, "SmartLabourAdmin");
                    //objmail.UrlGenerator("Contoller","Action","new { Area = ""}));
                    // DecryptedUserId = DecryptedUserId.Replace("(((", "=");
                    // encryptedString = encryptedString.Replace("(((", "=");
                    string UserId = Common.Encryption.Encrypt(Convert.ToString(org.USERID), "SmartLabourAdmin");
                    UserId = objCommon.UrlEncode(UserId);
                    //var EncryptedUSerId = UserId.Replace("/", "$$$");
                    //EncryptedUSerId = EncryptedUSerId.Replace("=", "(((");
                    //EncryptedUSerId = EncryptedUSerId.Replace("+", ")))");
                    string Path = Common.Encryption.Encrypt(Convert.ToString(HsId), "SmartLabourAdmin");
                    Path = objCommon.UrlEncode(UserId);
                    //var EncryptedHsid = Path.Replace("/", "$$$");
                    //EncryptedHsid = EncryptedHsid.Replace("=", "(((");
                    //EncryptedHsid = EncryptedHsid.Replace("+", ")))");

                    string Url = HostName + "/Session/AssignSessionHealth/" + UserId + "/" + "?Hsid=" + Path;
                    //A Health and Safety issue has been added successfully from User (Name of the user). Please click on the link below to post your comments
                    string LabourName = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.Name).SingleOrDefault();
                    objmail.SendingMail(org.USEREMAIL, "Smart Labour - Health and Safety", org.USEREMAIL, Url, "HealthAndSaefty", "A Health and Safety issue has been added successfully from User (" + LabourName + ").  Please click on the link below to post your comments");
                }
                objmail.SendingMail(Email, "Smart Labour", Email, "", "", " Your health and safety issue has submitted successfully !.");
                return "SUCCESS";
            }
            else
            {
                return "NOT SUCCESS";
            }
        }


        #region Insert The Health And Safety

        /// <summary>
        /// To Store the Health and Safety
        /// </summary>
        /// <param name="LabourId">Emirates ID as string</param>
        /// <param name="strImage">Converted Image as string</param>
        /// <param name="strAudio">Converted Audio as string - nullable</param>
        /// <param name="Comments">Comments as string - nullable </param>
        /// <returns></returns>
        public string SubmitHealthAndSafety(string LabourId, string strImage, string strAudio = null, string Comments = null)
        {
            CommonFunctions objCommon = new CommonFunctions();
            //byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(strImage);
            //  byte[] toEncodeAsBytes = System.Convert.FromBase64String(strImage);
            // string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            if (Comments == "undefined")
            {
                Comments = "";
            }
            if (strAudio == "undefined")
            {
                strAudio = "";
            }
            SmartLabourEntities entities = new SmartLabourEntities();
            CommonClass objmail = new CommonClass();
            DataAccess ObjDa = new DataAccess();
            DataTable ds = new DataTable();
            //byte[] Image = Convert.FromBase64String(strImage);
            //byte[] Audio;
            //// bool exists = System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Image"));
            //if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Image")))
            //{
            //    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Image"));
            //}
            //if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Audio")))
            //{
            //    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Audio"));
            //}

            //string ImageFileName = "A" + LabourId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //string AudioFileName = "I" + LabourId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //string ImagePath = HttpContext.Current.Server.MapPath("/Upload_Files/Image/") + ImageFileName + ".jpg";
            //string ImagePath2 = HttpContext.Current.Server.MapPath("/Upload_Files/Image/") + ImageFileName + ".png";
            //var bytes = Convert.FromBase64String(strImage);
            //File.WriteAllBytes(ImagePath, Image);
            //File.WriteAllBytes(ImagePath, toEncodeAsBytes);
            ////File.WriteAllBytes(ImagePath2, toEncodeAsBytes);
            //if (strAudio != null && strAudio != "undefined")
            //{
            //    string AudioPath = HttpContext.Current.Server.MapPath("/Upload_Files/Audio/") + AudioFileName + ".mp3";
            //    Audio = Convert.FromBase64String(strAudio);
            //    File.WriteAllBytes(AudioPath, Audio);
            //}
            //else
            //{
            //    AudioFileName = null;
            //}

            ds = ObjDa.InsertHealthAndSafety(LabourId, strImage, strAudio, Comments);
            if (ds.Rows[0][0].ToString() == "Duplicate")
            {
                return "Duplicate comments not allowed";
            }

            int HsId = (from n in entities.HealthSafety where n.LabourID == LabourId && n.ImagePath == strImage orderby n.HSId descending select n.HSId).FirstOrDefault();
            if (ds.Rows.Count > 0)
            {
                string Email = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.EmailID).SingleOrDefault();
                int orgId = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.OrgId).SingleOrDefault();

                string EmailOrg = (from n in entities.AdminLogin where n.USERID == orgId && n.STATUS == true select n.USEREMAIL).SingleOrDefault();
                string HostName = (from n in entities.AdminContactus where n.STATUS == true select n.HostName).FirstOrDefault();

                // Common.Encryption.Encrypt(logindtls.USEREMAIL, "SmartLabourAdmin");
                List<TBL_ADMINLOGIN_SMT> Oid = (from m in entities.AdminLogin where m.OrgId == orgId && m.STATUS == true select m).ToList<TBL_ADMINLOGIN_SMT>();
                foreach (TBL_ADMINLOGIN_SMT org in Oid)
                {
                    //string strEmail = Common.Encryption.Encrypt(org.USEREMAIL, "SmartLabourAdmin");
                    //string strLabour = Common.Encryption.Encrypt(org.USEREMAIL, "SmartLabourAdmin");
                    //objmail.UrlGenerator("Contoller","Action","new { Area = ""}));
                    // DecryptedUserId = DecryptedUserId.Replace("(((", "=");
                    // encryptedString = encryptedString.Replace("(((", "=");
                    string UserId = Common.Encryption.Encrypt(Convert.ToString(org.USERID), "SmartLabourAdmin");
                    UserId = objCommon.UrlEncode(UserId);
                    //var EncryptedUSerId = UserId.Replace("/", "$$$");
                    //EncryptedUSerId = EncryptedUSerId.Replace("=", "(((");
                    //EncryptedUSerId = EncryptedUSerId.Replace("+", ")))");
                    string Path = Common.Encryption.Encrypt(Convert.ToString(HsId), "SmartLabourAdmin");
                    Path = objCommon.UrlEncode(UserId);
                    //var EncryptedHsid = Path.Replace("/", "$$$");
                    //EncryptedHsid = EncryptedHsid.Replace("=", "(((");
                    //EncryptedHsid = EncryptedHsid.Replace("+", ")))");

                    string Url = HostName + "/Session/AssignSessionHealth/" + UserId + "/" + "?Hsid=" + Path;
                    //A Health and Safety issue has been added successfully from User (Name of the user). Please click on the link below to post your comments
                    string LabourName = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.Name).SingleOrDefault();
                    objmail.SendingMail(org.USEREMAIL, "Smart Labour - Health and Safety", org.USEREMAIL, Url, "HealthAndSaefty", "A Health and Safety issue has been added successfully from User (" + LabourName + ").  Please click on the link below to post your comments");
                }
                objmail.SendingMail(Email, "Smart Labour", Email, "", "", " Your health and safety issue has submitted successfully !.");
                return "SUCCESS";
            }
            else
            {
                return "NOT SUCCESS";
            }
        }

        #endregion

        #region GetArticalList

        /// <summary>
        /// To Return Home Content Article List
        /// </summary>
        /// <returns></returns>
        public List<TBL_Artical_SMT> GetArticleList()
        {
            SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
            return (from n in SmtDbEntites.Artical
                    where n.Status && n.Homecontent
                    select n).ToList<TBL_Artical_SMT>();
        }

        #endregion

        #region Terms And Conditions

        /// <summary>
        /// To Get Terms and Conditions List
        /// </summary>
        /// <returns></returns>
        public List<TBL_TERMSANDCONDITION_SMT> GetTermsAndConditions()
        {
            SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
            List<TBL_TERMSANDCONDITION_SMT> list = new List<TBL_TERMSANDCONDITION_SMT>();
            return (from n in SmtDbEntites.Termsandcondition
                    where n.STATUS
                    orderby n.CREATEDDATE
                    select n).ToList<TBL_TERMSANDCONDITION_SMT>();
        }

        #endregion

        #region Contact Us

        /// <summary>
        /// To Get The Contact Us Details
        /// </summary>
        /// <returns></returns>
        public List<TBL_AdminCONTACTUS_SMT> GetContactUs()
        {
            SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
            List<TBL_AdminCONTACTUS_SMT> list = new List<TBL_AdminCONTACTUS_SMT>();
            return (from n in SmtDbEntites.AdminContactus
                    where n.STATUS
                    orderby n.CREATEDDATE
                    select n).ToList<TBL_AdminCONTACTUS_SMT>();
        }

        /// <summary>
        /// To Store The Contact Us Details
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="PhoneNo"></param>
        /// <param name="Comments"></param>
        /// <returns></returns>
        public string SaveContactus(string FirstName, string LastName, string Email, string PhoneNo, string Comments)
        {
            CommonClass ObjCommon = new CommonClass();
            SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
            TBL_CONTACTUS_SMT objcontact = new TBL_CONTACTUS_SMT();
            objcontact.FIRSTNAME = FirstName;
            objcontact.LASTNAME = LastName;
            objcontact.EMAILID = Email;
            objcontact.COMMENTS = Comments;
            objcontact.PHONENO = PhoneNo;
            objcontact.CREATEDDATE = new DateTime?(DateTime.Now);
            SmtDbEntites.Contactus.Add(objcontact);
            SmtDbEntites.SaveChanges();
            string str = ObjCommon.SendingMail(objcontact.EMAILID, "Smart Labour", objcontact.EMAILID, "", "", "Thank you for contactus we will contact you soon.");
            return "SUCCESS";

        }

        #endregion

        #region GetOrganization List

        /// <summary>
        /// To Get The List Of The Organizations
        /// </summary>
        /// <returns></returns>
        public List<TBL_OrganisationMaster> GetOrganizationList()
        {
            SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
            List<TBL_OrganisationMaster> list = new List<TBL_OrganisationMaster>();
            return (from n in SmtDbEntites.Organisation
                    where n.IsActive
                    orderby n.OrganisationName
                    select n).ToList<TBL_OrganisationMaster>();
        }

        #endregion

        #region Get Testimonal Video List

        /// <summary>
        /// Get Testimonal Video List
        /// </summary>
        /// <returns> Title,Name,Image,MP4filename  and Description </returns>
        public List<TestimonalVideoList> GetTestimonalVideoList()
        {
            try
            {
                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                List<TestimonalVideoList> list = new List<TestimonalVideoList>();
                DataSet dataSet = objTransDB.ExecuteDataSet("Sp_GetTestimaonalVideoList");
                string HostName = (from n in SmtDbEntites.HostName select n.HostName).SingleOrDefault();
                string strPath = string.Empty;
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    string VideoUrl = HostName + "/Uplodify/Testimonialvideo/" + dataSet.Tables[0].Rows[i]["MP4filename"].ToString();
                    //string VideoUrl = "";
                    string path = HostName + "/Uplodify/TestimonialImages/" + dataSet.Tables[0].Rows[i]["Image"].ToString();
                    // byte[] Image = System.IO.File.ReadAllBytes(path);
                    //  string strImage = Convert.ToBase64String(Image);

                    // strPath = strPath + "|||" + path;
                    TestimonalVideoList item = new TestimonalVideoList   //Title,Name,Image,MP4filename,Description
                    {
                        //VideoUrl = string.Empty,
                        VideoUrl = VideoUrl, ///Common.Encryption.Encrypt(VideoUrl, "SmartLabourAdmin"),
                        Name = dataSet.Tables[0].Rows[i]["Name"].ToString(),
                        Title = dataSet.Tables[0].Rows[i]["Title"].ToString(),
                        Image = path,
                        Description = dataSet.Tables[0].Rows[i]["Description"].ToString()
                    };
                    list.Add(item);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Get Testimonal Video List

        /// <summary>
        /// Get Testimonal Video List
        /// </summary>
        /// <returns> Title,Name,Image,MP4filename  and Description </returns>
        public string GetTestimonalVideoList1()
        {
            try
            {
                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                List<TestimonalVideoList> list = new List<TestimonalVideoList>();
                DataSet dataSet = objTransDB.ExecuteDataSet("SL_SP_WebServiceURL");
                string strPath = dataSet.Tables[0].Rows[0]["URL"].ToString();

                //for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                //{
                //    string VideoUrl = System.Web.HttpContext.Current.Server.MapPath("/Uplodify/Testimonialvideo/" + dataSet.Tables[0].Rows[i]["MP4filename"].ToString());                    
                //    string path = System.Web.HttpContext.Current.Server.MapPath("~/Uplodify/TestimonialImages/" + dataSet.Tables[0].Rows[i]["Image"].ToString());
                //    byte[] Image = System.IO.File.ReadAllBytes(path);
                //     string strImage = Convert.ToBase64String(Image);

                //    strPath = strPath + "|||" + path;
                //    TestimonalVideoList item = new TestimonalVideoList   //Title,Name,Image,MP4filename,Description
                //    {
                //        //VideoUrl = string.Empty,
                //        VideoUrl = VideoUrl,//Common.Encryption.Encrypt(VideoUrl, "SmartLabourAdmin"),
                //        Name = dataSet.Tables[0].Rows[i]["Name"].ToString(),
                //        Title = dataSet.Tables[0].Rows[i]["Title"].ToString(),
                //        Image = path,
                //        Description = dataSet.Tables[0].Rows[i]["Description"].ToString()
                //    };
                //    list.Add(item);
                //}
                ////return list;
                return strPath;
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                //string str = ex.ToString() + "|||";
                return raise.ToString();
            }
        }


        #endregion

        #region Get Category List

        /// <summary>
        /// Get Category List
        /// </summary>
        /// <returns>  </returns>
        public List<Category> GetCategoryList(string OrgId)
        {
            try
            {
                //Category
                int Orgid = 0;
                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                List<TBL_CategoryMaster> list = new List<TBL_CategoryMaster>();
                Orgid = Convert.ToInt32(OrgId);
                list = (from n in SmtDbEntites.Category where n.OrgId == Orgid && n.Status == true select n).ToList();
                // return list;

                List<Category> list2 = new List<Category>();
                foreach (TBL_CategoryMaster CM in list)
                {
                    Category item = new Category
                    {
                        CategoryId = CM.CategoryId,
                        CategoryName = CM.CategoryName,
                        OrgId = CM.OrgId,
                        CreatedBy = CM.CreatedBy,

                        ModifiedBy = CM.ModifiedBy,
                        CreatedDate = Convert.ToString(CM.CreatedDate),
                        ModifiedDate = Convert.ToString(CM.ModifiedDate),
                        Status = CM.Status
                    };
                    list2.Add(item);
                }
                return list2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Sub Category List

        /// <summary>
        /// Get Sub Category List
        /// </summary>
        /// <returns>  </returns>
        public List<SubCategory> GetSubCategoryList(string CategoryId)
        {
            try
            {
                int Categoryid = 0;
                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                List<TBL_SubCategoryMaster> list = new List<TBL_SubCategoryMaster>();
                Categoryid = Convert.ToInt32(CategoryId);
                list = (from n in SmtDbEntites.SubCategory where n.CategoryId == Categoryid & n.Status == true select n).ToList();

                List<SubCategory> list2 = new List<SubCategory>();
                foreach (TBL_SubCategoryMaster SCM in list)
                {
                    SubCategory item = new SubCategory
                    {
                        SubCategoryId = SCM.SubCategoryId,
                        SubCategoryName = SCM.SubCategoryName,
                        CategoryId = Convert.ToInt32(SCM.CategoryId),
                        CreatedBy = SCM.CreatedBy,
                        ModifiedBy = SCM.ModifiedBy,
                        CreatedDate = Convert.ToString(SCM.CreatedDate),
                        ModifiedDate = Convert.ToString(SCM.ModifiedDate),
                        Status = SCM.Status,
                    };
                    list2.Add(item);
                }
                return list2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Category List

        /// <summary>
        /// Get Category List
        /// </summary>//
        /// <returns>  </returns>
        public string GetCategoryList1(string OrgId)
        {
            try
            {
                int Orgid = 0;
                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                List<TBL_CategoryMaster> list = new List<TBL_CategoryMaster>();
                Orgid = Convert.ToInt32(OrgId);
                list = (from n in SmtDbEntites.Category where n.OrgId == Orgid && n.Status == true select n).ToList();
                // return list;
                return "Success;";
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                //string str = ex.ToString() + "|||";
                return raise.ToString();
            }
        }
        #endregion

        #region Get Country List

        /// <summary>
        /// Get Country List
        /// </summary>
        /// <returns>  </returns>
        public List<Country> GetCountryList()
        {
            try
            {
                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                List<TBL_Countries> list = new List<TBL_Countries>();
                list = (from n in SmtDbEntites.Countries select n).ToList();

                List<Country> list2 = new List<Country>();
                foreach (TBL_Countries CM in list)
                {
                    Country item = new Country
                    {
                        CountryCode = CM.CountryCode,
                        CountryName = CM.CountryName
                    };
                    list2.Add(item);
                }
                return list2;
            }
            catch (Exception)
            {
                List<Country> list2 = new List<Country>();
                return list2;
            }
        }

        #endregion

        #region Posting Testimonial Labour & Sponsor

        /// <summary>
        /// Post The Testimonial For Labour and Sponsor
        /// </summary>
        /// <param name="Title">string</param>
        /// <param name="Name">string</param>
        /// <param name="Designation">string</param>
        /// <param name="Desccription">string</param>
        /// <param name="UserId">string</param>
        /// <param name="strImage">Base64string</param>
        /// <param name="strVideo">Base64string</param>
        /// <param name="UserType">string</param>
        /// <returns>Status Message</returns>
        public string PostTestimonial(string Title, string Name, string Designation, string Desccription, string UserId, string strImage, string strVideo)
        {
            try
            {
                TBL_TESTIMONIAL_SMT objTestimonial = new TBL_TESTIMONIAL_SMT();
                //  byte[] Image = Convert.FromBase64String(strImage);
                //  string ImageFileName = "Img" + UserId + "_" + DateTime.Now.ToString("yyyyMMddHHmm");
                // string VideoFileName = "Video" + UserId + "_" + DateTime.Now.ToString("yyyyMMddHHmm");
                // string ImagePath = HttpContext.Current.Server.MapPath("/Uplodify/TestimonialImages/") + ImageFileName + ".jpg";
                // var bytes = Convert.FromBase64String(strImage);
                //   File.WriteAllBytes(ImagePath, Image);
                ///  if (strVideo != null)
                //  {
                //  string VideoPath = HttpContext.Current.Server.MapPath("/Uplodify/Testimonialvideo/") + VideoFileName + ".mp4";
                ////  Video = Convert.FromBase64String(strVideo);
                //File.WriteAllBytes(VideoPath, Video);
                // }
                DataSet dataSet = objTransDB.ExecuteDataSet("SMT_SP_PostTestimonial", Title, Name, Designation, Desccription, strImage, null, null, strVideo);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    return "SUCCESS";
                }
                return "NOT SUCCESS";
            }
            catch
            {
                return "NOT SUCCESS";
            }
        }

        /// <summary>
        /// Post The Testimonial For Labour and Sponsor
        /// </summary>
        /// <param name="Title">string</param>
        /// <param name="Name">string</param>
        /// <param name="Designation">string</param>
        /// <param name="Desccription">string</param>
        /// <param name="UserId">string</param>
        /// <param name="strImage">Base64string</param>
        /// <param name="strVideo">Base64string</param>
        /// <param name="UserType">string</param>
        /// <returns>Status Message</returns>
        public string PostTestimonial1(string Title, string Name, string Designation, string Desccription, string UserId, string strImage, string strVideo)
        {
            try
            {
                CommonFunctions objCommon1 = new CommonFunctions();
                TBL_TESTIMONIAL_SMT objTestimonial = new TBL_TESTIMONIAL_SMT();
                //  byte[] Image = Convert.FromBase64String(strImage);
                string ImageFileName = "Img" + UserId + "_" + DateTime.Now.ToString("yyyyMMddHHmm");
                // string VideoFileName = "Video" + UserId + "_" + DateTime.Now.ToString("yyyyMMddHHmm");

                // var bytes = Convert.FromBase64String(strImage);
                //   File.WriteAllBytes(ImagePath, Image);
                ///  if (strVideo != null)
                //  {
                //  string VideoPath = HttpContext.Current.Server.MapPath("/Uplodify/Testimonialvideo/") + VideoFileName + ".mp4";
                ////  Video = Convert.FromBase64String(strVideo);
                //File.WriteAllBytes(VideoPath, Video);
                // }
                if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Uplodify/TestimonialImages")))
                {
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Uplodify/TestimonialImages"));
                }
                string ImagePath = HttpContext.Current.Server.MapPath("/Uplodify/TestimonialImages/") + ImageFileName + ".jpg";
                strImage = objCommon1.UrlDecode(strImage);
                Image img = objCommon1.Base64ToImage(strImage);

                var bytes = Convert.FromBase64String(strImage);
                using (var imageFile = new FileStream(ImagePath, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }
                DataSet dataSet = objTransDB.ExecuteDataSet("SMT_SP_PostTestimonial", Title, Name, Designation, Desccription, strImage, null, null, strVideo);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    return "SUCCESS";
                }
                return "NOT SUCCESS";
            }
            catch
            {
                return "NOT SUCCESS";
            }
        }

        #endregion

        #region Get Question List

        /// <summary>
        /// To Get Particular Question List
        /// </summary>
        /// <returns>  </returns>
        public List<QuestionList> GetQuestionList(string QuestionId)
        {
            try
            {
                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                List<TBL_QUESTION_SMT> list = new List<TBL_QUESTION_SMT>();
                list = (from n in SmtDbEntites.Question select n).ToList();
                string HostName = (from n in SmtDbEntites.HostName select n.HostName).SingleOrDefault();
                List<QuestionList> list2 = new List<QuestionList>();
                QuestionList item = new QuestionList();
                foreach (TBL_QUESTION_SMT QM in list)
                {
                    if (QM.QuestionType == true)
                    {
                        item = new QuestionList
                        {
                            CourseID = Convert.ToString(QM.CourseID),
                            QuestionID = Convert.ToString(QM.QuestionID),
                            QuestionType = "Text",
                            QustionDesc = QM.QuestionDesc,
                            CreditPoints = Convert.ToString(QM.CreditPoints)
                        };
                    }
                    else if (QM.QuestionType == false)
                    {
                        string VideoPath = HostName + "/Uplodify/QuestionVideos/" + QM.QuestionDesc;

                        item = new QuestionList
                        {
                            CourseID = Convert.ToString(QM.CourseID),
                            QuestionID = Convert.ToString(QM.QuestionID),
                            QuestionType = "Video",
                            QustionDesc = VideoPath,
                            CreditPoints = Convert.ToString(QM.CreditPoints)
                        };
                    }
                    list2.Add(item);
                }
                return list2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get All Questions List for a Course
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public List<ServiceQuestionList> GetAllQuestionList(string CourseId, string LabourId)
        {
            // List<TBL_QUESTION_SMT> list = new List<TBL_QUESTION_SMT>();
            List<TBL_ANSWER_SMT> list = new List<TBL_ANSWER_SMT>();
            List<ServiceQuestionList> list2 = new List<ServiceQuestionList>();
            try
            {
                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                DataSet dsResults = objTransDB.ExecuteDataSet("spSL_CourseLanguage", CourseId);
                int CourseID = 0;
                if (CourseId != string.Empty)
                {
                    CourseID = Convert.ToInt32(CourseId);
                }
                int? CategoryId = 0;
                int? SubCategoryId = 0;
                CategoryId = (from n in SmtDbEntites.Labours where n.LabourID.Trim() == LabourId.Trim() && n.STATUS == true select n.CategoryId).SingleOrDefault();
                SubCategoryId = (from m in SmtDbEntites.Labours where m.LabourID.Trim() == LabourId.Trim() && m.STATUS == true select m.SubCategoryId).SingleOrDefault();

                if (SubCategoryId == 0)
                {
                    /*For Non  SubCategoryId*/
                    list = (from n in SmtDbEntites.Question
                            join m in SmtDbEntites.Courses on n.CourseID equals m.CourseID
                            join o in SmtDbEntites.Answer on n.QuestionID equals o.QuestionID
                            where n.CourseID == CourseID && m.CategoryId == CategoryId && m.STATUS == true
                            select o).ToList();
                }
                else
                {
                    /*For  SubCategoryId*/
                    list = (from n in SmtDbEntites.Question
                            join m in SmtDbEntites.Courses on n.CourseID equals m.CourseID
                            join o in SmtDbEntites.Answer on n.QuestionID equals o.QuestionID
                            where n.CourseID == CourseID && m.CategoryId == CategoryId && m.SubCategoryId == SubCategoryId && m.STATUS == true
                            select o).ToList();
                }

                //  List<TBL_ANSWER_SMT> list = (from n in entities.Answer.Include("question")
                //                             where n.question.CourseID == id
                //                             select n).ToList<TBL_ANSWER_SMT>();
                //List<ServiceCourse> list2 = new List<ServiceCourse>();
                //foreach (TBL_ANSWER_SMT tbl_answer_smt in list)
                //{
                //    ServiceCourse item = new ServiceCourse
                //    {
                //        CourseID = course.CourseID,
                //        CourseName = course.CourseName,
                //        Title = course.QuestionTitle,
                //        QuestionID = tbl_answer_smt.question.QuestionID,
                //        QuestionDesc = tbl_answer_smt.question.QuestionDesc,
                //        AnswerID = tbl_answer_smt.AnswerID,
                //        AnswerDesc = tbl_answer_smt.AnswerDesc
                //    };
                //    list2.Add(item);


                // list = (from m in list.ToList() join n in SmtDbEntites.Labours.ToList() on m.cos.CategoryId equals n.CategoryId select m);
                string HostName = (from n in SmtDbEntites.HostName select n.HostName).SingleOrDefault();

                ServiceQuestionList item = new ServiceQuestionList();
                foreach (TBL_ANSWER_SMT QM in list)
                {
                    if (QM.question.QuestionType == true)
                    {
                        item = new ServiceQuestionList
                        {
                            CourseID = Convert.ToString(QM.question.CourseID),
                            QuestionID = Convert.ToString(QM.QuestionID),
                            QuestionType = "Text",
                            QustionDesc = QM.question.QuestionDesc,
                            CreditPoints = Convert.ToString(QM.question.CreditPoints),
                            AnswerID = QM.AnswerID,
                            AnswerDesc = QM.AnswerDesc,
                            Language = dsResults.Tables[0].Rows[0][0].ToString()
                        };
                    }
                    else if (QM.question.QuestionType == false)
                    {
                        string VideoPath = HostName + "/Uplodify/QuestionVideos/" + QM.question.QuestionDesc;
                        item = new ServiceQuestionList
                        {
                            CourseID = Convert.ToString(QM.question.CourseID),
                            QuestionID = Convert.ToString(QM.QuestionID),
                            QuestionType = "Video",
                            QustionDesc = VideoPath,
                            CreditPoints = Convert.ToString(QM.question.CreditPoints),
                            AnswerID = QM.AnswerID,
                            AnswerDesc = QM.AnswerDesc,
                            Language = dsResults.Tables[0].Rows[0][0].ToString()
                        };
                    }
                    list2.Add(item);
                }
                return list2;
            }
            catch (Exception)
            {
                return list2;
            }
        }

        #endregion

        #region Push notification mesage send to labours

        /// <summary>
        /// Send Notification Message to Particular Labour in Organization
        /// </summary>
        /// <param name="LabourId"></param>
        /// <returns></returns>
        public string GetPushNotification(string LabourId)
        {
            SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
            CommonClass objCommon = new CommonClass();
            int OrgId = 0;
            OrgId = objCommon.GetOrgIdFromLabour(LabourId);
            string Message = (from n in SmtDbEntites.NotificationMessage where n.OrgId == OrgId && n.Status == true select n.PushMessage).FirstOrDefault();
            return Message;
        }

        #endregion

        #region ServiceTypeList

        /// <summary>
        /// Get the Service Types
        /// </summary>       
        /// <returns></returns>
        public List<ServicePlanTypeList> GetServiceTypeList()
        {
            try
            {
                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                List<TBL_SERVICETYPE_SMT> list = new List<TBL_SERVICETYPE_SMT>();
                list = (from n in SmtDbEntites.ServiceType where n.STATUS == true select n).ToList<TBL_SERVICETYPE_SMT>();
                List<ServicePlanTypeList> list2 = new List<ServicePlanTypeList>();
                foreach (TBL_SERVICETYPE_SMT CM in list)
                {
                    ServicePlanTypeList item = new ServicePlanTypeList
                    {
                        ServiceTypeId = CM.SERVICETYPEID,
                        ServiceTypeName = CM.SERVICETYPENAME
                    };
                    list2.Add(item);
                }
                return list2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Upload Files

        [WebMethod]
        [HttpPost]
        public string AttachFiles()
        {
            try
            {
                string FileName1 = "Not Success";
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                    {
                        HttpPostedFile file = HttpContext.Current.Request.Files["Image"];
                        if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Image")))
                        {
                            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Image"));
                        }
                        string FileType = string.Empty;
                        FileType = file.FileName.Substring(file.FileName.Length - 3, 3);

                        if (FileType == "jpg" || FileType == "jpeg")
                        {
                            using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/Upload_Files/Image/") + file.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                            {
                                file.InputStream.CopyTo(fileStream);
                                FileName1 = "Success";
                            }
                        }

                        HttpPostedFile file1 = HttpContext.Current.Request.Files["Audio"];
                        if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Audio")))
                        {
                            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Audio"));
                        }

                        FileType = file1.FileName.Substring(file1.FileName.Length - 3, 3);

                        if (FileType == "wav" || FileType == "mp3")
                        {
                            using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/Upload_Files/Audio/") + file1.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                            {
                                file1.InputStream.CopyTo(fileStream);
                            }
                        }
                    }
                }
                return FileName1;
            }
            catch
            {
                return "NOT SUCCESS";
            }
            //SmartLabourEntities entities = new SmartLabourEntities();
            //CommonClass objmail = new CommonClass();
            //DataAccess ObjDa = new DataAccess();
            //DataTable ds = new DataTable();
            //string ImageFileName = string.Empty;
            //string AudioFileName = string.Empty;
            //try {

            //    if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Image")))
            //    {
            //        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Image"));
            //    }
            //    if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Audio")))
            //    {
            //        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Audio"));
            //    }

            //     ImageFileName = "Img" + LabourId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //     AudioFileName = "Audio" + LabourId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

            //    if (HttpContext.Current.Request.Files.Count > 0)
            //    {
            //        HttpPostedFile file = HttpContext.Current.Request.Files[0];
            //        string FileType = file.FileName.Substring(file.FileName.Length - 3, 3);
            //        if (FileType == "jpg")
            //        {                     
            //            using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/Upload_Files/Image/") + ImageFileName + ".jpg", System.IO.FileMode.Create, System.IO.FileAccess.Write))
            //            {
            //                file.InputStream.CopyTo(fileStream);
            //            }
            //        }
            //        if (FileType == "mp3")
            //        {
            //            FileType = "Test";
            //            using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/Upload_Files/Audio/") + AudioFileName + ".jpg", System.IO.FileMode.Create, System.IO.FileAccess.Write))
            //            {
            //                file.InputStream.CopyTo(fileStream);
            //            }
            //        }

            //        return file.ContentType + "_Success_" + file.FileName + "_" + FileType;
            //    }

            //    }
            //catch(Exception Ex)
            //{
            //    return Ex.ToString();
            //}

            //ds = ObjDa.InsertHealthAndSafety(LabourId, ImageFileName, AudioFileName, Comments);

            //int HsId = (from n in entities.HealthSafety where n.LabourID == LabourId && n.ImagePath == ImageFileName select n.HSId).SingleOrDefault();

            //if (ds.Rows.Count > 0)
            //{
            //    string Email = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.EmailID).SingleOrDefault();
            //    int orgId = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.OrgId).SingleOrDefault();

            //    string EmailOrg = (from n in entities.AdminLogin where n.USERID == orgId && n.STATUS == true select n.USEREMAIL).SingleOrDefault();
            //    string HostName = (from n in entities.HostName select n.HostName).SingleOrDefault();

            //    // Common.Encryption.Encrypt(logindtls.USEREMAIL, "SmartLabourAdmin");
            //    List<TBL_ADMINLOGIN_SMT> Oid = (from m in entities.AdminLogin where m.OrgId == orgId && m.STATUS == true select m).ToList<TBL_ADMINLOGIN_SMT>();
            //    foreach (TBL_ADMINLOGIN_SMT org in Oid)
            //    {                  
            //        string UserId = Common.Encryption.Encrypt(Convert.ToString(org.USERID), "SmartLabourAdmin");
            //        var EncryptedUSerId = UserId.Replace("/", "$$$");
            //        EncryptedUSerId = EncryptedUSerId.Replace("=", "(((");
            //        EncryptedUSerId = EncryptedUSerId.Replace("+", ")))");
            //        string Path = Common.Encryption.Encrypt(Convert.ToString(HsId), "SmartLabourAdmin");
            //        var EncryptedHsid = Path.Replace("/", "$$$");
            //        EncryptedHsid = EncryptedHsid.Replace("=", "(((");
            //        EncryptedHsid = EncryptedHsid.Replace("+", ")))");
            //        string Url = HostName + "/Session/AssignSessionHealth/" + EncryptedUSerId + "/" + "?Hsid=" + EncryptedHsid;

            //        //A Health and Safety issue has been added successfully from User (Name of the user). Please click on the link below to post your comments

            //        string LabourName = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.Name).SingleOrDefault();
            //        objmail.SendingMail(org.USEREMAIL, "Smart Labour - Health and Safety", org.USEREMAIL, Url, "HealthAndSaefty", "A Health and Safety issue has been added successfully from User (" + LabourName + ").  Please click on the link below to post your comments");
            //    }

            //    objmail.SendingMail(Email, "Smart Labour", Email, "", "", " Your health and safety issue has submitted successfully !.");
            //    return "SUCCESS";
            //}
            //else
            //{
            //    return "NOT SUCCESS";
            //}
        }

        public static DataTable ConvertListToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }


        public string ReadMessageNotification(ReadMessageNotification _ReadMessageNotification)
        {

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database database = factory.Create("DefaultConnection");
            DataSet dsResult;
            using (var sqlCmd = database.GetStoredProcCommand("dbo.spSM_SaveMobileNotificationReadTransaction"))
            {
                var db = (SqlDatabase)database;
                db.AddInParameter(sqlCmd, "pNotificationTransaction", SqlDbType.Structured, ConvertListToDataTable(_ReadMessageNotification.MNotificationTransaction));
                db.AddInParameter(sqlCmd, "pLabourID", SqlDbType.VarChar, _ReadMessageNotification.LabourID);
                db.AddInParameter(sqlCmd, "pTransactionType", SqlDbType.VarChar, _ReadMessageNotification.TransactionType);
                dsResult = db.ExecuteDataSet(sqlCmd);
            }
            return dsResult.Tables[0].Rows[0][0].ToString();
        }

        public void UploadImage(string filename, Stream image)
        {
            var buf = new byte[1024];
            var path = Path.Combine(@"e:\temp\output\", filename);
            int len = 0;
            using (var fs = File.Create(path))
            {
                while ((len = image.Read(buf, 0, buf.Length)) > 0)
                {
                    fs.Write(buf, 0, len);
                }
            }
        }

        /// <summary>
        /// Uploads a Image and Audio Files in Web service using Multipart Form Data
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [HttpPost]
        public string AttachHealthFiles()
        {
            string DateTime1 = string.Empty;
            DateTime1 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            DataSet dataSet = new DataSet();
            try
            {
                DataAccess ObjDa = new DataAccess();
                DataTable ds = new DataTable();
                string FileName1 = "Not Success";
                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "Before");
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideFileCount=" + HttpContext.Current.Request.Files.Count.ToString());
                    for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                    {
                        dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideFileLoop_" + i.ToString());
                        HttpPostedFile file = HttpContext.Current.Request.Files[i];
                        if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Image")))
                        {
                            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Image"));
                        }

                        if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Audio")))
                        {
                            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Audio"));
                        }

                        string FileType = file.FileName.Substring(file.FileName.Length - 3, 3);
                        string exttension = System.IO.Path.GetExtension(file.FileName);
                        FileType = exttension;
                        dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "SplitFileType_" + FileType);
                        if (FileType == "jpg" || FileType == "jpeg")
                        {
                            dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideImageFileType_" + FileType);
                            using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/Upload_Files/Image/") + file.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                            {
                                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "BeforeImageFileCreate_" + file.FileName);
                                file.InputStream.CopyTo(fileStream);
                                FileName1 = "Success";
                                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "AfterImageFileCreate_" + file.FileName);
                            }
                        }

                        if (FileType == "wav" || FileType == "mp3")
                        {
                            dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideAudioFileType_" + FileType);
                            using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/Upload_Files/Audio/") + file.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                            {
                                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "BeforeAudioFileCreate_" + file.FileName);
                                file.InputStream.CopyTo(fileStream);
                                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "AfterAudioFileCreate_" + file.FileName);

                            }
                        }
                    }
                }
                return FileName1;
            }
            catch (Exception Ex)
            {
                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "Exception_" + Ex.ToString());
                return "NOT SUCCESS";
            }
        }

        // [WebMethod]
        // [HttpPost]
        public string AttachFilesTest(string LabourId, string Comments = null)
        {
            SmartLabourEntities entities = new SmartLabourEntities();
            CommonClass objmail = new CommonClass();
            DataAccess ObjDa = new DataAccess();
            DataTable ds = new DataTable();
            string ImageFileName = string.Empty;
            string AudioFileName = string.Empty;
            try
            {

                if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Image")))
                {
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Image"));
                }
                if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Upload_Files/Audio")))
                {
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Upload_Files/Audio"));
                }

                ImageFileName = "Img" + LabourId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                AudioFileName = "Audio" + LabourId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    HttpPostedFile file = HttpContext.Current.Request.Files[0];
                    string FileType = file.FileName.Substring(file.FileName.Length - 3, 3);
                    if (FileType == "jpg")
                    {
                        using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/Upload_Files/Image/") + ImageFileName + ".jpg", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                        {
                            file.InputStream.CopyTo(fileStream);
                        }
                    }
                    if (FileType == "mp3")
                    {
                        FileType = "Test";
                        using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/Upload_Files/Audio/") + AudioFileName + ".jpg", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                        {
                            file.InputStream.CopyTo(fileStream);
                        }
                    }
                    return file.ContentType + "_Success_" + file.FileName + "_" + FileType;
                }

            }
            catch (Exception Ex)
            {
                return Ex.ToString();
            }

            ds = ObjDa.InsertHealthAndSafety(LabourId, ImageFileName, AudioFileName, Comments);

            int HsId = (from n in entities.HealthSafety where n.LabourID == LabourId && n.ImagePath == ImageFileName select n.HSId).SingleOrDefault();

            if (ds.Rows.Count > 0)
            {
                string Email = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.EmailID).SingleOrDefault();
                int orgId = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.OrgId).SingleOrDefault();

                string EmailOrg = (from n in entities.AdminLogin where n.USERID == orgId && n.STATUS == true select n.USEREMAIL).SingleOrDefault();
                string HostName = (from n in entities.HostName select n.HostName).SingleOrDefault();

                // Common.Encryption.Encrypt(logindtls.USEREMAIL, "SmartLabourAdmin");
                List<TBL_ADMINLOGIN_SMT> Oid = (from m in entities.AdminLogin where m.OrgId == orgId && m.STATUS == true select m).ToList<TBL_ADMINLOGIN_SMT>();
                foreach (TBL_ADMINLOGIN_SMT org in Oid)
                {
                    string UserId = Common.Encryption.Encrypt(Convert.ToString(org.USERID), "SmartLabourAdmin");
                    var EncryptedUSerId = UserId.Replace("/", "$$$");
                    EncryptedUSerId = EncryptedUSerId.Replace("=", "(((");
                    EncryptedUSerId = EncryptedUSerId.Replace("+", ")))");
                    string Path = Common.Encryption.Encrypt(Convert.ToString(HsId), "SmartLabourAdmin");
                    var EncryptedHsid = Path.Replace("/", "$$$");
                    EncryptedHsid = EncryptedHsid.Replace("=", "(((");
                    EncryptedHsid = EncryptedHsid.Replace("+", ")))");
                    string Url = HostName + "/Session/AssignSessionHealth/" + EncryptedUSerId + "/" + "?Hsid=" + EncryptedHsid;

                    //A Health and Safety issue has been added successfully from User (Name of the user). Please click on the link below to post your comments

                    string LabourName = (from n in entities.Labours where n.LabourID == LabourId && n.STATUS == true select n.Name).SingleOrDefault();
                    objmail.SendingMail(org.USEREMAIL, "Smart Labour - Health and Safety", org.USEREMAIL, Url, "HealthAndSaefty", "A Health and Safety issue has been added successfully from User (" + LabourName + ").  Please click on the link below to post your comments");
                }

                objmail.SendingMail(Email, "Smart Labour", Email, "", "", " Your health and safety issue has submitted successfully !.");
                return "SUCCESS";
            }
            else
            {
                return "NOT SUCCESS";
            }
        }

        #endregion

        #region Get State List

        /// <summary>
        /// Get State List
        /// </summary>
        /// <returns>  </returns>
        public List<State> GetStateList(string CountryName)
        {
            try
            {

                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                List<TBL_States> list = new List<TBL_States>();
                int CountryId = 0;
                try
                {
                    CountryId = (from n in SmtDbEntites.Countries where n.CountryName.ToLower().Trim() == CountryName.ToLower().Trim() select n.CountryId).SingleOrDefault();
                }
                catch
                {
                }
                list = (from n in SmtDbEntites.States where n.CountryId == CountryId select n).ToList();

                List<State> list2 = new List<State>();
                foreach (TBL_States CM in list)
                {
                    State item = new State
                    {
                        StateId = CM.StateId,
                        StateName = CM.StateName
                    };
                    list2.Add(item);
                }
                return list2;
            }
            catch (Exception)
            {
                List<State> list2 = new List<State>();
                return list2;
            }
        }

        #endregion

        #region Get City List

        /// <summary>
        /// Get City List
        /// </summary>
        /// <returns>  </returns>
        public List<City> GetCityList(string StateName)
        {
            try
            {

                SmartLabourEntities SmtDbEntites = new SmartLabourEntities();
                List<TBL_Cities> list = new List<TBL_Cities>();

                Int64 StateId = 0;
                try
                {
                    StateId = (from n in SmtDbEntites.States where n.StateName.ToLower().Trim() == StateName.ToLower().Trim() select n.StateId).SingleOrDefault();
                }
                catch (Exception)
                {

                }

                list = (from n in SmtDbEntites.Cities where n.StateId == StateId select n).ToList();

                List<City> list2 = new List<City>();
                foreach (TBL_Cities CM in list)
                {
                    City item = new City
                    {
                        //CountryId=CM.CountryId,
                        CityId = CM.CityId,
                        CityName = CM.CityName
                    };
                    list2.Add(item);
                }
                return list2;
            }
            catch (Exception)
            {
                List<City> list2 = new List<City>();
                return list2;
            }
        }

        #endregion

    }

}
