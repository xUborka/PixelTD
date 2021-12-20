using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public GameObject turret;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion look_rotation = Quaternion.LookRotation(dir);
        Vector3 rotation_target = Quaternion.Lerp(turret.transform.rotation, look_rotation, Time.deltaTime * 150f).eulerAngles;
        turret.transform.rotation = Quaternion.Euler(0f, 0f, rotation_target.z);
    }
}
