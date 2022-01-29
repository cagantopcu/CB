
using System;
using System.Collections.Generic;

namespace Cleverbit.CodingTask.Data.Models
{
    public class Match
    {
        public int Id { get; set; }

        public DateTime ExpireDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<MatchDetail> MatchDetails { get; set; }
    }
}
