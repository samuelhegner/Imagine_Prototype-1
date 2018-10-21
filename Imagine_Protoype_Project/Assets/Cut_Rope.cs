using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Rope : MonoBehaviour {
    bool cutLeft;
    bool cutRight;
    bool cutRopes;

    float a;

    int numberRopesCut;

    void Start()
    {
        a = 1;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetMouseButton(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null) {
                if (hit.collider.tag == "Link") {

                    if (hit.transform.parent.name == "Anchor Left" && cutLeft == false){
                        cutLeft = true;
                        numberRopesCut++;
                    }

                    if (hit.transform.parent.name == "Anchor Right" && cutRight == false)
                    {
                        cutRight = true;
                        numberRopesCut++;
                    }

                    Destroy(hit.collider.gameObject);
                }
            } 
        }

        if (numberRopesCut == 2) {
            cutRopes = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement_Cosmos>().JourneyStarted = true;
        }
	}
}
