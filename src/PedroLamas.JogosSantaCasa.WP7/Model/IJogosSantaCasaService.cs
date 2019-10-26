using PedroLamas.ServiceModel;

namespace PedroLamas.JogosSantaCasa.Model
{
    public interface IJogosSantaCasaService
    {
        void GetResults(ResultCallback<SantaCasaGamesResponse[]> callback, object state);

        void GetResults(ResultCallback<SantaCasaGamesResponse[]> callback, string etag, object state);
    }
}