using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace codesnippets.Infrastructure
{
    public enum Theme { Red, White, BlackGlass, Clean }

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString GenerateCaptcha(this HtmlHelper helper, Theme theme, string callBack = null)
        {
            string htmlInjectString = @"<div class=""g-recaptcha"" data-sitekey=""{0}""></div>";

            var publicKey = ConfigurationManager.AppSettings["recaptchaPublicKey"];

            if (string.IsNullOrWhiteSpace(publicKey))
                throw new InvalidKeyException("ReCaptcha.PublicKey missing from appSettings");

            if (!string.IsNullOrWhiteSpace(callBack))
                callBack = string.Concat(", callback: ", callBack);

            var html = string.Format(htmlInjectString, publicKey, theme.ToString().ToLower(), callBack);
            return MvcHtmlString.Create(html);
        }
    }
}
