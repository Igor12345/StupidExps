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
      //https://learn.microsoft.com/en-us/azure/app-service/webjobs-sdk-how-to#custom-binding-expressions
      public static void ProcessQueueMessage([QueueTrigger("%customqueue%")] string message, ILogger logger)
      {
         logger.LogWarning(message);
      }


      // public static void ProcessQueueMessage2([QueueTrigger("cool-queue")] string message, ILogger logger)
      // {
      //    logger.LogWarning(message);
      // }
   }
}
