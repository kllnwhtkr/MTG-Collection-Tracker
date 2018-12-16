﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTG_Librarian
{
    public static class Globals
    {
        public static Dictionary<string, MagicCard> AllCards = new Dictionary<string, MagicCard>();
        public static class Forms
        {
            public static WeifenLuo.WinFormsUI.Docking.DockPanel DockPanel { get; set; }
        }

        public static class ImageLists
        {
            public static ImageList ManaIcons { get; set; }
            public static ImageList SymbolIcons16 { get; set; }
            public static ImageList SmallIconList { get; set; }
        }
    }
}
