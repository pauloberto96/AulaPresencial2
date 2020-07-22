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

        public void Cadastrar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }

        public List<Endereco> ListarEnderecos()
        {
            return _context.Enderecos.ToList();
        }
    }
}
