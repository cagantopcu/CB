using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cleverbit.CodingTask.Contract;
using Cleverbit.CodingTask.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepository _matchRepository;

        public MatchController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        // GET api/match/
        [HttpGet("GetAllMatches")]
        public async Task<List<Match>> GetAllMatches()
        {
            var matches = await _matchRepository.GetAllMatches();
            return matches;
        }

        // GET api/match/
        [HttpPost("CreateMatch")]
        public Match CreateMatch(int firstUserId, int secondUserId)
        {
            Match match = _matchRepository.CreateMatch(firstUserId, secondUserId);
            return match;
        }

        [HttpGet("GetMyMatches")]
        public async Task<List<Match>> GetMyMatches()
        {
            var matches = await _matchRepository.GetMatchesByUserId(GetCurrentUser());
            return matches;
        }


        [HttpPost("Match")]
        public async Task<int> Match(int matchDetailId, short number)
        {
            var result = await _matchRepository.UpdateMatchDetail(matchDetailId, GetCurrentUser(), number);
            return result;
        }

        private int GetCurrentUser()
        {
            int currentUserId;
            int.TryParse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value, out currentUserId);
            return currentUserId;
        }
    }

}
