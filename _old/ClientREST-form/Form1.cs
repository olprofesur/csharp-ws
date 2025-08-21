using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientREST_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClientREST.init();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;
            int idInt;
            Album a=null;
            if (id != null && int.TryParse(id, out idInt))
            {
                a=await ClientREST.GetAlbumAsync("/albums/" + id);
                textBoxTitle.Text = a.title;
                textBoxUserID.Text = a.userId+"";
            }
            

        }
    }

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


    class ClientREST
    {

        static HttpClient client = new HttpClient();

        public static void init()
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        static void ShowProduct(Album album)
        {
            Console.WriteLine(album.ToString());
        }

        public static async Task<Album> GetAlbumAsync(string path)
        {
            Album product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await JsonSerializer.DeserializeAsync<Album>(await response.Content.ReadAsStreamAsync());
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


        /*static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }*/

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
                /*
                album = await GetAlbumAsync(url);
                ShowProduct(album);*/

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
