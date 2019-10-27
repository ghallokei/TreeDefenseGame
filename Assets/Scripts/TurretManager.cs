
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public List<GameObject> turrets = new List<GameObject>();
    public GameObject noobWizard;
    public GameObject advancedWizard;
    public GameObject masterWizard;
    
    public EnemyManager EnemyManager;
    
    public void spawnNoobWizard(Vector3 location)
    {
        GameObject go = Instantiate(noobWizard, transform);
        go.transform.position = location;
        go.GetComponent<Turret>().enemies = EnemyManager.enemies;
        turrets.Add(go);
    }
    
    public void spawnAdvancedWizard(Vector3 location)
    {
        GameObject go = Instantiate(advancedWizard, transform);
        go.transform.position = location;
        go.GetComponent<Turret>().enemies = EnemyManager.enemies;
        turrets.Add(go);
    }
    
    public void spawnMasterWizard(Vector3 location)
    {
        GameObject go = Instantiate(masterWizard, transform);
        go.transform.position = location;
        go.GetComponent<Turret>().enemies = EnemyManager.enemies;
        turrets.Add(go);
    }
}
