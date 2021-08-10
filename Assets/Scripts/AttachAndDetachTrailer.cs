using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachAndDetachTrailer : MonoBehaviour
{
    public GameObject ParentTruck;
    public GameObject PositionInTruck;
    public GameObject TrailerParent;
    public Button Dattached;
    public bool Attched=false;
    public GameObject[] wheelCollidersScripts;
    public static AttachAndDetachTrailer instance;


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (Attched)
        {
            return;
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                TrailerParent.transform.parent = ParentTruck.transform;
                TrailerParent.transform.localPosition = PositionInTruck.transform.localPosition; 
                Attched = true;
                TrailerParent.GetComponent<ConfigurableJoint>().connectedBody = ParentTruck.GetComponent<Rigidbody>();
                gameManger._gameManger.CompleteBtns();
                gameManger._gameManger.GiveDataIn_InstuctionsPanel(1);
                gameManger._gameManger.InstructionPanel.SetActive(true);
                gameManger._gameManger.LevelCounter++;
                Invoke("onRcc_Trailer", 1.5f);
                ParentTruck.transform.GetComponent<RCC_CameraConfig>().automatic = true;
                TimerScript.instance.startTime = false;
            }
        }
    }
    void onRcc_Trailer()
    {
        TrailerParent.GetComponent<ConfigurableJoint>().connectedBody = ParentTruck.GetComponent<Rigidbody>();
        TrailerParent.GetComponent<RCC_TruckTrailer>().enabled = true;
        for (int i = 0; i < wheelCollidersScripts.Length; i++)
        {
            wheelCollidersScripts[i].GetComponent<RCC_WheelCollider>().enabled = true;
        }
    }

    public void Deattached()
    {
        Dattached.gameObject.SetActive(false);
        TrailerParent.transform.parent = ParentTruck.transform.parent;
        TrailerParent.GetComponent<ConfigurableJoint>().connectedBody = null;
        ParentTruck.transform.GetComponent<RCC_CameraConfig>().automatic = false;
        ParentTruck.transform.GetComponent<RCC_CameraConfig>().distance = 12;
        ParentTruck.transform.GetComponent<RCC_CameraConfig>().height = 4;
        Attched = false;
    }
}
