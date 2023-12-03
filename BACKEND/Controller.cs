
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

[Route("api/stock")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly StockContext _context;

    public StockController(StockContext context)
    {
        _context = context;
    }

    [HttpGet("{symbol}")]
    public IActionResult GetStockData(string symbol)
    {
        var stockData = _context.StockPrices
            .Where(s => s.Symbol == symbol)
            .OrderByDescending(s => s.Date)
            .Take(30)
            .ToList();

        

        return Ok(stockData);
    }
}
