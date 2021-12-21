using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public GameObject turret;
    public GameObject fire_pos;
    public GameObject target;
    public GameObject projectile;
    public float fire_rate;

    // Start is called before the first frame update
    void Start()
    {
        fire_rate = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targ = target.transform.position;
        Vector3 objectPos = turret.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        turret.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        fire_rate += Time.deltaTime;
        if (fire_rate > 1.0f){
            fire_rate = 0.0f;
            GameObject projectile_object = (GameObject)Instantiate(projectile, fire_pos.transform.position, fire_pos.transform.rotation);
            Projectile proj_par = projectile_object.GetComponent<Projectile>();
            if (proj_par != null){
                proj_par.target = target;
            }
        }

        // Vector3 dir = target.transform.position - transform.position;
        // Quaternion look_rotation = Quaternion.LookRotation(dir);
        // Vector3 rotation_target = Quaternion.Lerp(turret.transform.rotation, look_rotation, Time.deltaTime * 10f).eulerAngles;
        // print(rotation_target);
        // turret.transform.rotation = Quaternion.Euler(0f, 0f, rotation_target.z);
    }
}
