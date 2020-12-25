using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    
    BuildManager buildmanager;
    void Start()
    {
        buildmanager = BuildManager.instance;
        //nodes = (Node[])GameObject.FindObjectsOfType(typeof(Node));
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret selected");
        buildmanager.HighlightNodes(standardTurret);
        //buildmanager.SelectTurretToBuild(standardTurret);
        
    }
    public void SelectMissileLauncher()
    {
        buildmanager.HighlightNodes(missileLauncher);
        Debug.Log("Missile Launcher selected");
        //buildmanager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectlaserBeamer()
    {
        buildmanager.HighlightNodes(laserBeamer);
        Debug.Log("Laser Beamer selected");
        //buildmanager.SelectTurretToBuild(laserBeamer);
    }

    
}
