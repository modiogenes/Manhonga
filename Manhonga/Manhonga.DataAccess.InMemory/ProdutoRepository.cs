using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Manhonga.Core.Models;

namespace Manhonga.DataAccess.InMemory
{
    public class ProdutoRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Produto> produtos;

        public ProdutoRepository()
        {
            produtos = cache["produtos"] as List<Produto>;
            if (produtos == null)
            {
                produtos = new List<Produto>();
            }
        }

        public void Commit()
        {
            cache["produtos"] = produtos;
        }

        public void Insert(Produto p)
        {
            produtos.Add(p);
        }

        public void Update(Produto produto) {
            Produto produtoToUpdate = produtos.Find(p => p.ProdutoId == produto.ProdutoId);

            if (produtoToUpdate != null)
            {
                produtoToUpdate = produto;
            }
            else
            {
                throw new Exception("Produto não encontrado");
            }
        }

        public Produto Find(string ProdutoId)
        {
            Produto produto = produtos.Find(p => p.ProdutoId == ProdutoId);

            if (produto != null)
            {
                return produto;
            }
            else
            {
                throw new Exception("Produto não encontrado");
            }
        }

        public IQueryable<Produto> Collection() {
            return produtos.AsQueryable();
        }

        public void Delete(string Id) {
            Produto produtoToDelete = produtos.Find(p => p.ProdutoId == Id);

            if (produtoToDelete != null)
            {
                produtos.Remove(produtoToDelete);
            }
            else
            {
                throw new Exception("Produto não encontrado");
            }
        }
    }
}