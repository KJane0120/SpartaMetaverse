
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target;
    float offsetY;
    public float smoothSpeed = 5.0f;
    public Vector2 minMaxY = new Vector2(0.2f, 19.5f);
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

        Vector3 targetPos = transform.position;
        targetPos.y = target.position.y + offsetY;
        targetPos.y = Mathf.Clamp(targetPos.y, minMaxY.x, minMaxY.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}
