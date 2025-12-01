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
    /// Логика взаимодействия для ScooterCard.xaml
    /// </summary>
    public partial class ScooterCard : UserControl
    {
        public ScooterCard(string id, string name, string number, string power)
        {
            InitializeComponent();
            idText.Text = '#' + id;
            scooterText.Text = name;
            numberText.Text = number.ToUpper();
            batareyText.Text = power + '%';
        }
    }
}
