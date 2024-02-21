using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestructionPoint;
    Transform EndPosition;
    // Start is called before the first frame update
    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        EndPosition = transform.Find("EndPosition");
        if(EndPosition.position.x < platformDestructionPoint.transform.position.x){
            Destroy(gameObject);
        }
    }
}
