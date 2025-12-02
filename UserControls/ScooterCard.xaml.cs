using System.Windows.Controls;

namespace ScooterSharing.UserControls
{
    public partial class ScooterCard : UserControl
    {
        public ScooterCard(int id, string number, string power)
        {
            InitializeComponent();
            idText.Text = '#' + id.ToString();
            scooterText.Text = "Самокат";
            NameText.Text = number.ToUpper();
            batareyText.Text = power + '%';
        }
    }
}
