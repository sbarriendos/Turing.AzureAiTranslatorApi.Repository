using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;
public class TranslatorDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TranslatorEntity> Translators { get; set; }
}
