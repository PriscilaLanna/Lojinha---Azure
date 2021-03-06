﻿using AutoMapper;
using LojinhaPri.FIAP.Core.Models;
using LojinhaPri.FIAP.Core.Services;
using LojinhaPri.FIAP.Core.ViewModels;
using LojinhaPri.FIAP.Infrastructure.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojinhaPri.FIAP.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoServices _produtoServices;
        private readonly IMapper _mapper;
        //private readonly IAzureStorage _azureStorage;
      
        public ProdutosController(IProdutoServices produtoServices, IMapper mapper)
        {
            _produtoServices = produtoServices;
            _mapper = mapper;
            //_azureStorage = azureStorage;
        }

        public IActionResult Create()
        {
            var produto = new Produto
            {
                Id = 330845,
                Nome = "PERFUME 212 VIP ROSÉ",
                Descricao = "Perfume 212 Vip Rose De Carolina Herrera Eau De Parfum Feminino",
                Categoria = new Categoria { Id = 1, Nome = "Perfumes" },
                Fabricante = new Fabricante { Id = 1, Nome = "Carolina Herrera" },
                Preco = 389.90m,
                Tags = new[] { "VIP 212", "212", "Perfume" },
                ImagemPrincipalUrl = "https://60175z.ha.azioncdn.net/media/catalog/product/cache/0a2bc38b67edd8e5c70546a21088f7a5/1/0/103724603_4.jpg"
            };

            //_azureStorage.AddProduto(produto);
           //_produtoServices.AddProduto(produto);

            return Content("Ok");
        }
        
        public async Task<IActionResult> List()
        {
            // return Json(await _azureStorage.GetProdutos());

            var produtos = await _produtoServices.GetProdutos();
            var vm = _mapper.Map<List<ProdutoViewModel>>(produtos);
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoServices.GetProduto(id);
            // var vm = _mapper.Map<ProdutoViewModel>(produto);
            //  return View(vm);

            return Json(produto);
        }
    }
}
