using ScooterSharing.UserControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ScooterSharing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StackPanel[] stackPanels;
        public MainWindow()
        {
            InitializeComponent();
            stackPanels = [scootersBlock, pointsBlock, tarifsBlock];
            Scooters.IsChecked = true;
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            int index = radioButton.Name switch
            {
                "Scooters" => 0,
                "Points" => 1,
                "Tarifs" => 2,
            };

            foreach (var panel in stackPanels)
                panel.Visibility = Visibility.Collapsed;

            stackPanels[index].Visibility = Visibility.Visible;
        }
        private void SearchButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}