using LojinhaPri.FIAP.Core.Models;

namespace LojinhaPri.FIAP.Infrastructure.Storage
{
    public interface IAzureStorage
    {
        void AddProduto(Produto produto);
    }
}