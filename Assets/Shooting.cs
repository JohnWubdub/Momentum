using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;

    Sound sound;

    public int clip = 10;

    public float reloadTime = .5f;
    public float nextReload;

    void Start ()
    {
        sound = GetComponent<Sound>();
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clip > 0 && Global.me.reloading == false)
        {
            Fire();
        }
        if (Input.GetMouseButton(1) && clip < 10)
        {
            Global.me.reloading = true;
            Debug.Log("fuck");
            if (Time.time > nextReload)
            {
                clip += 1;
                sound.Reload();
                nextReload = Time.time + reloadTime;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            Global.me.reloading = false;
            Debug.Log("y33t");
        }


    }

    void Fire ()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, rot_z - 90));
        Global.me.screenshake.SetScreenShake(.05f, .5f, Vector3.right);
        sound.Shot();
        clip -= 1;
    }
}
