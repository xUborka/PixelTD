using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private GameObject route_reference;
    private int current_target_index;

    public void set_route(GameObject route){
        route_reference = route;
    }

    // Start is called before the first frame update
    void Start()
    {
        current_target_index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (route_reference == null){
            return;
        }

        Transform target_position = route_reference.transform.GetChild(current_target_index);
        if (Vector2.Distance(target_position.position, transform.position) < 0.1f){
            current_target_index += 1;
        }

        if (current_target_index >= route_reference.transform.childCount){
            Destroy(gameObject);
            return;
        }

        Transform movement_target = route_reference.transform.GetChild(current_target_index);
        Vector3 dir = movement_target.position - transform.position;
        float speed = 3.0f;
        float distance_this_frame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distance_this_frame, Space.World);
    }
}
