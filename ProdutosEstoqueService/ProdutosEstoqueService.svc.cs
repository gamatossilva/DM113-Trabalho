using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EstoqueEntityModel;
using System.ServiceModel.Activation;

namespace ProdutosEstoque {
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProdutosEstoqueService : IProdutosEstoqueService {
        public bool AdicionarEstoque(string numeroProduto, int quantidade) {

            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    int idProduto = (from p in database.ProdutoEstoque
                                     where String.Compare(p.NumeroProduto, numeroProduto) == 0
                                     select p.Id).First();

                    ProdutoEstoque produtoEstoque = database.ProdutoEstoque.First(pi => pi.Id == idProduto);
                    produtoEstoque.EstoqueProduto += quantidade;
                    database.SaveChanges();
                }
            }
            catch {
                return false;
            }
            return true;
        }

        public int ConsultarEstoque(string numeroProduto) {

            int quantidadeTotal = 0;

            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoque.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    quantidadeTotal = produtoEstoque.EstoqueProduto;
                }
            }
            catch {
            }
            return quantidadeTotal;
        }

        public bool IncluirProduto(ProdutoEstoqueData produtoEstoqueData) {

            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                    produtoEstoque.NumeroProduto = produtoEstoqueData.NumeroProduto;
                    produtoEstoque.NomeProduto = produtoEstoqueData.NomeProduto;
                    produtoEstoque.DescricaoProduto = produtoEstoqueData.DescricaoProduto;
                    produtoEstoque.EstoqueProduto = produtoEstoqueData.EstoqueProduto;

                    database.ProdutoEstoque.Add(produtoEstoque);
                   
                    database.SaveChanges();
                }
            }
            catch {
                return false;
            }
            return true;

        }

        public List<string> ListarProdutos() {

            List<string> listaProdutoEstoque = new List<string>();

            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    List<ProdutoEstoque> produtos = (from produto in database.ProdutoEstoque
                                                     select produto).ToList();

                    foreach (ProdutoEstoque produtoEstoque in produtos) {
                        ProdutoEstoqueData produtoEstoqueData = new ProdutoEstoqueData() {
                            NomeProduto = produtoEstoque.NomeProduto
                        };
                        listaProdutoEstoque.Add(produtoEstoque.NomeProduto);
                    }
                }
            }
            catch {
            }
            return listaProdutoEstoque;
        }

        public bool RemoverEstoque(string numeroProduto, int quantidade) {

            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    int idProduto = (from p in database.ProdutoEstoque
                                     where String.Compare(p.NumeroProduto, numeroProduto) == 0
                                     select p.Id).First();

                    ProdutoEstoque produtoEstoque = database.ProdutoEstoque.First(pi => pi.Id == idProduto);
                    produtoEstoque.EstoqueProduto -= quantidade;
                    database.SaveChanges();
                }
            }
            catch {
                return false;
            }
            return true;
        }

        public bool RemoverProduto(string removeProduto) {

            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    int idProduto = (from p in database.ProdutoEstoque
                                     where String.Compare(p.NumeroProduto, removeProduto) == 0
                                     select p.Id).First();

                    ProdutoEstoque produtoEstoque = database.ProdutoEstoque.First(pi => pi.Id == idProduto);
                    database.ProdutoEstoque.Remove(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch {
                return false;
            }
            return true;

        }

        public ProdutoEstoqueData VerProduto(string numeroProduto) {

            ProdutoEstoqueData produtoEstoqueData = null;

            try {
                using (ProvedorEstoque database = new ProvedorEstoque()) {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoque.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    produtoEstoqueData = new ProdutoEstoqueData() {
                        NumeroProduto = produtoEstoque.NumeroProduto,
                        NomeProduto = produtoEstoque.NomeProduto,
                        DescricaoProduto = produtoEstoque.DescricaoProduto,
                        EstoqueProduto = produtoEstoque.EstoqueProduto
                    };
                };
            }
            catch {
            }
            return produtoEstoqueData;
        }
    }
}
