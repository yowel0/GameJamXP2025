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
    public int defense = 0;
    public int damage = 1;
    public float speed = 1;

    private int _maxHealth;
    private int _defense;
    private int _damage;
    private float _speed;
    
    public UnityEvent onAttack;

    void Awake()
    {
        health = maxHealth;
        SaveValues();
    }

    public void Hit(int _amount){
        int damage = _amount - defense;
        if (damage < 1){
            damage = 1;
        }
        health -= damage;
    }

    public void AttackEntity(Entity _entity){
        _entity.Hit(damage);
        onAttack?.Invoke();
    }

    public void AddHealth(int _amount){
        maxHealth += _amount;
        health += _amount;
    }

    public void AddDefense(int _amount){
        defense += _amount;
    }

    public void AddDamage(int _amount){
        damage += _amount;
    }

    public void AddSpeed(int _amount){
        speed += _amount;
    }

    public virtual void SaveValues(){
        _maxHealth = maxHealth;
        _defense = defense;
        _damage = damage;
        _speed = speed;
    }

    public virtual void ResetValues(){
        maxHealth = _maxHealth;
        health = maxHealth;
        defense = _defense;
        damage = _damage;
        speed = _speed;
    }
}
