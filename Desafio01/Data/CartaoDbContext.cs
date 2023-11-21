using Desafio01.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio01.Data;

public class CartaoDbContext : DbContext
{
    public CartaoDbContext(DbContextOptions<CartaoDbContext> options) : base(options)
    {

    }
    public DbSet<CartaoCredito> CartaoCredito {get; set;}
}
