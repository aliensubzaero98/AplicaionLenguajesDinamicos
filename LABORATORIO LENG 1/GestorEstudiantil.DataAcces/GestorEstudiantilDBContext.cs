using GestorEstudiantil.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorEstudiantil.DataAcces
{
    public class GestorEstudiantilDBContext:DbContext
    {
        public DbSet<Semestre> Semestre { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<SemestreMateria> SemestreMateria { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<EstudianteMatriculado> EstudianteMatriculado { get; set; }
        public DbSet<Asistencia> Asistencia { get; set; }
        public IQueryable<Semestre> Semestres { get; internal set; }

        public GestorEstudiantilDBContext(DbContextOptions<GestorEstudiantilDBContext> options) : base(options) 
        {

        }

        public GestorEstudiantilDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gestorestudiantil.db");
        }
    }

}
