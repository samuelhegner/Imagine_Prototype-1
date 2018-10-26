using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrail : MonoBehaviour
{

    public int length;
    public float distanceBetweenPoints = 10f;
    public float rangeX;
    public float smoothness;

    float lineWidth;

    LineRenderer rend;

    float randomXOffset;

    Vector3[] Points;

    public GameObject box;


    private void Awake()
    {
        rend = GetComponent<LineRenderer>();
        Vector3 [] TempPoints = new Vector3[length];
        for (int i = 0; i < TempPoints.Length; i++) {

            float lastX = transform.position.x;
            float firstY = transform.position.y;

            if (i == 0)
            {
                TempPoints[i] = transform.position;
            }
            else {
                randomXOffset = Random.Range(-(rangeX), (rangeX));
                TempPoints[i] = new Vector3(lastX + randomXOffset, firstY + distanceBetweenPoints * i, 0);
                lastX = TempPoints[i].x;
            }
        }

        Points = Game_Manager.MakeSmoothCurve(TempPoints, smoothness);

        for (int i = 0; i < Points.Length -1; i++){
            GameObject boxTemp = Instantiate(box, Points[i], transform.rotation);
            boxTemp.transform.parent = transform;
        }

        for (int i = 0; i < transform.childCount -1 ; i++)
        {
            if(i < transform.childCount-2){
                Vector3 toVector = Points[i + 1] - Points[i];
                float angle = Mathf.Atan2(toVector.y, toVector.x) * Mathf.Rad2Deg;
                Quaternion NewRot = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.GetChild(i).transform.rotation = NewRot;
            }else{
                Vector3 toVector = Points[i] - Points[i -1];
                float angle = Mathf.Atan2(toVector.y, toVector.x) * Mathf.Rad2Deg;
                Quaternion NewRot = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.GetChild(i).transform.rotation = NewRot;
            }

        }


        rend.positionCount = Points.Length;
        rend.SetPositions(Points);
        rend.startWidth = 5f;
        rend.endWidth = 5f;

        lineWidth = rend.startWidth;



        /*Vector2[] TwoDeePoints = new Vector2[Points.Length];
        for (int i = 0; i < TwoDeePoints.Length; i++) {
            Vector3[] TwoDeePointsTemp = new Vector3[Points.Length];
            TwoDeePointsTemp[i] = transform.InverseTransformPoint(Points[i].x, Points[i].y, 0);
            TwoDeePoints[i] = new Vector2(TwoDeePointsTemp[i].x, TwoDeePointsTemp[i].y);
        }

        Vector2[] RightArray = new Vector2[Points.Length]; ;
        Vector2[] LeftArray = new Vector2[Points.Length];

        float angle;
        float xOff;
        float yOff;

        for (int i = 0; i < TwoDeePoints.Length; i++) {

            xOff = 0;
            yOff = 0;
            
            if (i < TwoDeePoints.Length - 1) {
                angle = Vector2.SignedAngle(Vector3.up, (TwoDeePoints[i + 1] - TwoDeePoints[i]));

                float percentAngle = 90 / angle;
                yOff = (rend.startWidth / 2) / percentAngle;
                xOff = (rend.startWidth / 2) - yOff;

                print("yOff= " + yOff);
                print("xOff= " + xOff);
            }

            

            LeftArray[i] = new Vector2(TwoDeePoints[i].x, TwoDeePoints[i].y);
            RightArray[i] = new Vector2(TwoDeePoints[i].x + rend.startWidth / 2, TwoDeePoints[i].y);
        }

        EdgeCollider2D edgeRight = gameObject.AddComponent<EdgeCollider2D>();
        EdgeCollider2D edgeLeft = gameObject.AddComponent<EdgeCollider2D>();

        edgeRight.points = RightArray;
        edgeLeft.points = LeftArray;*/
    }
}