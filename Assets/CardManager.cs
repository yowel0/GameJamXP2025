using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CardManager : MonoBehaviour
{
    public Card activeCard = null;
    [SerializeField]
    BattleManager battleManager;
    [SerializeField]
    Card cardPrefab;
    [SerializeField]
    List<CardSO> cards;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        if (activeCard == null){
            activeCard = FindAnyObjectByType<Card>();
        }
        player = FindAnyObjectByType<Player>();
        SpawnNextCard();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeCard == null){
            SpawnNextCard();
        }
    }

    public void SpawnNextCard(){
        if (cards.Count <= 0 || player.Accepts <= 0){
            battleManager.StartBattle();
            return;
        }
        SpawnCard(cards[0]);
        cards.RemoveAt(0);
    }

    void SpawnCard(CardSO _cardSO){
        activeCard = Instantiate(cardPrefab);
        activeCard.cardSO = _cardSO;
    }
}
