using System.Collections;

namespace MiniORM;

// DbSet represents each table of the database. Entity class acts as a column description of the table in DB
public class DbSet<TEntity> : ICollection<TEntity>
    where TEntity : class, new()
{
    internal ChangeTracker<TEntity> ChangeTracker { get; set; }

    internal IList<TEntity> Entities { get; set; }

    internal DbSet(IEnumerable<TEntity> entities)
    {
        this.Entities = entities.ToList();
        this.ChangeTracker = new ChangeTracker<TEntity>(entities);

    }

    public void Add(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("Item cannon be null");
        }

        Entities.Add(entity);
        ChangeTracker.Add(entity);
    }

    public void Clear()
    {
        while (Entities.Any())
        {
            var entity = Entities.First();
            Remove(entity);
        }
    }

    public bool Contains(TEntity item) => Entities.Contains(item);

    public void CopyTo(TEntity[] array, int arrayIndex) => Entities.CopyTo(array, arrayIndex);

    public bool Remove(TEntity item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("Item cannot be null");
        }

        var removedSuccessfully = Entities.Remove(item);

        if (removedSuccessfully)
        {
            ChangeTracker.Remove(item);
        }

        return removedSuccessfully;
    }

    public int Count => Entities.Count;

    public bool IsReadOnly => Entities.IsReadOnly;

    public IEnumerator<TEntity> GetEnumerator() => Entities.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities.ToArray())
        {
            Remove(entity);
        }
    }
}
