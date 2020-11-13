using CourierBusinessLogic.Interfaces;
using CourierDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourierDatabaseImplement.Implements
{
    public class DeliveryActLogic : IDeliveryActLogic
    {
        public void Create(CourierBusinessLogic.Models.DeliveryAct act)
        {
            using (var context = new CourierDatabase())
            {
                DeliveryAct element = new DeliveryAct();
                context.DeliveryActs.Add(element);

                if (act.Id.HasValue)
                {
                    element.Id = act.Id.Value;
                }
                else
                {
                    Random rnd = new Random();
                    while (true)
                    {
                        element.Id = rnd.Next(0, int.MaxValue);
                        if (context.DeliveryActs.FirstOrDefault(rec => rec.Id == element.Id) == null)
                        {
                            break;
                        }
                    }
                }

                element.CourierFIO = act.CourierFIO;
                element.DeliveryType = act.DeliveryType.Value;
                element.DeliveryDate = act.DeliveryDate;

                context.SaveChanges();
            }
        }

        public void Update(CourierBusinessLogic.Models.DeliveryAct act)
        {
            using (var context = new CourierDatabase())
            {
                DeliveryAct element = context.DeliveryActs.FirstOrDefault(rec => rec.Id == act.Id);

                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }

                element.CourierFIO = act.CourierFIO;
                element.DeliveryType = act.DeliveryType.Value;
                element.DeliveryDate = act.DeliveryDate;

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
                    (act.Id.HasValue && rec.Id == act.Id) ||
                    (   act.DeliveryType.HasValue && rec.DeliveryType == act.DeliveryType && 
                        act.CourierFIO != "" && rec.CourierFIO == act.CourierFIO && 
                        act.DeliveryDate.HasValue && rec.DeliveryDate == act.DeliveryDate))
                .Select(rec => new CourierBusinessLogic.Models.DeliveryAct
                {
                    Id = rec.Id,
                    CourierFIO = rec.CourierFIO,
                    DeliveryType = rec.DeliveryType,
                    DeliveryDate = rec.DeliveryDate
                })
                .ToList();
            }
        }
    }
}
