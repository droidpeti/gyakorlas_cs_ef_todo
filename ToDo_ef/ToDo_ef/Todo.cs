using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_ef
{
    class Todo
    {
        public int Id { get; set; }
        public string Tevekenyseg { get; set; }
        public DateOnly Datum { get; set; }
        public byte Fontossag { get; set; }
        public bool Folyamatos { get; set; }
        public bool Elvegzett { get; set; }

    }
}
