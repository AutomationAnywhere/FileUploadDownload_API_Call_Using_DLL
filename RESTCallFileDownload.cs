using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace FileUploadAndDownload
{
    public class RESTCallFileDownload
    {

        public static string ToSafeFileName(string s)
        {
            return s
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }

        //This method is specifically for GET(method) type of API
        public static string FileDownloadRequest_GET(string domain, string apiUrl, string cookie, string headers, string outputFolder)
        {
            string[] cookies = cookie.Split(';');
            CookieContainer cookieContainer = new CookieContainer();
            if (cookie.Length != 0)
            {

                Uri target = new Uri(domain);
                foreach (string cookie_ in cookies)
                {
                    if (cookie_.Length != 0)
                    {
                        cookieContainer.Add(new Cookie(cookie_.Split('=')[0], cookie_.Split('=')[1]) { Domain = target.Host });
                    }
                }
            }
            string remoteUrl = string.Format(apiUrl);
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(remoteUrl);
            httpRequest.CookieContainer = cookieContainer;

            if (headers.Length != 0)
            {
                string[] headers_ = headers.Split(';');
                foreach (string header in headers_)
                {
                    if (header.Length != 0)
                    {
                        if (header.Split('=')[0] == "Accept")
                        {
                            httpRequest.Accept = header.Split('=')[1] + ";";
                        }
                        else if (header.Split('=')[0] == "Content-Type")
                        {
                            httpRequest.ContentType = header.Split('=')[1] + ";";
                        }
                        else
                        {
                            httpRequest.Headers.Add(header.Split('=')[0], header.Split('=')[1]);
                        }

                    }
                }
            }
            try
            {
                WebResponse response = httpRequest.GetResponse();
                string contentDisposition = response.Headers["Content-Disposition"];
                if (contentDisposition != "")
                {
                    var cp = new ContentDisposition(contentDisposition);
                    string fileName = cp.FileName;
                   string finalPath= Path.Combine(outputFolder, ToSafeFileName(fileName));
                    using (Stream output = File.OpenWrite(finalPath))
                    using (Stream input = response.GetResponseStream())
                    {
                        input.CopyTo(output);
                    }

                    return "File saved in  : " + "" + finalPath;
                }
                else
                {
                    return "Unable to retrive file name & extension from the response ,  contentDisposition is empty";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

       

        //This method is for both GET& POST types of APIs
        public static string FileDownloadRequest(string domain, string apiUrl, string cookie, string headers,string method,string inputData, string outputFolder)
        {
            //***cookie**//
            //key=value;key2=value2

            //****Headers****/
            //key=value;key2=value2

            //****inputData****/
            //from bot   { "companyId":"IQ24143"}
            //from C# code   "{\"companyId\":\"IQ24143\"}",


            string[] cookies = cookie.Split(';');
            CookieContainer cookieContainer = new CookieContainer();
            if (cookie.Length != 0)
            {

                Uri target = new Uri(domain);
                foreach (string cookie_ in cookies)
                {
                    if (cookie_.Length != 0)
                    {
                        cookieContainer.Add(new Cookie(cookie_.Split('=')[0], cookie_.Split('=')[1]) { Domain = target.Host });
                    }
                }
            }

            string remoteUrl = string.Format(apiUrl);
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(remoteUrl);
            httpRequest.CookieContainer = cookieContainer;
           

            if (headers.Length != 0)
            {
                string[] headers_ = headers.Split(';');
                foreach (string header in headers_)
                {
                    if (header.Length != 0)
                    {
                        if (header.Split('=')[0] == "Accept")
                        {
                            httpRequest.Accept = header.Split('=')[1];
                        }
                        else if (header.Split('=')[0] == "Content-Type")
                        {
                            httpRequest.ContentType = header.Split('=')[1];
                        }
                        else
                        {
                            httpRequest.Headers.Add(header.Split('=')[0], header.Split('=')[1]);
                        }

                    }
                }
            }
            httpRequest.Method = method;
            if (method == "POST")
            {

                byte[] dataStream = Encoding.UTF8.GetBytes(inputData);
                httpRequest.ContentLength = dataStream.Length;
                Stream newStream = httpRequest.GetRequestStream();
                // Send the data.
                newStream.Write(dataStream, 0, dataStream.Length);
                newStream.Close();
            }

            try
            {
               
                WebResponse response = httpRequest.GetResponse();
                

                string contentDisposition = response.Headers["Content-Disposition"];
               

                if (contentDisposition != "")
                {
                    string[] stringSeparators = new string[] { "filename="};
                    var fileName = contentDisposition.Split(stringSeparators, StringSplitOptions.None)[1];
                    //var cp = new ContentDisposition(contentDisposition);
                    //string fileName = cp.FileName;
                    string finalPath = Path.Combine(outputFolder, ToSafeFileName(fileName));
                    using (Stream output = File.OpenWrite(finalPath))
                   // using (Stream output = File.OpenWrite("" + outputFolder + "/" + fileName))
                    using (Stream input = response.GetResponseStream())
                    {
                        input.CopyTo(output);
                    }

                    return "File saved in  : " + "" + finalPath;
                }
                else
                {
                    return "Unable to retrive file name & extension from the response ,  contentDisposition is empty";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }


        public static string FileDownloadRequest1(string domain, string apiUrl, string cookie, string headers, string method, string inputData, string outputFolder)
        {
            //***cookie**//
            //key=value;key2=value2

            //****Headers****/
            //key=value;key2=value2

            //****inputData****/
            //from bot   { "companyId":"IQ24143"}
            //from C# code   "{\"companyId\":\"IQ24143\"}",


            string[] cookies = cookie.Split(';');
            CookieContainer cookieContainer = new CookieContainer();
            if (cookie.Length != 0)
            {

                Uri target = new Uri(domain);
                foreach (string cookie_ in cookies)
                {
                    if (cookie_.Length != 0)
                    {
                        cookieContainer.Add(new Cookie(cookie_.Split('=')[0], cookie_.Split('=')[1]) { Domain = target.Host });
                    }
                }
            }

            string remoteUrl = string.Format(apiUrl);
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(remoteUrl);
            httpRequest.CookieContainer = cookieContainer;


            if (headers.Length != 0)
            {
                string[] headers_ = headers.Split(';');
                foreach (string header in headers_)
                {
                    if (header.Length != 0)
                    {
                        if (header.Split('=')[0] == "Accept")
                        {
                            httpRequest.Accept = header.Split('=')[1];
                        }
                        else if (header.Split('=')[0] == "Content-Type")
                        {
                            httpRequest.ContentType = header.Split('=')[1];
                        }
                        else
                        {
                            httpRequest.Headers.Add(header.Split('=')[0], header.Split('=')[1]);
                        }

                    }
                }
            }
            httpRequest.Method = method;
            if (method == "POST")
            {

                byte[] dataStream = Encoding.UTF8.GetBytes(inputData);
                httpRequest.ContentLength = dataStream.Length;
                Stream newStream = httpRequest.GetRequestStream();
                // Send the data.
                newStream.Write(dataStream, 0, dataStream.Length);
                newStream.Close();
            }

            try
            {

                WebResponse response = httpRequest.GetResponse();


                string contentDisposition = response.Headers["Content-Disposition"];


                if (contentDisposition != "")
                {
                    string[] stringSeparators = new string[] { "filename=" };
                    var fileName = contentDisposition.Split(stringSeparators, StringSplitOptions.None)[1];
                    //var cp = new ContentDisposition(contentDisposition);
                    //string fileName = cp.FileName;
                    string finalPath = Path.Combine(outputFolder, ToSafeFileName(fileName));
                    using (Stream output = File.OpenWrite(finalPath))
                    // using (Stream output = File.OpenWrite("" + outputFolder + "/" + fileName))
                    using (Stream input = response.GetResponseStream())
                    {
                        input.CopyTo(output);
                    }

                    return "File saved in  : " + "" + finalPath;
                }
                else
                {
                    return "Unable to retrive file name & extension from the response ,  contentDisposition is empty";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }


    }
}
