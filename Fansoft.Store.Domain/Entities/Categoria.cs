using System.Collections.Generic;

namespace Fansoft.Store.Domain.Entities
{
    public class Categoria : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }


    }
}
