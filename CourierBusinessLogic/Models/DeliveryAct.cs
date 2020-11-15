using CourierBusinessLogic.Enums;
using System;

namespace CourierBusinessLogic.Models
{
    public class DeliveryAct : ICloneable
    {
        public int? id;
        public string courierFIO;
        public DeliveryType? deliveryType;
        public DateTime? deliveryDate;

        public int? Id { set { id = value; } get { return id; } }
        public string CourierFIO { set { courierFIO = value; } get { return courierFIO; } }
        public DeliveryType? DeliveryType { set { deliveryType = value; } get { return deliveryType; } }
        public DateTime? DeliveryDate { set { deliveryDate = value; } get { return deliveryDate; } }
        public string PromoEffects { get; set; }

        public object Clone()
        {
            return new DeliveryAct
            {
                id = id,
                courierFIO = courierFIO.Clone().ToString(),
                deliveryDate = deliveryDate,
                deliveryType = deliveryType
            };
        }
    }
}
