public abstract class UIController<T> : IUIController where T : UIScreen
{
    protected T _view;
    public T View => _view;
    protected bool _isActive;
    public bool IsActive => _isActive;

    public virtual void Initialize(UIScreen view)
    {
        _view = (T)view;
    }

    public virtual void Refresh()
    {

    }

    public virtual void Open()
    {
        _isActive = true;
        _view.SetState(true);
    }

    public virtual void Close()
    {
        _isActive = false;
        _view.SetState(false);
    }
}
