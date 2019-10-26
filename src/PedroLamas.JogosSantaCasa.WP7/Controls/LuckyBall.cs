using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PedroLamas.JogosSantaCasa.Controls
{
    public class LuckyBall : Control
    {
        private TextBlock _numberTextBlock;
        private Ellipse _backgroundEllipse;

        #region Properties

        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(int), typeof(LuckyBall), new PropertyMetadata(99, OnNumberChanged));

        public static void OnNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var luckyBall = (LuckyBall)d;

            luckyBall.Update();
        }

        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(LuckyBall), new PropertyMetadata(null, OnFillChanged));

        public static void OnFillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var luckyBall = (LuckyBall)d;

            luckyBall.Update();
        }

        public LuckyBallFillMode FillMode
        {
            get { return (LuckyBallFillMode)GetValue(FModeProperty); }
            set { SetValue(FModeProperty, value); }
        }

        public static readonly DependencyProperty FModeProperty =
            DependencyProperty.Register("FillMode", typeof(LuckyBallFillMode), typeof(LuckyBall), new PropertyMetadata(LuckyBallFillMode.Manual, OnFillModeChanged));

        public static void OnFillModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var luckyBall = (LuckyBall)d;

            luckyBall.Update();
        }

        #endregion

        public LuckyBall()
        {
            DefaultStyleKey = typeof(LuckyBall);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _numberTextBlock = GetTemplateChild("NumberTextBlock") as TextBlock;
            _backgroundEllipse = GetTemplateChild("BackgroundEllipse") as Ellipse;

            Update();
        }

        private void Update()
        {
            if (_backgroundEllipse != null)
            {
                switch (FillMode)
                {
                    case LuckyBallFillMode.Totoloto:
                        if (Number <= 9)
                            _backgroundEllipse.Fill = new SolidColorBrush(Colors.Blue);
                        else if (Number <= 19)
                            _backgroundEllipse.Fill = new SolidColorBrush(Colors.Orange);
                        else if (Number <= 29)
                            _backgroundEllipse.Fill = new SolidColorBrush(Colors.Green);
                        else if (Number <= 39)
                            _backgroundEllipse.Fill = new SolidColorBrush(Colors.Red);
                        else
                            _backgroundEllipse.Fill = new SolidColorBrush(Colors.Purple);

                        break;
                    default:
                        _backgroundEllipse.Fill = Fill;

                        break;
                }
            }

            if (_numberTextBlock != null)
            {
                _numberTextBlock.Text = Number.ToString();
            }
        }
    }
}