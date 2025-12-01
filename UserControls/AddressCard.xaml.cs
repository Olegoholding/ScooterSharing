using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScooterSharing.UserControls
{
    /// <summary>
    /// Логика взаимодействия для AddressCard.xaml
    /// </summary>
    public partial class AddressCard : UserControl
    {

        //CurrentScootersPanel - StackPanel в который добовляются номера самокатов
        //AddNewScooterComboBox - ComboBox с самокатами которых нет на месте

        bool simpleMod = true;
        const double SimpleHeight = 200;
        const double ExpandedHeight = double.NaN;

        public AddressCard(string id, string address, string count, string maxCount)
        {
            InitializeComponent();
            idText.Text = '#' + id;
            addressText.Text = address;
            countText.Text = count + '/' + maxCount;
        }
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (simpleMod)
            {
                ScooterPanel.Visibility = Visibility.Visible;
                AddScooterPanel.Visibility = Visibility.Visible;
                this.Height = ExpandedHeight;
                simpleMod = false;
            }
            else
            {
                ScooterPanel.Visibility = Visibility.Collapsed;
                AddScooterPanel.Visibility = Visibility.Collapsed;
                this.Height = SimpleHeight;
                simpleMod = true;
            }
        }

        private void AddNewScooterButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
