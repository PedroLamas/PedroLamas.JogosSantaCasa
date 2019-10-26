using System.Linq;
using Newtonsoft.Json;

namespace PedroLamas.JogosSantaCasa.Model
{
    public class SantaCasaTotobolaResult : SantaCasaGameResult
    {
        #region Properties

        [JsonProperty("games")]
        public string Games { get; set; }

        [JsonProperty("extra")]
        public string ExtraGame { get; set; }

        [JsonIgnore]
        public override bool IsBettingEnabled
        {
            get
            {
                return false;
            }
        }

        #endregion

        public override string ToString()
        {
            return string.Join(" ", Games.Select(x => x.ToString())) + " + " + string.Join(" ", ExtraGame.Select(x => x.ToString()));
        }
    }
}