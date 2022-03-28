using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int score;
    // current Char
    public GameObject currentChar;
    public bool addList = true;

    private void Awake()
    {
        // define the currentChar
        currentChar = GameManager.Instance.character;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collectable>() && other.GetComponent<Collectable>().addList)
        {
            other.GetComponent<Collectable>().addList = false;
            // score updated
            currentChar.GetComponent<Character>().currentScore += other.GetComponent<Collectable>().score;
            GameManager.Instance.scoreText.text = "Your Score: " + currentChar.GetComponent<Character>().currentScore;
            GameManager.Instance.stackList.Add(other.gameObject);
        }
    }
}
