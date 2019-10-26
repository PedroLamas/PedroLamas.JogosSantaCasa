using Newtonsoft.Json;

namespace PedroLamas.JogosSantaCasa.Model
{
    public abstract class SantaCasaGameResult
    {
        [JsonIgnore]
        public virtual bool IsBettingEnabled
        {
            get
            {
                return true;
            }
        }
    }
}