using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Card activeCard = null;
    [SerializeField]
    BattleManager battleManager;
    [SerializeField]
    Card cardPrefab;
    [SerializeField]
    int cardsLimit = 10;
    [SerializeField]
    public List<CardSO> cards;

    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI descriptionText;

    [SerializeField]
    Image Damage;
    [SerializeField]
    Image Defense;
    [SerializeField]
    Image Health;
    [SerializeField]
    Image Speed;

    void OnEnable()
    {
        if (nameText != null)
            nameText.gameObject.SetActive(true);
        if (descriptionText != null)
            descriptionText.gameObject.SetActive(true);
    }

    void OnDisable()
    {
        if (nameText != null)
            nameText.gameObject.SetActive(false);
        if (descriptionText != null)
            descriptionText.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (activeCard == null){
            activeCard = FindAnyObjectByType<Card>();
        }
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
        nameText.text = activeCard.cardSO.cardName;
        descriptionText.text = activeCard.cardSO.description;
        cards.RemoveAt(0);
        SetStatsUI();
    }

    void SpawnCard(CardSO _cardSO){
        activeCard = Instantiate(cardPrefab);
        activeCard.cardSO = _cardSO;
    }

    public void ReshuffleCards(){
        print("reshulffel");
        List<CardSO> allCards = Resources.LoadAll<CardSO>("Cards").ToList();
        cards = new List<CardSO>();
        if (cardsLimit > allCards.Count)
            cardsLimit = allCards.Count;
        for (int i = cardsLimit - 1; i >= 0; i--){
            int randInt = Random.Range(0,allCards.Count);
            print(randInt);
            cards.Add(allCards[randInt]);
            allCards.RemoveAt(randInt);
        }
    }

    void SetStatsUI(){
        if (!Damage)
            return;
        if (activeCard.cardSO.damage > 0){
            Damage.color = new Color(1,1,1,1f);
        }
        else{
            Damage.color = new Color(1,1,1,0.5f);
        }

        if (activeCard.cardSO.defense > 0){
            Defense.color = new Color(1,1,1,1f);
        }
        else{
            Defense.color = new Color(1,1,1,0.5f);
        }

        if (activeCard.cardSO.health > 0){
            Health.color = new Color(1,1,1,1f);
        }
        else{
            Health.color = new Color(1,1,1,0.5f);
        }

        if (activeCard.cardSO.speed > 0){
            Speed.color = new Color(1,1,1,1f);
        }
        else{
            Speed.color = new Color(1,1,1,0.5f);
        }
    }
}
