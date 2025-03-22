using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameObject[] toEnable;
    public GameObject[] toDisable;
    [SerializeField]
    Entity player;
    int playerAttackedCount = 0;
    Entity activeEnemy;
    [SerializeField]
    Entity[] enemyPrefabs;
    int enemyAttackedCount = 0;

    [SerializeField]
    Button replayButton;
    bool battleOngoing = false;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeEnemy == null){
            activeEnemy = Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Count())]);
        }
        if (!battleOngoing){
            activeEnemy.gameObject.SetActive(false);
        }
        else{
            activeEnemy.gameObject.SetActive(true);
            timer += Time.deltaTime;
            float attacksInterval = 1/player.speed;
            if (timer/attacksInterval > playerAttackedCount){
                playerAttackedCount++;
                player.AttackEntity(activeEnemy);
                print(timer/attacksInterval + " " + playerAttackedCount);
            }
            attacksInterval = 1/activeEnemy.speed;
            if (timer/attacksInterval > enemyAttackedCount){
                enemyAttackedCount++;
                activeEnemy.AttackEntity(player);
                print(timer/attacksInterval + " " + enemyAttackedCount);
            }
            if (activeEnemy.health <= 0){
                Destroy(activeEnemy.gameObject);
                StopBattle();
            }
            if (player.health <= 0){
                Destroy(player.gameObject);
                StopBattle();
            }
            //enemy.AttackEntity(player);
        }
    }

    public void StartBattle(){
        battleOngoing = true;
        timer = 0;
        foreach (var gObj in toEnable){
            gObj.SetActive(true);
        }
        foreach (var gObj in toDisable){
            gObj.SetActive(false);
        }
    }

    void StopBattle(){
        battleOngoing = false;
        playerAttackedCount = 0;
        enemyAttackedCount = 0;
        replayButton.gameObject.SetActive(true);
    }

    public void Replay(){
        replayButton.gameObject.SetActive(false);
        foreach (var gObj in toEnable){
            gObj.SetActive(false);
        }
        foreach (var gObj in toDisable){
            if (gObj != null){
                gObj.SetActive(true);
            }
        }
        CardManager cardManager = FindObjectOfType<CardManager>();
        cardManager.ReshuffleCards();
        player.health = player.maxHealth;
    }
}
