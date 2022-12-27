// See https://aka.ms/new-console-template for more information
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;



var cosmosDbClient = new CosmosClient(connectionString: @"update  conenction string here");

var container = cosmosDbClient.GetDatabase("SampleDB").GetContainer("SampleContainer");


var samepleDataQuery = container.GetItemLinqQueryable<SampleData>();

using FeedIterator<SampleData> feed = samepleDataQuery.Select(x => x).ToFeedIterator();

while (feed.HasMoreResults)
{
    var response = feed.ReadNextAsync();
    var result = response.Result.ToList();
    foreach (SampleData sampleData in result)
    {
        Console.WriteLine(sampleData.address);
        Console.WriteLine(sampleData.id);
        Console.WriteLine(sampleData._rid);
        Console.WriteLine(sampleData._self);
        Console.WriteLine(sampleData._etag);
        Console.WriteLine(sampleData._attachments);
        Console.WriteLine(sampleData._ts);
        Console.WriteLine(Environment.NewLine);
    }


}

Console.ReadLine();


public class SampleData
{
    public string address { get; set; }
    public string id { get; set; }
    public string _rid { get; set; }
    public string _self { get; set; }
    public string _etag { get; set; }
    public string _attachments { get; set; }
    public int _ts { get; set; }
}

