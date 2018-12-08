using LojinhaPri.FIAP.Core.Models;
using LojinhaPri.FIAP.Infrastructure.Redis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojinhaPri.FIAP.Core.Services
{
    public class CarrinhoServices : ICarrinhoServices
    {
        private readonly IRedisCache _cache;
        private readonly string _key = "RM330845";

        public CarrinhoServices(IRedisCache cache)
        {
            _cache = cache;
        }

        public void Clear(string usuario)
        {
            _cache.Set($"{_key}:carrinho:{usuario}", null);
        }

        public void Save(string usuario, Carrinho carrinho)
        {
            _cache.Set($"{_key}:carrinho:{usuario}", JsonConvert.SerializeObject(carrinho));
        }

        public Carrinho Get(string usuario)
        {
            var value = _cache.Get($"{_key}:carrinho:{usuario}");
            if (string.IsNullOrWhiteSpace(value))
            {
                var carrinho = new Carrinho();

                Save(usuario, carrinho);

                return carrinho;
            }
            return JsonConvert.DeserializeObject<Carrinho>(value);
        }
    }
}
