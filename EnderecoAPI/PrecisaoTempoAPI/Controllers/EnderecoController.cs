using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrevisaoTempoAPI.Models;
using PrevisaoTempoAPI.Repository;

namespace PrevisaoTempoAPI.Controllers
{
    //Paulo Roberto da Silva Filho Matricula: 1829176
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public IActionResult Index()
        {
            return Listar();
        }

        public IActionResult Listar()
        {
            List<Endereco> enderecos = _enderecoRepository.ListarEnderecos();

            EnderecoViewModel enderecoViewModel = new EnderecoViewModel
            {
                Enderecos = enderecos
            };

            return View(enderecoViewModel);
        }

        [HttpPost]
        public IActionResult PesquisarEndereco(string txtCEP)
        {
            string url = string.Format("https://viacep.com.br/ws/{0}/json/", txtCEP);
            WebClient cliente = new WebClient();
            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(cliente.DownloadString(url));
            _enderecoRepository.Cadastrar(endereco);
            return RedirectToAction("Index");
        }
    }
}