using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gate_control : MonoBehaviour
{
    [SerializeField] private TMP_Text gateNumberText = null;
 
    [SerializeField] private enum GateType
    {
        PositiveGate,
        NegativeGate
    }
    public int getGateNumber()
    {
        return gateNumber;
    }
    [SerializeField] private GateType gate_Type;

    [SerializeField] private int gateNumber;
    void Start()
    {
        RndGateNumber();
       
    }

    
    private void RndGateNumber()
    {
        switch (gate_Type)
        {
            case GateType.PositiveGate: gateNumber = Random.Range(1,10);
                gateNumberText.text = gateNumber.ToString();
                break;
            case GateType.NegativeGate: gateNumber = Random.Range(-10, -1);
                gateNumberText.text = gateNumber.ToString();
                break;
        }
    }
}
