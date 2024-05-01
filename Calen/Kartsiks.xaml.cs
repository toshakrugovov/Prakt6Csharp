﻿using System;
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
    /// Логика взаимодействия для Kartsiks.xaml
    /// </summary>
    public partial class Kartsiks : UserControl
    {
        public DateTime sohrnDAteee;
        public Kartsiks()
        {
            InitializeComponent();
            MouseLeftButtonDown += CalendarItemUserControl_MouseLeftButtonDown;
        }

       

        private void CalendarItemUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).Content = new sohrnpagexaml(sohrnDAteee);
        }
    }
}
