using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChickenStats", menuName = "ScriptableObjects/ChickenStats", order = 1)]

public class ChickenSO : ScriptableObject
{
    [field: Header("Chicken Stats")]
    [field: SerializeField] public Transform MoveLocation;
    [field: SerializeField] public float WalkSpeed { get; private set; }
    

}
