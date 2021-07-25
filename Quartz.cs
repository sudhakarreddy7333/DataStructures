using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms
{
    public class Quartz
    {
        public DateTime? GetTime()
        {
            CronExpression cron = new CronExpression("0 0/5 * 1/1 * ? *");
            return cron.GetNextValidTimeAfter(DateTime.UtcNow)?.DateTime;
        }
    }
}
