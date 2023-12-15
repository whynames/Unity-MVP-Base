using System;

public abstract class BaseModel<TData> : IModel<TData> where TData : IDataPack
{
    protected TData data = default;

    protected BaseModel()
    {
    }

    protected BaseModel(TData data)
    {
        this.data = data;
    }

    public virtual TData Initialize()
    { // Adjust initialization logic as needed
        return data;
    }
}
public class BaseData : IDataPack
{
    object data;

    public BaseData(object data)
    {
        this.data = data;
    }

    /// <summary>
    /// シーンロード完了時にシーンロード非同期操作の完了通知を登録する
    /// </summary>

    public T GetData<T>() where T : notnull, new()
    {
        // シーンデータがnullの場合、新しく生成する。
        data ??= new T();

        // 指定されたシーンデータの型と一致しない場合、例外を投げる
        if (!(data is T))
            throw new InvalidCastException($"SceneDataPackの型が一致しません。{typeof(T)}を指定してください。");

        // シーンデータを渡す
        return (T)data;
    }

    public void SetData<T>(T data) where T : notnull, new()
    {
        // シーンデータがnullの場合、新しく生成する。
        this.data = data;

        // 指定されたシーンデータの型と一致しない場合、例外を投げる
        if (!(data is T))
            throw new InvalidCastException($"SceneDataPackの型が一致しません。{typeof(T)}を指定してください。");

        // シーンデータを渡す
    }
}

public interface IDataPack
{
    /// <summary>
    /// シーンデータを取得する。
    /// </summary>
    public T GetData<T>() where T : notnull, new();

    /// <summary>
    /// シーンロード完了を通知する。
    /// </summary>
}