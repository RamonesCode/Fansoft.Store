using Fansoft.Store.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Fansoft.Store.UI.ViewModels
{
    public class CategoriaIndexVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }

		public int QtdeProdutos { get; set; }

	}

    public class CategoriaAddEditVM 
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(50, ErrorMessage = "limite excedido")]
        public string Nome { get; set; }
    }

    public static class CategoriaVMModelExtensions 
    {
        public static CategoriaAddEditVM ToCategoriaAddEditVM(this Categoria data) 
        {
            return new CategoriaAddEditVM() { Nome = data.Nome };
        }

        public static CategoriaIndexVM ToCategoriaIndexVM(this Categoria data) 
        {
            return new CategoriaIndexVM() {
                Id = data.Id,
                Nome = data.Nome,
                DataCadastro = data.DataCadastro,
                QtdeProdutos = data.Produtos.Count()
            };
        }

        public static Categoria ToData(this CategoriaAddEditVM model) 
        {
            return new Categoria() { Nome = model.Nome  };
        }
    }

}
