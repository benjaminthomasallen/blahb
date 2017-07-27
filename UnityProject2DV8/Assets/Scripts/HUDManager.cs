using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    public Text armySizeText;
    public Text resourceText;
    public Text infoText;
    public Text baseHealthText;

    private int healthRed;
    private int healthBlue;

    private int armysize;
    private int resources = 10;

    private string currentUnit;
    private string unitTeam;
    private int maxHealth;
    private int currentHealth;
    private int atk;
    private int def;
    private int move;
    private int sight;
    private int range;

    // Use this for initialization
    void Start () {

        armysize = 1; //change it later to the correct size based on list
        armySizeText.text = "Army Size:\n" + armysize;

        //Using the clicked on unit as a base we go to the list of that Unit and take the data
        //current Defaults to Heavy Knight Data
        getUnitInfo();
        infoText.text = "Unit: " + currentUnit + "\nTeam: " + unitTeam + "\n\nHP: " + currentHealth + "/" + maxHealth + "\nAtk: " + atk + "\nDef: " + def + "\nMove: " + move + "\nSight: " + sight + "\nRange: " + range;

        healthGet();
        baseHealthText.text = "Base HP:\n" + healthRed + "-" + healthBlue + "\nRed-Blue";

        //was for testing
        //resourceText.text = "Resources:\n" + resources;
    }
	
	// Update is called once per frame
	void Update () {

        armysize = 1; //change it later to the correct size absed on list
        armySizeText.text = "Army Size:\n" + armysize;

        //Using the clicked on unit as a base we go to the list of that Unit and take the data
        //current Defaults to Heavy Knight Data
        getUnitInfo();
        infoText.text = "Unit: " + currentUnit + "\nTeam: " + unitTeam + "\n\nHP: " + currentHealth + "/" + maxHealth + "\nAtk: " + atk + "\nDef: " + def + "\nMove: " + move + "\nSight: " + sight + "\nRange: " + range;

        healthGet();
        baseHealthText.text = "Base HP:\n" + healthRed + "-" + healthBlue + "\nRed-Blue";

        //was for testing
        //resourceText.text = "Resources:\n" + resources;
    }

    //Updated and extracts data on clicked target
    private void getUnitInfo()
    {
        currentUnit = "Heavy Knight";
        unitTeam = "Red";
        maxHealth = 25;
        currentHealth = 25;
        atk = 8;
        def = 6;
        move = 2;
        sight = 2;
        range = 1;    
    }

    //will get the health of both players and display them here
    //defaults at 50 each
    private void healthGet()
    {
        healthRed = 50;
        healthBlue = 50;
    }
}
