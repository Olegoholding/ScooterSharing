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
        public AddressCard(string id, string address, string count, string maxCount)
        {
            InitializeComponent();
            idText.Text = '#' + id;
            addressText.Text = address;
            countText.Text = count + '/' + maxCount;
        }
    }
}
