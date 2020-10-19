using CourierBusinessLogic.Enums;

namespace CourierBusinessLogic.Models
{
    public class DeliveryAct
    {
        public int? Id { set; get; }

        public string CourierFIO { set; get; }

        public DeliveryType? DeliveryType { set; get; }

        public decimal Count { set; get; }
    }
}
