using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartLabours
{
    public class RouteConfig
    {
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        name: "Default",
        //        url: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        //    );
        //}
            public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute("Articles", "Articles/{Id}", new { controller = "ArticalFront", action = "Articals" });
        routes.MapRoute("ArticleDetails", "ArticleDetails/{Id}", new { controller = "ArticalFront", action = "ArticalDetails" });
        routes.MapRoute("Testimonials", "Testimonials/{page}", new { controller = "TestimonialFront", action = "Testimonials" });
        routes.MapRoute("SponsorDetails", "SponsorDetails", new { controller = "sponsor", action = "SponsorDetails" });
        routes.MapRoute("LabourDetails", "LabourDetails", new { controller = "Labour", action = "LabourDetails" });
        routes.MapRoute("AboutUs", "AboutUs", new { controller = "AboutUs", action = "AboutUs" });
        routes.MapRoute("SponsorProfileDetails", "SponsorProfileDetails", new { controller = "SponsorAccount", action = "ProfileDetails" });
        routes.MapRoute("LabourProfileDetails", "LabourProfileDetails", new { controller = "LabourAccount", action = "ProfileDetails" });
        routes.MapRoute("ContactUs", "ContactUs", new { controller = "ContactUs", action = "Contactus" });
        routes.MapRoute("SponsorRegistration", "SponsorRegistration", new { controller = "Sponsor", action = "SponsorRegister" });
        routes.MapRoute("Sponsorforgotpassword", "Sponsorforgotpassword", new { controller = "Home", action = "sponsorforgotpassword" });
        routes.MapRoute("LabourRegistration", "LabourRegistration", new { controller = "Labour", action = "Register" });
        routes.MapRoute("Labourforgotpassword", "Labourforgotpassword", new { controller = "Home", action = "forgotpassword" });
        routes.MapRoute("Termsandcondition", "Termsandcondition", new { controller = "Termsandcondition", action = "Termsandcondition" });
        routes.MapRoute("PostTestimonial", "PostTestimonial", new { controller = "LabourAccount", action = "PostTestimonial" });
        routes.MapRoute("LabourDetails/{page}", "LabourDetails/{page}", new { controller = "Labour", action = "LabourDetails" });
        routes.MapRoute("SponsorDetails/{page}", "SponsorDetails/{page}", new { controller = "Sponsor", action = "SponsorDetails" });
        routes.MapRoute("Sitemap", "Sitemap", new { controller = "Home", action = "sitemap" });
        routes.MapRoute("PhoneTransactionHistory ", "PhoneTransactionHistory", new { controller = "PhoneAcceptedHistory", action = "PhoneAssignedHistory" });
        routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
    }

    }
}