using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Services.Description;
using System.Web.Mvc;
using System.Web.Security;
using NextFlex_Configurator.Models;
using System.Configuration;
using System.Security.Principal;

namespace NextFlex_Configurator.Services
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeAttributes : FilterAttribute, IAuthorizationFilter
    {
        public AuthorizeAttributes(){}
        protected virtual bool AuthorizeCore(HttpContextBase httpContext){ return true; }  
        public virtual void OnAuthorization(AuthorizationContext filterContext){}  
        protected void HandleUnauthorizedRequest(AuthorizationContext filterContext){}  
    }
      
    public abstract class RoleResolverClass : RoleProvider
    //public class RoleResolverClass
    {
        public override string[] GetRolesForUser(string username)
        //public string[] GetRolesForUser(string username)
        {
            using (DbContextEntities db = new DbContextEntities())
            {
                var objUser = db.users.FirstOrDefault(x => x.username == username);
                user usr = db.users.FirstOrDefault(u => u.username.Equals(username, StringComparison.CurrentCultureIgnoreCase) || u.username.Equals(username, StringComparison.CurrentCultureIgnoreCase));

                var roles = from ur in db.users
                            from r in db.access_level
                            where ur.access_level == r.accesslevel
                            select r.accesslevel_desc;
                
                if (objUser == null)
                {
                    return null;
                }
                else
                {
                    //string[] ret = objUser.access_level.ToString(
                    return null;
                }
                /*
                if (roles != null)
                    return roles.ToArray();
                else
                    return new string[] { };
                */
                
            }
        }

       public override bool IsUserInRole(string username, string roleName)
        ///public bool IsUserInRole(string username, string roleName)
        {
            using (DbContextEntities db = new DbContextEntities())
            {
                user usr = db.users.FirstOrDefault(u => u.username.Equals(username, StringComparison.CurrentCultureIgnoreCase) || u.device_id.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));

                var roles = from ur in db.users
                            from r in db.access_level
                            where ur.access_level == r.accesslevel
                            select r.accesslevel_desc;
                if (usr != null)
                    return roles.Any(r => r.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
                else
                    return false;
            }
        }

        public override string[] GetAllRoles()
        /// public string[] GetAllRoles()
        {
            using (var DbContextEntities = new DbContextEntities())
            {
                return DbContextEntities.access_level.Select(r => r.accesslevel_desc).ToArray();
            }
        }
    }

    /*
    public static bool IsBetween(this DateTime dt, DateTime start, DateTime end)
    {
        return dt >= start && dt <= end;
    }
       public class CustomAuthorizeAttribute : AuthorizeAttribute
       {
           public CustomAuthorizeAttribute(params string[] roleKeys)
           {
               List<string> roles = new List<string>(roleKeys.Length);

               //foreach(var roleKey in roleKeys) {
               //roles.Add(ConfigurationManager.AppSettings["DirectorRole"]);
               //}
               var allRoles = (access_level)ConfigurationManager.GetSection("access_level");
               foreach (var roleKey in roleKeys)
               {
                   roles.Add(allRoles[roleKey]);
               }

               this.Roles = string.Join(",", roles);
           }

       }
        */
    /* public class CustomAuthorizeAttribute : AuthorizeAttribute  
         {  
            DbContextEntities context = new DbContextEntities(); // my entity  
            private readonly string[] allowedroles;  
            public CustomAuthorizeAttribute(params string[] roles)
            {  
               this.allowedroles = roles;  
            }
                 protected override bool AuthorizeCore(HttpContextBase httpContext)
                 {
                     bool authorize = false;
                     foreach (var role in allowedroles)
                     {
                         var user = context.users.Where(m => m.username == User.Identity.CurrentUser/* getting user form current context *//* && m.access_level == role &&
                m.IsActive == true); // checking active users with allowed roles.  
                         if (user.Count() > 0)
                         {
                             authorize = true; /* return true if Entity has current user(active) with specific role *//*
                         }
                     }
                     return authorize;
                     }   protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {  
               filterContext.Result = new HttpUnauthorizedResult();  
           }  
         }  */


    public class PdfConvertr 
    {


        public static void PdfConvtrFunction()
        {
            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
            //SelectPdf.PdfDocument doc = converter.ConvertUrl("http://www.nexthermal.org/ConfigBasic/GetConfigDiag");
            SelectPdf.PdfDocument doc = converter.ConvertUrl("http://localhost:61404/ConfigBasic/GetConfigDiag");
            doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/Uploads/test.pdf"));  //save in local, send from local, delete from local
            doc.Close();
        }
    }

    public class ContactClasses
    {
        public string cfname { get; set; }
        public string cflname { get; set; }
        public string cfmob { get; set; }
        public string cfemail { get; set; }
        public string cfcomp { get; set; }
        public string cfmesg { get; set; }
    }

}