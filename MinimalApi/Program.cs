using MinimalApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", (string name) => $"Hola {name}");
app.MapGet("/hellowithname/{name}/{lastname}",
    (string name, string lastname) => $"Hola {name} {lastname}");
app.MapGet("/response", async () =>
{
    HttpClient httpClient = new HttpClient();
    var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    return responseBody;
});
app.MapGet("/photos", async () =>
{
    HttpClient httpClient = new HttpClient();
    var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos/1");
    response.EnsureSuccessStatusCode();
    //string responseBody = await response.Content.ReadAsStringAsync();
    Photo body = await response.Content.ReadFromJsonAsync<Photo>();    
    return body;
});



app.Run();
