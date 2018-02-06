using UnityEngine;
using System.Collections;

public class Global : MonoBehaviourSingleton<Global> //acts almost like a bank for the global variables to be called later
{
    public static Global me;
    public bool reloading = false;
    public Screenshake screenshake; 


    private void Awake()
    {
        me = this; //awakens the script
    }
}
