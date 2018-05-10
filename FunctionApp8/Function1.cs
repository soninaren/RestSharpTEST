using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using RestSharp;

namespace FunctionApp8
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            var client = new RestClient("http://www.google.com");
            var request = new RestRequest(Method.GET);
            request.AddParameter("q", "test");
            
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            log.Info(content);
        }
    }
}
