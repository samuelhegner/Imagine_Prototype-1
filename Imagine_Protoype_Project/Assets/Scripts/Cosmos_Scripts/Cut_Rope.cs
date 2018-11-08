using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Rope : MonoBehaviour {
    bool cutLeft;
    bool cutRight;
    bool cutRopes;

    float a;

    int numberRopesCut;

    GameObject player;
    float yPos;

    public float dist;

    void Start()
    {
        a = 1;
        player = GameObject.Find("Player");
        yPos = player.transform.position.y;
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

        

        BaloonRise();
	}

    void LateUpdate(){
        if (numberRopesCut == 2) {
            cutRopes = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement_Cosmos>().JourneyStarted = true;
            GameObject.FindGameObjectWithTag("Ray").GetComponent<LineRenderer>().enabled = false;

            GameObject[] anchors = GameObject.FindGameObjectsWithTag("Anchor");

            for(int i = 0; i < anchors.Length; i++){
                anchors[i].GetComponent<Destroy_Self>().enabled = true;
                for(int j = 0; j < anchors[i].transform.childCount; j++){
                    anchors[i].transform.GetChild(j).GetComponent<Destroy_Self>().enabled = true;
                }
            }

            Destroy(gameObject);
        }
    }

    void BaloonRise(){
        Vector3 goTo = new Vector3(player.transform.position.x, yPos + dist, player.transform.position.z);

        player.transform.position = Vector3.Lerp(player.transform.position, goTo, Time.fixedDeltaTime * 3);
    }
}
