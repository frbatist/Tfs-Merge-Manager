using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFS.Modelos
{
    public class Merge
    {
        public int IdChangeSetInicio { get; set; }
        public int IdChangeSetFim { get; set; }
        public string Mensagem { get; set; }
        public int Conflitos { get; set; }
        public bool Finalizado { get; set; }
    }
}
