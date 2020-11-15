using System;
using System.Collections.Generic;
using System.Linq;
using AlocaGFT.Data.Repositories.Generics;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Repositories
{
    public class CargoRepository : CrudRepository<Cargo>, ICargoRepository
    {
        public CargoRepository(AlocaGFTDbContext context) : base(context)
        {}
    }
}