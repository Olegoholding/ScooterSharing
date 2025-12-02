using ScooterSharing.Back;
using ScooterSharing.UserControls;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ScooterSharing
{
    public partial class MainWindow : Window
    {
        //stackPanels = [scootersBlock, pointsBlock, tarifsBlock];
        DataTable dt;
        string TagElem;
        public MainWindow()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString();
        }
        protected void HidePanel() => stackPanel.Children.OfType<StackPanel>().ToList().ForEach(rb => rb.Visibility = Visibility.Collapsed);
        protected void DeleteChildren()
        {
            wrapPanel.Children.Clear();
            DltComboBox.Items.Clear();
        }
        private void CheckedScooters(object sender, RoutedEventArgs e)
        {
            HidePanel();
            DeleteChildren();

            scootersBlock.Visibility = Visibility.Visible;

            SrcLbl.Text = "Название самоката";
            TagElem = (((RadioButton)sender).Tag).ToString();
            dt = new Back.DatabaseInteraction().GetData($"Select * from {TagElem}");
            foreach (DataRow row in dt.Rows)
            {
                DltComboBox.Items.Add((int)(row["Номер"]));
                wrapPanel.Children.Add(new ScooterCard((int)(row["Номер"]), row["НомерСамоката"].ToString(), row["СостояниеБатареи"].ToString()));
            }
        }
        private void CheckedPoints(object sender, RoutedEventArgs e)
        {
            HidePanel();
            DeleteChildren();

            pointsBlock.Visibility = Visibility.Visible;

            SrcLbl.Text = "Адрес";
            TagElem = (((RadioButton)sender).Tag).ToString();
            dt = new DatabaseInteraction().GetData($"Select * from {TagElem}");
            foreach (DataRow row in dt.Rows)
            {
                DltComboBox.Items.Add((int)(row["Номер"]));
                wrapPanel.Children.Add(new AddressCard((int)(row["Номер"]), row["Адрес"].ToString(), row["КолвоМест"].ToString()));
            }
        }
        private void CheckedTariffs(object sender, RoutedEventArgs e)
        {
            HidePanel();
            DeleteChildren();

            tarifsBlock.Visibility = Visibility.Visible;

            SrcLbl.Text = "Название тарифа";
            TagElem = (((RadioButton)sender).Tag).ToString();
            dt = new Back.DatabaseInteraction().GetData($"Select * from {TagElem}");
            foreach (DataRow row in dt.Rows)
            {
                DltComboBox.Items.Add((int)(row["Номер"]));
                wrapPanel.Children.Add(new TarifCard((int)(row["Номер"]), row["Название"].ToString(), row["Цена"].ToString()));
            }
        }
        private void SearchButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = wrapPanel.Children.Count - 1; i >= 0; i--)
            {
                var item = wrapPanel.Children[i];

                dynamic dynamicItem = item;
                if (dynamicItem.NameText.Text != SrcBox.Text)
                {
                    wrapPanel.Children[i].Visibility = Visibility.Collapsed;
                }
                else
                {
                    wrapPanel.Children[i].Visibility = Visibility.Visible;
                }
            }
        }

        private void DeleteButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => new DatabaseInteraction().DeleteData(TagElem, Convert.ToInt16(DltComboBox.Text));

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string command = "";
            switch (TagElem)
            {
                case "Самокаты":
                    command = $"INSERT INTO Самокаты (НомерСамоката, СостояниеБатареи) VALUES('{scooterNumber.Text}', '{Convert.ToInt16(scooterPower.Text)}');";
                    break;
                case "Тарифы":
                    command = $"INSERT INTO Тарифы (Название, Цена) VALUES('{tarifName.Text}', '{tarifPrice.Text}');";
                    break;
                case "Точки":
                    command = $"INSERT INTO Точки (КолвоМест, Адрес) VALUES('{pointCount.Text}', '{pointAddress.Text}');";
                    break;
            }
            new DatabaseInteraction().DoCommand(command);
        }
    }
}