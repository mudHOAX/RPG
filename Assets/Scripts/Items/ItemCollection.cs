using System.Collections.Generic;

public class ItemCollection<T> : List<T> where T : Item
{
    public T GetById(int id)
    {
        T item = Find(i => i.Id == id);

        if (item != null)
        {
            return item;
        }

        throw new KeyNotFoundException(string.Format("Item is not present within the collection. Id: {0}", id));
    }

    public bool TryGetById(int id, out T item)
    {
        try
        {
            item = GetById(id);
            return true;
        }
        catch
        {
            item = null;
            return false;
        }
    }
}