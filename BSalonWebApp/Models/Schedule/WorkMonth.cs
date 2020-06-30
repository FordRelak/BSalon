using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSalonWebApp.Models.Schedule
{
    public class WorkMonth
    {
        public List<WorkDay>[] WorkDays = new List<WorkDay>[4];
    }
}
