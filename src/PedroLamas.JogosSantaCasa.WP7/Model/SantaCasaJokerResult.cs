using Newtonsoft.Json;

namespace PedroLamas.JogosSantaCasa.Model
{
    public class SantaCasaJokerResult : SantaCasaGameResult
    {
        #region Properties

        [JsonProperty("num")]
        public string Number { get; set; }

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
            return Number;
        }
    }
}