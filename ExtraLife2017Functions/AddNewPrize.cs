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
    public static class AddNewProduct
    {
        [FunctionName("AddNewPrize")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Prizes/AddNewPrize")]
            HttpRequestMessage req, 
            TraceWriter log)
        {
            log.Info("AddNewPrize HTTP trigger function processed a request.");

            var prize = JsonConvert.DeserializeObject<Prize>(req.Content.ReadAsStringAsync().Result);

            IPrizeRepository repository = new PrizeRepository();
            var newPrize = repository.SaveAsync(prize).Result.ToImmutableList();
            var builder = ImmutableList.CreateBuilder<Prize>();
            builder.AddRange(newPrize);

            return req.CreateResponse(HttpStatusCode.OK, builder);
        }
    }
}
