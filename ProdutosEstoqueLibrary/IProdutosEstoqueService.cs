using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProdutosEstoque {

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01")]
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

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02")]
    public interface IProdutosEstoqueServiceV2 {

        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        int ConsultarEstoque(string numeroProduto);

        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        bool AdicionarEstoque(string numeroProduto, int quantidade);

        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        bool RemoverEstoque(string numeroProduto, int quantidade);
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
