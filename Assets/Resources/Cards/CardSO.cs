using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card")]
public class CardSO : ScriptableObject
{
    public string cardName;
    public Sprite sprite;
    public string description;
    public int health;
    public int damage;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
