using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PedroLamas.JogosSantaCasa.Controls
{
    public class Clover : Control
    {
        private Path _cloverPath;

        #region Properties

        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(Clover), new PropertyMetadata(null, OnFillChanged));

        public static void OnFillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var clover = (Clover)d;

            clover.Update();
        }

        #endregion

        public Clover()
        {
            DefaultStyleKey = typeof(Clover);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _cloverPath = GetTemplateChild("CloverPath") as Path;

            Update();
        }

        private void Update()
        {
            if (_cloverPath != null)
            {
                _cloverPath.Fill = Fill;
            }
        }
    }
}