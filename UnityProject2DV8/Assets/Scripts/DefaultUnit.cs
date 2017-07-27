using UnityEngine;
using System.Collections;

public class DefaultUnit : MonoBehaviour
{

    private int team;
    private bool active;
    public int hp, att, def, move, sight, range;

    public void setTeam(int team)
    {
        this.team = team;
    }
    public int whichteam()
    {
        return team;
    }
    public void setActivity(bool active)
    {
        this.active = active;
    }
    public bool activity()
    {
        return active;
    }
    public void setUnitStats(string type)
    {
        switch (type)
        {
            case "SwordsMan":
                hp = 15;
                att = 5;
                def = 3;
                move = 2;
                sight = 0;
                range = 1;
                break;

            case "Knight":
                hp = 20;
                att = 7;
                def = 5;
                move = 6;
                sight = 0;
                range = 1;
                break;

            case "HeavyKnight":
                hp = 25;
                att = 8;
                def = 6;
                move = 2;
                sight = 0;
                range = 1;
                break;

            case "Archer":
                hp = 10;
                att = 3;
                def = 2;
                move = 2;
                sight = 2;
                range = 2;
                break;

            case "LongBowMan":
                hp = 15;
                att = 5;
                def = 3;
                move = 2;
                sight = 2;
                range = 2;
                break;

            case "CrossbowMan":
                hp = 15;
                att = 7;
                def = 3;
                move = 2;
                sight = 3;
                range = 3;
                break;

            case "HorseMan":
                hp = 15;
                att = 6;
                def = 4;
                move = 3;
                sight = 2;
                range = 1;
                break;

            case "Calvary":
                hp = 20;
                att = 9;
                def = 6;
                move = 4;
                sight = 0;
                range = 1;
                break;

            case "Scout":
                hp = 10;
                att = 1;
                def = 1;
                move = 4;
                sight = 3;
                range = 1;
                break;

            case "Assassin":
                hp = 10;
                att = 8;
                def = 2;
                move = 3;
                sight = 2;
                range = 1;
                break;

            case "Catapult":
                hp = 15;
                att = 10;
                def = 0;
                move = 2;
                sight = 2;
                range = 2;
                break;
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
