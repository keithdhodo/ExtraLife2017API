using System.Collections.Generic;
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
    public static class AddNewPrizes
    {
        [FunctionName("AddNewPrizes")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Prizes/AddNewPrizes")]
            HttpRequestMessage req, TraceWriter log)
        {
            log.Info("AddNewPrize HTTP trigger function processed a request.");

            var prizes = JsonConvert.DeserializeObject<List<Prize>>(req.Content.ReadAsStringAsync().Result);

            IPrizeRepository repository = new PrizeRepository();
            var newPrizes = repository.SaveAsync(prizes).Result.ToImmutableList();
            var builder = ImmutableList.CreateBuilder<Prize>();
            builder.AddRange(newPrizes);

            return req.CreateResponse(HttpStatusCode.OK, builder);
        }
    }
}
