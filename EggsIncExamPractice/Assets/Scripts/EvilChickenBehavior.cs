using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EvilChickenBehavior : MonoBehaviour
{
    [SerializeField] private ChickenSO chickenStats;

    score _score;

    private Rigidbody rb;

    Transform moveLocation;

    float walkSpeed = 10.0f;


    GameObject currentTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == null)
        {
            currentTarget = GameObject.Find("Chicken(Clone)");
            moveLocation = currentTarget.transform;
        }
        else
        {
            //Destroy(gameObject);
        }

        transform.LookAt(moveLocation);
        rb.velocity = transform.forward * walkSpeed;
    }

    private void OnDisable()
    {

    }

    public void TakeDamage()
    {
        Destroy(gameObject);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Chicken")
        {
            Destroy(collision.gameObject);
        }
    }

}
