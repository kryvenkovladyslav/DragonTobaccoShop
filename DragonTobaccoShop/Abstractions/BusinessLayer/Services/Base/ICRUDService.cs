using System.Threading.Tasks;

namespace Abstractions.BusinessLayer.Services.Base
{
    public interface ICRUDService<TModel> where TModel : class
    {
        public Task<TModel> CreateAsync(TModel model);
        public Task<TModel> UpdateAsync(TModel model);
        public Task DeleteAsync(TModel model);
        public Task<bool> IsAlreadyExist(TModel model);
    }
}