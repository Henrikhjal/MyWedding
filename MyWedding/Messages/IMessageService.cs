using System.Collections.Generic;
using System.ServiceModel;
using MyWedding.Models;

namespace Services
{
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        List<Message> GetMessages();

        [OperationContract]
        Message GetMessageById(int Id);

        [OperationContract]
        void AddMessage(Message message);
    }
}
