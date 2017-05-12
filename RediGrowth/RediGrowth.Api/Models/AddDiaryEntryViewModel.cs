using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RediGrowth.Api.Models
{
    public class AddDiaryEntryViewModel
    {
        public class DiaryNote
        {
            public Guid Id { get; set; }
            public string Text { get; set; }
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid PersonId { get; set; }
        public int Rating { get; set; }
        public List<DiaryNote> Notes { get; set; }
    }
}
