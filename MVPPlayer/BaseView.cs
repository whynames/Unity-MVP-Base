using UnityEngine;

public abstract class BaseView<TData> : MonoBehaviour, IView<TData>
{
    protected TData data;

    public virtual void Initialize(TData initialData)
    {
        data = initialData;
    }

    public abstract void UpdateView(TData initialData);
}
public class DebugView : BaseView<BaseData>
{
    public override void Initialize(BaseData initialData)
    {
        base.Initialize(initialData);
    }

    public override void UpdateView(BaseData initialData)
    {
        Debug.Log(initialData);
    }
}