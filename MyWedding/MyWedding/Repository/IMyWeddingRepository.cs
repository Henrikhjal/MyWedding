using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWedding.Repository
{
    public interface IMyWeddingRepository
    {
        void AddMessage(MyWedding.Models.Message message);

    }
}
