

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class Program
{
    private static readonly JsonSerializerOptions JsonOut = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
    };

    public static async Task Main()
    {
        using var http = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") };

        Console.WriteLine("=== JSONPlaceholder /albums CRUD con una sola classe Album ===\n");

        // READ: GET /albums/1
        Console.WriteLine("GET /albums/1");
        Album? one = await http.GetFromJsonAsync<Album>("albums/1");
        Console.WriteLine(JsonSerializer.Serialize(one, JsonOut));
        Console.WriteLine();

        // READ: GET /albums
        Console.WriteLine("GET /albums");
        List<Album>? all = await http.GetFromJsonAsync<List<Album>>("albums");
        Console.WriteLine($"Totale album: {all?.Count}");
        if (all is { Count: > 0 })
            Console.WriteLine(JsonSerializer.Serialize(all[0], JsonOut));
        Console.WriteLine();

        // CREATE: POST /albums
        Console.WriteLine("POST /albums");
        var toCreate = new Album { UserId = 1, Title = "Nuovo album (demo)" };
        var resPost = await http.PostAsJsonAsync("albums", toCreate, JsonOut);
        resPost.EnsureSuccessStatusCode();
        Album? created = await resPost.Content.ReadFromJsonAsync<Album>();
        Console.WriteLine(JsonSerializer.Serialize(created, JsonOut));
        Console.WriteLine("Nota: JSONPlaceholder non persiste (id tipico: 101).\n");

        // UPDATE: PUT /albums/1
        Console.WriteLine("PUT /albums/1");
        var toUpdate = new Album { UserId = 1, Id = 1, Title = "Album aggiornato via PUT" };
        var resPut = await http.PutAsJsonAsync("albums/1", toUpdate, JsonOut);
        resPut.EnsureSuccessStatusCode();
        Album? updated = await resPut.Content.ReadFromJsonAsync<Album>();
        Console.WriteLine(JsonSerializer.Serialize(updated, JsonOut));
        Console.WriteLine();

        // PATCH: /albums/1 (uso la stessa classe Album con solo Title impostato)
        Console.WriteLine("PATCH /albums/1");
        var toPatch = new Album { Title = "Titolo patch" };
        var patchReq = new HttpRequestMessage(new HttpMethod("PATCH"), "albums/1")
        {
            Content = JsonContent.Create(toPatch, options: JsonOut)
        };
        var resPatch = await http.SendAsync(patchReq);
        resPatch.EnsureSuccessStatusCode();
        Album? patched = await resPatch.Content.ReadFromJsonAsync<Album>();
        Console.WriteLine(JsonSerializer.Serialize(patched, JsonOut));
        Console.WriteLine();

        // DELETE: /albums/1
        Console.WriteLine("DELETE /albums/1");
        var resDel = await http.DeleteAsync("albums/1");
        Console.WriteLine($"Esito: {(int)resDel.StatusCode} {resDel.ReasonPhrase} (200 o 204)");
        Console.WriteLine("\n=== Fine Demo ===");
    }
}

public class Album
{
    [JsonPropertyName("userId")] public int UserId { get; set; }
    [JsonPropertyName("id")]     public int Id { get; set; }
    [JsonPropertyName("title")]  public string? Title { get; set; }
}
