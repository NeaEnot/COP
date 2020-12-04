using System.ComponentModel.Composition;
using PluginConfiguration.Interfaces;
using CourierBusinessLogic.Models;
using System.Windows.Forms;

namespace DeliveryTypeChanger
{
    [Export(typeof(IChanger))]
    public class DeliveryTypeChanger : IChanger
    {
        public string Name => "Изменение типа доставки";

        public Form ChangeForm(DeliveryAct act)
        {
            return new FormChangeType(act);
        }
    }
}
