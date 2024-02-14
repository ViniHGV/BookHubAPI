using BookHub.API.Contract;
using BookHub.API.Dtos;
using BookHub.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookHub.API.Infra.Persistence.Repositories
{
    public class CategoryRepository(AppDbContext dbcontext) : ICategoryRepository
    {
        private readonly AppDbContext _dbcontext = dbcontext;

        public async Task<bool> Create(CreateCategoryDTO entityDTO)
        {
            try
            {
                var newCategory = new Category(
                    Name: entityDTO.Name,
                    Sumarry: entityDTO.Sumarry
                );

                await _dbcontext.Categories.AddAsync(newCategory);
                Save();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            var searchById = await GetById(id, 0);

            try
            {
                _dbcontext.Categories.Remove(searchById);
                Save();
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<Category>> GetAll(int pageSkip)
        {
            var categoriesSize = await _dbcontext.Categories.CountAsync();
            List<Category> categoriesList = [];

            categoriesList = await (categoriesSize > 10 ?
                _dbcontext.Categories
                .Skip(pageSkip * 10)
                .Take(10)
                .ToListAsync()
            :
                _dbcontext.Categories.ToListAsync());

            return categoriesList;
        }

        public async Task<Category> GetById(int id, int pageSkip)
        {
            var categoryById = await _dbcontext.Categories
            .Include(c => c.Books.Skip(pageSkip * 10).Take(10))
            .FirstOrDefaultAsync(c => c.Id.Equals(id)) ??
                throw new ArgumentException("A categoria inserida não existe!");

            return categoryById;
        }

        public async Task<Category> GetByName(string name)
        {
            var categoryByName = await _dbcontext.Categories
            .FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));

            return categoryByName;
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public async Task<bool> Update(int id, CreateCategoryDTO entityDTO)
        {
            var categoryById = await GetById(id, 0);

            try
            {
                categoryById.Name = entityDTO.Name;
                categoryById.Sumarry = entityDTO.Sumarry;

                _dbcontext.Categories.Update(categoryById);
                Save();

                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}