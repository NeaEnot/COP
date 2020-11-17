using _4thLabComponents;
using CourierBusinessLogic.Interfaces;
using CourierDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourierDatabaseImplement.Implements
{
    public class DeliveryActLogic : IDeliveryActLogic
    {
        private CacheComponent<DeliveryAct> cache = new CacheComponent<DeliveryAct>();
        private bool isDisconnected = false;

        public void Create(CourierBusinessLogic.Models.DeliveryAct act)
        {
            try
            {
                if (isDisconnected)
                {
                    RestoreFromCache();
                }

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
                    element.PromoEffects = act.PromoEffects;

                    context.SaveChanges();

                    List<DeliveryAct> list = cache.Elements;
                    list.Add(element);
                    cache.Elements = list;
                }
            }
            catch (DbUpdateException)
            {
                isDisconnected = true;

                DeliveryAct element = new DeliveryAct();

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
                        if (cache.Elements.FirstOrDefault(rec => rec.Id == element.Id) == null)
                        {
                            break;
                        }
                    }
                }

                element.CourierFIO = act.CourierFIO;
                element.DeliveryType = act.DeliveryType.Value;
                element.DeliveryDate = act.DeliveryDate;
                element.PromoEffects = act.PromoEffects;

                List<DeliveryAct> list = cache.Elements;
                list.Add(element);
                cache.Elements = list;

                throw new Exception("При работе с базой данных произошла ошибка. Изменения сохранены в кэш");
            }
        }

        public void Update(CourierBusinessLogic.Models.DeliveryAct act)
        {
            try
            {
                if (isDisconnected)
                {
                    RestoreFromCache();
                }

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
                    element.PromoEffects = act.PromoEffects;

                    context.SaveChanges();

                    List<DeliveryAct> list = cache.Elements;
                    DeliveryAct cacheElement = list.FirstOrDefault(rec => rec.Id == act.Id);

                    cacheElement.CourierFIO = act.CourierFIO;
                    cacheElement.DeliveryType = act.DeliveryType.Value;
                    cacheElement.DeliveryDate = act.DeliveryDate;
                    cacheElement.PromoEffects = act.PromoEffects;

                    cache.Elements = list;
                }
            }
            catch (DbUpdateException)
            {
                isDisconnected = true;

                List<DeliveryAct> list = cache.Elements;
                DeliveryAct element = list.FirstOrDefault(rec => rec.Id == act.Id);

                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }

                element.CourierFIO = act.CourierFIO;
                element.DeliveryType = act.DeliveryType.Value;
                element.DeliveryDate = act.DeliveryDate;
                element.PromoEffects = act.PromoEffects;

                cache.Elements = list;

                throw new Exception("При работе с базой данных произошла ошибка. Изменения сохранены в кэш");
            }
        }

        public void Delete(CourierBusinessLogic.Models.DeliveryAct act)
        {
            try
            {
                if (isDisconnected)
                {
                    RestoreFromCache();
                }

                using (var context = new CourierDatabase())
                {
                    DeliveryAct element = context.DeliveryActs.FirstOrDefault(rec => rec.Id == act.Id);

                    if (element != null)
                    {
                        context.DeliveryActs.Remove(element);
                        context.SaveChanges();

                        List<DeliveryAct> list = cache.Elements;
                        DeliveryAct cacheElement = list.FirstOrDefault(rec => rec.Id == act.Id);
                        list.Remove(cacheElement);
                        cache.Elements = list;
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
            }
            catch (DbUpdateException)
            {
                isDisconnected = true;

                List<DeliveryAct> list = cache.Elements;
                DeliveryAct element = list.FirstOrDefault(rec => rec.Id == act.Id);

                if (element != null)
                {
                    list.Remove(element);
                    cache.Elements = list;
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }

                throw new Exception("При работе с базой данных произошла ошибка. Изменения сохранены в кэш");
            }
        }

        public List<CourierBusinessLogic.Models.DeliveryAct> Read(CourierBusinessLogic.Models.DeliveryAct act)
        {
            try
            {
                if (isDisconnected)
                {
                    RestoreFromCache();
                }

                using (var context = new CourierDatabase())
                {
                    List<DeliveryAct> list = context.DeliveryActs
                    .Where(rec =>
                        (act == null) ||
                        (act.Id.HasValue && rec.Id == act.Id) ||
                        (act.DeliveryType.HasValue && rec.DeliveryType == act.DeliveryType &&
                            act.CourierFIO != "" && rec.CourierFIO == act.CourierFIO &&
                            act.DeliveryDate.HasValue && rec.DeliveryDate == act.DeliveryDate))
                    .ToList();

                    cache.Elements = list;

                    return list
                    .Select(rec => new CourierBusinessLogic.Models.DeliveryAct
                    {
                        Id = rec.Id,
                        CourierFIO = rec.CourierFIO,
                        DeliveryType = rec.DeliveryType,
                        DeliveryDate = rec.DeliveryDate,
                        PromoEffects = rec.PromoEffects
                    })
                    .ToList();
                }
            }
            catch
            {
                isDisconnected = true;

                return cache.Elements
                .Select(rec => new CourierBusinessLogic.Models.DeliveryAct
                {
                    Id = rec.Id,
                    CourierFIO = rec.CourierFIO,
                    DeliveryType = rec.DeliveryType,
                    DeliveryDate = rec.DeliveryDate,
                    PromoEffects = rec.PromoEffects
                })
                .ToList();
            }
        }

        private void RestoreFromCache()
        {
            using (var context = new CourierDatabase())
            {
                List<DeliveryAct> list = cache.Elements;
                List<int> ids = new List<int>();

                foreach (DeliveryAct item in cache.Elements)
                {
                    DeliveryAct element = context.DeliveryActs.FirstOrDefault(rec => rec.Id == item.Id);

                    if (element == null)
                    {
                        element = new DeliveryAct();
                        context.DeliveryActs.Add(element);
                        element.Id = item.Id;
                    }

                    element.CourierFIO = item.CourierFIO;
                    element.DeliveryType = item.DeliveryType;
                    element.DeliveryDate = item.DeliveryDate;
                    element.PromoEffects = item.PromoEffects;

                    ids.Add(element.Id);
                }

                List<DeliveryAct> listToRemove = context.DeliveryActs.Where(rec => !ids.Contains(rec.Id)).ToList();
                context.DeliveryActs.RemoveRange(listToRemove);
            }

            isDisconnected = false;
        }
    }
}
