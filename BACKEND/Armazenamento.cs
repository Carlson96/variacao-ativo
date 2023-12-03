
using Microsoft.EntityFrameworkCore;

public class StockContext : DbContext
{
    public DbSet<StockPrice> StockPrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("sua_string_de_conexao");
}

public class StockPrice
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Symbol { get; set; }
    public decimal Value { get; set; }
}

