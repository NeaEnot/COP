using CourierBusinessLogic.Models;

namespace PluginConfiguration.Interfaces
{
    public interface IPrinter
    {
        string Name { get; }

        void Print(DeliveryAct act);
    }
}
