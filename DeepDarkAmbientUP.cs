using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepDarkAmbientUP : MonoBehaviour
{
    public DeepDarkAmbient DDA;
    private void OnTriggerEnter(Collider other)
    {
        DDA.ChangeAudio(.3f);
    }

    private void OnTriggerExit(Collider other)
    {
        DDA.ChangeAudio(.2f);
    }

}
