using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientSample
{

    public class Album
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }

        override
        public string ToString()
        {
            return "Album: " + id + " " + title + " owned by " + userId;
        }
    }


    class Program
    {

        static HttpClient client = new HttpClient();

        static void ShowProduct(Album album)
        {
            Console.WriteLine(album.ToString());
        }

        static async Task<Album> GetAlbumAsync(string path)
        {
            Album product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product =  await JsonSerializer.DeserializeAsync<Album>(await response.Content.ReadAsStreamAsync());
            }
            return product;
        }


        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Album album = null;

                // Get an existing product
                album = await GetAlbumAsync("/albums/2");
                ShowProduct(album);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}

