using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Elements")]
    public Button startButton;
    public Text scoreText;
    public Text successText;
    public Text failText;

    // define the character
    public GameObject character;

    private void Awake()
    {
        Instance = this;

        failText.gameObject.SetActive(false);
        successText.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameState()
    {
        character.GetComponent<Character>().setAnim();
    }

    public void levelFail()
    {
        failText.gameObject.SetActive(true);
    }
    public void levelSuccess()
    {
        successText.gameObject.SetActive(true);
    }
}
