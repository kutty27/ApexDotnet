using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json.Linq;
using RestSharp.Serialization.Json;
using System.Reflection;
using Newtonsoft.Json;
using ApexAPI;
using ApexAPI.Repository;
using ApexAPI.Models;
using ApexAPI.Controllers;
using ApexAPI.Interface;
using System.Net.Http.Headers;

namespace ApexAPI
{
    [TestFixture]
    public class FunctionalTest : IDisposable
    {
        public static List<String> failMessage = new List<String>();
        public static String failureMsg = "";
        public static int failcnt = 1;
        public int totalTestcases = 0;

        public int userport;
        public string appURL;
        RestClient client;



        [OneTimeSetUp]
        public void Setup()
        {
            //userport = Int32.Parse(Environment.GetEnvironmentVariable("userport"));
            client = new RestClient("https://localhost:7162");// + userport);
            //client = new RestClient("https://localhost:5000");

        }

        [OneTimeTearDown]
        public void Dispose()
        {
            if (totalTestcases > 0)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./FailedTest.txt"))
                {
                    foreach (string line in failMessage)
                    {
                        //Console.WriteLine("line " + line);
                        file.WriteLine(line);
                    }
                }
            }
            else
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./FailedTest.txt"))
                {
                    file.WriteLine("error");
                }
            }
            //_driver.Quit();
            //_driver.Dispose();
        }

        public void ExceptionCatch(string functionName, string catchMsg, string msg, string msg_name, string exceptionMsg = "")
        {
            failMessage.Add(functionName);

            if (msg == "")
            {
                msg = exceptionMsg + (exceptionMsg != "" ? " - " : "") + catchMsg + "\n";
                msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
            }
            else
                msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

            failureMsg += msg_name;
            failcnt++;
            Assert.Fail(msg);
        }

        IRestResponse response = null;

        [Test, Order(1)]
        public void Test1_GetAllDetails_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Hospital/GetAllDetails", Method.GET);

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Hospital/GetAllDetails' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Hospital/GetAllDetails' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(2)]
        public void Test2_GetAllDetails_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {

                // RestClient client = new RestClient(appURL);
                RestRequest request = new RestRequest("api/Hospital/GetAllDetails", Method.GET);

                response = client.Execute(request);
                var content = response.Content;
                //  Console.WriteLine("---1----" + response.Content);

                if (!response.Content.Contains("102"))
                {
                    msg += "Get service Fetched data is not correct. Check logic in 'GetAllDetails'.\n";
                }


                List<Hospital> busResponse = new JsonDeserializer().Deserialize<List<Hospital>>(response);

                if (busResponse.Count != 3)
                {
                    msg += "Get all details list count retrieved is NOT correct. Check logic in 'GetAllDetails'.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetAllDetails' Get service Fetched data is not correct. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(3)]
        public void Test3_GetWardDetailsById_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                //RestClient client = new RestClient(appURL);
                RestRequest request = new RestRequest("api/Hospital/GetWardDetailsById/102", Method.GET);

                response = client.Execute(request);
                var content = response.Content;
                //msg += "---1----" + response.StatusCode;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Hospital/GetWardDetailsById' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Hospital/GetWardDetailsById' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(4)]
        public void Test4_GetWardDetailsById_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Hospital/GetWardDetailsById/102", Method.GET);

                response = client.Execute(request);
                var content = response.Content;
                //msg += "---1----" + response.Content;

                if (!response.Content.Contains("30"))
                {
                    msg += "Get service Fetched data is not correct. Check logic in 'GetWardDetailsById'.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetWardDetailsById' Get service Fetched data is not correct. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }

        }

        [Test, Order(5)]
        public void Test5_GetWardWithMaxBedCountAvailable_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                //RestClient client = new RestClient(appURL);
                RestRequest request = new RestRequest("api/Hospital/GetWardWithMaxBedCountAvailable", Method.GET);

                response = client.Execute(request);
                var content = response.Content;
                //Console.WriteLine("---1----" + response.StatusCode);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Hospital/GetWardWithMaxBedCountAvailable' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Hospital/GetWardWithMaxBedCountAvailable' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(6)]
        public void Test6_GetWardWithMaxBedCountAvailable_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Hospital/GetWardWithMaxBedCountAvailable", Method.GET);

                response = client.Execute(request);
                var content = response.Content;
                //Console.WriteLine("---1----" + response.Content);

                if (!response.Content.Contains("General"))
                {
                    msg += "Get service Fetched data is not correct. Check logic in 'GetWardWithMaxBedCountAvailable'.\n";
                }


                Hospital roomResponse = new JsonDeserializer().Deserialize<Hospital>(response);

                if (roomResponse.WardName != "General")
                {
                    msg += "Get ward list details retrieved is NOT correct. Check logic in 'GetWardWithMaxBedCountAvailable'.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetWardWithMaxBedCountAvailable' Get service Fetched data is not correct. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }




        [Test, Order(7)]
        public void Test7_GetAllDoctors_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                //RestClient client = new RestClient(appURL);
                RestRequest request = new RestRequest("api/Doctor/GetAllDoctors", Method.GET);

                response = client.Execute(request);
                var content = response.Content;
                //Console.WriteLine("---1----" + response.StatusCode);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Doctor/GetAllDoctors' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Doctor/GetAllDoctors' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(8)]
        public void Test8_GetAllDoctors_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {

                //RestClient client = new RestClient(appURL);
                RestRequest request = new RestRequest("api/Doctor/GetAllDoctors", Method.GET);

                response = client.Execute(request);
                var content = response.Content;

                if (!response.Content.Contains("9129540430"))
                {
                    msg += "Get service Fetched data is not correct. Check logic in 'GetAllDoctors'.\n";
                }


                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetAllDoctors' Get service Fetched data is not correct. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(9)]
        public void Test9_GetDoctorsByWardName_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                //RestClient client = new RestClient(appURL);
                RestRequest request = new RestRequest("api/Doctor/GetDoctorsByWardName/General", Method.GET);

                response = client.Execute(request);
                var content = response.Content;
                //Console.WriteLine("---1----" + response.StatusCode);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Doctor/GetDoctorsByWardName' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Doctor/GetDoctorsByWardName' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(10)]
        public void Test10_GetDoctorsByWardName_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {

                //RestClient client = new RestClient(appURL);
                RestRequest request = new RestRequest("api/Doctor/GetDoctorsByWardName/General", Method.GET);

                response = client.Execute(request);
                var content = response.Content;
                //Console.WriteLine("---1----" + response.Content);

                if (!response.Content.Contains("Joy"))
                {
                    msg += "Get service Fetched data is not correct. Check logic in 'GetDoctorsByWardName'.\n";
                }


                List<Doctor> userResponse = new JsonDeserializer().Deserialize<List<Doctor>>(response);

                if (userResponse.Count != 2)
                {
                    msg += "Get Doctors list count retrieved is NOT correct. Check logic in 'GetDoctorsByWardName'.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetDoctorsByWardName' Get service Fetched data is not correct. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(11)]
        public void Test11_AddDoctor_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Doctor/AddDoctor", Method.POST);

                request.AddJsonBody(new
                {
                    Id = 1191,
                    FirstName = "FirstTest",
                    LastName = "LastTest",
                    Gender = "TestGender",
                    Hospital = new Hospital { WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul" },
                    Contact = 9099081224

                });

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Doctor/AddDoctor' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Doctor/AddDoctor' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(12)]
        public void Test12_AddDoctor_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Doctor/AddDoctor", Method.POST);

                request.AddJsonBody(new
                {
                    Id = 1191,
                    FirstName = "FirstTest",
                    LastName = "LastTest",
                    Gender = "TestGender",
                    Hospital = new Hospital { WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul" },
                    Contact = 9099081224

                });

                response = client.Execute(request);
                var content = response.Content;

                RestRequest requestActual = new RestRequest("api/Test/GetAllDoctors", Method.GET);
                response = client.Execute(requestActual);

                var responseActual = JsonConvert.DeserializeObject<List<Doctor>>(response.Content);
                bool isExists = responseActual.Where(w => w.Id == 1191 &&
                    w.FirstName == "FirstTest" &&
                    w.LastName == "LastTest" &&
                    w.Gender == "TestGender" &&
                    w.Contact == 9099081224).Any();

                if (response.StatusCode != HttpStatusCode.OK || isExists == false)
                {
                    msg += "POST service Fetched data is not correct. Check logic in 'AddDoctor'.\n";
                }


                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'AddDoctor' POST service Fetched data is not correct. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(13)]
        public void Test13_UpdateDoctorContact_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Doctor/UpdateDoctorContact/1122", Method.PUT)
                {
                    RequestFormat = DataFormat.Json
                };

                Object obj = 9638521470;
                request.AddParameter("application/json", obj, ParameterType.UrlSegment);
                request.AddBody(obj.ToString());

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Doctor/UpdateDoctorContact' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Doctor/UpdateDoctorContact' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(14)]
        public void Test14_UpdateDoctorContact_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Doctor/UpdateDoctorContact/1123", Method.PUT)
                {
                    RequestFormat = DataFormat.Json
                };

                Object obj = 9638521479;
                request.AddParameter("application/json", obj, ParameterType.UrlSegment);
                request.AddBody(obj.ToString());

                response = client.Execute(request);
                var content = response.Content;

                //
                RestRequest requestActual = new RestRequest("api/Test/GetAllDoctors", Method.GET);
                response = client.Execute(requestActual);
                //

                if (!response.Content.Contains("9638521479"))
                {
                    msg += "Post service Fetched data is not correct. Check logic in 'UpdateDoctorContact'.\n";
                }


                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'UpdateDoctorContact' POST service Fetched data is not correct. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(15)]
        public void Test15_RemoveDoctor_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                //RestClient client = new RestClient(appURL);
                RestRequest request = new RestRequest("api/Doctor/RemoveDoctor/1122", Method.DELETE);

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Doctor/RemoveDoctor' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Doctor/RemoveDoctor' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }
        
        [Test, Order(16)]
        public void Test16_RemoveDoctor_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                var cnt = StaticData.lsDoctors.Count();
                RestRequest request = new RestRequest("api/Doctor/RemoveDoctor/1123", Method.DELETE);

                response = client.Execute(request);
                var content = response.Content;


                RestRequest requestActual = new RestRequest("api/Test/GetAllDoctors", Method.GET);
                response = client.Execute(requestActual);

                var responseActual = JsonConvert.DeserializeObject<List<Doctor>>(response.Content);
                bool isExists = responseActual.Where(w => w.Id == 1123).Any();

                if (isExists)
                {
                    msg += "Delete Doctor is not working. Check logic in 'RemoveDoctor'.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'RemoveDoctor' DELETE service Fetched data is not correct. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }





        [Test, Order(17)]
        public void Test17_GetAllPatients_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                //RestClient client = new RestClient(appURL);
                RestRequest request = new RestRequest("api/Patient/GetAllPatients", Method.GET);

                response = client.Execute(request);
                var content = response.Content;
                //Console.WriteLine("---1----" + response.StatusCode);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Patient/GetAllPatients' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Patient/GetAllPatients' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(18)]
        public void Test18_GetAllPatients_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Patient/GetAllPatients", Method.GET);

                response = client.Execute(request);
                var content = response.Content;

                List<Patient> passengerResponse = new JsonDeserializer().Deserialize<List<Patient>>(response);

                if (passengerResponse.Count != 4)
                {
                    msg += "Get All Patients list count retrieved is NOT correct. Check logic in 'GetAllPatients'.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "GET service Fetched data is not correct. Check logic in 'GetAllPatients'. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(19)]
        public void Test19_AddPatient_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                //RestClient client = new RestClient("http://localhost:8090");
                RestRequest request = new RestRequest("api/Patient/AddPatient", Method.POST);

                request.AddJsonBody(new
                {
                    Id = 10119,
                    FirstName = "FirstTest",
                    LastName = "LastTest",
                    Gender = "TestGender",
                    Hospital = new Hospital { WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul" },
                    BedNumber = 22,
                    Contact = 9099081224
                });

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Patient/AddPatient' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Patient/AddPatient' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(20)]
        public void Test20_AddPatient_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Patient/AddPatient", Method.POST);

                request.AddJsonBody(new
                {
                    Id = 10120,
                    FirstName = "FirstTest",
                    LastName = "LastTest",
                    Gender = "TestGender",
                    Hospital = new Hospital { WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul" },
                    BedNumber = 22,
                    Contact = 9099081224

                });

                response = client.Execute(request);
                var content = response.Content;

                RestRequest requestActual = new RestRequest("api/Test/GetAllPatients", Method.GET);
                response = client.Execute(requestActual);
                var responseActual = JsonConvert.DeserializeObject<List<Patient>>(response.Content);

                bool isExists = responseActual.Where(w => w.Id == 10120 &&
                    w.FirstName == "FirstTest" &&
                    w.LastName == "LastTest" &&
                    w.Gender == "TestGender" &&
                    w.Hospital.WardId == 100 &&
                    w.Hospital.WardName == "Emergency" &&
                    w.Hospital.AvailableBedsCount == 25 &&
                    w.Hospital.HeadDoctorName == "Alex Paul" &&
                    w.BedNumber == 22 &&
                    w.Contact == 9099081224).Any();

                if (response.StatusCode != HttpStatusCode.OK || isExists == false)
                {
                    msg += "Post service Fetched data is not correct. Check logic in 'AddPatient'.\n";
                }


                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'AddPatient' POST service Fetched data is not correct. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(21)]
        public void Test21_UpdatePatientWardName_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                //RestClient client = new RestClient("http://localhost:8090");
                RestRequest request = new RestRequest("api/Patient/UpdatePatientWardName/10110", Method.PUT)
                {
                    RequestFormat = DataFormat.Json
                };

                Object obj = "MCU";
                request.AddParameter("application/json", obj, ParameterType.UrlSegment);
                request.AddBody(obj.ToString());

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Patient/UpdatePatientWardName' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Patient/UpdatePatientWardName' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(22)]
        public void Test22_UpdatePatientWardName_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {

                //RestClient client = new RestClient("http://localhost:8090");
                RestRequest request = new RestRequest("api/Patient/UpdatePatientWardName/10110", Method.PUT)
                {
                    RequestFormat = DataFormat.Json
                };

                Object obj = "MCU";
                request.AddParameter("application/json", obj, ParameterType.UrlSegment);
                request.AddBody(obj.ToString());

                response = client.Execute(request);
                var content = response.Content;

                RestRequest requestActual = new RestRequest("api/Test/GetPatientById/10110", Method.GET);
                response = client.Execute(requestActual);
                //msg += "--1--" + response.Content + "--";
                //

                RestRequest requestActual1 = new RestRequest("api/Patient/GetAllPatients", Method.GET);
                response = client.Execute(requestActual1);

                var data = StaticData.lsPatients.Where(w => w.Id == 10110).FirstOrDefault();

                if (data != null)
                {
                    if (!response.Content.Contains("MCU"))//|| data.IsPaid != true)
                    {
                        msg += "Put service Fetched data is not correct. Check logic in 'UpdatePatientWardName'.\n";
                    }
                }
                else
                    msg += "Put service Fetched data is not correct. Check logic in 'UpdatePatientWardName'.\n";



                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'UpdatePatientWardName' PUT service Fetched data is not correct. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }




        [Test, Order(23)]
        public void Test23_AddDoctor_Validation()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Doctor/AddDoctor", Method.POST);

                request.AddJsonBody(new
                {
                    Id = 1121,
                    FirstName = "FirstTest",
                    LastName = "LastTest",
                    Gender = "TestGender",
                    Hospital = new Hospital { WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul" },
                    Contact = 9099081224
                });

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.InternalServerError)
                {
                    msg += "'AddDoctor' validation is not working, check business rules in problem statement.\n";
                }


                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "'AddDoctor' validation is not working, check business rules in problem statement. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(24)]
        public void Test24_UpdateDoctorContact_Validation()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Doctor/UpdateDoctorContact/1121", Method.PUT)
                {
                    RequestFormat = DataFormat.Json
                };

                Object obj = 0;
                request.AddParameter("application/json", obj, ParameterType.UrlSegment);
                request.AddBody(obj.ToString());

                response = client.Execute(request);
                var content = response.Content;



                if (response.StatusCode != HttpStatusCode.InternalServerError)
                {
                    msg += "'UpdateDoctorContact' validation is not working, check business rules in problem statement.\n";
                }


                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "'UpdateDoctorContact' validation is not working, check business rules in problem statement. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(25)]
        public void Test25_RemoveDoctor_Validation()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                //RestClient client = new RestClient(appURL);
                RestRequest request = new RestRequest("api/Doctor/RemoveDoctor/10000", Method.DELETE);

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.InternalServerError)
                {
                    msg += "'RemoveDoctor' validation is not working, check business rules in problem statement.\n";
                }




                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "'RemoveDoctor' validation is not working, check business rules in problem statement. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(26)]
        public void Test26_AddPatient_Validation()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Patient/AddPatient", Method.POST);

                request.AddJsonBody(new
                {
                    Id = 10110,
                    FirstName = "FirstTest",
                    LastName = "LastTest",
                    Gender = "TestGender",
                    Hospital = new Hospital { WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul" },
                    BedNumber = 22,
                    Contact = 9099081224

                });

                response = client.Execute(request);
                var content = response.Content;
                //Console.WriteLine("---1----" + response.Content);

                if (response.StatusCode != HttpStatusCode.InternalServerError)
                {
                    msg += "'AddPatient' validation is not working, check business rules in problem statement.\n";
                }


                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "'AddPatient' validation is not working, check business rules in problem statement. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }
    }
}
