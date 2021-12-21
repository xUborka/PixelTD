using UnityEngine;

public class AimScript : MonoBehaviour
{
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject fire_pos;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float fire_rate;
    [SerializeField] private float range;

    private string enemy_tag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        fire_rate = 1.0f;
        range = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
            float closest_dist = Mathf.Infinity;

            foreach (GameObject enemy in enemies){
                float current_dist = Vector2.Distance(enemy.transform.position, transform.position);
                if (closest_dist > current_dist){
                    closest_dist = current_dist;
                    target = enemy;
                }
            }
        }

        if (target == null){
            return;
        }
        
        Vector3 targ = target.transform.position;
        Vector3 objectPos = turret.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        turret.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        fire_rate -= Time.deltaTime;
        if (fire_rate < 0.0f){
            fire_rate = 1.0f;
            GameObject projectile_object = (GameObject)Instantiate(projectile, fire_pos.transform.position, fire_pos.transform.rotation);
            Projectile proj_par = projectile_object.GetComponent<Projectile>();
            if (proj_par != null){
                proj_par.target = target;
            }
        }
    }
}
