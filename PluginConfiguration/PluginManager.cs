using CourierBusinessLogic.Models;
using PluginConfiguration.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PluginConfiguration
{
    public class PluginManager
    {
        public delegate Form FormDelegate(DeliveryAct act);

        [ImportMany(typeof(IChanger))]
        IEnumerable<IChanger> Changers { get; set; }

        [ImportMany(typeof(IModifier))]
        IEnumerable<IModifier> Modifiers { get; set; }

        [ImportMany(typeof(IPrinter))]
        IEnumerable<IPrinter> Printers { get; set; }

        public readonly Dictionary<string, FormDelegate> ChangersDict = new Dictionary<string, FormDelegate>();
        public readonly Dictionary<string, Action<DeliveryAct, string>> ModifiersDict = new Dictionary<string, Action<DeliveryAct, string>>();
        public readonly Dictionary<string, Action<DeliveryAct>> PrintersDict = new Dictionary<string, Action<DeliveryAct>>();

        public List<string> Headers { get; set; } = new List<string>();

        public PluginManager()
        {
            try
            {
                AggregateCatalog catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins")));
                CompositionContainer container = new CompositionContainer(catalog);
                container.ComposeParts(this);
                if (Changers.Count() != 0)
                {
                    Changers.ToList().ForEach(p =>
                    {
                        ChangersDict.Add(p.Name, p.ChangeForm);
                        Headers.Add(p.Name);
                    });
                }
                if (Modifiers.Count() != 0)
                {
                    Modifiers.ToList().ForEach(p =>
                    {
                        ModifiersDict.Add(p.Name, p.Modify);
                        Headers.Add(p.Name);
                    });
                }
                if (Printers.Count() != 0)
                {
                    Printers.ToList().ForEach(p =>
                    {
                        PrintersDict.Add(p.Name, p.Print);
                        Headers.Add(p.Name);
                    });
                }
            }
            catch (ChangeRejectedException ex)
            {
                Debug.WriteLine(ex.Message);
                foreach (var error in ex.Errors)
                    Debug.WriteLine(error.Element.DisplayName + " " + error.Description);
            }
        }
    }
}
