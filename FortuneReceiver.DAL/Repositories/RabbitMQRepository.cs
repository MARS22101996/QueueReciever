using System;
using System.Collections.Generic;
using System.Text;
using FortuneReceiver.DAL.Entities;
using FortuneReceiver.DAL.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace FortuneReceiver.DAL.Repositories
{
   public class RabbitMqRepository : IQueueRepository
   {
      private const string QueueName = "hello";
      private const string RabitMqHostName = "localhost";
      private readonly IConnection _connection;

      public RabbitMqRepository()
      {
         _connection = GetConnection();
      }

      public IEnumerable<FortuneMessage> Recieve()
      {
         var messages = new List<FortuneMessage>();
         try
         {
            using (var channel = _connection.CreateModel())
            {
               channel.QueueDeclare(QueueName, false, false, false, null);
               var result = channel.BasicGet(QueueName, true);
               if (result != null)
               {
                  var jsonifiedMessage = Encoding.UTF8.GetString(result.Body);
                  var fortuneMessage = JsonConvert.DeserializeObject<FortuneMessage>(jsonifiedMessage);
                  messages.Add(fortuneMessage);
               }
            }
         }
         catch (Exception ex)
         {
            throw new Exception("Exception was throwed during recieving the message", ex);
         }

         return messages;
      }

      private IConnection GetConnection()
      {
         var factory = new ConnectionFactory
         {
            HostName = RabitMqHostName,
         };

         return factory.CreateConnection();
      }
   }
}
