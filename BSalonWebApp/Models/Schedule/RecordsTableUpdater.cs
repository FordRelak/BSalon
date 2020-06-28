using BSalonWebApp.Data;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BSalonWebApp.Models.Schedule
{
    public class RecordsTableUpdater : IHostedService
    {
        private readonly BSalonDbContext _context;
        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
           TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var lastDBRecord = _context.Records.ToList().Last();
            if (lastDBRecord.Time.Date < DateTime.Now.Date.AddDays(30))
            {
                for (int i = 1; i <= (DateTime.Now.Date.AddDays(30).Date - lastDBRecord.Time.Date).TotalDays; i++)
                {
                    var TempDay = new WorkDay(lastDBRecord.Time.Date.AddDays(i));
                    foreach (var item in TempDay.Records)
                        _context.Records.Add(item);
                    _context.SaveChanges();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public RecordsTableUpdater(BSalonDbContext context) =>
            _context = context;

    }
}
