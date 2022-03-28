using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int score;
    public Character currentChar;

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
        // Collectable Object
        if (other.GetComponent<Collectable>())
        {
            Debug.Log("TEst");
            currentChar.currentScore += other.GetComponent<Collectable>().score;
            GameManager.Instance.scoreText.text = "Your Score: " + currentChar.currentScore;
            // must fix
            currentChar.stackList.Add(other.gameObject);
            //other.transform.gameObject.SetActive(false);
        }
    }
}
