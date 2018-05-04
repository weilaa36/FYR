using System;
using SQLite;

namespace FYR.Classes
{
    public class TableJournal
    {
        

        [MaxLength(160)]
        public string entry { get; set; }

    }
}