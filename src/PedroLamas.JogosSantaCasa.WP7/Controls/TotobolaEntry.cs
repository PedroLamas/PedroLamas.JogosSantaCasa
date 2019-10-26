using System.Windows;
using System.Windows.Controls;

namespace PedroLamas.JogosSantaCasa.Controls
{
    public class TotobolaEntry : Control
    {
        private Grid _itemsGrid;

        #region Properties

        public string Possibilities
        {
            get { return (string)GetValue(PossibilitiesProperty); }
            set { SetValue(PossibilitiesProperty, value); }
        }

        public static readonly DependencyProperty PossibilitiesProperty =
            DependencyProperty.Register("Possibilities", typeof(string), typeof(TotobolaEntry), new PropertyMetadata(null, OnPossibilitiesChanged));

        public static void OnPossibilitiesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var totobolaEntry = (TotobolaEntry)d;

            totobolaEntry.Update();
        }

        public string Result
        {
            get { return (string)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(string), typeof(TotobolaEntry), new PropertyMetadata(null, OnResultChanged));

        public static void OnResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var totobolaEntry = (TotobolaEntry)d;

            totobolaEntry.Update();
        }

        #endregion

        public TotobolaEntry()
        {
            DefaultStyleKey = typeof(TotobolaEntry);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _itemsGrid = GetTemplateChild("ItemsGrid") as Grid;

            Update();
        }

        private void Update()
        {
            if (_itemsGrid != null)
            {
                var result = Result ?? string.Empty;

                var possibilities = (Possibilities ?? string.Empty).ToCharArray();

                for (var possibilityIndex = 0; possibilityIndex < possibilities.Length; possibilityIndex++)
                {
                    var possibility = possibilities[possibilityIndex].ToString();

                    var itemBorder = _itemsGrid.Children[possibilityIndex] as Border;

                    if (itemBorder != null)
                    {
                        itemBorder.Opacity = result == possibility ? 1 : 0.2;

                        var itemTextBlock = itemBorder.Child as TextBlock;

                        if (itemTextBlock != null)
                            itemTextBlock.Text = possibility;
                    }
                }
            }
        }
    }
}