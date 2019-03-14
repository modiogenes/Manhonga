using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manhonga.Core.Models
{
    public class Produto
    {
        public string ProdutoId { get; set; }

        [StringLength(20)]
        [DisplayName("Nome do Produto")]
        public string ProdutoNome { get; set; }

        [DisplayName("Descrição")]
        public string ProdutoDescricao { get; set; }

        [Range(0,1000)]
        [DisplayName("Preço")]
        public decimal ProdutoPreco { get; set; }

        [DisplayName("Categoria")]
        public string ProdutoCategoria { get; set; }

        [DisplayName("Imagem")]
        public string ProdutoImagem { get; set; }

        public Produto()
        {
            this.ProdutoId = Guid.NewGuid().ToString();
        }

    }
}