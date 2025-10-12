using domain.Entities;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using service.Interfaces;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class CategoriasController(
        ILogger<CategoriasController> logger
            , ICategoriaService categoriaService) : Controller
    {
        private readonly ILogger<CategoriasController> _logger = logger;
        private readonly ICategoriaService _categoriaService = categoriaService;

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaCategorias = _categoriaService.Listar();
            List<CategoriaModel> listaCategoriaModel = new List<CategoriaModel>();
            foreach (var item in listaCategorias)
            {
                var itemCategoria = new CategoriaModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };

                listaCategoriaModel.Add(itemCategoria);

            }

            ViewBag.ListaCategoria = listaCategoriaModel;
            return View();
        }

        [HttpGet]
        [Route("CadastrarAtualizar/{Id?}")]
        public IActionResult CadastrarAtualizar(int? Id)
        {
            if (Id != null)
            {
                var categoria = _categoriaService.RegistroPorId((int)Id);
                var categoriaModel = new CategoriaModel
                {
                    Id = categoria.Id,
                    Descricao = categoria.Descricao,
                    Tipo = categoria.Tipo
                };
                return View(categoriaModel);
            }
            else
            {
                return View();

            }

        }

        [HttpPost]
        [Route("CadastrarAtualizar/{Id?}")]
        public IActionResult CadastrarAtualizar(CategoriaModel model, int? Id)
        {
            var categoria = new Categoria
            {
                Id = Id ?? model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo
            };
            _categoriaService.CadastrarAlterar(categoria);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{Id}")]
        public IActionResult Excluir(int Id)
        {
            _categoriaService.Excluir(Id);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}