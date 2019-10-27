using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestManager : MonoBehaviour
{
    public GameObject tree;
    public List<Tree> trees = new List<Tree>();

    public PlayerController playerInfo;

    private void Update()
    {
        CheckForDeadTrees();
        if (trees.Count == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public bool spawnTree(Vector3 location)
    {
        GameObject go = Instantiate(tree, transform);
        trees.Add(go.GetComponent<Tree>());
        go.transform.position = location;
        return true;
    }

    public GameObject getClosestTree(Vector3 pos)
    {
        float distance = 9999999999;
        if (trees.Count == 0)
        {
            return gameObject;
        }
        GameObject closestObject = trees[0].gameObject;

        foreach (Tree tree in trees)
        {
            float currDistance = Vector3.Distance(pos, tree.transform.position);

            if (currDistance < distance)
            {
                distance = currDistance;
                closestObject = tree.gameObject;
            }
        }

        return closestObject;
    }

    private void CheckForDeadTrees()
    {
        for (int i = trees.Count-1; i >= 0; i--)
        {
            if (trees[i].getHealth() <= 0)
            {
                playerInfo.DeleteEP();
                Destroy(trees[i].gameObject);
                trees.Remove(trees[i]);
            }
        }
    }
}