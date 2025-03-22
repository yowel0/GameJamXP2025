using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    CardManager cardManager;
    [SerializeField]
    TextMeshProUGUI handsText;
    [SerializeField]
    TextMeshProUGUI cardsLeftText;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        cardManager = FindAnyObjectByType<CardManager>();
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }

    public void AcceptCurrentCard(){
        cardManager.activeCard.Accept();
    }

    public void DenyCurrentCard(){
        cardManager.activeCard.Deny();
    }

    void SetText(){
        handsText.text = player.accepts.ToString();
        cardsLeftText.text = "Cards Left: " + (cardManager.cards.Count + 1);
    }
}
