using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Contract;
using Cleverbit.CodingTask.Data;
using Cleverbit.CodingTask.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cleverbit.CodingTask.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly CodingTaskContext _context;

        public MatchRepository(CodingTaskContext context)
        {
            _context = context;
        }

        public Task<List<Match>> GetAllMatches()
        {
            return _context.Matches.ToListAsync();
        }

        public Task<List<Match>> GetMatchesByUserId(int userId)
        {
            Task<List<Match>> matches = _context.MatchDetails.Where(m => m.UserId == userId).Select(m => m.Match).ToListAsync();
            return matches;
        }

        public Match CreateMatch(int firstUserId, int secondUserId)
        {
            var currentDate = DateTime.UtcNow;

            Match match = new Match()
            {
                CreatedDate = currentDate,
                ExpireDate = currentDate.AddMinutes(5)
            };
            match.MatchDetails.Add(CreateNewMatchDetail(firstUserId, currentDate));
            match.MatchDetails.Add(CreateNewMatchDetail(secondUserId, currentDate));

            _context.Add(match);
            _context.SaveChangesAsync();
            return match;
        }

        public Task<int> UpdateMatchDetail(int matchDetailId, int userId, short number)
        {
            var matchDetail = _context.MatchDetails.FirstOrDefault(m => m.Id == matchDetailId  && m.UserId == userId);
            matchDetail.Number = number;
            _context.Attach(matchDetail).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task<Match> GetMatch(int matchId)
        {
            return _context.Matches.FirstOrDefaultAsync(m => m.Id == matchId);
        }

        /// <summary>
        /// Creates new match details 
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="currentDate">Creation Date</param>
        /// <returns></returns>
        private MatchDetail CreateNewMatchDetail(int userId, DateTime currentDate)
        {
            return new MatchDetail()
            {
                UserId = userId,
                CreatedDate = currentDate,
                Number = -1
            };
        }
    }
}
