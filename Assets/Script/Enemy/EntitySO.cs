using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Order", menuName = "EntitySO")]
public class EntitySO : ScriptableObject
{
    public string entityName;
    public Sprite entityIcon;
    public GameObject entityPrefab;
    public float hp;
    public float damage;
}
