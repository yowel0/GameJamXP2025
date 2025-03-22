using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Entity entity;
    Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        entity = GetComponentInParent<Entity>();
        slider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)entity.health / entity.maxHealth;
    }
}
