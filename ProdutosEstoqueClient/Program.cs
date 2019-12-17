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

            Console.WriteLine("Teste 1: Adicionar Produto 11");
            ProdutoEstoqueData produtoEstoqueData = new ProdutoEstoqueData();
            produtoEstoqueData.NomeProduto = "Produto 11";
            produtoEstoqueData.NumeroProduto = "11000";
            produtoEstoqueData.DescricaoProduto = "Este é o produto 11";
            produtoEstoqueData.EstoqueProduto = 11000;
            if (produtosEstoqueClient.IncluirProduto(produtoEstoqueData)) {
                Console.WriteLine("Produto Incluído");
            } else {
                Console.WriteLine("Falha ao incluir produto");
            }
            Console.WriteLine();

            
            Console.WriteLine("Teste 2: Remover o produto 10");
            if (produtosEstoqueClient.RemoverProduto("10000")) {
                Console.WriteLine("Produto removido");
            } else {
                Console.WriteLine("Produto não encontrado");
            }
            Console.WriteLine();

            Console.WriteLine("Teste 3: Listar todos os produtos");
            List<string> produtosEstoque = produtosEstoqueClient.ListarProdutos().ToList();
            foreach(string s in produtosEstoque) {
                Console.WriteLine("Produto: " + s);
            }
            Console.WriteLine();
            

            Console.WriteLine("Teste 4: Todas as informações do Produto 2");
            ProdutoEstoqueData produto2 = produtosEstoqueClient.VerProduto("2000");
            Console.WriteLine("Numero do Produto: {0}", produto2.NumeroProduto);
            Console.WriteLine("Nome do Produto: {0}", produto2.NomeProduto);
            Console.WriteLine("Descrição do Produto: {0}", produto2.DescricaoProduto);
            Console.WriteLine("Estoque do Produto {0}", produto2.EstoqueProduto);
            Console.WriteLine();

            Console.WriteLine("Teste 5: Adicionar 10 unidades para o Produto 2");
            produtosEstoqueClient.AdicionarEstoque("2000", 10);
            Console.WriteLine();

            Console.WriteLine("Teste 6: Consultar estoque do Produto 2");
            int quantidadeEstoque = produtosEstoqueClient.ConsultarEstoque("2000");
            Console.WriteLine("Quantidade no estoque do Produto 2: " + quantidadeEstoque);
            Console.WriteLine();

            Console.WriteLine("Teste 7: Consultar estoque atual do Produto 1");
            int estoqueAtualProduto1 = produtosEstoqueClient.ConsultarEstoque("1000");
            Console.WriteLine("Quantidade atual no estoque do Produto 1: " + estoqueAtualProduto1);
            Console.WriteLine();

            Console.WriteLine("Teste 8: Removendo 20 unidades do produto 1");
            produtosEstoqueClient.RemoverEstoque("1000", 20);
            Console.WriteLine();

            Console.WriteLine("Teste 9: Quantidade atualizada no estoque do Produto 1");
            int estoqueAtualizadoProduto1 = produtosEstoqueClient.ConsultarEstoque("1000");
            Console.WriteLine("Quantidade atualizada no estoque do Produto 1: " + estoqueAtualizadoProduto1);
            Console.WriteLine();
            

            Console.WriteLine("Teste 10: Todas as informações do Produto 1");
            ProdutoEstoqueData produto1 = produtosEstoqueClient.VerProduto("1000");
            Console.WriteLine("Numero do Produto: {0}", produto1.NumeroProduto);
            Console.WriteLine("Nome do Produto: {0}", produto1.NomeProduto);
            Console.WriteLine("Descrição do Produto: {0}", produto1.DescricaoProduto);
            Console.WriteLine("Estoque do Produto {0}", produto1.EstoqueProduto);
            Console.WriteLine();
            

            produtosEstoqueClient.Close();

            Console.WriteLine("Pressione ENTER para sair");
            Console.ReadLine();
        }
    }
}
