using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ProdutosEstoqueClient.ProdutosEstoqueService;


namespace ProdutosEstoqueClientV2 {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Pressione ENTER quando o serviço estiver executando");
            Console.ReadLine();
            
            ProdutosEstoqueServiceV2Client produtosEstoqueClientV2 = new ProdutosEstoqueServiceV2Client("WS2007HttpBinding_IProdutosEstoqueService");
            
            Console.WriteLine("Teste 1: Consultar estoque atual do Produto 1");
            int estoqueAtualProduto1 = produtosEstoqueClientV2.ConsultarEstoque("1000");
            Console.WriteLine("Quantidade atual no estoque do Produto 1: " + estoqueAtualProduto1);
            Console.WriteLine();
            
            Console.WriteLine("Teste 2: Adicionar 10 unidades para o Produto 1");
            produtosEstoqueClientV2.AdicionarEstoque("1000", 10);
            Console.WriteLine();
            
            Console.WriteLine("Teste 3: Quantidade atualizada no estoque do Produto 1");
            int estoqueAtualizadoProduto1 = produtosEstoqueClientV2.ConsultarEstoque("1000");
            Console.WriteLine("Quantidade atualizada no estoque do Produto 1: " + estoqueAtualizadoProduto1);
            Console.WriteLine();
            
            Console.WriteLine("Teste 4: Consultar estoque atual do Produto 5");
            int estoqueAtualProduto5 = produtosEstoqueClientV2.ConsultarEstoque("5000");
            Console.WriteLine("Quantidade atual no estoque do Produto 5: " + estoqueAtualProduto5);
            Console.WriteLine();
            
            Console.WriteLine("Teste 5: Removendo 10 unidades do produto 5");
            produtosEstoqueClientV2.RemoverEstoque("5000", 10);
            Console.WriteLine();
            
            Console.WriteLine("Teste 6: Quantidade atualizada no estoque do Produto 5");
            int estoqueAtualizadoProduto5 = produtosEstoqueClientV2.ConsultarEstoque("5000");
            Console.WriteLine("Quantidade atualizada no estoque do Produto 5: " + estoqueAtualizadoProduto5);
            Console.WriteLine();
            
            produtosEstoqueClientV2.Close();

            Console.WriteLine("Pressione ENTER para sair");
            Console.ReadLine();
        }
    }
}
