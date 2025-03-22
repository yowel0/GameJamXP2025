using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 10;
    [HideInInspector]
    public int health;
    public int damage = 1;
    public float speed = 1;
    
    public UnityEvent onAttack;

    void Awake()
    {
        health = maxHealth;
    }

    public void Hit(int _amount){
        health -= _amount;
    }

    public void AttackEntity(Entity _entity){
        _entity.Hit(damage);
        onAttack?.Invoke();
    }

    public void AddHealth(int _amount){
        maxHealth += _amount;
        health += _amount;
    }

    public void AddDamage(int _amount){
        damage += _amount;
    }

    public void AddSpeed(int _amount){
        speed += _amount;
    }
}
