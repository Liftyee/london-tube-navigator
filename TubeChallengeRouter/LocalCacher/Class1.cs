namespace LocalCacher;
using System.Runtime.Serialization;

public interface ICache
{
    public T Load<T>(string filename);
    public void Save<T>(string filename, T obj);
}

public class SerializationCache : ICache // WAIT, SERIALIZATION IS DEPRECATED 
{
    public T Load<T>(string filename)
    {
        throw new NotImplementedException();
    }

    public void Save<T>(string filename, T obj)
    {
        throw new NotImplementedException();
    }
}