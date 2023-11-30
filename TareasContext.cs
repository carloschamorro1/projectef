using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() 
        { 
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), 
            Nombre = "Actividades pendientes", 
            Peso = 20
        });
        categoriasInit.Add(new Categoria() 
        { 
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), 
            Nombre = "Actividades personales", 
            Peso = 50
        });
        
        modelBuilder.Entity<Categoria>(categoria => 
        {
            categoria.ToTable("Categorias");
            categoria.HasKey(c => c.CategoriaId);
            categoria.Property(c => c.Nombre).HasMaxLength(150).IsRequired();
            categoria.Property(c => c.Descripcion).IsRequired(false);
            categoria.Property(c => c.Peso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() 
        { 
            TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), 
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), 
            PrioridadTarea = Prioridad.Media, 
            Titulo = "Pago de servicios publicos", 
            FechaCreacion = DateTime.Now 
        });
        tareasInit.Add(new Tarea() 
        { 
            TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), 
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), 
            PrioridadTarea = Prioridad.Baja, 
            Titulo = "Terminar de ver pelicula en netflix", 
            FechaCreacion = DateTime.Now 
        });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tareas");
            tarea.HasKey(t => t.TareaId);

            tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(t => t.CategoriaId);

            tarea.Property(t => t.Titulo).HasMaxLength(200).IsRequired();

            tarea.Property(t => t.Descripcion).IsRequired(false);

            tarea.Property(t => t.PrioridadTarea);
            
            tarea.Property(t => t.FechaCreacion);

            tarea.Ignore(p => p.Resumen);
            tarea.HasData(tareasInit);
            
        });
    }

}