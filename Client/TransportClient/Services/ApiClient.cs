using System.Net.Http.Json;
using TransportClient.Models;

namespace TransportClient.Services;

public class ApiClient
{
    private readonly HttpClient _http;
    public ApiClient()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://localhost:5000/api/");
    }

    // DRIVERS

    public async Task<List<Driver>> GetDrivers()
    {
        var result = await _http.GetFromJsonAsync<List<Driver>>("drivers");
        return result ?? new List<Driver>();
    }

    public async Task AddDriver(Driver driver)
    {
        var response = await _http.PostAsJsonAsync("drivers", driver);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteDriver(int id)
    {
        var response = await _http.DeleteAsync($"drivers/{id}");
        response.EnsureSuccessStatusCode();
    }

    // TRANSPORTS 

    public async Task<List<Transport>> GetTransports()
    {
        var result = await _http.GetFromJsonAsync<List<Transport>>("transports");
        return result ?? new List<Transport>();
    }

    public async Task AddTransport(Transport t)
    {
        var response = await _http.PostAsJsonAsync("transports", t);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteTransport(int id)
    {
        var response = await _http.DeleteAsync($"transports/{id}");
        response.EnsureSuccessStatusCode();
    }

    // REPAIRS 

    public async Task<List<Repair>> GetRepairs()
    {
        var result = await _http.GetFromJsonAsync<List<Repair>>("repairs");
        return result ?? new List<Repair>();
    }

    public async Task AddRepair(Repair r)
    {
        var response = await _http.PostAsJsonAsync("repairs", r);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteRepair(int id)
    {
        var response = await _http.DeleteAsync($"repairs/{id}");
        response.EnsureSuccessStatusCode();
    }
}