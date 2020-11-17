using CourierBusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierDatabaseImplement.Models
{
    public class DeliveryAct : ICloneable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }

        public string CourierFIO { set; get; }

        public DeliveryType DeliveryType { set; get; }

        public DateTime? DeliveryDate { set; get; }

        public string PromoEffects { get; set; }

        public object Clone()
        {
            return new DeliveryAct
            {
                Id = Id,
                CourierFIO = CourierFIO,
                DeliveryType = DeliveryType,
                DeliveryDate = DeliveryDate,
                PromoEffects = PromoEffects
            };
        }
    }
}
