using LojaWeb.Controllers.Base;
using LojaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace LojaWeb.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //get
        public IActionResult Index()
        {
            return View();
        }

        //get
        public IActionResult Privacy()
        {
            //utilizando viewBag para passar valor da controller para view Dinamicamente
            //essa propriedade chamada 'NomePeloViewBag' nao existe em lugar nenhum.
            //pode ser criada para receber pequenos dados a serem enviados para a View
            ViewBag.NomePeloViewBag = "Diego";

            //utilizando ViewData para passar valor da controller para view Dinamicamente
            ViewData["NomePeloViewData"] = "Montania";

            Mensagem("Bem vindo!!!", TiposMensagem.MensagemInfo);

            return View();
        }

        //criando um post
        [HttpPost]
        public IActionResult Privacy(string Id, string Nome)
        {
            if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Id))
            {
                Mensagem("Insira informações nos campos solicitados!", TiposMensagem.MensagemErro);
                return View();
            }

            //se todos os campos forem preenchidos, retorna pra index
            return View("Index");
        }

        //a rota nao precisa ter o mesmo nome da Action.
        //sempre que possivel criar com nomes iguais. 
        //Fica mais facil de visualizar qual rota é de qual Action
        //criando uma rota especifica
        [Route("/Mensagem/Saudacao/")]
        public IActionResult Saudacao()
        {
            return Content("Olá usuario! Este Rota não possui parametros!");
        }

        //criando uma rota especifica com parametros
        //se colocar um '?' apos o nome do parametro na rota, aceitará também parametros nulos.
        [Route("/Mensagem/SaudacaoComParametros/{nomeUsuario}")]
        public IActionResult SaudacaoComParametros(string nomeUsuario)
        {
            return Content($"Olá {nomeUsuario}! Este Rota possui parametros");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
