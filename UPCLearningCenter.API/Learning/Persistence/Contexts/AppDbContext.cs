using Microsoft.EntityFrameworkCore;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Shared.Extensions;

namespace UPCLearningCenter.API.Learning.Persistence.Contexts;
//llamamos a Dbcontext es importante instalar los paquetes primero
//de lo contrario no funciona
//generamos un constructor
public class AppDbContext: DbContext
{
    private DbSet<Category>? categories;

    public DbSet<Category> Categories {
        get => GetContext(categories);
        set => categories = value;
    }
    
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);

        var CategoryEntity = builder.Entity<Category>();
        CategoryEntity.ToTable("Categories");
        CategoryEntity.HasKey(p => p.id);
        CategoryEntity.Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        CategoryEntity.Property(p => p.Name).IsRequired();
//es necesario que sea en formato snake case. recordemos que en shared -< extensions
//implementamos el formato
        builder.UseSnakeCase();
    }
    private static T GetContext<T>(T? ctx) {
        if (ctx == null) throw new NullReferenceException();
        return ctx;
    }
}