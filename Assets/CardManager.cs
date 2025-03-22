using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public List<CardSO> cards;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        if (activeCard == null){
            activeCard = FindAnyObjectByType<Card>();
        }
        player = FindAnyObjectByType<Player>();
        ReshuffleCards();
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
        if (cards.Count <= 0){
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

    public void ReshuffleCards(){
        print("reshulffel");
        List<CardSO> allCards = Resources.LoadAll<CardSO>("Cards").ToList();
        cards = new List<CardSO>();
        for (int i = allCards.Count - 1; i >= 0; i--){
            int randInt = Random.Range(0,allCards.Count);
            print(randInt);
            cards.Add(allCards[randInt]);
            allCards.RemoveAt(randInt);
        }
    }
}
