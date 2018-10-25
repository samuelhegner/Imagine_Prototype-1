using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrail : MonoBehaviour {

    public int length;
    public float distanceBetweenPoints = 10f;
    public float rangeX;
    public float smoothness;

    LineRenderer rend;

    float randomXOffset;

    Vector3[] Points;

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

        rend.positionCount = Points.Length;
        rend.SetPositions(Points);
        rend.startWidth = 5f;
        rend.endWidth = 5f;


        Vector2[] TwoDeePoints = new Vector2[Points.Length];
        for (int i = 0; i < TwoDeePoints.Length; i++) {
            Vector3[] TwoDeePointsTemp = new Vector3[Points.Length];
            TwoDeePointsTemp[i] = transform.InverseTransformPoint(Points[i].x, Points[i].y, 0);
            TwoDeePoints[i] = new Vector2(TwoDeePointsTemp[i].x, TwoDeePointsTemp[i].y);
        }

        Vector2[] RightArray = new Vector2[Points.Length]; ;
        Vector2[] LeftArray = new Vector2[Points.Length];

        for (int i = 0; i < TwoDeePoints.Length; i++) {
            LeftArray[i] = new Vector2(TwoDeePoints[i].x - rend.startWidth / 2, TwoDeePoints[i].y);
            RightArray[i] = new Vector2(TwoDeePoints[i].x + rend.startWidth / 2, TwoDeePoints[i].y);
        }

        EdgeCollider2D edgeRight = gameObject.AddComponent<EdgeCollider2D>();
        EdgeCollider2D edgeLeft = gameObject.AddComponent<EdgeCollider2D>();

        edgeRight.points = RightArray;
        edgeLeft.points = LeftArray;
    }
}