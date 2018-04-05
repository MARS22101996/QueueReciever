using System.Runtime.Serialization;

namespace FortuneReceiver.DAL.Entities
{
   [DataContract(Name = "FortuneMessage", Namespace = "FortuneMessage")]
   public class FortuneMessage
   {
      [DataMember]
      public int Id { get; set; }

      [DataMember]
      public string Topic { get; set; }

      [DataMember]
      public string Body { get; set; }
   }
}