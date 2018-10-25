using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Collision : MonoBehaviour {
    public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player") {
            int ran = Random.Range(0, 2);
            print(ran);

            if (ran < 1f)
            {
                anim.SetTrigger("CollisionRight");
            }
            else {
                anim.SetTrigger("CollisionLeft");
            }
            StartCoroutine(KillGameObject());
        }
    }

    IEnumerator KillGameObject() {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    } 
}
