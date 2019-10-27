using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class PlayerController : MonoBehaviour
{
    public ForestManager forest;
    public TurretManager TurretManager;
    public Camera cam;
    public int ep { private set; get; }
    public Sprite unselected;
    public Sprite selected;

    public string selectedButton;

    public Text epText;

    public Text TextScore;

    public int score;

    public Text feedBack;
    private void Update()
    {
        TextScore.text = score.ToString();

        epText.text = ep.ToString();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);


        if (!checkPreCollision(hit.point) && Input.GetMouseButtonUp(1))
        {
            feedBack.text = "Can't place item. Try placing it somewhere else!";
            return;
        }

        if (Input.GetMouseButtonUp(1) && ep >= 25 && selectedButton == "TreeButton")
        {
            forest.spawnTree(hit.point);
            ep -= 25;
            AddPoints(25);
            feedBack.text = " ";
        }
        else if (Input.GetMouseButtonUp(1) && selectedButton == "Wizard1" && ep >= 15)
        {
            TurretManager.spawnNoobWizard(hit.point);
            ep -= 15;
            feedBack.text = " ";
        }
        else if (Input.GetMouseButtonUp(1) && selectedButton == "Wizard2" && ep >= 35)
        {
            TurretManager.spawnAdvancedWizard(hit.point);
            ep -= 35;
            feedBack.text = " ";
        }
        else if (Input.GetMouseButtonUp(1) && selectedButton == "Wizard3" && ep >= 50)
        {
            TurretManager.spawnMasterWizard(hit.point);
            ep -= 50;
            feedBack.text = " ";
        }
        else if (Input.GetMouseButtonUp(1))
        {
            feedBack.text = "Not enough EP";
        }
    }

    private void Start()
    {
        ep = 100;
    }

    public void ButtonSelect(Button buttonSelect)
    {
        GameObject currentButton = GameObject.Find(selectedButton);
        if (currentButton != null)
        {
            currentButton.GetComponent<Button>().image.sprite = unselected;
        }

        if (buttonSelect.image.sprite == unselected)
        {
            selectedButton = buttonSelect.gameObject.name;
            buttonSelect.image.sprite = selected;
        }
        else
        {
            selectedButton = "";
            buttonSelect.image.sprite = unselected;
        }
    }

    public void AddEP()
    {
        ep += 10;
    }

    public void DeleteEP()
    {
        ep -= 15;
    }

    public void AddPoints(int amount)
    {
        score += amount;
    }

    public bool checkPreCollision(Vector3 pos)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, 1.5f);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].name != "Ground")
            {
                return false;
            }
        }

        return true;
    }
}