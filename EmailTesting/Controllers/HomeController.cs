using EmailTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmailTesting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ViewResult Email(MailModel _objModelMail)
        {
            //MailMessage mail = new MailMessage();
            //mail.To.Add("shaharia.rabby@sqgc.com");
            ////mail.To.Add("Another Email ID where you wanna send same email");
            //mail.From = new MailAddress("rabbisqgc@gmail.com");
            //mail.Subject = "Email using Gmail";

            //string Body = "Hi, this mail is to test sending mail" +
            //              "using Gmail in ASP.NET";
            //mail.Body = Body;

            //mail.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            //smtp.Credentials = new System.Net.NetworkCredential
            //     ("rabbisqgc@gmail.com", "rabbi123##");
            ////Or your Smtp Email ID and Password
            //smtp.EnableSsl = true;
            //smtp.Send(mail);

            //return View();

            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                //smtp.Host = "localhost";
                smtp.Port = 587;
                //smtp.UseDefaultCredentials = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("rabbisqgc@gmail.com", "qcajrcwacgodmxpl"); // Enter seders User name and password       
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;



                smtp.Send(mail);
                return View("Index", _objModelMail);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<string> Scrap()
        {
            string url = "https://www.lipsum.com/";
            HttpClient httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync(url);
            return res;
        }
    }
}