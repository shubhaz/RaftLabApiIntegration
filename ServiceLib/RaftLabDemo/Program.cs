using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLib.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        // Register ReqresClient with HttpClient and base address
        services.AddHttpClient<ReqresClient>(client =>
        {
            client.BaseAddress = new Uri("https://reqres.in/api/");
            client.DefaultRequestHeaders.Add("x-api-key", "reqres-free-v1");
        });
    })
    .Build();

// Resolve ReqresClient directly
var client = host.Services.GetRequiredService<ReqresClient>();

Console.WriteLine("Fetching users from page 1...");
var userList = await client.GetUsersAsync();
if (userList?.Data != null)
{
    foreach (var user in userList.Data)
    {
        Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName} - {user.Email}");
    }
}

Console.WriteLine("\nFetching user with ID 2...");
var user2 = await client.GetUserAsync(2);
if (user2 != null)
    Console.WriteLine($"{user2.Id}: {user2.FirstName} {user2.LastName} - {user2.Email}");
else
    Console.WriteLine("User not found.");
