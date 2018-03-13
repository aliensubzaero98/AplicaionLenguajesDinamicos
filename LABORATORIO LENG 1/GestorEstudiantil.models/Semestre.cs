using System;
using System.Collections.Generic;
using System.Text;

namespace GestorEstudiantil.models
{
    public class Semestre
    {
        public int SemestreId { get; set; }
        public string NombreSemestre { get; set; }
        public IList<SemestreMateria> Materias { get; set; }

    }
}
