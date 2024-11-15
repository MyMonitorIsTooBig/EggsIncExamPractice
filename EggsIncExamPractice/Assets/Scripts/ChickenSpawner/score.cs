using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public float moneyScore = 0.0f;
    public float chickens = 0.0f;

    public float money = 0.0f;

    public Text moneyText;
    public Text chickenText;
    public Text actualMoneyText;

    ChickenSpawn multiplier;

    // Start is called before the first frame update
    void Start()
    {
        multiplier = GameObject.Find("ChickenPool").GetComponent<ChickenSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        money += moneyScore * 0.01f * multiplier.multiplier;


        chickenText.text = "Chickens: " + chickens.ToString();
        moneyText.text = "Money/Second: " + moneyScore.ToString();
        actualMoneyText.text = "Money: " + money.ToString();
    }



}
