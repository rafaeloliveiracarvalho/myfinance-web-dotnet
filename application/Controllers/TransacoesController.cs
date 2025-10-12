using domain.Entities;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using service.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class TransacoesController : Controller
    {
        private readonly ILogger<TransacoesController> _logger;
        private readonly ITransacaoService _transacaoService;
        private readonly ICategoriaService _categoriaService;

        public TransacoesController(
            ILogger<TransacoesController> logger,
            ITransacaoService transacaoService,
            ICategoriaService categoriaService)
        {
            _logger = logger;
            _transacaoService = transacaoService;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaTransacoes = _transacaoService.Listar();
            List<TransacaoModel> listaTransacaoModel = new List<TransacaoModel>();
            foreach (var item in listaTransacoes)
            {
                var itemTransacao = new TransacaoModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Valor = item.Valor,
                    Data = item.Data,
                    CategoriaId = item.CategoriaId,
                    Categoria = item.Categoria
                };

                listaTransacaoModel.Add(itemTransacao);

            }

            ViewBag.ListaTransacao = listaTransacaoModel;
            return View();
        }

        [HttpGet]
        [Route("CadastrarAtualizar/{Id?}")]
        public IActionResult CadastrarAtualizar(int? Id)
        {
            var categorias = _categoriaService.Listar()
                .OrderBy(c => c.Descricao)
                .ToList();

            ViewBag.Categorias = new SelectList(categorias, "Id", "Descricao");

            if (Id != null)
            {
                var transacao = _transacaoService.RegistroPorId((int)Id);
                var TransacaoModel = new TransacaoModel()
                {
                    Id = transacao.Id,
                    Descricao = transacao.Descricao,
                    Valor = transacao.Valor,
                    Data = transacao.Data,
                    CategoriaId = transacao.CategoriaId,
                    Categoria = transacao.Categoria
                };
                return View(TransacaoModel);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Route("CadastrarAtualizar/{Id?}")]
        public IActionResult CadastrarAtualizar(TransacaoModel model, int? Id)
        {
            var transacao = new Transacao
            {
                Id = Id ?? model.Id,
                Descricao = model.Descricao,
                Valor = model.Valor,
                Data = model.Data,
                CategoriaId = model.CategoriaId,
                Categoria = model.Categoria
            };
            _transacaoService.CadastrarAlterar(transacao);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{Id}")]
        public IActionResult Excluir(int Id)
        {
            _transacaoService.Excluir(Id);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}