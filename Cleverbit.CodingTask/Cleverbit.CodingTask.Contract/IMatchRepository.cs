using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Data.Models;

namespace Cleverbit.CodingTask.Contract
{
    public interface IMatchRepository
    {
        /// <summary>
        /// Gets All matches
        /// </summary>
        /// <returns>Match List</returns>
        Task<List<Match>> GetAllMatches();

        /// <summary>
        /// Gets matches of spesific user by user Id
        /// </summary>
        /// <param name="userId">User Id </param>
        /// <returns>Match List</returns>
        Task<List<Match>> GetMatchesByUserId(int userId);

        Match CreateMatch(int firstUserId, int secondUserId);

        Task<int> UpdateMatchDetail(int matchDetailId, int userId, short number);

        Task<Match> GetMatch(int matchId);

    }
}
