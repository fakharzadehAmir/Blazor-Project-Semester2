using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using P8.Server.Controllers;
using P8.Shared;
using System.Linq;

namespace P8.Server.DB
{
    public class InstrumentProvider
    {
        private readonly InstrumentDbContext _context;
        private readonly ILogger _logger;
        public InstrumentProvider(InstrumentDbContext context, ILoggerFactory LoggerFactory)
        {
            this._context = context;
            this._logger = LoggerFactory.CreateLogger("InstrumentProvider");
        }
        public void AddInstrument(Instrument instrument)
        {
            if(this._context.Instruments == null)
                instrument.Id = 1;
            if(this._context.Instruments != null)
                instrument.Id = this._context.Instruments.Select(a => a.Id).Max() + 1;
            _context.Instruments.Add(instrument);
            _context.SaveChanges();
        }
        public void UpdateInstrument(Instrument instrument)
        {
            if(this._context.Instruments != null)
                this._context.Instruments.Update(instrument);
            _context.SaveChanges();
        }
        public void RemoveInstrument(Instrument instrument)
        {
            if(this._context.Instruments != null)
                this._context.Instruments.Remove(instrument);
            _context.SaveChanges();
        }
        public List<Instrument> GetAllInstrument() =>
            this._context.Instruments.OrderBy(ins => ins.Id).ToList();
    }
}