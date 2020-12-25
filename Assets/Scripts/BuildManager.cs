using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private Node[] nodes;

    void Start()
    {
        nodes = (Node[])GameObject.FindObjectsOfType(typeof(Node));
    }

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Morethan 1 buildmanager in scene");
        }
        instance = this;

    }
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void selectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public TurretBlueprint GetTurreToBuild()
    {
        return turretToBuild;
    }
    public void UnSelectTurret()
    {
        turretToBuild = null;
    }
    public void HighlightNodes(TurretBlueprint passedTurret)
    {
        if ((turretToBuild != null && turretToBuild.Equals(passedTurret)) || (passedTurret == null))
        {
            UnSelectTurret();
            foreach (Node node in nodes)
            {
                node.GetComponent<Renderer>().material.color = node.notEnoughMoneyColor;
            }

        }
        else
        {
            SelectTurretToBuild(passedTurret);
            foreach (Node node in nodes)
            {
                node.GetComponent<Renderer>().material.color = node.TurretPositionColor;
            }
        }
    }
}
