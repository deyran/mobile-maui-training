using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAPI.Data
{
    public class DataService
    {
        private readonly HttpClient _client;

        public DataService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://example.com/api/");
        }
        public async Task<List<Item>> GetItemsAsync()
        {
            var response = await _client.GetAsync("items");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<List<Item>>(content);
                return items;
            }
            else
            {
                return null;
            }
        }
        public async Task<Item> GetItemAsync(int id)
        {
            var response = await _client.GetAsync($"items/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<Item>(content);
                return item;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> AddItemAsync(Item item)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("items", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateItemAsync(Item item)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"items/{item.Id}", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _client.DeleteAsync($"items/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}