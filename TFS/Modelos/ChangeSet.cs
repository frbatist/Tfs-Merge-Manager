using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFS
{
    public class ChangeSet
    {
        public bool Selecionado { get; set; }
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string CodigoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Comentario { get; set; }
    }
}
