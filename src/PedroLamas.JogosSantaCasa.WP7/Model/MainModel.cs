using System.Collections.Generic;

namespace PedroLamas.JogosSantaCasa.Model
{
    public class MainModel : IMainModel
    {
        private IList<SantaCasaGamesResponse> _results;

        #region Properties

        public IList<SantaCasaGamesResponse> Results
        {
            get
            {
                return _results;
            }
            set
            {
                _results = value;

                SelectedResultIndex = _results == null || _results.Count == 0 ? -1 : 0;
            }
        }

        public string ETag { get; set; }

        public int SelectedResultIndex { get; set; }

        #endregion
    }
}