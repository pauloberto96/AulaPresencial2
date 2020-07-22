using Microsoft.EntityFrameworkCore;
using PrevisaoTempoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisaoTempoAPI.Repository
{
    public class EnderecoContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }

        public EnderecoContext(DbContextOptions<EnderecoContext> options) : base(options)
        {

        }
    }
}
