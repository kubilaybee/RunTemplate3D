using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // char check run or idle anim
    public bool run=false;
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
        if (run)
        {
            characterMovement();
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
    public void setAnim()
    {
        run = !run;
        animRun.SetBool("Run", run);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Collectable Object
        if (other.GetComponent<Collectable>())
        {
            currentScore += other.GetComponent<Collectable>().score;
            GameManager.Instance.scoreText.text = "Your Score: " + currentScore;
            other.transform.gameObject.SetActive(false);
        }
        // Obstacle Object
        if (other.GetComponent<Obstacle>())
        {
            setAnim();
            GameManager.Instance.levelFail();
            other.transform.gameObject.SetActive(false);
        }
        //Obstacle Object
        if (other.GetComponent<StageCompleted>())
        {
            setAnim();
            GameManager.Instance.levelSuccess();
        }
    }
}
