using gfQL_specFlow.Types;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace gfQL_specFlow.Pages
{
    public class ClientPage
    {
        private readonly GraphQLHttpClient _graphQlClient = new GraphQLHttpClient("https://localhost:44303/graphql", new NewtonsoftJsonSerializer());
                     
        public async Task<ICollection<Quote>> GetAllQuotes()
        {
            var request = new GraphQLRequest  
            {
                Query = @"query{quotes {
                               id
                               author
                           }}",

            };

            var response = await _graphQlClient.SendQueryAsync<QuoteCollectionResponse>(request);
            var daten = response.Data.Quotes;
            return daten;
        }

        public async Task<Quote> AddUser(QuoteInput quote)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation($quote: quoteInput!){
                             createQuote(quote: $quote){
                                id
                                author
                                text
                                category{
                                    name
                                  }
                              }
                           }",
                Variables = new { quote }
            };

            var response = await _graphQlClient.SendMutationAsync<QuoteResponse>(request);
            return response.Data.Quote;
        }

    }

}
