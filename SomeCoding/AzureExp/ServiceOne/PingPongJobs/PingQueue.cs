using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongJobs
{
   public class PingQueue
   {
      public static void ProcessQueueMessage([QueueTrigger("cool-queue")] string message, ILogger logger)
      {
         logger.LogWarning(message);
      }
   }
}
