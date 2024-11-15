using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenSpawn : MonoBehaviour
{
    [SerializeField]
    ChickenObjectPool _pool;


    public Text modeText;

    [SerializeField]
    float timeUntilNextSpawn = 0.5f;
    float currentTime = 0.0f;


    [SerializeField]
    float currentMulti = 1.0f;

    float timeUntilNoMulti = 1.0f;
    float notPressingTime = 0.0f;
    float multiCurrentTime = 0.0f;


    public float multiplier = 0.0f;


    public Text text;

    [SerializeField]
    GameObject EvilChicken;

    float randomNum;

    bool damageMode = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!damageMode)
        {
            modeText.text = "Current Mode: Spawn (Swap with TAB)";
        }
        else if (damageMode)
        {
            modeText.text = "Current Mode: DESTROY (Swap with TAB)";
        }



        text.text = multiplier.ToString();

        if (multiCurrentTime >= 0 && multiCurrentTime <= 9)
        {
            multiplier = 1.0f;
        }
        if (multiCurrentTime >= 9 && multiCurrentTime <= 19)
        {
            multiplier = 1.1f;
        }
        if (multiCurrentTime >= 19 && multiCurrentTime <= 29)
        {
            multiplier = 1.2f;
        }
        if (multiCurrentTime >= 29 && multiCurrentTime <= 39)
        {
            multiplier = 1.3f;
        }
        if (multiCurrentTime >= 39 && multiCurrentTime <= 49)
        {
            multiplier = 1.4f;
        }
        if (multiCurrentTime >= 49 && multiCurrentTime <= 59)
        {
            multiplier = 1.5f;
        }
        if (multiCurrentTime >= 59 && multiCurrentTime <= 69)
        {
            multiplier = 1.6f;
        }
        if (multiCurrentTime >= 69 && multiCurrentTime <= 79)
        {
            multiplier = 1.7f;
        }
        if (multiCurrentTime >= 79 && multiCurrentTime <= 89)
        {
            multiplier = 1.8f;
        }
        if (multiCurrentTime >= 89 && multiCurrentTime <= 99)
        {
            multiplier = 1.9f;
        }
        if (multiCurrentTime >= 99 && multiCurrentTime <= 109)
        {
            multiplier = 2.0f;
        }


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            damageMode = !damageMode;
        }

        //Debug.Log(currentTime);
        if (Input.anyKey){
            if (!damageMode)
            {
                multiCurrentTime += Time.deltaTime;
                notPressingTime = 0.0f;
                if (currentTime == 0.0f)
                {
                    _pool.Spawn();

                    randomNum = Random.Range(0, 100);

                    if (randomNum == 20)
                    {
                        Instantiate(EvilChicken, _pool.spawn);
                    }


                }
                currentTime += Time.deltaTime;
                if (currentTime >= timeUntilNextSpawn)
                {
                    currentTime = 0.0f;
                }

            }

            if (damageMode)
            {
                Destroy(GameObject.Find("EvilChicken(Clone)"));
            }

        }

        if (Input.anyKeyDown)
        {
            if (!damageMode)
            {
                currentTime = 0.0f;
                multiCurrentTime += Time.deltaTime;
                notPressingTime = 0.0f;
            }
            if (damageMode)
            {
                Destroy(GameObject.Find("Evil Chicken(Clone)"));
            }

        }

        if (!Input.anyKey && !Input.anyKeyDown)
        {
            if(notPressingTime == timeUntilNoMulti)
            {
                multiCurrentTime = 0.0f;
                notPressingTime = 0.0f;
            }
            notPressingTime += Time.deltaTime;
        }
    }
}
