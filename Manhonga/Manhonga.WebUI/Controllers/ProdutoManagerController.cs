using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manhonga.Core.Models;
using Manhonga.DataAccess.InMemory;

namespace Manhonga.WebUI.Controllers
{
    public class ProdutoManagerController : Controller
    {
        ProdutoRepository context;

        public ProdutoManagerController()
        {
            context = new ProdutoRepository();
        }
        // GET: ProdutoManager
        public ActionResult Index()
        {
            List<Produto> produtos = context.Collection().ToList();
            return View(produtos);
        }

        public ActionResult Novo()
        {
            Produto produto=new Produto();
            return View(produto);
        }

        [HttpPost]
        public ActionResult Novo(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }
            else
            {
                context.Insert(produto);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Editar(string ProdutoId)
        {
            Produto produto = context.Find(ProdutoId);
            if (produto == null)
            {
                return HttpNotFound();
            }
            else {
                return View(produto);
            }
        }

        [HttpPost]
        public ActionResult Editar(Produto produto, string ProdutoId)
        {
            Produto produtoEditar = context.Find(ProdutoId);

            if (produtoEditar == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(produto);
                }

                produtoEditar.ProdutoCategoria = produto.ProdutoCategoria;
                produtoEditar.ProdutoDescricao = produto.ProdutoDescricao;
                produtoEditar.ProdutoImagem = produto.ProdutoImagem;
                produtoEditar.ProdutoNome = produto.ProdutoNome;
                produtoEditar.ProdutoPreco = produto.ProdutoPreco;

                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Apagar(string ProdutoId)
        {
            Produto produtoToApagar = context.Find(ProdutoId);

            if (produtoToApagar == null)
            {
                return HttpNotFound();
            }
            else 
            {
                return View(produtoToApagar);
            }
        }

        [HttpPost]
        [ActionName("Apagar")]
        public ActionResult ConfirmaApagar(string ProdutoId)
        {
            Produto produtoToDelete = context.Find(ProdutoId);

            if (produtoToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(ProdutoId);
                context.Commit(); 
                return RedirectToAction("Index");
            }
        }
    }
}