using Avalonia.Controls;
using Avalonia.Interactivity;
using RapidPack.Models;
using System;
using System.Globalization;

namespace RapidPack
{
    public partial class MainWindow : Window
    {
        private readonly ParcelCalculator _calculator = new ParcelCalculator();

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double weight = (double)(WeightInput.Value ?? 0);
                
                string type = (TypeInput.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Standardowa";
                
                int h = int.Parse(HeightInput.Text ?? "0");
                int w = int.Parse(WidthInput.Text ?? "0");
                int d = int.Parse(DepthInput.Text ?? "0");
                
                bool isExpress = ExpressInput.IsChecked ?? false;
                
                decimal finalPrice = _calculator.Calculate(weight, type, h, w, d, isExpress);
                
                ResultOutput.Text = $"Suma: {finalPrice:C2}";
                ResultOutput.Foreground = Avalonia.Media.Brushes.DarkGreen;
            }
            catch (ArgumentException ex)
            {
                ResultOutput.Text = ex.Message;
                ResultOutput.Foreground = Avalonia.Media.Brushes.Red;
            }
            catch (Exception)
            {
                ResultOutput.Text = "Błędne dane wymiarów!";
                ResultOutput.Foreground = Avalonia.Media.Brushes.Red;
            }
        }
    }
}