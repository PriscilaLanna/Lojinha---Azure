using System.Collections.Generic;
using System.Threading.Tasks;
using LojinhaPri.FIAP.Core.Models;

namespace LojinhaPri.FIAP.Core.Services
{
    public interface IProdutoServices
    {
        Task<List<Produto>> GetProdutos();
        Task<Produto> GetProduto(int id);
    }
}