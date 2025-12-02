using System.Windows.Controls;

namespace ScooterSharing.UserControls
{
    public partial class TarifCard : UserControl
    {
        public TarifCard(int id, string tarif, string price)
        {
            InitializeComponent();
            idText.Text = '#' + id.ToString();
            NameText.Text = tarif;
            priceText.Text = price + " руб/мин";
        }
    }
}
