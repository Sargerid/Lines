using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;//platform speed
    public int startPoint;//starting index(position of the platform)
    public Transform[] points;//array of transform points

    private int i;//index of array
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startPoint].position;
    }

    // Update is called once per frame
    void Update()
    {

        //changing the distance of the platform and the point
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;//increase index
            if (i == points.Length)//check if the platform was on the last point after the index increase
            {
                i = 0;//reset index
            }
        }
        //moving platform to the point withe the index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
    
}
