using CodeBridge.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeBridge.BLL.Interfaces
{
    public interface IDogService
    {
        public Task<string> PingAsync();

        public Task<List<Dog>> GetDogsAsync(string attribute, string order, int pageNumber, int limit);

        public Task<bool> PostDog(Dog dogRequest);
    }
}
