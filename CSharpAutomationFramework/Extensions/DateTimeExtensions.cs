using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAutomationFramework.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool RetryUntilSuccessOrTimeout(this TimeSpan timeOut, Func<bool> task)
        {
            var success = false;
            var endTime = DateTime.Now.Add(timeOut);
            while ((!success) && (DateTime.Now < endTime))
            {
                success = task?.Invoke() ?? default(bool);
                Thread.Sleep(1000);
            }

            return success;
        }
    }
}
