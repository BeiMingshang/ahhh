using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] VoidEventChannel gateTriggeredEventChannel;
    //[SerializeField]GateTrigger gateTrigger;

    private void OnEnable()
    {

      //  gateTrigger.Delegate += Open;
        gateTriggeredEventChannel.AddListener(Open);
    }
    private void OnDisable()
    {
       // gateTrigger.Delegate -= Open; 
        gateTriggeredEventChannel.RemoveListener(Open);
    }
    void Open()
    {
        Destroy(gameObject);
    }
}
