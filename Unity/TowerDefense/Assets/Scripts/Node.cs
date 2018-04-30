using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;


    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.instance.GetTurretToBuild() == null)
            return;



        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.instance.GetTurretToBuild() == null)
            return;

        if (turret != null)
        {
            print("Can't build here");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

	void Start ()
	{
	    rend = GetComponent<Renderer>();
	    startColor = rend.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
