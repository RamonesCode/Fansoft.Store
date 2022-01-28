using Fansoft.Store.Domain.Contracts.Data;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fansoft.Store.UI.Controllers
{
    public class PerfisController : Controller
    {
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUnitOfWork _uow;

        public PerfisController(
            IPerfilRepository perfilRepository,
            IUnitOfWork uow)
        {
            _perfilRepository = perfilRepository;
            _uow = uow;
        }

        public IActionResult Index()
        {
            var model = _perfilRepository.GetAllWithUsuarios().Select(x => x.ToPerfilIndexVM());
            return View(model);
        }

        [HttpGet]
        public IActionResult AddEdit(int id)
        {
            var model = new PerfilAddEditVM();

            if (id > 0)
            {
                var data = _perfilRepository.Get(id);
                model = data.ToPerfilAddEditVM();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddEdit(int id, PerfilAddEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var perfil = model.ToData();

            if (id == 0)
            {
                _perfilRepository.Add(perfil);
            }
            else
            {
                perfil.Id = id;
                perfil.DataAlteracao = DateTime.Now;
                _perfilRepository.Update(perfil);
            }

            _uow.Commit();

            return RedirectToAction("Index");
        }


        [HttpDelete]
        public IActionResult Excluir(int id)
        {

            var perfil = _perfilRepository.Get(id);
            if (perfil == null)
            {
                return BadRequest();
            }

            _perfilRepository.Delete(perfil);
            _uow.Commit();

            return NoContent();
        }
    }
}
