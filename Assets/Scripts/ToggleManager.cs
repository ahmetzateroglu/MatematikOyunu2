using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class ToggleManager : MonoBehaviour
{



    public Toggle toplama;
    public Toggle cikarma;
    public Toggle carpma;
    public Toggle bolme;


    public Toggle muzik;
    public Toggle sesler;
    public Toggle timerses;



    public static int karisiktoplama;
    public static int karisikcikarma;

    public static int karisikbolme;
    public static int karisikcarpma;
    

    public static int muzikackapa;
    public static int seslerackapa;
    public static int timersesackapa;

    void Start()
    {
        

        toplama.GetComponent<Toggle>();
        cikarma.GetComponent<Toggle>();
        carpma.GetComponent<Toggle>();
        bolme.GetComponent<Toggle>();

        muzik.GetComponent<Toggle>();
        sesler.GetComponent<Toggle>();
        timerses.GetComponent<Toggle>();



        if (PlayerPrefs.HasKey("karisiktoplama")) 
        {

            karisiktoplama = PlayerPrefs.GetInt("karisiktoplama"); 

        }
        else
        {
            PlayerPrefs.SetInt("karisiktoplama", 0);

        }

        if (karisiktoplama == 0)
        {
            
            toplama.isOn = false;

        }
        if (karisiktoplama == 1)
        {
            
            toplama.isOn = true;

        }

        /////////////

        if (PlayerPrefs.HasKey("karisikcikarma")) 
        {
          
            karisikcikarma = PlayerPrefs.GetInt("karisikcikarma"); 

        }
        else 
        {
            PlayerPrefs.SetInt("karisikcikarma", 0);

        }

        if (karisikcikarma == 0)
        {
            
            cikarma.isOn = false;

        }
        if (karisikcikarma == 1)
        {
            
            cikarma.isOn = true;

        }

        /////////////

        if (PlayerPrefs.HasKey("karisikcarpma")) 
        {

            karisikcarpma = PlayerPrefs.GetInt("karisikcarpma"); 

        }
        else 
        {
            PlayerPrefs.SetInt("karisikcarpma", 0);

        }

        if (karisikcarpma == 0)
        {
           
            carpma.isOn = false;

        }
        if (karisikcarpma == 1)
        {
            
            carpma.isOn = true;

        }

        /////////////
        ///
        if (PlayerPrefs.HasKey("karisikbolme")) 
        {

            karisikbolme = PlayerPrefs.GetInt("karisikbolme"); 

        }
        else 
        {
            PlayerPrefs.SetInt("karisikbolme", 0);

        }

        if (karisikbolme == 0)
        {
         
            bolme.isOn = false;

        }
        if (karisikbolme == 1)
        {
            
            bolme.isOn = true;

        }

        /////
        ///

        if (PlayerPrefs.HasKey("muzikackapa"))
        {

            muzikackapa = PlayerPrefs.GetInt("muzikackapa"); 

        }
        else 
        {
            PlayerPrefs.SetInt("muzikackapa", 0);

        }

        if (muzikackapa == 0)
        {

            muzik.isOn = false;

        }
        if (muzikackapa == 1)
        {

            muzik.isOn = true;

        }

        /////////////////


        if (PlayerPrefs.HasKey("seslerackapa")) 
        {

            seslerackapa = PlayerPrefs.GetInt("seslerackapa"); 

        }
        else 
        {
            PlayerPrefs.SetInt("seslerackapa", 0);

        }

        if (seslerackapa == 0)
        {

            sesler.isOn = false;

        }
        if (seslerackapa == 1)
        {

            sesler.isOn = true;

        }

        /////////////////////


        if (PlayerPrefs.HasKey("timersesackapa"))
        {

            timersesackapa = PlayerPrefs.GetInt("timersesackapa"); 

        }
        else 
        {
            PlayerPrefs.SetInt("timersesackapa", 0);

        }

        if (timersesackapa == 0)
        {

            timerses.isOn = false;

        }
        if (timersesackapa == 1)
        {

            timerses.isOn = true;

        }
    }



    int Say()
    {
        int sayac = 2;
        if (toplama.isOn == false)
            sayac -= 1;
        if (cikarma.isOn == false)
            sayac -= 1;
        if (carpma.isOn == false)
            sayac -= 1;
        if (bolme.isOn == false)
            sayac -= 1;

        return sayac;
    }

    void Update()
    {
       

        if ( Say() <= -1 && toplama.isOn==true)
        {           
            cikarma.isOn = true;
            CikarmaDurumDegis(true);
        }
        else if (Say() <= -1 && cikarma.isOn == true)
        {
            toplama.isOn = true;
            ToplamaDurumDegis(true);
        }
        else if(Say() <= -1 && toplama.isOn == false && cikarma.isOn == false) 
        {
            toplama.isOn = true;
            ToplamaDurumDegis(true);           
        }       

        ToplamaDurumDegis(toplama.isOn);
        CikarmaDurumDegis(cikarma.isOn);

        CarpmaDurumDegis(carpma.isOn);  
        BolmeDurumDegis(bolme.isOn);

        MuzikAcKapa(muzik.isOn);

        SeslerAcKapa(sesler.isOn);

        TimerSesAcKapa(timerses.isOn);


    }



    public void ToplamaDurumDegis(bool deger)
    {

        if (deger == true)
        {


            karisiktoplama = 1;
            PlayerPrefs.SetInt("karisiktoplama", karisiktoplama);
         
        }
        else
        {


            karisiktoplama = 0;
            PlayerPrefs.SetInt("karisiktoplama", karisiktoplama);
         
        }
    }

    public void CikarmaDurumDegis(bool deger)
    {

        if (deger == true)
        {


            karisikcikarma = 1;
            PlayerPrefs.SetInt("karisikcikarma", karisikcikarma);

        }
        else
        {


            karisikcikarma = 0;
            PlayerPrefs.SetInt("karisikcikarma", karisikcikarma);
          
        }
    }

    public void CarpmaDurumDegis(bool deger)
    {

        if (deger == true)
        {
          

            karisikcarpma = 1;
            PlayerPrefs.SetInt("karisikcarpma", karisikcarpma);
           
        }
        else
        {

            karisikcarpma = 0;
            PlayerPrefs.SetInt("karisikcarpma", karisikcarpma);
           
        }
    }

    public void BolmeDurumDegis(bool deger)
    {

        if (deger == true)
        {

            karisikbolme = 1; 
            PlayerPrefs.SetInt("karisikbolme", karisikbolme);
           
        }
        else
        {

            karisikbolme = 0;
            PlayerPrefs.SetInt("karisikbolme", karisikbolme);
           
        }
    }

    public void MuzikAcKapa(bool deger)
    {

        if (deger == true)
        {

            muzikackapa = 1; 
            PlayerPrefs.SetInt("muzikackapa", muzikackapa);
        }
        else
        {

            muzikackapa = 0;
            PlayerPrefs.SetInt("muzikackapa", muzikackapa);
        }
    }

    public void SeslerAcKapa(bool deger)
    {

        if (deger == true)
        {

            seslerackapa = 1; 
            PlayerPrefs.SetInt("seslerackapa", seslerackapa);
        }
        else
        {

            seslerackapa = 0;
            PlayerPrefs.SetInt("seslerackapa", seslerackapa);
        }
    }

    public void TimerSesAcKapa(bool deger)
    {

        if (deger == true)
        {
           

            timersesackapa = 1;
            PlayerPrefs.SetInt("timersesackapa", timersesackapa);
        }
        else
        {

            timersesackapa = 0;
            PlayerPrefs.SetInt("timersesackapa", timersesackapa);
        }
    }





}
