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

namespace ExtraLife2017Functions
{
    public static class GetPrizesUnwon
    {
        [FunctionName("GetPrizesUnwon")]

        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Prizes/Unwon")]
            HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info("GetPrizes HTTP trigger function processed a request.");

            IPrizeRepository repository = new PrizeRepository();
            var prizes = repository.RetrieveAsync().Result.Where(prize => string.IsNullOrEmpty(prize.WonBy)).ToImmutableList();
            var builder = ImmutableList.CreateBuilder<Prize>();
            builder.AddRange(prizes);
            
            return req.CreateResponse(HttpStatusCode.OK, builder);
        }
    }
}
