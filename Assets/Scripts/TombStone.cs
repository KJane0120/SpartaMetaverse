using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombStone : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        //canvas = GetComponentInChildren<Canvas>(true);
        if (canvas == null) 
            return;
        else 
            canvas.gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canvas.gameObject.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canvas.gameObject.SetActive(false);
    }
}
