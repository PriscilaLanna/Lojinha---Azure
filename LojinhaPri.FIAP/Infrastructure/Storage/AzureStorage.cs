using LojinhaPri.FIAP.Core.Entities;
using LojinhaPri.FIAP.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojinhaPri.FIAP.Infrastructure.Storage
{
    public class AzureStorage : IAzureStorage
    {
        private readonly CloudStorageAccount _account;
        private readonly CloudTableClient _tableClient;

        public AzureStorage(IConfiguration config)
        {
            _account = CloudStorageAccount.Parse(config.GetSection("Azure:Storage").Value);
            _tableClient = _account.CreateCloudTableClient();
        }

        public void AddProduto(Produto produto)
        {
            var json = JsonConvert.SerializeObject(produto);

            var table = _tableClient.GetTableReference("produtos");
            table.CreateIfNotExistsAsync().Wait();

            var entity = new ProdutoEntity("13net", produto.Id.ToString());//"RM330845"
            entity.Produto = json;

            TableOperation operation = TableOperation.Insert(entity);
            table.ExecuteAsync(operation).Wait();
        }

        public async Task<List<Produto>> GetProdutos()
        {
            var table = _tableClient.GetTableReference("produtos");
            table.CreateIfNotExistsAsync().Wait();

            var query = new TableQuery<ProdutoEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "13net"));

            TableContinuationToken token = null;

            var segment = await table.ExecuteQuerySegmentedAsync(query, token);
            var produtoEntity = segment.ToList();

            return produtoEntity.Select(x =>
              JsonConvert.DeserializeObject<Produto>(x.Produto == null ? "" : x.Produto)
          ).ToList();
        }
    }
}
