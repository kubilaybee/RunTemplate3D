using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Elements")]
    public Button startButton;
    public Button nextStageBtn;
    public Text stageTxt;
    public Text scoreText;
    public Text successText;
    public Text failText;

    // define the character
    public GameObject character;

    // stages
    public List<GameObject> levelStages = new List<GameObject>();
    public int stage = 0;
    public GameObject currentLevel;

    private void Awake()
    {
        Instance = this;

        failText.gameObject.SetActive(false);
        successText.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        nextStage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameState()
    {
        character.GetComponent<Character>().startRun();
    }

    public void levelFail()
    {
        failText.gameObject.SetActive(true);
    }
    public void levelSuccess()
    {
        stage++;
        if(stage == levelStages.Count)
        {
            stage = 0;
        }
        successText.gameObject.SetActive(true);
        nextStageBtn.gameObject.SetActive(true);
    }
    public void nextStage()
    {
        nextStageBtn.gameObject.SetActive(false);
        currentLevel = levelStages[stage];
        currentLevel = Instantiate(currentLevel, new Vector3(0, 0, 0), Quaternion.identity);
        stageTxt.text = "Stage - " + (stage + 1);
        character.GetComponent<Character>().stageComp(new Vector3(0,0,0));
        successText.gameObject.SetActive(false);
        nextStageBtn.gameObject.SetActive(false);
    }
}
