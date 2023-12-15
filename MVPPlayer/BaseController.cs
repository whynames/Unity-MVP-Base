using UnityEngine;

public abstract class BaseController<TModel, TView, TPresenter, TData> : MonoBehaviour
    where TModel : IModel<TData>, new()
    where TView : MonoBehaviour, IView<TData>
    where TPresenter : IPresenter<TModel, TView, TData>, new()
    where TData : IDataPack
{
    protected TModel model;
    [SerializeField]
    protected TView view;
    protected TPresenter presenter;
    protected TData data;

    protected virtual void Awake()
    {
        InitializeComponents();
    }

    protected virtual void InitializeComponents()
    {
        model = new TModel();
        data = model.Initialize(); // Initialize data here
        presenter = new TPresenter();
    }
    protected virtual void Initialize()
    {
        presenter.Initialize(model, view, data);
    }
}


public interface IModel<TData>
{
    TData Initialize();
}

public interface IView<TData>
{
    void Initialize(TData initialData);
}
public interface IPresenter<TModel, TView, TData>
    where TModel : IModel<TData>
    where TView : IView<TData>
    where TData : IDataPack
{
    void Initialize(TModel model, TView view, TData data);
}
