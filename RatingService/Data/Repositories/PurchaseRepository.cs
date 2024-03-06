using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RatingService.Data.Interface;
using RatingService.Entities;

namespace RatingService.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly Context context;

        public PurchaseRepository(Context context)
        {
            this.context = context;
        }

        public Purchase CreatePurchase(Purchase purchase)
        {
            var createdEntity = context.Purchase.Add(purchase);
            context.SaveChanges();
            return createdEntity.Entity;
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
