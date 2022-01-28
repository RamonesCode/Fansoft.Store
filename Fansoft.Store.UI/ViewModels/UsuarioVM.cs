using Fansoft.Store.Domain.Entities;
using Fansoft.Store.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Fansoft.Store.UI.ViewModels
{
    public class UsuarioIndexVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
		public string Perfis { get; set; }

		public string Email { get; set; }
        public string Genero { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public class UsuarioAddEditVM {

        public UsuarioAddEditVM()
        {
            Generos = UsuarioVMModelExtensions.GetGeneros();
        }


        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(50, ErrorMessage = "tamanho excedido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [EmailAddress(ErrorMessage = "email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string Senha { get; set; }

        [Compare("Senha",ErrorMessage ="as senhas não conferem")]
        [DataType(DataType.Password)]
        public string ConfirmacaoSenha { get; set; }


        [Required(ErrorMessage = "campos obrigatório")]
        public int? Genero { get; set; }
        public IEnumerable<SelectListItem> Generos { get; set; }

		public IEnumerable<int> PerfisId { get; set; }
		public IEnumerable<SelectListItem> Perfis { get; set; }
	}

    public static class UsuarioVMModelExtensions 
    {

        public static Usuario ToData(this UsuarioAddEditVM model) 
        {
            return new Usuario() { 
                Nome = model.Nome, Email = model.Email, Senha = model.Senha,
                Genero = (Genero)model.Genero
                
            };
        }

        public static UsuarioAddEditVM ToUsuarioAddEditVM(this Usuario data)
        {
            var senha = "SenhaTemporaria";

            return new UsuarioAddEditVM()
            {
                Nome = data.Nome,
                Email = data.Email,
                Senha = senha,
                ConfirmacaoSenha = senha,
                Genero = (int)data.Genero,
                Generos = GetGeneros()
            };
        }

        public static IEnumerable<SelectListItem> GetGeneros()
        {
            var generos = Enum.GetValues(typeof(Genero)).Cast<Genero>().ToList();
            return generos.Select(x => new SelectListItem { Text = Enum.GetName(x), Value =  ((int)x).ToString() });
        }


        public static UsuarioIndexVM ToUsuarioIndexVM(this Usuario data)
        {
            return new UsuarioIndexVM() { 
                Id = data.Id, Nome = data.Nome,
                Email = data.Email, Genero = Enum.GetName(data.Genero),
                DataCadastro = data.DataCadastro,
                Perfis = string.Join(", ", data.Perfis?.Select(x=>x.Nome))
            };
        }
    }
}
