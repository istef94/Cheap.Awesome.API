using NUnit.Framework;
using System.Net.Http;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;
using System;
using RestSharp;

namespace Cheap.Awesome.NUnit.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfApiRunUnderOneSecond()
        {
            var beforeExecution = DateTime.Now;
            var afterExecution = DateTime.Now;

            var serviceURL = "http://localhost:52729/hotel/279/23";
            var client = new RestClient(serviceURL);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            afterExecution = DateTime.Now;

            if ((afterExecution - beforeExecution < TimeSpan.FromSeconds(1)) && response.StatusCode == HttpStatusCode.OK)
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}