
using System;

namespace Cleverbit.CodingTask.Data.Models
{
    public class MatchDetail
    {
        public int Id { get; set; }
        public int MatchId { get; set; }

        public Match Match { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public short Number { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
