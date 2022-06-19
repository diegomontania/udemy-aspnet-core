using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LojaWeb.Controllers.Base;
using LojaWeb.Models;
using AutoMapper;
using LojaWeb.Models.ModeloDados;

namespace LojaWeb.Controllers
{
    public class ClienteController : BaseController
    {
        private List<ClienteViewModel> _listaClienteViewModel;

        //criando propriedade para fazer mapeamento com o Automapper
        private readonly IMapper _mapper;

        public ClienteController(IMapper mapper)
        {
            //injetando o mapper neste controller, para ser utilizado posteriormente
            _mapper = mapper;

            //adiciona dois clientes
            _listaClienteViewModel = new List<ClienteViewModel>
            {
                new ClienteViewModel { Nome = "Diego", Endereco = "Rua Alice", Telefone = "123" },
                new ClienteViewModel { Nome = "Marcela", Endereco = "Rua Jardim", Telefone = "133" }
            };
        }

        public IActionResult Index()
        {
            //passa essa lista para a View Index, já que este metodo possui uma View de mesmo nome,
            //nao é necessario passar o nome da view aqui.
            return View(_listaClienteViewModel);
        }

        //Utilizando Mapeamento do Automapper
        public IActionResult Create()
        {
            //instancia clienteModel, aqui o objeto está "vindo do banco de dados"
            var clienteModel = new ClienteModel
            {
                Id = 1,
                Nome = "A",
                Cpf = "1",
                Telefone = "2",
                NumeroCartaoCredito = "3",
                Endereco = "4"
            };

            //Associando ViewModel Com Model
            //clienteViewModel apenas com os campos da viewModel
            var clienteViewModel = _mapper.Map<ClienteViewModel>(clienteModel);

            return View(clienteViewModel);
        }

        //recebe o dados da view, ou seja o objeto 'Cliente' que foi manipulado na view.
        //este objeto será enviado ao servidor, já é possivel capturar ele aqui
        [HttpPost]
        public IActionResult Create(ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                Mensagem("Por favor, preencha todos os campos solicitados!", TiposMensagem.MensagemAtencao);
                return View("Create");
            }

            //adiciona este cliente criado na lista de clientes já existentes
            _listaClienteViewModel.Add(cliente);

            Mensagem("Cliente adicionado com sucesso!", TiposMensagem.MensagemSucesso);

            //retorna para a view "Index" a lista de objetos 'Clientes' com o novo cliente.
            return View("Index", _listaClienteViewModel);
        }

        //utilizando QueryString
        //https://localhost:44381/Cliente/QueryStringTeste?Nome=Diego&Idade=28
        public IActionResult QueryStringTeste(string nome, string idade)
        {
            //recebendo as informacoes da queryString
            System.Console.WriteLine($"{nome} {idade}");

            ViewData["Nome"] = nome;
            ViewData["Idade"] = idade;

            return View();
        }
    }
}
