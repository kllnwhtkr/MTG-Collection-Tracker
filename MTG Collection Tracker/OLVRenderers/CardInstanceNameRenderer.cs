﻿using BrightIdeasSoftware;
using System.Drawing;

namespace MTG_Collection_Tracker
{
    public class CardInstanceNameRenderer : BaseRenderer
    {
        public override void Render(Graphics g, Rectangle r)
        {
            var cardInstance = ListItem.RowObject as FullInventoryCard;
            int? imgIndex = ListView.SmallImageList?.Images?.IndexOfKey(cardInstance.ImageKey);
            int imgWidth = ListView.SmallImageList?.ImageSize.Width ?? 0;
            Rectangle backgroundRect = new Rectangle(r.Left - 1, r.Top - 1, r.Width + 1, r.Height + 1);
            if (IsItemSelected)
            {
                if (ListView.Focused)
                    g.FillRectangle(new SolidBrush(ListView.SelectedBackColor), backgroundRect);
                else
                    g.FillRectangle(new SolidBrush(ListView.UnfocusedSelectedBackColor), backgroundRect);
            }
            else
                g.FillRectangle(new SolidBrush(ListView.BackColor), backgroundRect);

            Brush fontColor = IsItemSelected && ListView.Focused ? Brushes.White : Brushes.Black;
            if (imgIndex.HasValue && imgIndex.Value != -1)
            {
                ListView.SmallImageList.Draw(g, 2, 0, imgIndex.Value);
                g.DrawString(GetText(), Font, fontColor, r.Left + imgWidth + 3, r.Top + 3);
            }
            else
                g.DrawString(GetText(), Font, fontColor, r.Left + 5, r.Top + 3);
        }
    }
}