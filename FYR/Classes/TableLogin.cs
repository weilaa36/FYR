using System;
using SQLite;

namespace FYR.Classes
{
    class TableLogin
    {
        [PrimaryKey, AutoIncrement, Column("_ID")]
        public int id { get; set; }

        [MaxLength(25)]
        public string username { get; set; }

        [MaxLength(25)]
        public string email { get; set; }

        [MaxLength(15)]
        public string password { get; set; }
    }
}
   
    

