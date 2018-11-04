using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_Ground_Checker : MonoBehaviour {

     public RenderTexture RT;

     public Color col;

     [Range(0f,360f)]
     public float MinHue;

     [Range(0f, 360f)]
     public float MaxHue;

     public void CompareColours() {

          Texture2D texture = new Texture2D(1,1, TextureFormat.RGB24, false);

          RenderTexture.active = RT;
          
          texture.ReadPixels(new Rect(0, 0, 1,1), 0, 0);
          texture.Apply();


          col = texture.GetPixel(0, 0);

          float h, s, v;
          
          Color.RGBToHSV(col, out h, out s, out v);


          

          h *= 360;

          Debug.Log(h);
          
          
          if (h > MinHue && h < MaxHue) {

               Debug.Log("Sploosh");
               
               
               
          } else {

               Debug.Log("Thud");
               
               
          }


          //texture.ReadPixels(RectReadPicture, 0, 0);
          //  texture. = RT; 



     }


}
