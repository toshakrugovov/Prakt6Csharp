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
    /// Логика взаимодействия для sohrnpagexaml.xaml
    /// </summary>
    public partial class sohrnpagexaml : Page
    {
        DayItems dayItems = new DayItems()
        {
            Items = new List<Item>() //тут сохранение вывод картинок через масиив
            {
                new Item()
                {
                    Name = "ЕЛ дошик",
                    IconPath = "..\\..\\Resources\\IMG_4994.png",
                },
                new Item()
                {
                    Name = "Сидел за компом",
                    IconPath = "..\\..\\Resources\\IMG_4995.png",
                },
                new Item()
                {
                    Name = "Сидел в гараже",
                    IconPath = "..\\..\\Resources\\IMG_4996.png",
                },
                new Item()
                {
                    Name = "Играл в ГТА",
                    IconPath = "..\\..\\Resources\\IMG_4997.png",
                },
                new Item()
                {
                    Name = "Сидел в парке",
                    IconPath = "..\\..\\Resources\\IMG_4998.png",
                },
               
            }
        };

        bool elementDate = true;
        int Index = 0;

        public sohrnpagexaml(DateTime SelectedDate)
        {
            InitializeComponent();
            DateTextBlock.Text = SelectedDate.ToLongDateString();
            dayItems.Day = SelectedDate;

            foreach (var day in DayItems.days)
            {
                if (day.Day == SelectedDate)
                {
                    dayItems = day;
                    elementDate = false;
                    Index = DayItems.days.IndexOf(day);
                    break;
                }
            }

            GenerateItems();
        }

        private void GenerateItems()
        {
            ItemsStackPanel.Children.Clear();

            TextBlock textblock = new TextBlock()
            {
                Text = "Как ты провел свой день?",
                TextAlignment = TextAlignment.Center,
                FontSize = 25,
            };

            ItemsStackPanel.Children.Add(textblock);



            foreach (Item item in dayItems.Items)   
            {
                StackPanel childrenStackPanel = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(5),
                };

                CheckBox checkBox = new CheckBox()
                {
                    IsChecked = item.IsSelected,
                    Margin = new Thickness(30, 5, 5, 5),
                    Tag = item,
                };

                checkBox.Checked += CheckBox_Checked;
                checkBox.Unchecked += CheckBox_Unchecked;

                BitmapImage bitmapkartinka = new BitmapImage(new Uri(item.IconPath, UriKind.Relative));

                Image kartinka = new Image()
                {
                    Source = bitmapkartinka,
                    Margin = new Thickness(5),
                    Stretch = Stretch.Fill,
                    MaxWidth = 100,
                    MaxHeight = 100,
                    Width = bitmapkartinka.PixelWidth,
                    Height = bitmapkartinka .PixelHeight,
                };

                TextBlock textBlock = new TextBlock()
                {
                    Text = item.Name,
                    FontSize = 16,
                };

                childrenStackPanel.Children.Add(checkBox);
                childrenStackPanel.Children.Add(kartinka);
                childrenStackPanel.Children.Add(textBlock);
                ItemsStackPanel.Children.Add(childrenStackPanel);
            };

            


        }

        private void nazad_Click(object sender, RoutedEventArgs e)  //логика кнокпи назад 
        {
            (Application.Current.MainWindow as MainWindow).Content = (Application.Current.MainWindow as MainWindow).datacalendarviv;
        }

         private void CheckBox_Checked(object sender, RoutedEventArgs e)
         {
            dayItems.Items[dayItems.Items.IndexOf((sender as CheckBox).Tag as Item)].IsSelected = (sender as CheckBox).IsChecked ?? false;
         }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            dayItems.Items[dayItems.Items.IndexOf((sender as CheckBox).Tag as Item)].IsSelected = (sender as CheckBox).IsChecked ?? false;
        }

        private void sohrn_Click(object sender, RoutedEventArgs e) //логика кнопки сохранить
        {
            bool flag = false;

            foreach (var item in dayItems.Items)
            {
                if (item.IsSelected)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                if (DayItems.days == null)
                {
                    DayItems.days = new List<DayItems>();
                }

                if (elementDate)
                {
                    DayItems.days.Add(dayItems);
                }
                else
                {
                    DayItems.days[Index] = dayItems;
                }
            }

            (Application.Current.MainWindow as MainWindow).Content = (Application.Current.MainWindow as MainWindow).datacalendarviv;
        }

       
    }
}
