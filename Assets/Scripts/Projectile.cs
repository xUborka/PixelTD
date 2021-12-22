using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public bool shot = false;
    public int damage;

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
                Enemy shoot_target = target.GetComponent<Enemy>();
                shoot_target.shoot_enemy(damage);
                Destroy(gameObject);
                return;
            }
            transform.Translate(dir.normalized * distance_this_frame, Space.World);
        }
        if (target == null && shot){
            // Projectile already fired, but target died
            // TODO: Maybe replace with find closest enemy
            Destroy(gameObject);
            return;
        }
    }
}
