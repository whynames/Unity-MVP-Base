public abstract class BasePresenter<TModel, TView, TData> : IPresenter<TModel, TView, TData>
    where TModel : IModel<TData>, new()
    where TView : IView<TData>
    where TData : IDataPack
{
    protected TModel model;
    protected TView view;

    public virtual void Initialize(TModel model, TView view, TData data)
    {
        this.model = model;
        this.view = view;
        view.Initialize(data);
    }

    public virtual void Bind()
    {

    }
}
