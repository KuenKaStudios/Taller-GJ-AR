using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerController : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour ImagenTarget;
    public AudioSource audio;
    //public Transform Main;

    public GameObject Bullet;
    public Transform ShootPoint;

    public float shootForce;

    private bool Trackeable;

    void Start()
    {
        ImagenTarget = GetComponent<TrackableBehaviour>();
        if (ImagenTarget)
        {
            ImagenTarget.RegisterTrackableEventHandler(this);
        }
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && Trackeable == true)
        {
            Shoot();
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Trackeable = true;
            audio.Play();

        }
        else
        {
            Trackeable = false;
            audio.Pause();
            
        }
    }

    public void Shoot() {

        GameObject go = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation, transform.parent) as GameObject;
        go.GetComponent<Rigidbody>().AddForce(transform.right * -1 * shootForce, ForceMode.VelocityChange);
        Destroy(go.gameObject, 3);

    }

}
