using System.Linq;
using Newtonsoft.Json;

namespace PedroLamas.JogosSantaCasa.Model
{
    public class SantaCasaLotariaResult : SantaCasaGameResult
    {
        #region Properties

        [JsonProperty("entries")]
        public SantaCasaLotariaEntry[] Entries { get; set; }

        #endregion

        public override string ToString()
        {
            return string.Join("; ", Entries.Select(x => x.Description + ": " + x.Number));
        }
    }
}