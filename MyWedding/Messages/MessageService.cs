using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWedding.Models;
using MyWedding.Repository;
using System.ServiceModel;

namespace Services
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class MessageService : IMessageService
    {
        private readonly IMyWeddingRepository _MyWeddingRepository;
        private readonly MyWeddingRepositoryDb _rep;

        public MessageService() //IMyWeddingRepository myWeddingRepository)
        {
            // IMyWeddingRepository _MyWeddingRepositoryDb;
            _rep = new MyWeddingRepositoryDb();

            _MyWeddingRepository = _rep; //  myWeddingRepository;
        }

        public void AddMessage(Message message)
        {
            message.Date = DateTime.Now;
            _MyWeddingRepository.AddMessage(message);
        }

        public Message GetMessageById(int Id)
        {
            return (_MyWeddingRepository.GetMessageById(Id));
        }

        public List<Message> GetMessages()
        {
            return (_MyWeddingRepository.GetAllMessages());
        }
    }
}
