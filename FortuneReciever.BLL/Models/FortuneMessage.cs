using System.Runtime.Serialization;

namespace FortuneReciever.BLL.Models
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