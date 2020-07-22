using PrevisaoTempoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisaoTempoAPI.Repository
{
    public interface IEnderecoRepository
    {
        void Cadastrar(Endereco endereco);

        List<Endereco> ListarEnderecos();

        Endereco ListarEndereco(string cep);

        void AlterarEndereco(Endereco endereco);

        void DeletarEndereco(int id);
    }
}