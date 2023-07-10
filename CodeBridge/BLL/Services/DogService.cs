using AutoMapper;
using CodeBridge.BLL.Interfaces;
using CodeBridge.DAL;
using CodeBridge.DAL.Interfaces;
using CodeBridge.Entities;
using CodeBridge.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace CodeBridge.BLL.Services
{
    public class DogService : IDogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly List<string> possibleAttributes = new() { "name", "color", "tail_length", "weight"};

        public DogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> PingAsync()
        {
            return "Dogs house service. Version 1.0.1";
        }

        public async Task<IEnumerable<DogDTO>> GetDogsAsync(string attribute, string order, int pageNumber, int limit)
        {
            var dogsDbSet = await _unitOfWork.Dogs.GetAllAsync();

            int dogsToSkip = (pageNumber - 1) * limit;

            if (possibleAttributes.Contains(attribute) && (order == "desc" || order == "asc"))
            {
                string orderByExpression = $"{attribute} {(order == "desc" ? "descending" : "ascending")}";

                dogsDbSet = dogsDbSet.AsQueryable().OrderBy(orderByExpression);
            }

            var dogs = dogsDbSet.Skip(dogsToSkip).Take(limit);

            var result = _mapper.Map<IEnumerable<DogDTO>>(dogs);
            
            return result;
        }

        public async Task<bool> PostDog(DogForCreationDTO dogForCreationDTO)
        {
            bool result = false;

            Dog dog = new(dogForCreationDTO.Name)
            {
                Id = Guid.NewGuid(),
                Color = dogForCreationDTO.Color,
                TailLength = dogForCreationDTO.TailLength,
                Weight = dogForCreationDTO.Weight
            };

            var checkDog = await (await _unitOfWork.Dogs.GetAllAsync()).AsQueryable().AnyAsync(d => d.Equals(dog));

            if (!checkDog)
            {
                result = await _unitOfWork.Dogs.CreateAsync(dog)
                    && await _unitOfWork.SaveChangesAsync();
            }
            
            return result;
        }
    }
}
