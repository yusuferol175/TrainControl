using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class vagon_olusum : MonoBehaviour
{
    [SerializeField] private GameObject vagon;
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject stop;
    [SerializeField] private GameObject vagon_baslangic;

    private float _newPos_z;
    System.Random rand = new System.Random();
    //-1.7 , 2.3
    private void araba_olus()
    {
        float rndVagon_X = (float)rand.Next(-1, 3);
        Instantiate(car, new Vector3(rndVagon_X, vagon_baslangic.transform.position.y, _newPos_z), Quaternion.identity);
        _newPos_z = _newPos_z + 8f;
    }
    private void stop_olus()
    {
        int randStopPos = rand.Next(0,2);
        if (randStopPos==0)
        {
            Instantiate(stop, new Vector3(-0.8f, vagon_baslangic.transform.position.y, _newPos_z), Quaternion.identity);
            _newPos_z = _newPos_z + 8f;
        }
        else if (randStopPos == 1)
        {

            Instantiate(stop, new Vector3(0.9f, vagon_baslangic.transform.position.y, _newPos_z), Quaternion.identity).transform.rotation = Quaternion.Euler(0f,180f,0f);
            _newPos_z = _newPos_z + 8f;
        }
        
        
    }
    void Start()
    {
        int randCar_Stage_1 = rand.Next(0, 3);
        int randCar_Stage_2 = rand.Next(4, 7);
        int randCar_Stage_3 = rand.Next(8, 11);
        int randCar_Stage_4 = rand.Next(12, 16);
        _newPos_z = vagon_baslangic.transform.position.z;
        for (int i = 0; i < 16; i++)
        {
            if (i == randCar_Stage_1)
            {
                araba_olus();
            }
            else if (i== randCar_Stage_2)
            {
                int randEngel = rand.Next(0, 2);
                if (randEngel==0)
                {
                    araba_olus();
                }
                else if (true)
                {
                    stop_olus();
                }
               
                
            }
            else if (i == randCar_Stage_3)
            {
                int randEngel = rand.Next(0, 2);
                if (randEngel == 0)
                {
                    araba_olus();
                }
                else if (true)
                {
                    stop_olus();
                }
            }
            else if (i == randCar_Stage_4)
            {
                int randEngel = rand.Next(0, 2);
                if (randEngel == 0)
                {
                    araba_olus();
                }
                else if (true)
                {
                    stop_olus();
                }
            }
            else
            {
                float rndVagon_X = (float)rand.Next(-1, 3);
                Instantiate(vagon, new Vector3(rndVagon_X, vagon_baslangic.transform.position.y, _newPos_z), Quaternion.identity);

                _newPos_z = _newPos_z + 8f;
            }

            
            
            
        }
    }

    
}
