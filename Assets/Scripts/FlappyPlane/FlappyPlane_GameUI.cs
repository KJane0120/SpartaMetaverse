using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlane_GameUI : FlappyPlane_BaseUI
{
    protected override UIState GetUIState()
    {
        return UIState.Game;
    }

    public override void Init(FlappyPlane_UIManager uiManager)
    {
        base.Init(uiManager);
    }
}
