using UnityEngine;

[CreateAssetMenu(fileName = "UIConfig", menuName = "Configs/UIConfig")]
public class UIConfig : ScriptableObject
{
    [SerializeField] float _restartingTime;
    public float RestartingTime => _restartingTime;
}
