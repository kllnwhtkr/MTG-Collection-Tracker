﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTG_Collection_Tracker
{
    public class FullInventoryCard : MagicCardBase
    {
        [Key]
        public int          InventoryId { get; set; }
        public int?         CatalogID { get; set; }
        public int          CollectionId { get; set; }
        public new int      multiverseId { get; set; }
        public int?         Count { get; set; }
        public double?      Cost { get; set; }
        public string       Tags { get; set; }
        private DateTime?   _timeAdded;
        public DateTime?    TimeAdded { get => _timeAdded; set { _timeAdded = value; UpdateSortableTimeAdded(); } }
        private int?        _insertionIndex;
        public int?         InsertionIndex { get => _insertionIndex; set { _insertionIndex = value; UpdateSortableTimeAdded();  } }
        [NotMapped]
        public String       SortableTimeAdded { get; set; }                            
        [NotMapped]
        public string       ImageKey => $"{Edition}: {rarity}";
        [NotMapped]
        public string       PaddedName => name.PadRight(500);
        [NotMapped]
        public InventoryCard InventoryCard
        {
            get
            {
                return new InventoryCard
                {
                    CatalogID = CatalogID,
                    CollectionId = CollectionId,
                    Cost = Cost,
                    Count = Count,
                    InsertionIndex = InsertionIndex,
                    InventoryId = InventoryId,
                    multiverseId_Inv = multiverseId,
                    Tags = Tags,
                    TimeAdded = TimeAdded,
                    uuid = uuid
                };
            }
        }

        private void UpdateSortableTimeAdded()
        {
            if (TimeAdded.HasValue) SortableTimeAdded = $"{ TimeAdded.Value.ToString("s") } { InsertionIndex.ToString().PadLeft(5) }";
            //else return "";
        }
    }
}