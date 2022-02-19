using gfQL_specFlow.Pages;
using gfQL_specFlow.Types;

namespace gfQL_specFlow.Steps
{
    [Binding]
    internal class GrQL
    {
        [When(@"Query_alle")]
        public async void WhenQuery_Alle()
        {
            ClientPage client = new ClientPage();
            List<Quote> daten = (List<Quote>)await client.GetAllQuotes();
           
            int len = daten.Count;
            for(int i = 0; i < len; i++)
            {
                var einer = daten[i].Author;
            }          

        }


        [When(@"mutationAdd_User")]
        public async Task WhenMutationAddAsync()
        {
            ClientPage client = new ClientPage();

            QuoteInput neu = new QuoteInput();
            neu.Author = "neu User_" + Guid.NewGuid().ToString().Substring(0,10); 
            neu.Text = "neu text für User";
            neu.CategoryId = 1;
            var xx = await client.AddUser(neu);
        }


    }
}
