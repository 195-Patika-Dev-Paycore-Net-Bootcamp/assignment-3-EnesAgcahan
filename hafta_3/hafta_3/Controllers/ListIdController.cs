using EnesAgcahan_Hafta3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EnesAgcahan_Hafta3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListIdController : ControllerBase
    {

        private readonly IMapperSession session;
        public ListIdController(IMapperSession session)
        {
            this.session = session;
        }
        [HttpGet("{Cluster}")]


        public ActionResult<List<List<container>>> GetContainerPiecesByVehicleId(int vehicleId, int pieces)
        {

            List<container> result = session.Containers.Where(x => x.vehicleid == vehicleId).ToList();
            List<List<container>> division = new List<List<container>>(pieces);
            division = result.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Index % pieces).Select(x => x.Select(c => c.Value).ToList()).ToList();

            return Ok(division);
        }
    }
}
