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

namespace Calen
{
    /// <summary>
    /// Логика взаимодействия для datacalendarviv.xaml
    /// </summary>
    public partial class datacalendarviv : Page
    {
        public datacalendarviv()
        {
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Today;

        }

        private void nvpered_Click(object sender, RoutedEventArgs e)
        {
            MyWrapPanel.Children.Clear(); // Очищаем все текущие элементы

            DateTime newDate = DatePicker.SelectedDate.Value.AddMonths(1);
            DatePicker.SelectedDate = newDate;

            CreateUserControlsBasedOnDays();
        }

        private void vnazad_Click(object sender, RoutedEventArgs e)
        {
            MyWrapPanel.Children.Clear(); // Очищаем все текущие элементы

            DateTime newDate = DatePicker.SelectedDate.Value.AddMonths(-1);
            DatePicker.SelectedDate = newDate;

            CreateUserControlsBasedOnDays();
        }

        



        public void CreateUserControlsBasedOnDays()
        {
            int daysInMonth = DateTime.DaysInMonth(DatePicker.SelectedDate.Value.Year, DatePicker.SelectedDate.Value.Month);

            MyWrapPanel.Children.Clear();

            for (int i = 1; i <= daysInMonth; i++)
            {
                var userControl = new Kartsiks();
                userControl.DayBlock.Text = i.ToString();

                DateTime dateTime = new DateTime(year: DatePicker.SelectedDate.Value.Year, DatePicker.SelectedDate.Value.Month, i);
                userControl.sohrnDAteee = dateTime;

                if (DayItems.days != null)
                {
                    foreach (var dayItems in DayItems.days)
                    {
                        if (dayItems.Day == dateTime)
                        {
                            foreach (var item in dayItems.Items)
                            {
                                if (item.IsSelected)
                                {
                                    BitmapImage bitmapkartinka = new BitmapImage(new Uri(item.IconPath, UriKind.Relative));
                                    userControl.ItemImage.Source = bitmapkartinka;
                                    userControl.ItemImage.Height = bitmapkartinka.PixelHeight;
                                    userControl.ItemImage.Width = bitmapkartinka.PixelWidth;
                                    break;
                                }
                            }
                        }
                    }   
                }

                MyWrapPanel.Children.Add(userControl);
            }
        }

    }
}


