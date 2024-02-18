
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternAsp.DatabaseContext;

namespace RepositoryPatternAsp.Service;

public class RepositoryService<TEntity, IModel> : IRepositoryService<TEntity, IModel> where TEntity : class, new() where IModel : class
{
    private readonly IMapper _mapper;
    private readonly StudentDbContext _dbContext;
    public RepositoryService(IMapper mapper, StudentDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        Dbset=_dbContext.Set<TEntity>();
    }
    public DbSet<TEntity> Dbset { get; }
    public async Task<IModel> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var entity=await Dbset.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        Dbset.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        var deleteModel= _mapper.Map<TEntity,IModel>(entity);
        return deleteModel;
    }

    public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entites=await Dbset.ToListAsync(cancellationToken);
        if (entites == null) return null;
        var data= _mapper.Map<IEnumerable<IModel>>(entites);
        return data;
    }

    public async Task<IModel> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var entity=await Dbset.FindAsync(id);
        if (entity == null)  return null; 
        var model=_mapper.Map<TEntity, IModel>(entity);
        return model;
    }

    public async Task<IModel> InsertAsync(IModel model, CancellationToken cancellationToken)
    {
        var entity= _mapper.Map<IModel, TEntity>(model);
        Dbset.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        var insertModel= _mapper.Map<TEntity,IModel>(entity);
        return insertModel;
    }

    public async Task<IModel> UpdateAsync(long id, IModel model, CancellationToken cancellationToken)
    {
        var entity = await Dbset.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        _mapper.Map(model, entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        var updatedModel = _mapper.Map<TEntity, IModel>(entity);
        return updatedModel;
    }
}
