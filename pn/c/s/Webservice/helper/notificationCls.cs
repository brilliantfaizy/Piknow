using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using Webservice.Models;

namespace Webservice.helper
{
    public class notificationCls
    {
        public notificationCls()
        {
           
        }

        public void sendPush(string deviceToken, string message)
        {
            try
            {
                Thread.Sleep(1000);
                string FCM_Authorization_Key = WebConfigurationManager.AppSettings["FCM_Authorization_Key"];
                var request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                RootObjectNotification postData = new RootObjectNotification();
                postData.to = deviceToken;
                postData.priority = "high";
                Notification sendData = new Notification();
                sendData.body = message;
                sendData.title = "Notification";
                postData.notification = sendData;

                var js = new JavaScriptSerializer();
                var data = Encoding.ASCII.GetBytes(js.Serialize(postData));
                request.Method = "POST";
                request.Headers.Add("Authorization", "key=" + FCM_Authorization_Key);
                request.ContentType = "application/json;charset=UTF-8";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                Thread.Sleep(1000);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                RootObject result = js.Deserialize<RootObject>(responseString);
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }

        }

        /* public async Task<string> sendNotification(string deviceToken, string message)
        {
            using (var client = new HttpClient())
            {
                Uri url = new Uri("https://fcm.googleapis.com/fcm/send");
                string FCM_Authorization_Key = WebConfigurationManager.AppSettings["FCM_Authorization_Key"];
                client.BaseAddress = new Uri("https://fcm.googleapis.com/fcm/send");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "key=" + FCM_Authorization_Key);
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                RootObjectNotification postData = new RootObjectNotification();
                postData.to = deviceToken;
                Notification sendData = new Notification();
                sendData.body = message;
                sendData.title = "Notification";
                postData.notification = sendData;
                var js = new JavaScriptSerializer();

                StringContent content = new StringContent(js.Serialize(postData));
                // HTTP POST
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    //product = JsonConvert.DeserializeObject<Product>(data);
                }
            }
            return "";
        }*/

        public object sendTestPush(string deviceToken, string message)
         {
             try
             {
                 string FCM_Authorization_Key = WebConfigurationManager.AppSettings["FCM_Authorization_Key"];
                 var request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                 RootObjectNotification postData = new RootObjectNotification();
                 postData.to = deviceToken;
                 postData.priority = "high";
                 Notification sendData = new Notification();
                 sendData.body = message;
                 sendData.title = "Notification";
                 postData.notification = sendData;

                 var js = new JavaScriptSerializer();
                 var data = Encoding.ASCII.GetBytes(js.Serialize(postData));
                 request.Method = "POST";
                 request.Headers.Add("Authorization", "key=" + FCM_Authorization_Key);
                 request.ContentType = "application/json;charset=UTF-8";
                 request.ContentLength = data.Length;

                 using (var stream = request.GetRequestStream())
                 {
                     stream.Write(data, 0, data.Length);
                 }

                 var response = (HttpWebResponse)request.GetResponse();
                 var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                 RootObject result = js.Deserialize<RootObject>(responseString);
                 return result;
             }
             catch (Exception ex)
             {
                 HandleAndLogException.LogErrorToText(ex);
                 return new ErrorMessage { error = "Something went wrong" };
             }

         }

        public object sendSMS(string number, string message)
        {

            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://rest.payamak-panel.com/api/SendSMS/SendSMS");
                string postData = "";
                postData +="From=10002970&";
                postData +="IsFlash=false&";
                postData +="PassWord=xA9\"eM,\"B%p8!Xy;&";
                postData +="Text=" +message+"&";
                postData +="To=" + number+"&";
                postData += "UserName=9120316727";

                var js = new JavaScriptSerializer();
                var data = Encoding.ASCII.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                sendMessageRespCls result = js.Deserialize<sendMessageRespCls>(responseString);
                return result;

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }

            return null;
        }


        public class sendMessageRespCls
        {
            public string Value { get; set; }
            public string RetStatus { get; set; }
            public string StrRetStatus { get; set; }
        }

        public class sendMessageCls
        {
            public string UserName { get; set; }
            public string PassWord { get; set; }
            public string To { get; set; }
            public string From { get; set; }
            public string Text { get; set; }
            public string IsFlash { get; set; }
        }

        public void SendCrash_Report(string ex)
        {
            try
            {
                string body = "<h3>Crash Report</h3> " + String.Format("{0:f}", DateTime.Now);
                body += ex;

                MailMessage message = new MailMessage();
                message.From = new MailAddress("astdevelopers@gmail.com");
                message.To.Add("mz.ashah@gmail.com");
                message.Subject = "Crash Report - Web Service " + String.Format("{0:f}", DateTime.Now);
                message.IsBodyHtml = true;
                message.Body = body;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("astdevelopers@gmail.com", "ColworxDev@");
                smtpClient.Send(message);
            }
            catch (Exception)
            {
                
            }
        }

        public bool SendEmail_toUser(string toEmail, string subject, string heading, string mailBody)
        {
            try
            {
                string body = "<h3>" + heading + "</h3> ";
                body += mailBody;

                MailMessage message = new MailMessage();
                message.From = new MailAddress("astdevelopers@gmail.com");
                message.To.Add(toEmail);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("astdevelopers@gmail.com", "ColworxDev@");
                smtpClient.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
         public class ErrorMessage
         {
             public string error { get; set; }
         }
        
        public string myTime(DateTime yourDate)
        {
                    var timeUtc = DateTime.UtcNow;
                    TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
                    //DateTime currentDate = easternTime.Date;

            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(easternTime.Ticks - yourDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }

        private class Result
        {
            public string error { get; set; }
            public string message_id { get; set; }
        }

        private class RootObject
        {
            public long multicast_id { get; set; }
            public int success { get; set; }
            public int failure { get; set; }
            public int canonical_ids { get; set; }
            public List<Result> results { get; set; }
        }

        public class Notification
        {
            public string title { get; set; }
            public string body { get; set; }
        }

        public class RootObjectNotification
        {
            public Notification notification { get; set; }
            public string to { get; set; }
            public string priority { get; set; }
        }
    }
}