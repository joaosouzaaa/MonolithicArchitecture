﻿using MonolithicArchitecture.API.Entities;

namespace MonolithicArchitecture.API.Interfaces.Repositories;
public interface ISpecialityRepository
{
    Task<bool> AddAsync(Speciality speciality);
    Task<bool> ExistsAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<List<Speciality>> GetAllAsync();
    Task<Speciality?> GetByIdAsync(int id);
}
