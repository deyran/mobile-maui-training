

using Newtonsoft.Json;

namespace MauiAPI.APIEln
{
    public class ApiElnData
    {
        private readonly HttpClient _client;
        private readonly string _baseAddress =
        "https://sgestorweb.eletronorte.com.br/engenharia/segtrabalho/api/";

        public ApiElnData()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseAddress);
        }

        public async Task<List<ExtintorData>> GetItemsAsync()
        {
            var response = await _client.GetAsync("extintoralmoxarifados");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var extintorData = JsonConvert.DeserializeObject<List<ExtintorData>>(content);

                return extintorData;
            }

            return null;
        }
    }
}
