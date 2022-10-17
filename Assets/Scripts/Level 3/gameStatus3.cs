using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using des = Destroy3;
using mg = GameManager3;


public class gameStatus3 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI statusText;
    public Player player;

    public static gameStatus3 gameStatusObj;
    public static int score = MapGenerator3.displayCharacter.Count;

    void Awake()
    {
        gameStatusObj = this;
    }
    void Start()
    {
        statusText = GetComponent<TMPro.TextMeshProUGUI>();
        player = gameObject.AddComponent<Player>();
    }

    // Update is called once per frame
    public void updateStatus()
    {   //when health is zero
        if (FindObjectOfType<Player>().currentHealth <= 0 )
        {
            Debug.Log("Game end health: "+ FindObjectOfType<Player>().currentHealth);
            statusText.text = "Game Over! :( \n\n The correct word was : " + mg.correct_word + "\nScore : " + ScoringSystem.myScore;
            PlayerPrefs.SetInt("gameStatus", 1);
            Camera3.GameEnd();
        }
        else
        { //when player wins
            statusText.text = "Congratulations! You Win!\n\n The correct word was: " + mg.correct_word + "\nScore : " + ScoringSystem.myScore;
            PlayerPrefs.SetInt("gameStatus", 1);
            //Camera.GameEnd();
        }
    }

}