using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Stats")]
    public int health = 10;
    public int damage = 1;
    public int speed = 1;
    
    public void Hit(int _amount){
        health -= _amount;
    }

    public void AttackEntity(Entity _entity){
        _entity.Hit(damage);
    }

    public void AddHealth(int _amount){
        health += _amount;
    }

    public void AddDamage(int _amount){
        damage += _amount;
    }

    public void AddSpeed(int _amount){
        speed += _amount;
    }
}
