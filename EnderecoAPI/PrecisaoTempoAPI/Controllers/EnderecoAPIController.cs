using Microsoft.AspNetCore.Mvc;
using PrevisaoTempoAPI.Models;
using PrevisaoTempoAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisaoTempoAPI.Controllers
{
    //Paulo Roberto da Silva Filho Matricula: 1829176
    [Route("api/endereco")]
    public class EnderecoAPIController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoAPIController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult ListarEnderecos()
        {
            return Ok(_enderecoRepository.ListarEnderecos());
        }

        [HttpGet]
        [Route("ListarEnderecos/{cep}")]
        public IActionResult ListarEnderecos([FromRoute] string cep)
        {
            return Ok(_enderecoRepository.ListarEndereco(cep));
        }

        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult CadastrarEndereco([FromBody] Endereco endereco)
        {
            _enderecoRepository.Cadastrar(endereco);

            return Ok("Cadastrado com sucesso!");
        }

        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult AlterarEndereco([FromBody] Endereco endereco)
        {
            _enderecoRepository.AlterarEndereco(endereco);

            return Ok("Endereço alterado com sucesso!");
        }

        [HttpDelete]
        [Route("DeletarEndereco/{id}")]
        public IActionResult DeletarEndereco([FromRoute] int id)
        {
            _enderecoRepository.DeletarEndereco(id);

            return Ok("Endereço deletado com sucesso!");
        }
    }
}
