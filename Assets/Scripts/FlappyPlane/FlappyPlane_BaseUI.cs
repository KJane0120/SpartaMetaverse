using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlappyPlane_BaseUI : MonoBehaviour
{
    protected FlappyPlane_UIManager uiManager;

    public virtual void Init(FlappyPlane_UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract UIState GetUIState();
    public void SetActive(UIState state)
    {
        gameObject.SetActive(GetUIState() == state);
    }
}
