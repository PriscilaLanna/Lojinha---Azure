using LojinhaPri.FIAP.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojinhaPri.FIAP.Infrastructure.Storage
{
    public interface IAzureStorage
    {
        void AddProduto(Produto produto);
        Task<List<Produto>> GetProdutos();
    }
}