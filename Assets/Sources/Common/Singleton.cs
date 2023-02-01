
public abstract class Singleton
{

}

public abstract class Singleton<T> : Singleton where T: new()
{
    public static readonly T Instance;

    static Singleton()
    {
        Instance = new T();
    }
}
