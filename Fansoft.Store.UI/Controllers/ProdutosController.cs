using Fansoft.Store.Domain.Contracts.Data;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fansoft.Store.UI.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public IUnitOfWork _uow { get; }

        public ProdutosController(
            IProdutoRepository produtoRepository, 
            ICategoriaRepository categoriaRepository,
             IUnitOfWork uow)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var produtos =  
                (await _produtoRepository.GetAllWithCategoriasAsync()).Select(x => x.ToProdutoIndexVM());
            return View(produtos);
        }

        [HttpGet]
        public IActionResult AddEdit(int id)
        {
            // ViewBag.Categorias = categorias;
            var model = new ProdutoAddEditVM();

            if (id > 0)
            {
                var data = _produtoRepository.Get(id);
                model = data.ToProdutoAddEditVM();
            }

            addCategoriasToModel(model);

            return View(model);
        }

        private void addCategoriasToModel(ProdutoAddEditVM model)
        {
            var categorias = _categoriaRepository.Get();
            model.Categorias = categorias.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(int id, ProdutoAddEditVM model)
        {
            if (!ModelState.IsValid)
            {
                addCategoriasToModel(model);
                return View(model);
            }


            var produto = model.ToData();

            if (id == 0)
            {
                _produtoRepository.Add(produto);
            }
            else
            {
                produto.Id = id;
                produto.DataAlteracao = DateTime.Now;
                _produtoRepository.Update(produto);
            }

            await _uow.CommitAsync();
          
            return RedirectToAction("Index");
        }


        [HttpDelete]
        public async Task< IActionResult> Excluir(int id)
        {

            var produto = await _produtoRepository.GetAsync(id);
            if (produto == null)
            {
                return BadRequest();
            }

            _produtoRepository.Delete(produto);
           await _uow.CommitAsync();

            return NoContent();
        }
    }
}
