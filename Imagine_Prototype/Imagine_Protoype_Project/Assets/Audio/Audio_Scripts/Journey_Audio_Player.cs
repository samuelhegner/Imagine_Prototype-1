using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioManager))]
public class Journey_Audio_Player : MonoBehaviour {

     public string CurrentJourneyName;

     [HideInInspector]
public bool playing;

     private bool hidden = true;

     private AudioManager _audioManager;

     private Animator _animator;

     void Start() {


          _audioManager = GetComponent<AudioManager>();
          _animator = GetComponent<Animator>();
          
          _audioManager.Play(CurrentJourneyName);
          playing = true;
          
          


     }


     public void TogglePause() {

          if (playing) {

               _audioManager.Pause(CurrentJourneyName);
               
               
          } else {

               _audioManager.Play(CurrentJourneyName);
               
          }

          playing = !playing;


     }


     public void StopAudio() {

          _audioManager.Stop(CurrentJourneyName);

          playing = false;

     }


     public void ToggleMenu() {


          hidden = !hidden;
          
          _animator.SetBool("Hidden", hidden);

          if (!hidden) {

               StartCoroutine(AutoHide(4f));

          }


     }


     IEnumerator AutoHide(float time) {

          while (time > 0) {


               
               
               time -= Time.deltaTime;

               yield return null;

               if (hidden) {

                    yield break;
                    
               }

          }
          
          
ToggleMenu();
          
          

     }



}
