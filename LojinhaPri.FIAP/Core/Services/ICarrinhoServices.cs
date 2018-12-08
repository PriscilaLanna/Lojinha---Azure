using LojinhaPri.FIAP.Core.Models;

namespace LojinhaPri.FIAP.Core.Services
{
    public interface ICarrinhoServices
    {
        void Clear(string usuario);
        Carrinho Get(string usuario);
        void Save(string usuario, Carrinho carrinho);
    }
}