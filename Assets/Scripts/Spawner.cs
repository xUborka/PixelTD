using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject unit_prefab;
    [SerializeField] private GameObject route_reference;
    [SerializeField] private float spawn_rate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawn_rate -= Time.deltaTime;
        if (spawn_rate < 0.0f){
            spawn_rate = 0.5f;
            GameObject unit_object = (GameObject)Instantiate(unit_prefab, transform.position, transform.rotation);
            Enemy movement = unit_object.GetComponent<Enemy>();
            movement.set_route(route_reference);
        }
        
    }
}
