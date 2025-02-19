using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlane_HomeUI : FlappyPlane_BaseUI
{
    protected override UIState GetUIState()
    {
        return UIState.Home;
    }

    public override void Init(FlappyPlane_UIManager uiManager)
    {
        base.Init(uiManager);
    }
}
