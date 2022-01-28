using Fansoft.Store.Domain.Contracts.Data;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Fansoft.Store.Domain.Helpers;
using Fansoft.Store.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fansoft.Store.UI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
		private readonly IPerfilRepository _perfilRepository;
		private readonly IUnitOfWork _uow;

        public UsuariosController(
            IUsuarioRepository usuarioRepository,
            IPerfilRepository perfilRepository,
             IUnitOfWork uow)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
            _uow = uow;
            
        }


        public async Task<IActionResult> Index()
        {
            var model = (await _usuarioRepository.GetAllWithPerfisAsync())
                            .Select(x => x.ToUsuarioIndexVM());
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            var model = new UsuarioAddEditVM();

            if (id > 0)
			{
				var data =  await _usuarioRepository.GetByIdWithPerfisAsync(id);
				model = data.ToUsuarioAddEditVM();
			
				model.PerfisId = data.Perfis?.Select(x => x.Id);
			}
           await getPerfisAsync(model);

            return View(model);
        }

		private async Task getPerfisAsync(UsuarioAddEditVM model)
		{
			model.Perfis =
				(await _perfilRepository.GetAsync())
                .Select(x => new SelectListItem()
				{ Value = x.Id.ToString(), Text = x.Nome });
		}

		[HttpPost]
        public async Task<IActionResult> AddEdit(int id, UsuarioAddEditVM model)
        {
            if (!ModelState.IsValid)
            {
               await getPerfisAsync(model);
                return View(model);
            }

            if (id == 0)
            {
                var usuario = model.ToData();
                usuario.Senha.Encrypt();
                usuario.Perfis = await montarPerfis(model.PerfisId);
                _usuarioRepository.Add(usuario);
            }
            else
            {
                var usuario = _usuarioRepository.GetByIdWithPerfis(id);
                usuario.Id = id;
                usuario.Nome = model.Nome;
                usuario.DataAlteracao = DateTime.Now;
                usuario.Perfis = await montarPerfis(model.PerfisId);
                _usuarioRepository.Update(usuario);
            }

           await _uow.CommitAsync();

            return RedirectToAction("Index");
        }
        //private IList
        private async Task<IEnumerable<Perfil>> montarPerfis(IEnumerable<int> perfisId)
		
        {
            return await _perfilRepository.GetByIdsAsync(perfisId);
		}

		[HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {

            var categoria = await _usuarioRepository.GetAsync(id);
            if (categoria == null)
            {
                return BadRequest();
            }

           _usuarioRepository.Delete(categoria);
           await _uow.CommitAsync();

            return NoContent();
        }

    }
}
