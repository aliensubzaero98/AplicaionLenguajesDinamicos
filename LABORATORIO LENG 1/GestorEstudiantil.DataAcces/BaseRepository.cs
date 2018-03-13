using System;
using System.Collections.Generic;
using System.Text;

namespace GestorEstudiantil.DataAcces
{
    public class BaseRepository
    {
        public GestorEstudiantilDBContext Context;

        public BaseRepository()
        {
            this.Context = new GestorEstudiantilDBContext();
        }
    }
}
