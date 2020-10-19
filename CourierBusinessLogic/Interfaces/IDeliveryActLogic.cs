using CourierBusinessLogic.Models;
using System.Collections.Generic;

namespace CourierBusinessLogic.Interfaces
{
    public interface IDeliveryActLogic
    {
        void CreateOrUpdate(DeliveryAct act);

        void Delete(DeliveryAct act);

        List<DeliveryAct> Read(DeliveryAct act);
    }
}
