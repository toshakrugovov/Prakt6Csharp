using System;
using System.Collections.Generic;

namespace Calen
{
    public class DayItems   //гет и сет 
    {
        public static List<DayItems> days = Filecs.Deserialization<DayItems>(MainWindow.sohrnJson);
        public DateTime Day { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }
        public string IconPath { get; set; }//это не меняй антон тут если убрать Path иконоки показываться не будут 
        public bool IsSelected { get; set; }
    }
}