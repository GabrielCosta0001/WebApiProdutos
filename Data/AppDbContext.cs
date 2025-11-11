using Microsoft.EntityFrameworkCore;
using WebApiProdutos.Models;

namespace WebApiProdutos.Data
{
    public class AppDbContext: DbContext  // atrevs dele que vamor enviar infomacao ou coletar infomacoes do banco de dados
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // esse constrtutor vai receber um dbcontexopstions, e ele vai ser do tipo appdbcontex
        {
            
        }

        public DbSet<ProdutoModel> Produtos{ get; set; }

    }
}
