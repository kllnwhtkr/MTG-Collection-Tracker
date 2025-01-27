﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KW.WinFormsUI.Docking;
using BrightIdeasSoftware;
using System.Collections;

namespace MTG_Librarian
{
    public partial class DBViewForm : DockForm
    {
        #region Fields

        private Dictionary<string, OLVSetItem> sets;
        private readonly System.Timers.Timer TextChangedWaitTimer = new System.Timers.Timer();
        public List<OLVSetItem> SetItems = new List<OLVSetItem>();

        #endregion Fields

        #region Constructors

        public DBViewForm()
        {
            InitializeComponent();
            setListView.SmallImageList = Globals.ImageLists.SmallIconList;
            setListView.TreeColumnRenderer = new SetRenderer();
            setListView.UseFiltering = true;
            cardListView.SmallImageList = Globals.ImageLists.SmallIconList;
            cardListView.VirtualListDataSource = new MyCustomSortingDataSource(cardListView);
            whiteManaButton.ImageList = blueManaButton.ImageList = blackManaButton.ImageList = redManaButton.ImageList = greenManaButton.ImageList
                                      = colorlessManaButton.ImageList = genericManaButton.ImageList = Globals.ImageLists.ManaIcons;
            (whiteManaButton.ImageKey, blueManaButton.ImageKey) = ("{W}", "{U}");
            (blackManaButton.ImageKey, redManaButton.ImageKey, greenManaButton.ImageKey) = ("{B}", "{R}", "{G}");
            (colorlessManaButton.ImageKey, genericManaButton.ImageKey) = ("{C}", "{X}");
            cardListView.UseFiltering = true;
            cardListView.SetDoubleBuffered();
            cardListView.AllColumns.FirstOrDefault(x => x.AspectName == "ManaCost").Renderer = new ManaCostRenderer();
            TextChangedWaitTimer.Interval = 400;
            TextChangedWaitTimer.Elapsed += (sender, e) =>
            {
                TextChangedWaitTimer.Stop();
                UpdateCardModelFilter();
            };
            DockAreas = DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockBottom;
        }

        #endregion Constructors

        #region Methods

        #region Filters

        private delegate void UpdateModelFilterDelegate();

        private void UpdateCardModelFilter()
        {
            if (InvokeRequired)
                BeginInvoke(new UpdateModelFilterDelegate(UpdateCardModelFilter));
            else
            {
                var selectedObjects = new List<object>();
                foreach (object o in cardListView.SelectedObjects)
                    selectedObjects.Add(o);
                cardListView.ModelFilter = new ModelFilter(GetCardFilter());
                cardListView.SelectedObjects = selectedObjects;
                cardListView.RefreshSelectedObjects();
            }
        }

        private Predicate<object> GetCardFilter()
        {
            return GetManaCostFilter()
                .And(GetCardNameFilter())
                .And(GetCardTextFilter())
                .And(GetOwnedStatusFilter()
                .And(GetTreeViewFilter())
                .And(GetTypeFilter()));
        }

        private Predicate<object> GetCardNameFilter()
        {
            return x => cardNameFilterBox.UserText == ""
                ? true
                : (x as OLVCardItem).Name?.ToUpper().Contains(cardNameFilterBox.UserText.ToUpper()) ?? false;
        }

        private Predicate<object> GetCardTextFilter()
        {
            return x => cardTextFilterTextBox.UserText == ""
                ? true
                : (x as OLVCardItem).Text?.ToUpper().Contains(cardTextFilterTextBox.UserText.ToUpper()) ?? false;
        }

        private Predicate<object> GetManaCostFilter()
        {
            Predicate<object> combinedFilter = x => true;

            if (whiteManaButton.Checked) combinedFilter = combinedFilter.And(x => (x as OLVCardItem).ManaCost?.Contains("W") ?? false);
            if (blueManaButton.Checked) combinedFilter = combinedFilter.And(x => (x as OLVCardItem).ManaCost?.Contains("U") ?? false);
            if (blackManaButton.Checked) combinedFilter = combinedFilter.And(x => (x as OLVCardItem).ManaCost?.Contains("B") ?? false);
            if (redManaButton.Checked) combinedFilter = combinedFilter.And(x => (x as OLVCardItem).ManaCost?.Contains("R") ?? false);
            if (greenManaButton.Checked) combinedFilter = combinedFilter.And(x => (x as OLVCardItem).ManaCost?.Contains("G") ?? false);
            if (colorlessManaButton.Checked) combinedFilter = combinedFilter.And(x => (x as OLVCardItem).ManaCost?.Contains("C") ?? false);
            if (genericManaButton.Checked) combinedFilter = combinedFilter.And(x => ((x as OLVCardItem).ManaCost?.Contains("X") ?? false)
                || ((x as OLVCardItem).ManaCost?.Any(c => char.IsDigit(c)) ?? false));
            return combinedFilter;
        }

        private Predicate<object> GetOwnedStatusFilter()
        {
            string ownedText = copiesOwnedFilterBox.Text;
            return x => ownedText == "" || ownedText == "All"
                ? true
                : (ownedText == "Owned"
                    ? (x as OLVCardItem).CopiesOwned > 0
                    : (x as OLVCardItem).CopiesOwned == 0);
        }

        private Predicate<object> GetSetNameTreeFilter()
        {
            string boxText = setFilterBox.UserText.ToUpper();
            return x => boxText == ""
                ? true
                : (x is OLVRarityItem rarityItem && (rarityItem.Parent as OLVSetItem).Name.ToUpper().Contains(boxText))
                  || (x is OLVSetItem && (x as OLVSetItem).Name.ToUpper().Contains(boxText));
        }

        private Predicate<object> GetSetTypeTreeFilter()
        {
            string comboBoxText = setTypeFilterComboBox.Text;
            return x => comboBoxText == "All Set Types" || comboBoxText == ""
                ? true
                : (x is OLVRarityItem rarityItem && (rarityItem.Parent as OLVSetItem).CardSet.BoosterV3 != null) ||
                  (x is OLVSetItem setItem && setItem.CardSet.BoosterV3 != null && setItem.CardSet.BoosterV3.Length > 0);
        }

        private Predicate<object> GetTreeViewFilter()
        {
            Predicate<object> combinedFilter = x => true;
            if (setListView.SelectedIndex != -1)
            {
                var lvItem = setListView.SelectedItem.RowObject as OLVItem;
                do
                {
                    combinedFilter = combinedFilter.And(lvItem.Filter);
                } while ((lvItem = lvItem.Parent) != null);
            }
            return combinedFilter;
        }

        private Predicate<object> GetTypeFilter()
        {
            return x => typeFilterTextBox.UserText == ""
                ? true
                : (x as OLVCardItem).MagicCard.type?.ToUpper().Contains(typeFilterTextBox.UserText.ToUpper()) ?? false;
        }

        #endregion Filters

        public void SortCardListView()
        {
            if (cardListView.PrimarySortColumn == null) // sort by set, number if not already sorted
            {
                var sorted = cardListView.Objects.Cast<OLVCardItem>().OrderBy(x => x.MagicCard.Edition).ThenBy(x => x.MagicCard.SortableNumber);
                cardListView.Objects = sorted;
            }
            else
                cardListView.Sort();
        }

        public void LoadSet(string SetCode)
        {
            var existingSet = setListView.Objects.Cast<OLVSetItem>().FirstOrDefault(x => x.CardSet.Code == SetCode);
            var selectedSet = setListView.SelectedObject as OLVSetItem;
            if (existingSet != null)
            {
                var existingCards = cardListView.Objects.Cast<OLVCardItem>().Where(x => x.MagicCard.SetCode == SetCode).ToArray();
                foreach (var card in existingCards)
                    Globals.Collections.MagicCardCache.Remove(card.MagicCard.uuid);
                setListView.RemoveObject(existingSet);
                cardListView.RemoveObjects(existingCards);
            }
            using (var context = new CardsDbContext())
            {
                var dbSet = (from s in context.Sets
                             where s.Code == SetCode
                             select s).FirstOrDefault();
                if (dbSet != null)
                {
                    var set = new OLVSetItem(dbSet);
                    var cards = from c in context.Catalog
                                where c.SetCode == SetCode
                                orderby new AlphaNumericString(c.number), c.name
                                select c;

                    foreach (var card in cards)
                    {
                        card.DisplayName = card.name;
                        set.AddCard(card);
                    }

                    set.CollapseParts();
                    set.BuildRarityItems();
                    setListView.AddObject(set);
                    cardListView.AddObjects(set.Cards);
                    foreach (var card in set.Cards)
                        Globals.Collections.MagicCardCache.Add(card.MagicCard.uuid, card.MagicCard);
                    if (setListView.Objects.Count() == 1) // first set added, must sort the tree
                        setListView.Sort(setListView.AllColumns[1], SortOrder.Descending);
                    SetItems.Add(set);
                }
            }
            if (selectedSet != null)
                setListView.SelectedObject = setListView.Objects.Cast<OLVSetItem>().FirstOrDefault(x => x.CardSet.Code == selectedSet.CardSet.Code);
        }

        public void LoadSets()
        {
            setListView.CanExpandGetter = x => x is OLVSetItem;
            setListView.ChildrenGetter = x => (x as OLVSetItem).Rarities;
            var renderer = setListView.TreeColumnRenderer;
            renderer.IsShowLines = false;
            renderer.UseTriangles = true;
            sets = new Dictionary<string, OLVSetItem>();
            using (var context = new CardsDbContext())
            {
                var dbSets = from s in context.Sets
                             orderby s.Name
                             select s;
                var cards = from c in context.Catalog
                            orderby c.Edition, new AlphaNumericString(c.number), c.name
                            select c;

                foreach (var card in cards)
                {
                    card.DisplayName = card.name;
                    if (!sets.TryGetValue(card.Edition, out OLVSetItem set))
                    {
                        set = new OLVSetItem(dbSets.FirstOrDefault(x => x.Name == card.Edition));
                        sets.Add(card.Edition, set);
                    }
                    set.AddCard(card);
                    Globals.Collections.MagicCardCache.Add(card.uuid, card);
                }
            }
            CollapseParts(sets);
            foreach (var set in sets.Values)
                set.BuildRarityItems();
            SetItems.AddRange(sets.Values);
        }

        private static void CollapseParts(Dictionary<string, OLVSetItem> sets)
        {
            foreach (var OLVSet in sets.Values)
                OLVSet.CollapseParts();
        }

        public void LoadTree()
        {
            foreach (var set in sets.Values)
            {
                setListView.AddObject(set);
                cardListView.AddObjects(set.Cards);
            }
            setListView.Sort(setListView.AllColumns[1], SortOrder.Descending);
        }

        private void UpdateSetModelFilter()
        {
            setListView.ModelFilter = new ModelFilter(GetSetNameTreeFilter().And(GetSetTypeTreeFilter()));
        }

        #endregion Methods

        #region Events

        #region DBViewForm Events

        public event EventHandler<CardsActivatedEventArgs> CardsActivated;

        private void OnCardsActivated(CardsActivatedEventArgs args)
        {
            CardsActivated?.Invoke(this, args);
        }

        public event EventHandler<CardSelectedEventArgs> CardSelected;

        private void OnCardSelected(CardSelectedEventArgs args)
        {
            CardSelected?.Invoke(this, args);
        }

        #endregion DBViewForm Events

        #region setListView Events

        private void treeListView1_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Model is OLVCardItem)
            {
                var padding = new Rectangle { X = -10 };
                e.Item.CellPadding = padding;
            }
        }

        private void treeListView1_ItemActivate(object sender, EventArgs e)
        {
            if (setListView.SelectedObject is OLVSetItem item)
            {
                if (!setListView.IsExpanded(item))
                    setListView.Expand(item);
                else
                    setListView.Collapse(item);
            }
        }

        private void setListView_SelectionChanged(object sender, EventArgs e)
        {
            cardListView.SelectedObject = null;
            UpdateCardModelFilter();
        }

        #endregion setListView Events

        #region cardListView Events

        private void fastObjectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cards = cardListView.SelectedObjects;
            if (cards.Count > 0)
                OnCardSelected(new CardSelectedEventArgs { MagicCards = cards });
        }

        private void fastObjectListView1_ItemActivate(object sender, EventArgs e)
        {
            OnCardsActivated(new CardsActivatedEventArgs { CardItems = new ArrayList { cardListView.SelectedObject as OLVCardItem } });
        }

        private void fastObjectListView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Cursor.Current = new Cursor(Properties.Resources.hand.GetHicon());
        }

        private void cardListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cardListView.SelectedItems != null)
                if (e.KeyChar == '\r')
                    e.Handled = true;
        }

        #endregion cardListView Events

        #region Menu Events

        private void updateThisSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setListView.SelectedObject is OLVSetItem setItem)
            {
                var newTask = new DownloadSetTask(setItem.CardSet);
                Globals.Forms.TasksForm.TaskManager.AddTask(newTask);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(setListView.SelectedObject is OLVSetItem))
                e.Cancel = true;
        }

        #endregion Menu Events

        #region Misc Events

        private void copiesOwnedFilterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCardModelFilter();
        }

        private void setTypeFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSetModelFilter();
        }

        private void cardNameFilterBox_TextChanged(object sender, EventArgs e)
        {
            TextChangedWaitTimer.Stop();
            TextChangedWaitTimer.Start();
        }

        private void setFilterBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSetModelFilter();
        }

        private void whiteManaButton_Click(object sender, EventArgs e)
        {
            UpdateCardModelFilter();
        }

        #endregion Misc Events

        #endregion Events

        #region Classes

        public class MyCustomSortingDataSource : FastObjectListDataSource
        {
            public MyCustomSortingDataSource(FastObjectListView listView) : base(listView)
            {
            }

            override public void Sort(OLVColumn column, SortOrder order)
            {
                if (column == listView.AllColumns.FirstOrDefault(x => x.AspectName == "CollectorNumber"))
                    FilteredObjectList.Sort(new CollectorNumberComparer { SortOrder = order });
                else if (column == listView.AllColumns.FirstOrDefault(x => x.AspectName == "DisplayName"))
                    FilteredObjectList.Sort(new NameComparer { SortOrder = order });
                else if (column == listView.AllColumns.FirstOrDefault(x => x.AspectName == "Type"))
                    FilteredObjectList.Sort(new TypeComparer { SortOrder = order });
                else if (column == listView.AllColumns.FirstOrDefault(x => x.AspectName == "Set"))
                    FilteredObjectList.Sort(new SetComparer { SortOrder = order });
                else if (column == listView.AllColumns.FirstOrDefault(x => x.AspectName == "ManaCost"))
                    FilteredObjectList.Sort(new ManaCostComparer { SortOrder = order });
                else if (column == listView.AllColumns.FirstOrDefault(x => x.AspectName == "CopiesOwned"))
                    FilteredObjectList.Sort(new CopiesOwnedComparer { SortOrder = order });
                RebuildIndexMap();
            }

            private class CopiesOwnedComparer : IComparer
            {
                public SortOrder SortOrder;

                public int Compare(object x, object y)
                {
                    int result = (x as OLVCardItem).CopiesOwned.CompareTo((y as OLVCardItem).CopiesOwned);
                    return SortOrder == SortOrder.Ascending ? result : -1 * result;
                }
            }

            private class CollectorNumberComparer : IComparer
            {
                public SortOrder SortOrder;

                public int Compare(object x, object y)
                {
                    int result = (x as OLVCardItem).SortableNumber.CompareTo((y as OLVCardItem).SortableNumber);
                    return SortOrder == SortOrder.Ascending ? result : -1 * result;
                }
            }

            private class NameComparer : IComparer
            {
                public SortOrder SortOrder;

                public int Compare(object x, object y)
                {
                    int result = (x as OLVCardItem).Name.CompareTo((y as OLVCardItem).Name);
                    return SortOrder == SortOrder.Ascending ? result : result * -1;
                }
            }

            private class TypeComparer : IComparer
            {
                public SortOrder SortOrder;

                public int Compare(object x, object y)
                {
                    int result = (x as OLVCardItem).Type.CompareTo((y as OLVCardItem).Type);
                    return SortOrder == SortOrder.Ascending ? result : result * -1;
                }
            }

            private class SetComparer : IComparer
            {
                public SortOrder SortOrder;

                public int Compare(object x, object y)
                {
                    int result = (x as OLVCardItem).Set.CompareTo((y as OLVCardItem).Set);
                    return SortOrder == SortOrder.Ascending ? result : result * -1;
                }
            }

            private class ManaCostComparer : IComparer
            {
                public SortOrder SortOrder;

                public int Compare(object x, object y)
                {
                    int result;
                    string valueX = (x as OLVCardItem).ManaCost ?? "";
                    string valueY = (y as OLVCardItem).ManaCost ?? "";
                    result = valueX.CompareTo(valueY);
                    return SortOrder == SortOrder.Ascending ? result : result * -1;
                }
            }
        }

        #endregion Classes
    }
}