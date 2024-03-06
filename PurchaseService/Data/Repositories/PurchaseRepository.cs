using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;
using PurchaseService.Data.Interface;
using PurchaseService.Entities;
using PurchaseService.Entities.Confirmations;
using RatingService.Data;

namespace PurchaseService.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PurchaseRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PurchaseConfirmation CreatePurchase(Purchase purchase)
        {
            var createdEntity = context.Purchase.Add(purchase);
            context.SaveChanges();
            return mapper.Map<PurchaseConfirmation>(createdEntity.Entity);
        }

        public Purchase GetPurchaseById(Guid purchaseId)
        {
            return context.Purchase.FirstOrDefault(e => e.purchaseId == purchaseId);
        }

        public void DeletePurchase(Guid purchaseId)
        {
            var purchase = GetPurchaseById(purchaseId);
            if (purchase != null)
            {
                context.Purchase.Remove(purchase);
                context.SaveChanges();
            }
        }

        public List<Purchase> GetPurchases()
        {
            return context.Purchase.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Purchase UpdatePurchase(Purchase purchase)
        {
            try
            {
                var existingPurchase = context.Purchase.FirstOrDefault(e => e.purchaseId == purchase.purchaseId);
                if (existingPurchase != null)
                {
                    existingPurchase.date = purchase.date;
                    existingPurchase.price = purchase.price;
                    existingPurchase.deliveryId = purchase.deliveryId;
                    existingPurchase.buyerId = purchase.buyerId;
                    existingPurchase.postId = purchase.postId;

                    context.SaveChanges();
                    return existingPurchase;
                }
                else
                {
                    throw new KeyNotFoundException($"Purchase with ID {purchase.purchaseId} not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
