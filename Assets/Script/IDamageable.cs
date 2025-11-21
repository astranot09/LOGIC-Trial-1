using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float health { get; set; }
    public void TakeDamage(float damage);

}
