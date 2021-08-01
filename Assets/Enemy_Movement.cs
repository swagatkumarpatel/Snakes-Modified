
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public Transform player;
    float degree;
    public GameObject Prefab;
    public Transform Bulletposition;
    Vector3 normalised_direction;
    float time=0;

    void Update()
    {
      normalised_direction = (player.position - transform.position).normalized;
        Vector3 direction_Length = player.position - transform.position;
        float Length = direction_Length.magnitude;
        if (Length > 300f)
        {
            transform.Translate(normalised_direction * 300f * Time.deltaTime, Space.World);
        }
       
        degree = Mathf.Atan2(normalised_direction.y, normalised_direction.x) * Mathf.Rad2Deg ;
        transform.eulerAngles = Vector3.forward * degree;
        time = time + 1f*Time.deltaTime;
        if (time >= 3)
        {
            GameObject Bullet_reference = Instantiate(Prefab, Bulletposition.position, transform.rotation) as GameObject;
            Bullet_reference.GetComponent<Rigidbody>().AddForce(normalised_direction * 1000f, ForceMode.Impulse);
            time = 0;
            Destroy(Bullet_reference, 4);
        }
        
    }
}
