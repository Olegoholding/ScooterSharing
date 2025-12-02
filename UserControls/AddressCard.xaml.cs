using ScooterSharing.Back;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ScooterSharing.UserControls
{
    public partial class AddressCard : UserControl
    {

        //CurrentScootersPanel - StackPanel в который добовляются номера самокатов
        //AddNewScooterComboBox - ComboBox с самокатами которых нет на месте

        bool simpleMod = true;
        const double SimpleHeight = 200;
        const double ExpandedHeight = double.NaN;
        int Address;
        int Scooter;

        DataTable DtScooters;
        public AddressCard(int id, string address, string maxCount)
        {
            InitializeComponent();
            int i = 0;
            idText.Text = '#' + id.ToString();
            NameText.Text = address;
            Address = id;

            DtScooters = new DatabaseInteraction().GetData(@"SELECT Самокаты.Номер, Самокаты.НомерСамоката FROM Самокаты 
            LEFT JOIN ПривязкаСамокатов ON Самокаты.Номер = ПривязкаСамокатов.Самокат
            WHERE ПривязкаСамокатов.Самокат IS NULL;");
            foreach (DataRow row in DtScooters.Rows)
            {
                AddNewScooterComboBox.Items.Add(new TextBlock() { Text = row["НомерСамоката"].ToString(), Uid = row["Номер"].ToString() });
            }
            DtScooters = new DatabaseInteraction().GetData($@"SELECT Самокаты.НомерСамоката, ПривязкаСамокатов.Адрес FROM ПривязкаСамокатов 
            JOIN Самокаты ON Самокаты.Номер = ПривязкаСамокатов.Самокат
            JOIN Точки ON ПривязкаСамокатов.Адрес = Точки.Номер
            WHERE Точки.Адрес = '{address}'");
            foreach (DataRow row in DtScooters.Rows)
            {
                CurrentScootersPanel.Children.Add(new TextBlock() { Text = row["НомерСамоката"].ToString()});
                i++;
            }
            countText.Text = i.ToString() + '/' + maxCount;
        }
        private void AddNewScooterButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) => new DatabaseInteraction().DoCommand($"INSERT INTO ПривязкаСамокатов (Самокат, Адрес) VALUES('{Scooter}', '{Address}');");
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
        private void AddNewScooterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AddNewScooterComboBox.SelectedItem is TextBlock item)
            {
                Scooter = Convert.ToInt16(item.Uid);
            }
        }
    }
}
