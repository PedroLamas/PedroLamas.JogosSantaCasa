using PedroLamas.ServiceModel;
using RestSharp;

namespace PedroLamas.JogosSantaCasa.Model
{
    public class JogosSantaCasaService : IJogosSantaCasaService
    {
        private readonly RestClient _client;

        public JogosSantaCasaService()
        {
            _client = new RestClient("http://api.pedrolamas.com/");

            _client.AddDefaultHeader("Accept", "text/json");
            _client.AddDefaultHeader("Accept-Encoding", "gzip");
        }

        public void GetResults(ResultCallback<SantaCasaGamesResponse[]> callback, object state)
        {
            GetResults(callback, null, state);
        }

        public void GetResults(ResultCallback<SantaCasaGamesResponse[]> callback, string etag, object state)
        {
            //var t = @"[{""d"":""Euromilhões"",""g"":""Euromilhões"",""c"":""Sorteio nº 015/2012"",""t"":1,""k"":""#003368"",""r"":{""nums"":[11,14,24,25,29],""stars"":[7,11]}},{""d"":""Totoloto"",""g"":""Totoloto"",""c"":""Sorteio nº 014/2012"",""t"":5,""k"":""#006EC6"",""r"":{""nums"":[4,12,14,16,25,9],""extra"":9}},{""d"":""Joker"",""g"":""Joker"",""c"":""Sorteio nº 08/2012"",""t"":2,""k"":""#EC6E00"",""r"":{""num"":1234206}},{""d"":""Totobola"",""g"":""Totobola"",""c"":""Concurso nº 08/2012"",""t"":4,""k"":""#006647"",""r"":{""games"":""2111XXXX12112"",""extra"":""0M""}},{""d"":""Totobola Extra"",""g"":""Totobola Ext."",""c"":""Concurso nº 07/2012"",""t"":4,""k"":""#006647"",""r"":{""games"":""112111222X222"",""extra"":""MM""}},{""d"":""Lotaria Clássica"",""g"":""Lot. Clássica"",""c"":""Extracção nº 08/2012"",""t"":3,""k"":""#9B1F2E"",""r"":{""entries"":[{""d"":""1º Prémio"",""n"":36093},{""d"":""2º Prémio"",""n"":58091},{""d"":""3º Prémio"",""n"":13694}]}},{""d"":""Lotaria Popular"",""g"":""Lot. Popular"",""c"":""Extracção nº 07/2012"",""t"":3,""k"":""#980070"",""r"":{""entries"":[{""d"":""1º Prémio"",""n"":24058},{""d"":""2º Prémio"",""n"":11470},{""d"":""3º Prémio"",""n"":62075},{""d"":""4º Prémio"",""n"":59814}]}}]";

            //DispatcherHelper.UIDispatcher.BeginInvokeAfterTimeout(2000, () =>
            //{
            //    //callback(new JogosSantaCasaServiceResult(new Exception(), state));
            //    callback(new JogosSantaCasaServiceResult(JsonConvert.DeserializeObject<SantaCasaGamesResponse[]>(t), state));
            //});

            //return;

            var request = new RestRequest("jogosSantaCasa/v1/getResults", Method.GET);

            if (!string.IsNullOrEmpty(etag))
                request.AddHeader("If-None-Match", etag);

            _client.GetResultAsync(request, callback, state);
        }
    }
}