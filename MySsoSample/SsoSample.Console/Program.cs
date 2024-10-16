// See https://aka.ms/new-console-template for more information
using IdentityModel.Client;
using Newtonsoft.Json;
using SsoSample.Console;
Console.WriteLine("hello world");
Thread.Sleep(10000);
var identityClient=new HttpClient();
var discovery = await identityClient.GetDiscoveryDocumentAsync("https://localhost:7003");
if (discovery.IsError)
{ 
    Console.WriteLine(discovery.Error);
    return; }
var tokenResponse =await identityClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = discovery.TokenEndpoint,
    ClientId="client",
    ClientSecret="secret",
    Scope="api1"
}) ;
if(tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    return; }
var client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7001");
client.SetBearerToken(tokenResponse.AccessToken);
var resultString = await client.GetStringAsync("/WeatherForecast");
var result = JsonConvert.DeserializeObject<List<WeatherForecast>>(resultString);
foreach (var item in result) {
    Console.WriteLine($"{item.Date}\t{item.Summary}\t\t{item.TemperatureC}\t\t{item.TemperatureF}");
    Console.WriteLine("".PadLeft(200, '_'));
}
Console.ReadLine();