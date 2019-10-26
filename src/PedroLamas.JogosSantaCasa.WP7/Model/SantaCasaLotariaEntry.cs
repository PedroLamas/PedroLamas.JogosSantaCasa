using Newtonsoft.Json;

namespace PedroLamas.JogosSantaCasa.Model
{
    public class SantaCasaLotariaEntry
    {
        #region Properties

        [JsonProperty("d")]
        public string Description { get; set; }

        [JsonProperty("n")]
        public string Number { get; set; }

        #endregion
    }
}