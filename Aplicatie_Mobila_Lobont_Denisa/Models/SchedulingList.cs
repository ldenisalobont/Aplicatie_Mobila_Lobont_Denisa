using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Aplicatie_Mobila_Lobont_Denisa.Models
{
    public class SchedulingList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
