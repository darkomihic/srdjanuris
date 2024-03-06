using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PurchaseService.Data.Interface;
using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;
using PurchaseService.Data.Interface;
using PurchaseService.Entities;
using PurchaseService.Entities.Confirmations;

namespace RatingService.Data.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public DeliveryRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public DeliveryConfirmation CreateDelivery(Delivery delivery)
        {
            var createdEntity = context.Delivery.Add(delivery);
            context.SaveChanges();
            return mapper.Map<DeliveryConfirmation>(createdEntity.Entity);
        }

        public Delivery GetDeliveryById(Guid deliveryId)
        {
            return context.Delivery.FirstOrDefault(e => e.deliveryId == deliveryId);
        }

        public void DeleteDelivery(Guid deliveryId)
        {
            var delivery = GetDeliveryById(deliveryId);
            if (delivery != null)
            {
                context.Delivery.Remove(delivery);
                context.SaveChanges();
            }
        }

        public List<Delivery> GetDeliverys()
        {
            return context.Delivery.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Delivery UpdateDelivery(Delivery delivery)
        {
            try
            {
                var existingDelivery = context.Delivery.FirstOrDefault(e => e.deliveryId == delivery.deliveryId);
                if (existingDelivery != null)
                {
                    existingDelivery.price = delivery.price;

                    context.SaveChanges();
                    return existingDelivery;
                }
                else
                {
                    throw new KeyNotFoundException($"Delivery with ID {delivery.deliveryId} not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
