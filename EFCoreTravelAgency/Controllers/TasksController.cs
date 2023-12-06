using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EfCore_Travel_Agency;
using static VatVerifier;


namespace EFCoreTravelAgency.Controllers
{
    [ApiController]
    [Route("api/Invoices")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TasksController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet("task1A/{minOccurences:int}")]
        public async Task<ActionResult<List<string>>> Task1A(int minOccurences)
        {
            var guestNames = await _context.Invoices
                .SelectMany(i => i.Observations)
                .GroupBy(o => o.GuestName)
                .Where(g => g.Count() >= minOccurences)
                .Select(g => new
                {
                    GuestName = g.Key,
                    TotalObservations = g.Count()
                })
                .ToListAsync();

            if (guestNames.Count == 0) return NotFound(); 

            return Ok(guestNames);

        }


        [HttpGet("task1B/{issueYear:int}")]
        public async Task<ActionResult> Task1B(int issueYear)
        {
            var travelAgents = await _context.InvoiceGroups
                .Where(ig => ig.IssueDate.Year == issueYear)
                .SelectMany(ig => ig.InvoiceGroupLinks)
                .Select(igl => igl.Invoice)
                .SelectMany(i => i.Observations)
                .GroupBy(o => o.TravelAgent)
                .Select(t => new
                {
                    TravelAgent = t.Key,
                    TotalNumberOfNights = t.Sum(t => t.NumberOfNights)
                })
                .ToListAsync();

            if (travelAgents.Count == 0) return NotFound();

            return Ok(travelAgents);

        }


        [HttpGet("task1C")]
        public async Task<ActionResult> Task1C()
        {
            var travelAgents = await _context.TravelAgentsInfo
                .FromSqlRaw("SELECT DISTINCT TravelAgentsInfo.* FROM TravelAgentsInfo " +
                                "LEFT JOIN Observations ON TravelAgentsInfo.TravelAgent = Observations.TravelAgent " +
                                "WHERE Observations.GuestName IS NULL OR Observations.GuestName = ''")
                .ToListAsync();
            
            if (travelAgents.Count == 0) return NotFound(); 

          

            return Ok(travelAgents);
;
            // SELECT * FROM TravelAgentsInfo 
            //      LEFT JOIN Observations ON TravelAgentsInfo.TravelAgent = Observations.TravelAgent
            //      WHERE GuestName IS NULL;



        }


        [HttpGet("task1D")]
        public async Task<ActionResult> Task1D()
        {
            var travelAgents = await _context.TravelAgentsInfo
                .FromSqlRaw("SELECT * FROM TravelAgentsInfo " +
                                "WHERE 2 < (SELECT COUNT(*) FROM Observations " +
                                "WHERE Observations.TravelAgent = TravelAgentsInfo.TravelAgent)")
                .ToListAsync();

            if (travelAgents.Count == 0) return NotFound();

            return Ok(travelAgents);


            // SELECT * FROM TravelAgentsInfo
            // WHERE 2 <
            //    (SELECT COUNT(*) FROM Observations
            //     WHERE Observations.TravelAgent = TravelAgentsInfo.TravelAgent);


        }


        [HttpGet("VatVerification/{countryCode}/{vatId}")]
        public async Task<ActionResult> VatVerification(string countryCode, string vatId)
        {
            VerificationStatus response = await VerifyAsync(countryCode, vatId);

            return Ok(response);


        }



    }
}
