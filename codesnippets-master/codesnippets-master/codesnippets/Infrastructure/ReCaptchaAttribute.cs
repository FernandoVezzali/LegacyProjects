using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace codesnippets.Infrastructure
{
    

    [Serializable]
    public class InvalidKeyException : ApplicationException
    {
        public InvalidKeyException() { }
        public InvalidKeyException(string message) : base(message) { }
        public InvalidKeyException(string message, Exception inner) : base(message, inner) { }
    }

    public class ReCaptchaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userIP = filterContext.RequestContext.HttpContext.Request.UserHostAddress;
            var privateKey = ConfigurationManager.AppSettings["recaptchaPrivateKey"];
            var recaptcha_response_field = filterContext.RequestContext.HttpContext.Request.Form["g-recaptcha-response"];

            if (string.IsNullOrWhiteSpace(privateKey))
                throw new InvalidKeyException("ReCaptcha.PrivateKey missing from appSettings");

            //var postData = string.Format("&privatekey={0}&remoteip={1}&challenge={2}&response={3}",
            //                             privateKey,
            //                             userIP,
            //                             filterContext.RequestContext.HttpContext.Request.Form["recaptcha_challenge_field"],
            //                             filterContext.RequestContext.HttpContext.Request.Form["recaptcha_response_field"]);

            string postData = string.Format("&secret={0}&response={1}&remoteip={2}",
                privateKey,
                recaptcha_response_field,
                userIP);
            

            var postDataAsBytes = Encoding.UTF8.GetBytes(postData);

            // Create web request
            var request = WebRequest.Create("https://www.google.com/recaptcha/api/siteverify");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataAsBytes.Length;
            var dataStream = request.GetRequestStream();
            dataStream.Write(postDataAsBytes, 0, postDataAsBytes.Length);
            dataStream.Close();

            // Get the response.
            var response = request.GetResponse();

            using (dataStream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(dataStream))
                {
                    var responseFromServer = reader.ReadToEnd();

                    JObject root = JObject.Parse(responseFromServer); 
                    var success = (string)root["success"];

                    if (!success.ToUpper().Equals("TRUE"))
                    {
                        JArray errors = (JArray)root["error-codes"];
                        foreach (var errMessage in errors)
                        {
                            ((Controller)filterContext.Controller).ModelState.AddModelError("ReCaptcha", (string)errMessage);
                        }
                    }
                }
            }
        }
    }
}
