using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;

public class RecordingManager : MonoBehaviour
{
    public RecordManager recordManager;
    // Start is called before the first frame update
    
    public void StartVid()
    {
        recordManager.StartRecord();
    }
    public void SaveVid()
    {
        recordManager.StopRecord();
    }
}
