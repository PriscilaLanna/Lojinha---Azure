using Microsoft.WindowsAzure.Storage.Table;

namespace LojinhaPri.FIAP.Core.Entities
{
    public class ProdutoEntity : TableEntity
    {
        public ProdutoEntity(string partitionKey, string rowKey)
            :base(partitionKey, rowKey)
        {

        }

        public ProdutoEntity()
        {

        }

        public string Produto { get; set; }
    }
}
