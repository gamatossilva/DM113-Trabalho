using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ProdutosEstoque;

namespace ProdutosEstoqueServiceHost {
    class Program {
        static void Main(string[] args) {

            ServiceHost produtosEstoqueServiceHost = new ServiceHost(typeof(ProdutosEstoqueService));
            produtosEstoqueServiceHost.Open();
            Console.WriteLine("Serviço iniciado");

            Console.ReadLine();
            Console.WriteLine("Serviço parado");
            produtosEstoqueServiceHost.Close();
        }
    }
}
