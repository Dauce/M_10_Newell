using M_10_Newell.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace M_10_Newell.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private  BowlingLeagueContext _BowlContext;
        
        public BowlingController(BowlingLeagueContext temp)
        {
            _BowlContext = temp;
        }
        
        [HttpGet(Name = "GetBowlingLeague")]
public IEnumerable<object> Get()
{
    var bowlerList = _BowlContext.Bowlers
        .Include(b => b.Team)  // Load the related Team data
        .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")  // Filter by TeamName
        .Select(b => new
        {
            // Projecting the properties into a new anonymous object
            BowlerName = $"{b.BowlerFirstName} {b.BowlerMiddleInit} {b.BowlerLastName}", // Combine names
            TeamName = b.Team.TeamName, // Add TeamName from the related Team
            Address = b.BowlerAddress,
            City = b.BowlerCity,
            State = b.BowlerState,
            Zip = b.BowlerZip,
            PhoneNumber = b.BowlerPhoneNumber
        })
        .ToList();
    
    return bowlerList;
}
    }
}