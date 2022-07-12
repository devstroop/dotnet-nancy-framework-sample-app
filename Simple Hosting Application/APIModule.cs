using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hosting_Application
{
    public class APIModule : Nancy.NancyModule
    {
        public APIModule()
        {
            // Page Root
            Get[@"/"] = parms =>
            {
                return "Hello World!";
            };



            // Sample Path
            Get[@"/sample"] = parms =>
            {
                string email = Request.Query.email;
                string password = Request.Query.password;
                return Nancy.HttpStatusCode.OK;
            };

            Post[@"/sample"] = parms =>
            {
                string email = Request.Form["email"];
                string password = Request.Form["password"];
                return Nancy.HttpStatusCode.OK;
            };



            // Unrouted Path
            Get[@"^(.*)$"] = parms =>
            {
                return Nancy.HttpStatusCode.BadRequest;
            };
            Post[@"^(.*)$"] = parms =>
            {
                return Nancy.HttpStatusCode.BadRequest;
            };
        }
    }
}
