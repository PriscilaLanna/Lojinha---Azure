using LojinhaPri.FIAP.Core.Models;
using LojinhaPri.FIAP.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojinhaPri.FIAP.Controllers
{
    [Authorize]
    public class CarrinhoController : Controller
    {
        private readonly IProdutoServices _produtoServices;
        private readonly ICarrinhoServices _carrinhoServices;

        public CarrinhoController(IProdutoServices produtoServices, ICarrinhoServices carrinhoServices)
        {
            _produtoServices = produtoServices;
            _carrinhoServices = carrinhoServices;
        }

        public async Task<ActionResult> Add(int id)
        {
            var usuario = HttpContext.User.Identity.Name;

            Carrinho carrinho = _carrinhoServices.Get(usuario);

            var produto = await _produtoServices.GetProduto(id);

            carrinho.Add(produto);

            _carrinhoServices.Save(usuario, carrinho);

            return PartialView("Index", carrinho);
        }

        public ActionResult Finalizar()
        {
            var usuario = HttpContext.User.Identity.Name;
            var carrinho = _carrinhoServices.Get(usuario);

           _carrinhoServices.Clear(usuario);

            return View(carrinho);
        }
            
    }
}
