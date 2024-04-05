using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

        static async Task<Uri> CreateProductAsync(Album product)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "/albums", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Album> UpdateProductAsync(Album product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"/albums/{product.id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            product = await JsonSerializer.DeserializeAsync<Album>(await response.Content.ReadAsStreamAsync());
            return product;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"/albums/{id}");
            return response.StatusCode;
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
                album = await GetAlbumAsync("/albums/1");
                ShowProduct(album);

                //Create a new product
                album = new Album();
                album.id = 99; album.title = "Test"; album.userId = 1;
                var url = await CreateProductAsync(album);
                Console.WriteLine($"New album reated at {url}");
                
                album = await GetAlbumAsync("https://jsonplaceholder.typicode.com/albums/1");
                ShowProduct(album);

                // Update the product
                Console.WriteLine("Updating title...");
                album.title = "Test2";
                await UpdateProductAsync(album);

                // Delete the product
                var statusCode = await DeleteProductAsync(album.id + "");
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}

