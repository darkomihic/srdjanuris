using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RatingService.Data.Interface;
using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Data.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public BuyerRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;   
        }

        public BuyerConfirmation CreateBuyer(Buyer buyer)
        {
            var createdEntity = context.Buyer.Add(buyer);
            context.SaveChanges();
            return mapper.Map<BuyerConfirmation>(createdEntity.Entity);
        }

        public Buyer GetBuyerById(Guid buyerId)
        {
            return context.Buyer.FirstOrDefault(e => e.buyerId == buyerId);
        }

        public void DeleteBuyer(Guid buyerId)
        {
            var buyer = GetBuyerById(buyerId);
            if (buyer != null)
            {
                context.Buyer.Remove(buyer);
                context.SaveChanges();
            }
        }

        public List<Buyer> GetBuyers()
        {
            return context.Buyer.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Buyer UpdateBuyer(Buyer buyer)
        {
            try
            {
                var existingBuyer = context.Buyer.FirstOrDefault(e => e.buyerId == buyer.buyerId);
                if (existingBuyer != null)
                {
                    existingBuyer.username = buyer.username;
                    existingBuyer.email = buyer.email;

                    context.SaveChanges();
                    return existingBuyer;
                }
                else
                {
                    throw new KeyNotFoundException($"Buyer with ID {buyer.buyerId} not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
