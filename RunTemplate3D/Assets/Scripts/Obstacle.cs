using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float pushf = 500f;
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
        // must fix
        if (other.GetComponent<Collectable>()&& GameManager.Instance.stackList.Contains(other.gameObject))
        {
            // we must remove item the stacklist
            GameManager.Instance.stackList.Remove(other.gameObject);
            // update the score text
            GameManager.Instance.character.GetComponent<Character>().currentScore -= other.gameObject.GetComponent<Collectable>().score;
            // change the collectable bool
            other.gameObject.GetComponent<Collectable>().addList = true;
            // for add force
            other.gameObject.GetComponent<Rigidbody>().isKinematic=false;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            // addforce
            other.gameObject.GetComponent<Rigidbody>().AddForce(0, pushf, pushf * Time.deltaTime);
            // is kinematic true
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;

        }
    }
}
