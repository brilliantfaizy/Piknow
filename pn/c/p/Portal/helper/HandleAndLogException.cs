using Portal.helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Portal.Models
{
    public class HandleAndLogException
    {
        public static void LogErrorToText(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append("********************" + "  Error Log - " + DateTime.Now + "*********************");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Exception Type : " + ex.GetType().Name);
            sb.Append(Environment.NewLine);
            sb.Append("Error Message : " + ex.Message);
            sb.Append(Environment.NewLine);
            sb.Append("Error Source : " + ex.Source);
            sb.Append(Environment.NewLine);
            if (ex.StackTrace != null)
            {
                sb.Append("Error Trace : " + ex.StackTrace);
            }
            Exception innerEx = ex.InnerException;

            while (innerEx != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append("Exception Type : " + innerEx.GetType().Name);
                sb.Append(Environment.NewLine);
                sb.Append("Error Message : " + innerEx.Message);
                sb.Append(Environment.NewLine);
                sb.Append("Error Source : " + innerEx.Source);
                sb.Append(Environment.NewLine);
                if (ex.StackTrace != null)
                {
                    sb.Append("Error Trace : " + innerEx.StackTrace);
                }
                innerEx = innerEx.InnerException;
            }

            string path = "KarenroWebservice" + "_logs_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~/Logs/")))
            {
                try
                {
                    var info = Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Logs/"));
                }
                catch (Exception eex)
                {
                }
            }
            string filePath = HttpContext.Current.Server.MapPath("~/Logs/" + path);
           // StreamWriter writer = new StreamWriter(filePath, true);
           // writer.WriteLine(sb.ToString());
            InsertText(filePath, sb.ToString());
            notificationCls Notification = new notificationCls();
            Notification.SendCrash_Report(sb.ToString());

           // writer.Flush();
           // writer.Close();
        }

        public static void InsertText(string path, string newText)
        {
            if (File.Exists(path))
            {
                string oldText = File.ReadAllText(path);
                using (var sw = new StreamWriter(path, false))
                {
                    sw.WriteLine(newText);
                    sw.WriteLine(oldText);
                    sw.Flush();
                    sw.Close();
                }
            }
            else File.WriteAllText(path, newText);

        }

    }
}