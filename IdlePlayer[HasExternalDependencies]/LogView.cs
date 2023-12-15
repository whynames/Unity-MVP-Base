using UnityEngine;

public class LogView : BaseView<PlayerData>
{
    public override void Initialize(PlayerData initialData)
    {
        base.Initialize(initialData);
    }
    // Specific implementation for PlayerView
    public override void UpdateView(PlayerData initialData)
    {
        Debug.Log(initialData.speed);
    }
}
