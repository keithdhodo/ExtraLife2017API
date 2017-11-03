using ExtraLife2017Functions.Interfaces;
using ExtraLife2017Functions.Models;
using ExtraLife2017Functions.Repositories;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExtraLife2017Functions
{
    public static class UpdatePrize
    {
        [FunctionName("UpdatePrize")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Prizes/Update")]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("PutUpdateProduct HTTP trigger function processed a request.");

            var prize = JsonConvert.DeserializeObject<Prize>(req.Content.ReadAsStringAsync().Result);

            IPrizeRepository repository = new PrizeRepository();
            var result = await repository.SaveAsync(prize.PrizeId, prize);
            var updatedPrize = result.ToImmutableList();
            var builder = ImmutableList.CreateBuilder<Prize>();
            builder.AddRange(updatedPrize);

            return req.CreateResponse(HttpStatusCode.OK, builder);
        }
    }
}
