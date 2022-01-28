using System.Collections.Generic;

namespace Fansoft.Store.Domain.Entities
{
    public class Perfil : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }
       // public ICollection<Usuario> Usuarios { get; set; }
    }
}
