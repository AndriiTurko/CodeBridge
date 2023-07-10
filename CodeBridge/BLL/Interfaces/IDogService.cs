using CodeBridge.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeBridge.BLL.Interfaces
{
    public interface IDogService
    {
        public Task<string> PingAsync();

        public Task<IEnumerable<DogDTO>> GetDogsAsync(string attribute, string order, int pageNumber, int limit);

        public Task<bool> PostDog(DogForCreationDTO dogForCreationDTO);
    }
}
