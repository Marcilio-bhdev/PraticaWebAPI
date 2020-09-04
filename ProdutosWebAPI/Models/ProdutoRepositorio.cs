using System;
using System.Collections.Generic;
using System.Linq;

namespace ProdutosWebAPI.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();
        private int _nextId = 1;
        public ProdutoRepositorio()
        {
            Add(new Produto
            {
                Nome = "Máquina de lavar",
                Categoria = "Eletrodomesticos",
                Preco = 5.00M,
            });
            Add(new Produto
            {
                Nome = "Fogão",
                Categoria = "Eletrodomesticos",
                Preco = 3.75M,
            });
            Add(new Produto
            {
                Nome = "Sófa",
                Categoria = "Móveis",
                Preco = 1.99M,
            });
            Add(new Produto
            {
                Nome = "Guarda Roupa",
                Categoria = "Móveis",
                Preco = 2.50M,
            });
            Add(new Produto
            {
                Nome = "Celular",
                Categoria = "Eletro Eletrônicos",
                Preco = 3.75M,
            });
            Add(new Produto
            {
                Nome = "Tv Smart",
                Categoria = "Eletro Eletrônicos",
                Preco = 7.75M,
            });

        }
        public Produto Add(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item");
            }
            item.Id = _nextId++;
            produtos.Add(item);
            return item;

        }
        public Produto GetById(int id)
        {
            return produtos.Find(p => p.Id == id);
        }

        public IEnumerable<Produto> GetALL()
        {
            return produtos;
        }

        public void Remove(int id)
        {
            produtos.RemoveAll(d => d.Id == id);
        }

        public bool Update(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item");
            }
            int index = produtos.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            produtos.RemoveAt(index);
            produtos.Add(item);
            return true;


        }
    }
}
