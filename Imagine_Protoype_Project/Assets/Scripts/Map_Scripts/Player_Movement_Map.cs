using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Map : MonoBehaviour {
    
    [SerializeField]
    bool tilt;
    [SerializeField]
    bool selected;

    bool twoFingers;
    bool waitingForTouch;

    private bool loadingScene;

    Rigidbody2D rb;


    public bool PC;

    float dirX, dirY;

    GameObject SelectedSite;

    Touch touch;

    Vector2 location;

    public GameObject Flag;
    public GameObject Basket;

    TrailRenderer trail;


    float movementSpeed;

    public float MaxSpeed;
    public float MinSpeed;

    public float MaxDistance;

	void Awake () {
        rb = GetComponent<Rigidbody2D>();
        selected = false;
        twoFingers = false;
        location = transform.position;
        waitingForTouch = true;
        trail = Basket.GetComponent<TrailRenderer>();
	}
	
	void Update () {

        AdjustTrail();

        if (tilt == false)
        {

            if (selected == false)
            {
                //For Mobile input

                if (twoFingers == false)
                {
                    if (Input.touchCount == 0 && waitingForTouch == false)
                    {
                        print("test");
                        location = SetPointToMove(touch.position);
                        waitingForTouch = true;
                        DropFlag();
                    }
                }




                if (Input.touchCount > 1)
                {
                    twoFingers = true;
                    touch = new Touch();
                    waitingForTouch = false;

                }
                else if (Input.touchCount == 1 && twoFingers == false)
                {
                    waitingForTouch = false;
                    touch = Input.GetTouch(0);
                }
                else if (Input.touchCount == 0) {
                    twoFingers = false;
                    waitingForTouch = true;
                    touch = new Touch();
                }




                //For PC input#

                if (PC) {
                    if (Input.GetMouseButtonUp(0))
                    {
                        location = SetPointToMove(Input.mousePosition);
                        DropFlag();
                    }
                }
                

                MoveToPoint(location); //Sets move towards location
            }
            else {
                if (Vector3.Distance(transform.position, SelectedSite.transform.position) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, SelectedSite.transform.position, movementSpeed * Time.deltaTime);
                }
                else {
                    if (!loadingScene)
                    {
                        SelectedSite.GetComponent<Site_Info>().LoadCorrespondingScene();
                        loadingScene = true;
                    }
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
        SetMoveSpeed(MinSpeed, MaxSpeed, pointToMove, transform.position);
        return pointToMove;
    }

    void MoveToPoint(Vector2 location) {
        transform.position = Vector2.MoveTowards(transform.position, location - new Vector2(Basket.transform.localPosition.x, Basket.transform.localPosition.y - 2f), movementSpeed * Time.deltaTime);
    }

    void DropFlag() {

        //TODO: Instantiate flag prefab, flag prefab animates, flag prefab checks ground, flag prefab instantiates ground effect.

        Flag.transform.position = location;
        Flag.GetComponent<Animator>().SetTrigger("Drop");
        
        Debug.Log("Dropping flag");
        
    }

    void SetMoveSpeed(float min, float max, Vector2 traget, Vector2 current){
        float dist = Vector2.Distance(traget, current);
        print(dist);
        if(dist < MaxDistance){
            float speedPercent = dist/MaxDistance;
            movementSpeed = MaxSpeed * speedPercent;
        }else{
            movementSpeed = MaxSpeed;
        }

        if(movementSpeed < MinSpeed){
            movementSpeed = MinSpeed;
        }

        print(movementSpeed);
    }

    float Map(float a, float b, float c, float d, float e)
    {
        float cb = c - b;
        float de = e - d;
        float howFar = (a - b) / cb;
        return d + howFar * de;
    }

    void AdjustTrail(){
        float time;
        time = Map(movementSpeed, MinSpeed, MaxSpeed, 0, 5);
        trail.time = time;
        float a;
        a = Map(movementSpeed, MinSpeed, MaxSpeed, 0f, 1f);
        Color col = new Color(1, 1, 1, a);
        Color endCol = new Color(1, 1, 1, 0);
        trail.startColor = col;
        trail.endColor = endCol;
    }
}