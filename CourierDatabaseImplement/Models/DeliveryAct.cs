using CourierBusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierDatabaseImplement.Models
{
    public class DeliveryAct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }

        public string CourierFIO { set; get; }

        public DeliveryType DeliveryType { set; get; }

        public DateTime? DeliveryDate { set; get; }

        public string PromoEffects { get; set; }
    }
}
