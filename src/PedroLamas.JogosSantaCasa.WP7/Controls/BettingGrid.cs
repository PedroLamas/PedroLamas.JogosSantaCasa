using System;
using System.Windows;
using System.Windows.Controls;
using Cimbalino.Phone.Toolkit.Extensions;

namespace PedroLamas.JogosSantaCasa.Controls
{
    public class BettingGrid : Control
    {
        private Grid _mainGrid;

        #region Properties

        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register("Columns", typeof(int), typeof(BettingGrid), new PropertyMetadata(3, OnColumnsChanged));

        private static void OnColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var bettingGrid = (BettingGrid)d;

            bettingGrid.Update();
        }

        public int MaxNumber
        {
            get { return (int)GetValue(MaxNumberProperty); }
            set { SetValue(MaxNumberProperty, value); }
        }

        public static readonly DependencyProperty MaxNumberProperty =
            DependencyProperty.Register("MaxNumber", typeof(int), typeof(BettingGrid), new PropertyMetadata(9, OnMaxNumberChanged));

        private static void OnMaxNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var bettingGrid = (BettingGrid)d;

            bettingGrid.Update();
        }

        #endregion

        public BettingGrid()
        {
            DefaultStyleKey = typeof(BettingGrid);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _mainGrid = GetTemplateChild("MainGrid") as Grid;

            Update();
        }

        private void Update()
        {
            if (_mainGrid == null)
                return;

            _mainGrid.Children.Clear();
            _mainGrid.ColumnDefinitions.Clear();
            _mainGrid.RowDefinitions.Clear();

            var maxNumber = MaxNumber;
            var columnCount = Columns;

            columnCount.Times(() =>
            {
                _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            });

            var rowCount = (int)Math.Ceiling((double)maxNumber / columnCount);

            rowCount.Times(x =>
            {
                _mainGrid.RowDefinitions.Add(new RowDefinition());
            });

            var itemIndex = 0;

            var nums = new int[] { 5, 12, 16, 38, 40 };

            for (var rowIndex = 0; rowIndex < rowCount && itemIndex < maxNumber; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnCount && itemIndex < maxNumber; columnIndex++, itemIndex++)
                {
                    var toggleButton = new ToggleButton();

                    toggleButton.Content = (itemIndex + 1).ToString();

                    toggleButton.IsChecked = Array.IndexOf(nums, itemIndex) != -1;

                    _mainGrid.Children.Add(toggleButton);

                    toggleButton.SetValue(Grid.ColumnProperty, columnIndex);
                    toggleButton.SetValue(Grid.RowProperty, rowIndex);
                }
            }
        }
    }
}