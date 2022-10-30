﻿using B.Models;

namespace B.Services
{
    public interface IDivisionService
    {
        Task<IEnumerable<DivisionModel>> GetAllData();
        Task<DivisionModel> AddDivisions(DivisionModel model);
        Task Synchronization();
    }
}
