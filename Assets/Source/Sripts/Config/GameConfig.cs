using UnityEngine;

public class GameConfig : MonoBehaviour
{
    [SerializeField] int maxScore;
    [SerializeField] int tapScore;

    public int MaxScore => maxScore;
    public int TapScore => tapScore;
}
