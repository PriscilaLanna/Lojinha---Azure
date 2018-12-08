﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojinhaPri.FIAP.Core.Models
{
    public class Carrinho
    {
        public Carrinho()
        {
            Items = new List<CarrinhoItem>();
        }

        public List<CarrinhoItem> Items { get; set; }

        public void Add(Produto produto)
        {
            if(Items.Any(X => X.Produto.Id == produto.Id))
            {
                var item = Items.FirstOrDefault(x => x.Produto.Id == produto.Id);
                item.Quantidade++;
            }
            else
            {
                Items.Add(new CarrinhoItem {
                    Produto = produto,
                    Quantidade = 1
                });
            }
        }
    }
}
