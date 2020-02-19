﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerreraTeam.Services
{
    public interface IGenericRepository<T> where T : class
    {

    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(object id);
    void Insert(T obj);
    void Update(T obj);
    void Delete(object id);
    void Save();

    }
}