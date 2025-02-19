using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlane_BgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        FlappyPlane_Obstacle[] obstacles = GameObject.FindObjectsOfType<FlappyPlane_Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for(int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //충돌에 대한 정보는 줄 수 없고, 나랑 부딪힌 충돌체에 대한 정보만 줄 수 있음
    {
        Debug.Log("Triggered: " + collision.name);

        if(collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }
        
        FlappyPlane_Obstacle obstacle = collision.GetComponent<FlappyPlane_Obstacle>();
        if( obstacle != null )
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }



    }

}
