using System.Linq;
using Newtonsoft.Json;

namespace PedroLamas.JogosSantaCasa.Model
{
    public class SantaCasaTotolotoResult : SantaCasaGameResult
    {
        #region Properties

        [JsonProperty("nums")]
        public int[] Numbers { get; set; }

        [JsonProperty("extra")]
        public int ExtraNumber { get; set; }

        #endregion

        public override string ToString()
        {
            return string.Join(" ", Numbers.Select(x => x.ToString())) + " + " + ExtraNumber.ToString();
        }
    }
}