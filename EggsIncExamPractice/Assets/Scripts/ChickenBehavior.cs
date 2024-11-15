using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ChickenBehavior : MonoBehaviour
{
    [SerializeField] private ChickenSO chickenStats;

    score _score;

    private Rigidbody rb;

    //public IObjectPool<GameObject> Pool { get; set; }

    public ChickenObjectPool Pool;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        chickenStats.MoveLocation = GameObject.Find("ChickenMoveTo").transform;

        _score = GameObject.Find("score").GetComponent<score>();

        Pool = GameObject.Find("ChickenPool").GetComponent<ChickenObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(chickenStats.MoveLocation);
        rb.velocity = transform.forward * chickenStats.WalkSpeed;
    }

    private void OnDisable()
    {
        
    }

    public void TakeDamage()
    {
        //Pool.OnReturnedToPool(gameObject);
        Pool._pool.Release(gameObject);
        //gameObject.SetActive(false);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Coop")
        {
            TakeDamage();
            _score.chickens++;
            _score.moneyScore += 0.1f;
            //Destroy(gameObject);
        }
    }

}
