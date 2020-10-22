using CourierBusinessLogic.Enums;
using System;

namespace CourierDatabaseImplement.Models
{
    public class DeliveryAct
    {
        public int Id { set; get; }

        public string CourierFIO { set; get; }

        public DeliveryType DeliveryType { set; get; }

        public DateTime? DeliveryDate { set; get; }
    }
}
