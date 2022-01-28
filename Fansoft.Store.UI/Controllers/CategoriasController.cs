using Fansoft.Store.Domain.Contracts.Data;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Fansoft.Store.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fansoft.Store.UI.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUnitOfWork _uow;

        public CategoriasController(
            ICategoriaRepository categoriaRepository,
            IUnitOfWork uow)
        {
            _categoriaRepository = categoriaRepository;
            _uow = uow;
        }

        public async Task< IActionResult> Index()
        {
            var model = (await _categoriaRepository.GetAsync())
                        .Select(x=>x.ToCategoriaIndexVM());
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            // ViewBag.Categorias = categorias;
            var model = new CategoriaAddEditVM();

            if (id > 0)
            {
                var data = await _categoriaRepository.GetAsync(id);
                model = data.ToCategoriaAddEditVM();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(int id, CategoriaAddEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var categoria = model.ToData();

            if (id == 0)
            {
                _categoriaRepository.Add(categoria);
            }
            else
            {
                categoria.Id = id;
                categoria.DataAlteracao = DateTime.Now;
                _categoriaRepository.Update(categoria);
            }

            await _uow.CommitAsync();

            return RedirectToAction("Index");
        }


        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {

            var categoria = await _categoriaRepository.GetAsync(id);
            if (categoria == null)
            {
                return BadRequest();
            }
            var count = await countProdAsync(categoria.Id);

            if (count > 0) {
                return BadRequest("Essa categorai possui x produtos");
            }

            _categoriaRepository.Delete(categoria);

            await _uow.CommitAsync();

            return NoContent();
        }

		private async Task<int> countProdAsync(int categoriaId)
		{
            return await _categoriaRepository.CountProdsAsync(categoriaId);
		}
	}
}
