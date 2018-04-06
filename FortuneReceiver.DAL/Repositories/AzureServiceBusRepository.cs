using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using FortuneReceiver.DAL.Entities;
using FortuneReceiver.DAL.Interfaces;
using Microsoft.ServiceBus.Messaging;

namespace FortuneReceiver.DAL.Repositories
{
   public class AzureServiceBusRepository : IQueueRepository
   {
      private const string QueueName = "queue-maria";
      private const int MessageCount = 1;

      private readonly Lazy<string> _connectionServiceBus =
      new Lazy<string>(GetServiceBusConnection);

      private QueueClient _client;

      public AzureServiceBusRepository()
      {
         InitializeQueueClient();
      }

      public IEnumerable<FortuneMessage> Recieve()
      {
         var messages = _client.ReceiveBatch(MessageCount).ToList();

         var recievedMessages = new List<FortuneMessage>();

         ConfigureFortuneMessages(messages, recievedMessages);

         return recievedMessages;
      }

      private static void ConfigureFortuneMessages(
         List<BrokeredMessage> messages,
         List<FortuneMessage> recievedMessages)
      {
         if (messages.Count == 0)
         {
            return;
         }

         foreach (var item in messages)
         {
            recievedMessages.Add(item.GetBody<FortuneMessage>());
            item.Complete();
         }
      }

      private static string GetServiceBusConnection()
      {
         try
         {
            var connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            return connectionString ?? string.Empty;
         }
         catch (ConfigurationErrorsException ex)
         {
            throw new Exception("Cannot read connection string from the config file", ex);
         }
      }

      private void InitializeQueueClient()
      {
         _client = QueueClient.CreateFromConnectionString(_connectionServiceBus.Value, QueueName);
      }
   }
}
