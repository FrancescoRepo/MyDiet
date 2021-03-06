﻿using MyDiet.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Business.IRepository
{
    public interface IPatientRepository : IRepository<PatientDto>
    {
        public Task DisassociateDiet(int id);
    }
}
