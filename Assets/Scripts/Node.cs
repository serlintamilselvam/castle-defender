using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Color TurretPositionColor;
 
    private Color startColor;
    private Renderer rend;
    private Color currentColor;
    BuildManager buildManager;

    [HideInInspector]
    public  GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    public Text notEnoughMoney;
   

    void Start()
    {
        rend = GetComponent<Renderer>();
        TurretPositionColor = new Color(105,100, 0);
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    public Vector3 GetBuildPosition(Vector3 positionOffset)
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        notEnoughMoney.text = "";
        if (turret != null)
        {
            buildManager.selectNode(this);
           // Debug.Log("Cant build there");
            return;
        }
        if (!buildManager.CanBuild)
            return;
        //build a turret
        BuildTurret(buildManager.GetTurreToBuild());
    }
    void BuildTurret(TurretBlueprint bluePrint)
    {
        if (PlayerStats.Money < bluePrint.cost)
        {
            Debug.Log("Not enough Money!");
            notEnoughMoney.text = "Not enough Money!";
            return;
        }
        PlayerStats.Money -= bluePrint.cost;
        GameObject turret1 = (GameObject)Instantiate(bluePrint.prefab, GetBuildPosition(bluePrint.prefab.GetComponent<Turret>().positionOffset), Quaternion.identity);
        turret = turret1;

        turretBluePrint = bluePrint;
        buildManager.HighlightNodes(null);
        Debug.Log("Turret build!");

    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBluePrint.upgradeCost)
        {
            Debug.Log("Not enough Money to upgrade!");
            notEnoughMoney.text = "Not enough Money to upgrade!";
            return;
        }
        PlayerStats.Money -= turretBluePrint.upgradeCost;
        //deleting old turret
        Destroy(turret);
        //build new turret
        GameObject turret1 = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(turretBluePrint.upgradedPrefab.GetComponent<Turret>().positionOffset), Quaternion.identity);
        turret = turret1;
        
        isUpgraded = true;
        Debug.Log("Turret Upgraded");
        buildManager.HighlightNodes(null);

    }
    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;
        if(buildManager.HasMoney)
            {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }
    void OnMouseExit()
    {
        if(buildManager.GetTurreToBuild() != null)
        {
            rend.material.color = TurretPositionColor; 
        }
        else
        {
            rend.material.color = startColor;
        }
    }
}
