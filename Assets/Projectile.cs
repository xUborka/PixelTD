using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null){
            Vector3 dir = target.transform.position - transform.position;
            float distance_this_frame = speed * Time.deltaTime;
            if (dir.magnitude <= distance_this_frame){
                Destroy(gameObject);
                return;
            }
            transform.Translate(dir.normalized * distance_this_frame, Space.World);
        }
    }
}
