using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProdutosEstoque {

    [ServiceContract]
    public interface IProdutosEstoqueService {

        [OperationContract]
        List<String> ListarProdutos();

        [OperationContract]
        bool IncluirProduto(ProdutoEstoqueData produtoEstoqueData);

        [OperationContract]
        bool RemoverProduto(string removeProduto);

        [OperationContract]
        int ConsultarEstoque(string numeroProduto);

        [OperationContract]
        bool AdicionarEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        bool RemoverEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        ProdutoEstoqueData VerProduto(string numeroProduto);

    }

    [DataContract]
    public class ProdutoEstoqueData {

        [DataMember]
        public string NumeroProduto;

        [DataMember]
        public string NomeProduto;

        [DataMember]
        public string DescricaoProduto;

        [DataMember]
        public int EstoqueProduto;

    }

}
