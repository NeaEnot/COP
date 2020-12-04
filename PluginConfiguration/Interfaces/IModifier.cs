using CourierBusinessLogic.Models;

namespace PluginConfiguration.Interfaces
{
    public interface IModifier
    {
        string Name { get; }

        void Modify(DeliveryAct act, string value);
    }
}
