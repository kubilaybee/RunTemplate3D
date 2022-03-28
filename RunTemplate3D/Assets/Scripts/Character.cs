using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // char check run or idle anim
    public Animator animRun;
    public float charSpeed;
    public int currentScore=0;

    private void Awake()
    {
        animRun = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animRun.GetBool("Run"))
        {
            characterMovement();
        }

        if ("Your Score: "+currentScore != GameManager.Instance.scoreText.text)
        {
            GameManager.Instance.scoreText.text = "Your Score: " + currentScore;
        }
    }

    // char movement
    public void characterMovement()
    {
        Vector3 newPos = transform.position;
        newPos.z += charSpeed;
        if (Input.mousePosition.x < 300 && newPos.x>-3)
        {
            newPos.x--;
        }
        if (Input.mousePosition.x > 300 && newPos.x < 3)
        {
            newPos.x++;
        }
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * charSpeed);
    }


    // char anim completed
    public void startRun()
    {
        animRun.SetBool("Run", !(animRun.GetBool("Run")));
    }

    private void OnTriggerEnter(Collider other)
    {
        // Collectable Object
        if (other.GetComponent<Collectable>())
        {
            other.GetComponent<Collectable>().addList = false;
            currentScore += other.GetComponent<Collectable>().score;
            GameManager.Instance.scoreText.text = "Your Score: " + currentScore;
            // must fix
            GameManager.Instance.stackList.Add(other.gameObject);
            //other.transform.gameObject.SetActive(false);
        }
        // Obstacle Object
        if (other.GetComponent<Obstacle>())
        {
            startRun();
            GameManager.Instance.levelFail();
            other.transform.gameObject.SetActive(false);
        }
        //Obstacle Object
        if (other.GetComponent<StageCompleted>())
        {
            startRun();
            GameManager.Instance.levelSuccess();
        }
    }

    public void stageComp(Vector3 startPos)
    {
        this.transform.position = startPos;
    }
}
