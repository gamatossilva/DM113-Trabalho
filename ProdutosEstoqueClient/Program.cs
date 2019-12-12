using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ProdutosEstoqueClient.ProdutosEstoqueService;

namespace ProdutosEstoqueClient {
    class Program {
        static void Main(string[] args) {
            ProdutosEstoqueServiceClient produtosEstoqueClient = new ProdutosEstoqueServiceClient();
            Console.WriteLine("Teste 1: Listar todos os produtos");

            List<string> produtosEstoque = produtosEstoqueClient.ListarProdutos().ToList();
            foreach(string s in produtosEstoque) {
                Console.WriteLine("Produto: " + s);
            }
            Console.ReadLine();
        }
    }
}
