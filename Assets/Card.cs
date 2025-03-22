using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
{
    private CardSO pCardSO;
    public CardSO cardSO
    {
        get { return pCardSO; }
        set {
             print("card SO is set");
             SetValues(value);
             pCardSO = value;
            }
    }
    
    [SerializeField]
    private CardSO card;
    Player player;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindAnyObjectByType<Player>();
        if (card != null){
            cardSO = card;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        transform.position += new Vector3(input.x, input.y ,0) * 100; 
        //print(input);
    }

    public void Accept(){
        if (player.Accepts > 0){
            player.Accepts--;
            player.AddHealth(cardSO.health);
            player.AddDamage(cardSO.damage);
            player.AddSpeed(cardSO.speed);
            Destroy(gameObject);
        }
    }

    public void Deny(){
        Destroy(gameObject);
    }

    void SetValues(CardSO _cardSO){
        gameObject.name = _cardSO.name;
        GetComponent<SpriteRenderer>().sprite = _cardSO.sprite;
    }
}
