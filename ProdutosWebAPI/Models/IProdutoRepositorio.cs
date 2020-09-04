using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosWebAPI.Models
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> GetALL();
        Produto GetById(int id);
        Produto Add(Produto item);
        bool Update(Produto item);
        void Remove(int id);
    }
}
