using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace five9ApiIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Going to call Run Report function");
            //It says James Test Matrix is not in myreport, however you can see the valid response.
            runReport();
            Console.Read();
            getContactFields();
            Console.Read();



        }

        private static void getContactFields()
        {
            try
            {
                XmlDocument soapEnvelopeXml = CreateSoapEnvelopForGetContactFields();
                HttpWebRequest webRequest = CreateWebRequest("https://api.five9.com/wsadmin/adminwebservice");

                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
                webRequest.KeepAlive = true;
                // Authentication of password and username using basic http
                webRequest.Headers.Add("Authorization", "Basic QXV0b21hdGlvbjpUZXN0aW5nMTIzIQ==");
                //get response
                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

                asyncResult.AsyncWaitHandle.WaitOne(3000);

                string soapResult;

                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                        Console.WriteLine(soapResult);
                        Console.ReadLine();
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                WebResponse errRsp = ex.Response;
                using (StreamReader rdr = new StreamReader(errRsp.GetResponseStream()))
                {
                    Console.WriteLine(rdr.ReadToEnd());
                }
            }
        }


        private static void runReport()
        {
            try
            {
                XmlDocument soapEnvelopeXml = CreateSoapEnvelop();
                HttpWebRequest webRequest = CreateWebRequest("https://api.five9.com/wsadmin/adminwebservice");

                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
                webRequest.KeepAlive = true;
                // Authentication of password and username using basic http
                webRequest.Headers.Add("Authorization", "Basic QXV0b21hdGlvbjpUZXN0aW5nMTIzIQ==");
                //get response
                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

                asyncResult.AsyncWaitHandle.WaitOne(3000);

                string soapResult;

                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                        Console.WriteLine(soapResult);
                        Console.ReadLine();
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                WebResponse errRsp = ex.Response;
                using (StreamReader rdr = new StreamReader(errRsp.GetResponseStream()))
                {
                    Console.WriteLine(rdr.ReadToEnd());
                }
            }
        }
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
        private static HttpWebRequest CreateWebRequest(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=UTF-8";
            webRequest.Accept = "*/*";
            webRequest.Method = "POST";
            return webRequest;
        }
        private static XmlDocument CreateSoapEnvelop()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(
                @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ser=""http://service.admin.ws.five9.com/""><soapenv:Header/><soapenv:Body><ser:runReport><folderName>My Reports</folderName><reportName>James Test Matrix</reportName><criteria><time><end>2020-05-10T23:00:00.000-07:00</end><start>2020-05-01T00:00:00.000-07:00</start></time></criteria></ser:runReport></soapenv:Body></soapenv:Envelope>");
            return soapEnvelopeDocument;
        }

        private static XmlDocument CreateSoapEnvelopForGetContactFields()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(
                @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ser=""http://service.admin.ws.five9.com/""><soapenv:Header/><soapenv:Body><ser:getContactFields><namePattern></namePattern></ser:getContactFields></soapenv:Body></soapenv:Envelope>");
            return soapEnvelopeDocument;
        }
    }
}
