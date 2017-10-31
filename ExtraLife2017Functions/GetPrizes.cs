using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ExtraLife2017Functions.Interfaces;
using ExtraLife2017Functions.Models;
using ExtraLife2017Functions.Repositories;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace ExtraLife2017Functions
{
    public static class GetPrizes
    {
        [FunctionName("GetPrizes")]

        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Prizes")]
            HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info("GetPrizes HTTP trigger function processed a request.");

            IPrizeRepository repository = new PrizeRepository();
            var prizes = repository.RetrieveAsync().Result.ToImmutableList();
            var builder = ImmutableList.CreateBuilder<Prize>();
            builder.AddRange(prizes);

            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(builder));
        }
    }
}
