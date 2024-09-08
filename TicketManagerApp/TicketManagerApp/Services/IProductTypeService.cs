﻿using TicketManager.Models.Models;

namespace TicketManagerApp.Services.ProductTypeServices
{
    public interface IProductTypeService
    {
        public Task <List<ProductType>> GetAllProductTypesByFamilyId(int familyId);
    }
}