using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace RemaxWebApi.Interfaces
{
    public interface IBaseObject
    {
        public Task<string> GetDetails();
        public Task<string> GetDetailsBasedOnId(int id);
        public Task<int> Create(string collection);
        public Task<int> Edit(string data);
        public Task<int> Delete(int id);
    }
}
