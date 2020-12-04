using CourierBusinessLogic.Models;
using System.Windows.Forms;

namespace PluginConfiguration.Interfaces
{
    public interface IChanger
    {
        string Name { get; }

        Form ChangeForm(DeliveryAct act);
    }
}
