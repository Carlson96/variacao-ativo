using System;
using System.Net.Http;
using System.Threading.Tasks;

class Teste.Net
{
    static async Task Main()
    {
        string symbol = "PETR4.SA";
        string url = $"https://query2.finance.yahoo.com/v8/finance/chart/{symbol}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                
            }
            else
            {
                Console.WriteLine($"Erro na solicitação: {response.StatusCode}");
            }
        }
    }
}
