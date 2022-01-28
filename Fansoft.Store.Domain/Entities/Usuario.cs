using Fansoft.Store.Domain.Enums;
using System.Collections.Generic;

namespace Fansoft.Store.Domain.Entities
{
    public class Usuario : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Genero Genero { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }

        public IEnumerable<Perfil> Perfis { get; set; }
        //public ICollection<Perfil> Perfis { get; set; }

        public IEnumerable<Perfil> PerfisAtualizado { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }

    }
}
