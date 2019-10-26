using System.Linq;
using Newtonsoft.Json;

namespace PedroLamas.JogosSantaCasa.Model
{
    public class SantaCasaEuromilhoesResult : SantaCasaGameResult
    {
        #region Properties

        [JsonProperty("nums")]
        public int[] Numbers { get; set; }

        [JsonProperty("stars")]
        public int[] Stars { get; set; }

        #endregion

        public override string ToString()
        {
            return string.Join(" ", Numbers.Select(x => x.ToString())) + " + " + string.Join(" ", Stars.Select(x => x.ToString()));
        }
    }
}