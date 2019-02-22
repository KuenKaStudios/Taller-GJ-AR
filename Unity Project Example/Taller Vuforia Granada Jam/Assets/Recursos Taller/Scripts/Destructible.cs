using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion;	// Reference to the shattered version of the object
    public GameObject Original;

    public int live;

    private void Update()
    {
        if (live <= 0)
        {
            Crack();
        }
    }

    // If the player clicks on the object
    void Crack ()
	{
        // Spawn a shattered object
        destroyedVersion.SetActive(true);
        Destroy(destroyedVersion, 5);
		// Remove the current object
		Destroy(Original);
	}

}
