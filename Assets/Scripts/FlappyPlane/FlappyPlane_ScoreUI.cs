using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlane_ScoreUI : FlappyPlane_BaseUI
{
    protected override UIState GetUIState()
    {
        return UIState.Score;
    }

    public override void Init(FlappyPlane_UIManager uiManager)
    {
        base.Init(uiManager);
    }
}
