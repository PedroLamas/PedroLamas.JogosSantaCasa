using System.Windows;
using PedroLamas.JogosSantaCasa.Model;

namespace PedroLamas.JogosSantaCasa.Helpers
{
    public class SantaCasaTemplateSelector : DataTemplateSelector
    {
        #region Properties

        public DataTemplate EuromilhoesDataTemplate { get; set; }

        public DataTemplate JokerDataTemplate { get; set; }

        public DataTemplate LotariaDataTemplate { get; set; }

        public DataTemplate TotobolaDataTemplate { get; set; }

        public DataTemplate TotolotoDataTemplate { get; set; }

        #endregion

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var santaCasaGamesResponse = (SantaCasaGamesResponse)item;

            switch (santaCasaGamesResponse.GameType)
            {
                case SantaCasaGameType.Euromilhoes:
                    return EuromilhoesDataTemplate;
                case SantaCasaGameType.Joker:
                    return JokerDataTemplate;
                case SantaCasaGameType.Lotaria:
                    return LotariaDataTemplate;
                case SantaCasaGameType.Totobola:
                    return TotobolaDataTemplate;
                case SantaCasaGameType.Totoloto:
                    return TotolotoDataTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}