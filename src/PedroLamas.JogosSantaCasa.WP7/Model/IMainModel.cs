using System.Collections.Generic;

namespace PedroLamas.JogosSantaCasa.Model
{
    public interface IMainModel
    {
        IList<SantaCasaGamesResponse> Results { get; set; }

        string ETag { get; set; }

        int SelectedResultIndex { get; set; }
    }
}