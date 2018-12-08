using LojinhaPri.FIAP.Core.Models;
using LojinhaPri.FIAP.Infrastructure.Redis;
using LojinhaPri.FIAP.Infrastructure.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojinhaPri.FIAP.Core.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IRedisCache _cache;
        private readonly IAzureStorage _storage;

        public ProdutoServices(IRedisCache cache, IAzureStorage storage)
        {
            _cache = cache;
            _storage = storage;
        }

        public async Task<Produto> GetProduto(int id)
        {
            return await _storage.GetProduto(id);
        }

        public async Task<List<Produto>> GetProdutos()
        {
            var key = "produtos";
            var value = _cache.Get(key);

            if (!string.IsNullOrEmpty(value))
            {
                var produtos = await _storage.GetProdutos();
                _cache.Set(key, JsonConvert.SerializeObject(produtos));
            }

            return JsonConvert.DeserializeObject<List<Produto>>(value);
        }             
    }
}
