using System.ComponentModel.Composition;
using PluginConfiguration.Interfaces;
using CourierBusinessLogic.Models;

namespace DeliveryDateChanger
{
    [Export(typeof(IModifier))]
    public class DeliveryDateChanger : IModifier
    {
        public string Name => "Перенос даты доставки";

        public void Modify(DeliveryAct act, string value)
        {
            int days = int.Parse(value);
            if (act.DeliveryDate.HasValue)
            {
                act.DeliveryDate = act.DeliveryDate.Value.AddDays(days);
            }
        }
    }
}
