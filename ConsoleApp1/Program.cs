using ProdutosEstoqueClient.ProdutosEstoqueService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Pressione ENTER quando o serviço estiver executando");
            Console.ReadLine();

            //ProdutosEstoqueServiceClient produtosEstoqueClient = new ProdutosEstoqueServiceClient();
            //ProdutosEstoqueServiceClient produtosEstoqueClient = new ProdutosEstoqueServiceClient("NetTcpBinding_IProdutosEstoqueService");
            ProdutosEstoqueServiceClient produtosEstoqueClient = new ProdutosEstoqueServiceClient("WS2007HttpBinding_IProdutosEstoqueService");
            

            produtosEstoqueClient.ConsultarEstoque("1000");

            produtosEstoqueClient.Close();
            Console.ReadLine();
        }
    }
}
