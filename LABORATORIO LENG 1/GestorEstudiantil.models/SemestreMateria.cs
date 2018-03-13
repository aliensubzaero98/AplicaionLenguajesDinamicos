using System;
using System.Collections.Generic;
using System.Text;

namespace GestorEstudiantil.models
{
   public class SemestreMateria
    {
        public int SemestreMateriaId { get; set; }

        public int MateriaId { get; set; }
        public Materia Materia { get; set; }

        public int SemestreId { get; set; }
        public Semestre Semestre { get; set; }

        public IList<EstudianteMatriculado>EstudianteMatriculado { get; set; }

    }
}
