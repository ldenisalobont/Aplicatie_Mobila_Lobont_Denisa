using System;
using System.Collections.Generic;
using System.Text;
using Aplicatie_Mobila_Lobont_Denisa.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace Nume_Pren_Lab10.Models
{
    public class Service
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        [OneToMany]
        public List<ListService> ListServices { get; set; }
    }
}