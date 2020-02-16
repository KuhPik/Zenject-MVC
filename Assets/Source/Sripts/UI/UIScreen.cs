using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIScreen : MonoBehaviour
{
    [SerializeField] protected GameObject _screen;

    public virtual void SetState(bool isOpen)
    {
        _screen.SetActive(isOpen);
    }
}
