using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientREST
{
    class Program
    {
        static readonly HttpClient _client = new HttpClient();
        static String defaultPath = "http://localhost:8080/matches";
        private static String jSonType = "application/json";

        static async Task RunAsync()
        {
            List<Match> list;
            list = await GetAllMatches(defaultPath);
            list.ForEach(Console.WriteLine);
            Match m = new Match("tt1","tt2","final",20,20.0);
            await AddMatch(defaultPath, m);
        }

        static async Task<Match> GetMatch(string path, string id)
        {
            Match match = null;
            var response = await _client.GetAsync(path + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                try
                {
                    // your code 
                    match = JsonConvert.DeserializeObject<Match>(jsonContent);

                }
                catch (AggregateException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return match;
        }

        static async Task AddMatch(string path, Match m)
        {
            var json = JsonConvert.SerializeObject(m);
            var response = await _client.PostAsync(path, new StringContent(json, Encoding.UTF8, "application/json"));
            Console.WriteLine(response.IsSuccessStatusCode ? "Added new match!" : "Add error!");
        }

        static async Task DeleteMatch(string path, string id)
        {
            var response = await _client.DeleteAsync(path + "/" + id);
            Console.WriteLine(response.IsSuccessStatusCode ? "Deleted selected match!" : "Delete error!");
        }

        static async Task UpdateMatch(string path, Match t)
        {
            var json = JsonConvert.SerializeObject(t);
            var response = await _client.PutAsync(path, new StringContent(json, Encoding.UTF8, "application/json"));
            Console.WriteLine(response.IsSuccessStatusCode ? "Updated selected match!" : "Update error!");
        }

        static async Task<List<Match>> GetAllMatches(string path)
        {
            var response = await _client.GetAsync(path);
            List<Match> matches = new List<Match>();

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(jsonContent);
                try
                {
                    // your code 
                    matches = JsonConvert.DeserializeObject<List<Match>>(jsonContent);


                }
                catch (AggregateException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            return matches;
        }

        static void Main(string[] args)
        {
            _client.BaseAddress = new Uri(defaultPath);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            RunAsync().Wait();
        }
    }

    
    

    
}
