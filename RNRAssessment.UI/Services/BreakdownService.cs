using Newtonsoft.Json;
using RNRAssessment.UI.Models;
using System.Text;

namespace RNRAssessment.UI.Services
{
    public class BreakdownService:IBreakdownService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public BreakdownService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IEnumerable<BreakdownModel>?> GetBreakdownsAsync()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            string requestUrl=(_configuration.GetValue<string>("Endpoints:RnrAssessment")
                +"/api/Breakdowns");
            client.BaseAddress = new Uri(requestUrl);
            HttpResponseMessage response=await client.GetAsync(requestUrl);
            if(response.IsSuccessStatusCode)
            {
                IEnumerable<BreakdownModel>? items = 
                    JsonConvert
                    .DeserializeObject<IEnumerable<BreakdownModel>>(
                        await response.Content.ReadAsStringAsync());
                return items;
            }
            return new List<BreakdownModel>();            
        }

        public async Task<BreakdownModel?> CreateBreakdownsAsync(BreakdownModel BreakdownModel)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            string requestUrl = (_configuration.GetValue<string>("Endpoints:RnrAssessment")
                + "/api/Breakdowns/Create");
            client.BaseAddress = new Uri(requestUrl);
            HttpResponseMessage response = await client.PostAsync(requestUrl,new StringContent(JsonConvert.SerializeObject(BreakdownModel),Encoding.UTF8,"application/json"));
            if (response.IsSuccessStatusCode)
            {
                BreakdownModel? item =
                    JsonConvert
                    .DeserializeObject<BreakdownModel>(
                        await response.Content.ReadAsStringAsync());
                return item;
            }
            return null;
        }

        public async Task<BreakdownModel?> GetBreakdownAsync(int BreakdownId)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            string requestUrl = (_configuration.GetValue<string>("Endpoints:RnrAssessment")
                + $"/api/Breakdowns/{BreakdownId}");
            client.BaseAddress = new Uri(requestUrl);
            HttpResponseMessage response = await client.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                BreakdownModel? item =
                    JsonConvert
                    .DeserializeObject<BreakdownModel>(
                        await response.Content.ReadAsStringAsync());
                return item;
            }
            return null;
        }

        public async Task<ExistModel?> BreakdownReferenceExistsAsync(string BreakdownReference)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            string requestUrl = (_configuration.GetValue<string>("Endpoints:RnrAssessment")
                + $"/api/Breakdowns/BreakdownReference/{BreakdownReference}");
            client.BaseAddress = new Uri(requestUrl);
            HttpResponseMessage response = await client.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                ExistModel? item =
                    JsonConvert
                    .DeserializeObject<ExistModel>(
                        await response.Content.ReadAsStringAsync());
                return item;
            }
            return null;
        }
        public async Task<BreakdownModel?> UpdateBreakdownsAsync(BreakdownModel breakdownModel)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            string requestUrl = (_configuration.GetValue<string>("Endpoints:RnrAssessment")
                + "/api/Breakdowns/Update");
            client.BaseAddress = new Uri(requestUrl);
            HttpResponseMessage response = await client.PutAsync(requestUrl, new StringContent(JsonConvert.SerializeObject(breakdownModel), Encoding.UTF8, "application/json")); 
            if (response.IsSuccessStatusCode)
            {
                BreakdownModel? items =
                    JsonConvert
                    .DeserializeObject<BreakdownModel>(
                        await response.Content.ReadAsStringAsync());
                return items;
            }
            return null;
        }
    }
}
