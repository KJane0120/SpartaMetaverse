
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target;
    float offsetY;

    public float minY = 0.0f;

    void Start()
    {
        if (target == null)
            return;
   
        offsetY = transform.position.y - target.position.y;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.y = target.position.y + offsetY;
        pos.y = Mathf.Clamp(pos.y, 0.2f, 19.5f);

        transform.position = pos;
    }
}
