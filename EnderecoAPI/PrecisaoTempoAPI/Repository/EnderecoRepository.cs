using PrevisaoTempoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisaoTempoAPI.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly EnderecoContext _context;

        public EnderecoRepository(EnderecoContext context)
        {
            _context = context;
        }

        public void AlterarEndereco(Endereco endereco)
        {
            var enderecoObject = _context.Enderecos.FirstOrDefault(x => x.Id == endereco.Id);

            if (enderecoObject != null)
            {
                enderecoObject.CEP = endereco.CEP;
                enderecoObject.Logradouro = endereco.Logradouro;
                enderecoObject.Complemento = endereco.Complemento;
                enderecoObject.Bairro = endereco.Bairro;
                enderecoObject.Localidade = endereco.Localidade;
                enderecoObject.UF = endereco.UF;
                enderecoObject.Unidade = endereco.Unidade;
                enderecoObject.IBGE = endereco.IBGE;
                enderecoObject.GIA = endereco.GIA;

                _context.SaveChanges();
            }
        }

        public void Cadastrar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }

        public void DeletarEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
                _context.SaveChanges();
            }
        }

        public Endereco ListarEndereco(string cep)
        {
            return _context.Enderecos.FirstOrDefault(x => x.CEP.Replace("-", "") == cep);
        }

        public List<Endereco> ListarEnderecos()
        {
            return _context.Enderecos.ToList();
        }
    }
}
