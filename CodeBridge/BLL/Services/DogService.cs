using CodeBridge.BLL.Interfaces;
using CodeBridge.DAL;
using CodeBridge.DAL.Interfaces;
using CodeBridge.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace CodeBridge.BLL.Services
{
    public class DogService : IDogService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly List<string> possibleAttributes = new() { "name", "color", "tail_length", "weight"};

        public DogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> PingAsync()
        {
            return "Dogs house service. Version 1.0.1";
        }

        public async Task<List<Dog>> GetDogsAsync(string attribute, string order, int pageNumber, int limit)
        {
            var dogsDbSet = _unitOfWork.Dogs.GetAllRaw();

            IQueryable<Dog> dogsQueryable = dogsDbSet;

            int dogsToSkip = (pageNumber - 1) * limit;

            if (possibleAttributes.Contains(attribute) && (order == "desc" || order == "asc"))
            {
                string orderByExpression = $"{attribute} {(order == "desc" ? "descending" : "ascending")}";

                dogsQueryable = dogsDbSet.OrderBy(orderByExpression);
            }

            var dogs = await dogsQueryable.Skip(dogsToSkip).Take(limit).ToListAsync();
            
            return dogs;
        }

        public async Task<bool> PostDog(Dog dogRequest)
        {
            bool result = false;

            Dog dog = new()
            {
                Id = new Guid(),
                Name = dogRequest.Name,
                Color = dogRequest.Color,
                Tail_length = dogRequest.Tail_length,
                Weight = dogRequest.Weight
            };

            var checkDog = _unitOfWork.Dogs.GetAllRaw().Any(d => d.Equals(dog));

            if (!checkDog)
            {
                result = await _unitOfWork.Dogs.CreateAsync(dog);
                await _unitOfWork.SaveChangesAsync();
            }
            
            return result;
        }
    }
}
