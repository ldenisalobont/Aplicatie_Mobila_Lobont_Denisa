using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Aplicatie_Mobila_Lobont_Denisa.Models
{
    public class ListService
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(SchedulingList))]
        public int SchedulingListID { get; set; }
        public int ServiceID { get; set; }
    }
}
