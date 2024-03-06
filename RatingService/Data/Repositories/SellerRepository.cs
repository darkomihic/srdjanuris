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
    public class SellerRepository : ISellerRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public SellerRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public SellerConfirmation CreateSeller(Seller seller)
        {
            var createdEntity = context.Seller.Add(seller);
            context.SaveChanges();
            return mapper.Map<SellerConfirmation>(createdEntity.Entity);
        }

        public Seller GetSellerById(Guid sellerId)
        {
            return context.Seller.FirstOrDefault(e => e.sellerId == sellerId);
        }

        public void DeleteSeller(Guid sellerId)
        {
            var seller = GetSellerById(sellerId);
            if (seller != null)
            {
                context.Seller.Remove(seller);
                context.SaveChanges();
            }
        }

        public List<Seller> GetSellers()
        {
            return context.Seller.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Seller UpdateSeller(Seller seller)
        {
            try
            {
                var existingSeller = context.Seller.FirstOrDefault(e => e.sellerId == seller.sellerId);
                if (existingSeller != null)
                {
                    existingSeller.username = seller.username;
                    existingSeller.email = seller.email;

                    context.SaveChanges();
                    return existingSeller;
                }
                else
                {
                    throw new KeyNotFoundException($"Seller with ID {seller.sellerId} not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
