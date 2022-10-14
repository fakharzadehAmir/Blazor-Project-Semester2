using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P8.Server.DB;
using P8.Shared;

namespace P8.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstrumentController : ControllerBase
    {
        private readonly InstrumentProvider _provider;
        public InstrumentController(InstrumentProvider provider)
        {
            this._provider = provider;
        }
        [HttpPost]
        [Route("addNewInstrumentToDb")]
        public Instrument AddNewInstrumentToDB(Instrument newInstrument)
        {
            this._provider.AddInstrument(newInstrument);
            return newInstrument;
        }
        [HttpPut]
        [Route("updateInstrumentInDB")]
        public Instrument UpdateInstrumentinDB(Instrument newInstrument)
        {
            this._provider.UpdateInstrument(newInstrument);
            return newInstrument;
        }
        [HttpDelete]
        [Route("removeInstrumentFromDB")]
        public Instrument RemoveInstrumentinDB(Instrument newInstrument)
        {
            this._provider.RemoveInstrument(newInstrument);
            return newInstrument;
        }
        [HttpGet]
        [Route("GetAllInstrumentFromDb")]
        public List<Instrument> GetAllInstrumentFromDb() =>
            this._provider.GetAllInstrument();
    }
}