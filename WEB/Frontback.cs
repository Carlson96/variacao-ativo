

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

[ApiController]
[Route("api/stock")]
public class StockController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public StockController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet("{symbol}")]
    public async Task<IActionResult> GetStockData(string symbol)
    {
        string url = $"https://query2.finance.yahoo.com/v8/finance/chart/{symbol}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string responseData = await response.Content.ReadAsStringAsync();
          
            return Ok(parsedData);
        }
        else
        {
            return BadRequest($"Erro na solicitação: {response.StatusCode}");
        }
    }
}
