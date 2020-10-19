using CourierBusinessLogic.Interfaces;
using CourierDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDatabaseImplement.Implements
{
    public class DeliveryActLogic : IDeliveryActLogic
    {
        public void CreateOrUpdate(CourierBusinessLogic.Models.DeliveryAct act)
        {
            using (var context = new CourierDatabase())
            {
                DeliveryAct element;

                if (act.Id.HasValue)
                {
                    element = context.DeliveryActs.FirstOrDefault(rec => rec.Id == act.Id);

                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new DeliveryAct();
                    context.DeliveryActs.Add(element);
                }

                element.CourierFIO = act.CourierFIO;
                element.DeliveryType = act.DeliveryType.Value;
                element.Count = act.Count;

                context.SaveChanges();
            }
        }

        public void Delete(CourierBusinessLogic.Models.DeliveryAct act)
        {
            using (var context = new CourierDatabase())
            {
                DeliveryAct element = context.DeliveryActs.FirstOrDefault(rec => rec.Id == act.Id);

                if (element != null)
                {
                    context.DeliveryActs.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<CourierBusinessLogic.Models.DeliveryAct> Read(CourierBusinessLogic.Models.DeliveryAct act)
        {
            using (var context = new CourierDatabase())
            {
                return context.DeliveryActs
                .Where(rec =>
                    (act == null) ||
                    (rec.Id == act.Id) ||
                    (act.DeliveryType.HasValue && rec.DeliveryType == act.DeliveryType) ||
                    (act.CourierFIO != "" && rec.CourierFIO == act.CourierFIO)
                )
                .Select(rec => new CourierBusinessLogic.Models.DeliveryAct
                {
                    Id = rec.Id,
                    CourierFIO = rec.CourierFIO,
                    DeliveryType = rec.DeliveryType,
                    Count = rec.Count
                })
                .ToList();
            }
        }
    }
}
