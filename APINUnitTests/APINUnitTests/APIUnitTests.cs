using APINUnitTests.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using Microsoft.Extensions.Configuration;

namespace APINUnitTests
{
	public class Tests
	{
        private string BASE_URL = "";
        public IConfigurationRoot Configuration { get; set; }

        [SetUp]
        public void Setup()
        {
            Configuration = new ConfigurationBuilder()
                            //.SetBasePath(env.ContentRootPath)
                            .AddJsonFile("config.json")
                            .Build();
            BASE_URL = Configuration["BaseURL"];
        }
        [Test]
        public void APIGetUserNameById()
        {
            //Test - this test simply creates a new user
            ToDo bodyObject = new ToDo();
            bodyObject.Description = Configuration["Description"];
            bodyObject.Name = Configuration["Name"];
            bodyObject.Status = Convert.ToBoolean(Configuration["Status"]);
            RestClient client = new RestClient(BASE_URL);
            var addToListURL = Configuration["AddToListURL"]; 
            RestRequest request = new RestRequest(addToListURL, Method.POST);
            request.AddJsonBody(bodyObject);

            IRestResponse response = client.Execute(request);
            var returnedResponse = new JsonDeserializer().Deserialize<string>(response);
            returnedResponse = returnedResponse.Replace('\\', ' ');
            ResultAPI result = JsonConvert.DeserializeObject<ResultAPI>(returnedResponse);    
            Assert.That(result.EndMessage, Is.EqualTo(Configuration["ResultAnswer"]));
        }
    }
}
