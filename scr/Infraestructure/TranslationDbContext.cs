using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;
public class TranslationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TranslationEntity> Translations { get; set; }
}
