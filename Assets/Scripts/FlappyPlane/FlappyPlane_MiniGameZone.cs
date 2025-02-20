using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlane_MiniGameZone : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        if (target == null)
            return;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target != null && collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("FlappyPlaneScene");
        }
        else return;
    }
}
