using Microsoft.EntityFrameworkCore;
using UPCLearningCenter.API.Learning.Domain.Models;
using UPCLearningCenter.API.Shared.Extensions;

namespace UPCLearningCenter.API.Learning.Persistence.Contexts;
//llamamos a Dbcontext es importante instalar los paquetes primero
//de lo contrario no funciona
//generamos un constructor
public class AppDbContext: DbContext
{
    private DbSet<Category>? _categories;
    private DbSet<Tutorial>? _tutorials;

    public DbSet<Category> Categories {
        get => GetContext(_categories);
        set => _categories = value;
    }

    public DbSet<Tutorial> Tutorials
    {
        get => GetContext(_tutorials);
        set => _tutorials = value;
    }

    public AppDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
//definicion  de category
        var categoryEntity = builder.Entity<Category>();
        categoryEntity.ToTable("Categories");
        categoryEntity.HasKey(p => p.id);
        categoryEntity.Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        categoryEntity.Property(p => p.Name).IsRequired();
        
        //relaciones
        categoryEntity.HasMany(p => p.Tutorials)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
        
        
        //definicion de tutorial
        
        var tutorialEntity = builder.Entity<Tutorial>();
        tutorialEntity.ToTable("Tutorials");
        tutorialEntity.HasKey(p => p.id);
        tutorialEntity.Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        tutorialEntity.Property(p => p.Title).IsRequired().HasMaxLength(50);
        tutorialEntity.Property(p => p.Description).HasMaxLength(120);
        
//es necesario que sea en formato snake case. recordemos que en shared -< extensions
//implementamos el formato
        builder.UseSnakeCase();
    }
    private static T GetContext<T>(T? ctx) {
        if (ctx == null) throw new NullReferenceException();
        return ctx;
    }
}