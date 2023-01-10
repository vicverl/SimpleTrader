using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.Services;

public class MajorIndexService : IMajorIndexService
{
    public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
    {
        using (HttpClient client = new HttpClient())
        {
            var uri = "https://financialmodelingprep.com/api/v3/quote/" + GetUriSuffix(indexType) + "?apikey=61ff40256ad16eaede4527a7c8d32d50";
            var response = await client.GetAsync(uri);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse.Substring(1, jsonResponse.Length - 2));
            majorIndex.Type = indexType;
            return majorIndex;
        }
    }

    private string GetUriSuffix(MajorIndexType indexType)
    {
        return indexType switch
        {
            MajorIndexType.DowJones => "AAPL",
            MajorIndexType.Nasdaq => "GOOG",
            MajorIndexType.SP500 => "META",
            _ => "AAPL"
        };
    }
}