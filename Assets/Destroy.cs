using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mg = GameManager;

public class Destroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collide) {
        //Debug.Log("objected collided");
        string collided_letter = gameObject.tag;
        //Debug.Log("Collided with letter : " + collided_letter);
        Destroy(gameObject);
        char inputLetter = char.Parse(collided_letter);
        int c = 0;
        for (int i = 0; i < mg.solvedList.Count; i++)
        {   
            Debug.Log(mg.solvedList[i]);
            if(mg.solvedList[i] == inputLetter){
                mg.letterHolderList[i].text = inputLetter.ToString();
                c=1;
                break;
            }
        }
        if(c == 0){
            Debug.Log("You hit the wrong letter");
            if(LivesScript.lives > 0) {
                LivesScript.lives -= 1;
            }
            if(LivesScript.lives == 0){
                Camera.GameEnd();
                Player.body.isKinematic = true;
            }
        }
    }
}