using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sesler : MonoBehaviour
{
    
    AudioSource SesKaynak;

    public AudioClip dogruSesi;
    public AudioClip yanlisSesi;
    public AudioClip timerSesi;




    void Start()
    {
        SesKaynak = gameObject.GetComponent<AudioSource>();
    }



    public void DogruSesiCal()  
    {
        SesKaynak.PlayOneShot(dogruSesi); 
        Debug.Log("Dogru Sesi");
    }

    public void YanlisSesiCal()
    {
        SesKaynak.PlayOneShot(yanlisSesi);
        Debug.Log("Yanlis Sesi");
    }

    public void TimerSesiCal()
    {
        SesKaynak.PlayOneShot(timerSesi);
        Debug.Log("Timer Sesi");
    }

    public void TimerSesiKapa()
    {
        SesKaynak.Stop();
        Debug.Log("Timer Sesi Durdu");
    }

}