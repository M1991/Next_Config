using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Configuration;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Net.Mime;

namespace NextFlex_Configurator.Services
{
    public class MailSender
    {
        public static void FunctionForMail(string recvr, string subject, string body)
        {
            #region GMAIL SENDER
            //string recvr = "manoj.haloi8@gmail.com";
            //try
            //{
            //    string from = "sales@nexthermal.com"; //any valid GMail ID  
            //    using (MailMessage mail = new MailMessage(from, objModelMail.To))
            //    {
            //        mail.Subject = objModelMail.Subject;
            //        mail.Body = objModelMail.Body;
            //        if (fileUploader != null)
            //        {
            //            string fileName = Path.GetFileName(fileUploader.FileName);
            //            mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
            //        }
            //        mail.IsBodyHtml = false;
            //        SmtpClient smtp = new SmtpClient();
            //        smtp.Host = "smtp.gmail.com";
            //        smtp.EnableSsl = true;
            //        NetworkCredential networkCredential = new NetworkCredential(from, "Gmail Id Password");
            //        smtp.UseDefaultCredentials = true;
            //        smtp.Credentials = networkCredential;
            //        smtp.Port = 587;
            //        smtp.Host = "localhost";
            //        smtp.Send(mail);
            //        ViewBag.Message = "Sent";
            //    }
            //catch (Exception ex)
            //{
            //   // MessageBox.Show(ex.Message);
            //}
            #endregion

            //var client = new SmtpClient("mail.domain.com", 25)         //Ensure that the port is the correct outgoing SMTP port
            //{
            //  
            // //   EnableSsl = true                                         //disabling SSL?
            //};

            #region OUTLOOK MAILER
            //try
            //{
            //    //Outlook.MailItem mailItem = (Outlook.MailItem)
            //    // this.Application.CreateItem(Outlook.OlItemType.olMailItem);
            //    //string logPath = @"D:\Tests\LogOutlook.txt";
            //    //Outlook.Application app = new Outlook.Application();
            //    Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();

            //    //Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            //    Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);


            //    mailItem.Subject = "Details of Invoice - Nexthermal";
            //    //To send multiple mails add a ; 
            //    //mailItem.To = "deep@nexthermal.in; manoj.haloi8@gmail.com";

            //    //UNCOMMENT BELOW //GENERATED  MAIL ID  LIST's
            //    // mailItem.To = _invEmail;

            //    mailItem.To = "manoj.haloi8@gmail.com";

            //    //UNCOMMENT BELOW LINE FOR CFU FINAL 
            //    // ask  for message contents
            //    string str = "\n\n\n" + "<i>This is an auto-generated email. If you have any queries, write back to </i> " + "<b>accounts@nexthermal.in" + "</b>\n Thank You";
            //    mailItem.Body = "This is a test Email \t Dated on :" + DateTime.Now.ToShortDateString() + "\n";
            //    //mailItem.Body = "\n\n\n"+"<i>This is an auto-generated email. If you have any queries, write back to </i> "+"<b>accounts@nexthermal.in"+"</b>\n Thank You";
            //    //mailItem.Body = "This is a test Email, Please don't get annoyed. Thank you";
            //    //mailItem.Sender = "deep@nexthermal.in";
            //    // mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
            //    mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            //    mailItem.Display(false);
            //    mailItem.Send();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Outlook mailer not working");
            //}
            #endregion


            #region DEFAULT MAILER
            try
            {
                //Define your Message
                MailMessage message = new MailMessage();
             //   string toEmail = "sales@nexthermal.com," + recvr;
                string toEmail = "manoranjan@nexthermal.in," + recvr;
                //DocumentModel doc = DocumentModel.Load("Sample.html", LoadOptions.HtmlDefault);
                //string fileNameWitPath = Path.Combine(Server.MapPath("~/FolderToSave"), fileName);
                //doc.Save("Sample.jpg", new ImageSaveOptions(ImageSaveFormat.Jpeg));

                message.IsBodyHtml = true;
                //  message.From = new MailAddress("sales@nexthermal.com", "Nexthermal Sales");
                MailAddress fromAddress = new MailAddress("manoranjan@nexthermal.in");
                message.From = fromAddress;
                string[] multiRecvr = toEmail.Split(',');
                foreach (string itemrecvr in multiRecvr)
                {
                    message.To.Add(new MailAddress(itemrecvr));
                }
                //message.To.Add(new MailAddress("example@gmail.com"));
                message.Subject = subject;
                //   string fileNameWitPath = Path.Combine(Server.MapPath("~/FolderToSave"), fileName);
                //     FileStream fs = new FileStream("C:\\TestFolder\\test.pdf", FileMode.Open, FileAccess.Read);
                //   Attachment a = new Attachment(fs, "test.pdf", MediaTypeNames.Application.Octet);
                //    message.Attachments.Add(a);
                message.Body = body;
                SmtpClient client = new SmtpClient();
                //client.Host = "localhost";
                //client.Host = "smtp.mail.nexthermal.org";
                //Send the actual message
                client.Send(message);
            }
            catch (Exception Exc)
            {
                throw new Exception("Message failed to send.");
            }

            #endregion
        }
    }

    public class ServerAttcher
    {



        //public ActionResult Create(DrawingModel model, string imageData)
        //{
        //    string fileName = "MyUniqueImageFileName.png";
        //    string fileNameWitPath = Path.Combine(Server.MapPath("~/FolderToSave"), fileName);

        //    using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
        //    {
        //        using (BinaryWriter bw = new BinaryWriter(fs))
        //        {
        //            byte[] data = Convert.FromBase64String(imageData);
        //            bw.Write(data);
        //            bw.Close();
        //        }
        //        fs.Close();
        //    }

        //    model.FileName = fileName;
        //    model.IsPublished = true;
        //    model.UserName = User.Identity.Name;
        //    model.ViewCount = 0;
        //    model.CreatedDateTime = DateTime.Now;

        //    if (ModelState.IsValid)
        //    {
        //        db.DrawingModels.Add(model);
        //        db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
    }

}