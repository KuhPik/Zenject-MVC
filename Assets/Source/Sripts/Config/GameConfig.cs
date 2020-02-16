using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] int maxScore;
    [SerializeField] int tapScore;

    public int MaxScore => maxScore;
    public int TapScore => tapScore;
}
