using System.Runtime.CompilerServices;
using UnityEngine;

public class Test01 : MonoBehaviour
{

    public LayerMask mask;

    void Update() {
        Ray ray= new Ray(transform.position,transform.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, 100, mask, QueryTriggerInteraction.Ignore)) {

            print(hitInfo.collider.gameObject.name);

            Debug.DrawLine(ray.origin, hitInfo.point, Color.yellow);
        }else{
            Debug.DrawLine(ray.origin,ray.origin+ray.direction*100, Color.green);
        }
    }
}
