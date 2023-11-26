using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSONRestAPIReadConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetEmployeeData();
            //CreateEmployee();
        }

        public static void GetEmployeeData()
        {
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/");
            var requestObject = new RestRequest("employees");
            var response = client.ExecuteAsync(requestObject);    //.ExecuteAsync(requestObject);

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            if (response.Status.Equals(System.Net.HttpStatusCode.OK))

            {
                //string rawResponse = response.Content;
                string rawResponse = response.ToString();
                Rootobject result = JsonConvert.DeserializeObject<Rootobject>(rawResponse);

                for (int i = 0; i < 24; i++)
                {
                    System.Console.WriteLine(result.data[i].id);
                    System.Console.WriteLine(result.data[i].employee_name);
                    System.Console.WriteLine(result.data[i].employee_age);
                    System.Console.WriteLine(result.data[i].employee_salary + "\n");
                }
            }
        }


        public static void CreateEmployee()
        {
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/");
            var requestObject = new RestRequest("create", Method.Post);
            requestObject.AddParameter("name", "Test Employee");
            requestObject.AddParameter("salary", "25000");
            requestObject.AddParameter("age", "21");
            requestObject.AddHeader("Content-Type", "application/json; charset=utf-8");


            var response = client.ExecuteAsync(requestObject);    //.ExecuteAsync(requestObject);

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            if (response.Status.Equals(System.Net.HttpStatusCode.OK))

            {
                //string rawResponse = response.Content;
                //Rootobject result = JsonConvert.DeserializeObject<Rootobject>(rawResponse);

            }
        }

        public class Rootobject
        {
            public string status { get; set; }
            public Datum[] data { get; set; }
            public string message { get; set; }
        }

        public class Datum
        {
            public int id { get; set; }
            public string employee_name { get; set; }
            public int employee_salary { get; set; }
            public int employee_age { get; set; }
            public string profile_image { get; set; }
        }

    }
}