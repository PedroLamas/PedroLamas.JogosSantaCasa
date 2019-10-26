using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PedroLamas.JogosSantaCasa.Model
{
    public class SantaCasaGamesResponse
    {
        private SantaCasaGameResult _result;

        #region Properties

        [JsonProperty("d")]
        public string Description { get; set; }

        [JsonProperty("g")]
        public string SmallDescription { get; set; }

        [JsonProperty("c")]
        public string Contest { get; set; }

        [JsonProperty("r")]
        public JObject InternalResult { get; set; } //SantaCasaGameResponse

        [JsonProperty("t")]
        public SantaCasaGameType GameType { get; set; }

        [JsonProperty("k")]
        public string Color { get; set; }

        [JsonIgnore]
        public SantaCasaGameResult Result
        {
            get
            {
                if (_result == null)
                {
                    switch (GameType)
                    {
                        case SantaCasaGameType.Euromilhoes:
                            _result = InternalResult.ToObject<SantaCasaEuromilhoesResult>();
                            break;
                        case SantaCasaGameType.Joker:
                            _result = InternalResult.ToObject<SantaCasaJokerResult>();
                            break;
                        case SantaCasaGameType.Lotaria:
                            _result = InternalResult.ToObject<SantaCasaLotariaResult>();
                            break;
                        case SantaCasaGameType.Totobola:
                            _result = InternalResult.ToObject<SantaCasaTotobolaResult>();
                            break;
                        case SantaCasaGameType.Totoloto:
                            _result = InternalResult.ToObject<SantaCasaTotolotoResult>();
                            break;
                    }
                }

                return _result;
            }
        }

        #endregion

        public override string ToString()
        {
            return Description + " (" + Contest + ")";
        }
    }
}