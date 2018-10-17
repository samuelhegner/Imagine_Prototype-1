using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Map : MonoBehaviour {
    
    [SerializeField]
    bool tilt;
    [SerializeField]
    bool selected;

    bool twoFingers;

    Rigidbody2D rb;


    float dirX, dirY;

    GameObject SelectedSite;

    Touch touch;

    Vector2 location;

    [SerializeField]
    float movementSpeed;

	void Awake () {
        rb = GetComponent<Rigidbody2D>();
        selected = false;
        twoFingers = false;
        location = transform.position;
	}
	
	void Update () {

        if (tilt == false)
        {

            if (selected == false)
            {
                //For Mobile input
                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);
                    if (Input.touchCount > 1) {
                        twoFingers = true;
                    }
                }

                if (touch.phase == TouchPhase.Ended && twoFingers == false)
                {
                    location = SetPointToMove(touch.position);
                }





                //For PC input
                if (Input.GetMouseButtonUp(0)) {
                    location = SetPointToMove(Input.mousePosition);
                }

                MoveToPoint(location); //Sets move towards location
            }
            else {
                if (Vector3.Distance(transform.position, SelectedSite.transform.position) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, SelectedSite.transform.position, movementSpeed * Time.deltaTime);
                }
                else {
                    SelectedSite.GetComponent<Site_Info>().LoadCorrespondingScene();
                }
            }
            
        }
        else {
            if (selected == false) {
                dirX = Input.acceleration.x * movementSpeed;
                dirY = Input.acceleration.y * movementSpeed;
            }
        }

    }

    void FixedUpdate()
    {
        if (tilt == true) {
            if (selected == false) {
                rb.velocity = new Vector2(dirX, dirY);
            }
        }
    }


    public void MoveToClosestSite() {
        selected = true;
        SelectedSite = GetComponent<Site_Finder>().closestSite;
    }

    Vector2 SetPointToMove(Vector2 screenPosition) {
        Vector2 pointToMove = Camera.main.ScreenToWorldPoint(screenPosition);
        return pointToMove;
    }

    void MoveToPoint(Vector2 location) {
        transform.position = Vector2.MoveTowards(transform.position, location, movementSpeed * Time.deltaTime);
    }
}