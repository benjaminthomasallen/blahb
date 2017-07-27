using UnityEngine;
using System.Collections;

public class GameplayManager : MonoBehaviour
{

    public DefaultUnit[,] PlayerUnits = new DefaultUnit[20, 50];
	public GameObject redSwordsmanPrefab;
    public GameObject redKnightPrefab;
	public GameObject redHeavyKnightPrefab;
	public GameObject redArcherPrefab;
	public GameObject redLongbowmanPrefab;
	public GameObject redCrossbowmanPrefab;
    public GameObject redScoutPrefab;
	public GameObject redHorsemanPrefab;
	public GameObject redCalvaryPrefab;
	public GameObject redAssassinPrefab;
	public GameObject redCatapultPrefab;
	public GameObject blueSwordsmanPrefab;
	public GameObject blueKnightPrefab;
	public GameObject blueHeavyKnightPrefab;
	public GameObject blueArcherPrefab;
	public GameObject blueLongbowmanPrefab;
	public GameObject blueCrossbowmanPrefab;
	public GameObject blueScoutPrefab;
	public GameObject blueHorsemanPrefab;
	public GameObject blueCalvaryPrefab;
	public GameObject blueAssassinPrefab;
	public GameObject blueCatapultPrefab;

    private Transform UnitHolder;
    private Vector2 mouseOver;
    private float minorOffset = 0.3f;
    private DefaultUnit selectedUnit;
    private Vector2 startDrag;
    private Vector2 endDrag;

    private int[,] possible = new int[20, 50];
    private BoardManager BScript;
    private GameObject shader;
    private Vector2[] tileCollection = new Vector2[75];
    private GameObject[] requestedTile = new GameObject[75];
    private int iteratorCount = 0;
    private int team_color = 1; 


    // Use this for initialization
    void Start()
    {
        //SpawnUnits ();
        BScript = GameObject.Find("GameManager(Clone)").GetComponent<BoardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseOver();

        int x = (int)mouseOver.x;
        int y = (int)mouseOver.y;

        if (selectedUnit != null)
            UpdateUnitMove(selectedUnit);

        if (Input.GetMouseButtonDown(0))
            SelectUnit(x, y);

        if (Input.GetMouseButtonUp(0))
            TryMove((int)startDrag.x, (int)startDrag.y, x, y);
            
    }

    private void UpdateMouseOver()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Tile")))
        {
            mouseOver.x = (int)(hit.point.x + minorOffset);
            mouseOver.y = (int)(hit.point.y + minorOffset);
        }
        else
        {
            mouseOver.x = -1;
            mouseOver.y = -1;
        }
    }

    private void UpdateUnitMove(DefaultUnit defUnit)
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Tile")))
        {
            defUnit.transform.position = hit.point;
        }
    }

    private void SelectUnit(int x, int y)
    {
        if (x < 0 || x >= 20 || y < 0 || y >= 50)
        {
            return;
        }

        DefaultUnit defUnit = PlayerUnits[x, y];
        if (defUnit != null)
        {
            selectedUnit = defUnit;
            startDrag = mouseOver;
            Debug.Log(selectedUnit.name);


            resetPossible();
            int move;
            move = getPlayerMove();
            findMovement(move, x, y, x, y);
            doShade();
        }
    }

    private void TryMove(int x1, int y1, int x2, int y2)
    {

        if (possible[x2, y2] == 0)
        {
            startDrag = new Vector2(x1, y1);
            endDrag = new Vector2(x2, y2);
            selectedUnit = PlayerUnits[x1, y1];

            MoveUnit(selectedUnit, x1, y1);

            if (x2 == x1 && y2 == y1)
            {
                ;
            }
            else
            {
                PlayerUnits[x1, y1] = selectedUnit;
                MoveUnit(selectedUnit, x1, y1);
            }
            EndMovement();
            undoShade();
            return;
        }
        

        startDrag = new Vector2(x1, y1);
        endDrag = new Vector2(x2, y2);
        selectedUnit = PlayerUnits[x1, y1];

        MoveUnit(selectedUnit, x2, y2);

        if (x2 == x1 && y2 == y1)
        {
            ;
        }
        else
        {
            PlayerUnits[x2, y2] = selectedUnit;
            PlayerUnits[x1, y1] = null;
            MoveUnit(selectedUnit, x2, y2);
        }
		EndMovement();
        undoShade();
    }

    private void EndMovement()
    {
        selectedUnit = null;
        startDrag = Vector2.zero;
    }

	public void SwitchTurn() 
	{

	}

    public void SpawnUnits()
    {

        UnitHolder = new GameObject("Units").transform;
        for (int x = 1; x < 4; x++)
        {
            for (int y = 1; y < 5; y += 2)
            {
                InstantiateUnit(redKnightPrefab, x, y);
            }
        }
        for (int x = 17; x < 20; x++)
        {
            for (int y = 47; y < 50; y += 2)
            {
                InstantiateUnit(blueHeavyKnightPrefab, x, y);
            }
        }
    }

    private void InstantiateUnit(GameObject unitType, int x, int y)
    {
        GameObject tempGO = Instantiate(unitType, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
        tempGO.transform.SetParent(UnitHolder);
        DefaultUnit defUnit = tempGO.GetComponent<DefaultUnit>();
        PlayerUnits[x, y] = defUnit;
        MoveUnit(defUnit, x, y);
    }

    private void MoveUnit(DefaultUnit defUnit, int x, int y)
    {
        defUnit.transform.position = (Vector3.right * x) + (Vector3.up * y);
    }

    private void findMovement(int move, int x, int y, int orig_x, int orig_y)
    {
        if (x < 0 || x >= 20 || y < 0 || y >= 50) {
            return;
        }
        possible[x, y] = 1;
        int terrainCost = getTerrainTypeCost(x, y);
        //check if we are on a tile we should not be on
        if (terrainCost == -1) {
            //if on a tile we cant be on, switch possible to 0, and end this loop
            possible[x, y] = 0;
            return;
        }

        if(x == orig_x && y == orig_y)
        {
            possible[x, y] = 1;
            tileCollection[iteratorCount].x = x;
            tileCollection[iteratorCount].y = y;
            iteratorCount++;
        }
        else if(PlayerUnits[x, y] != null)
        {
            possible[x, y] = 0;
            //check if ally or enemy
        }
        else
        {
            tileCollection[iteratorCount].x = x;
            tileCollection[iteratorCount].y = y;
            iteratorCount++;
        }

        //if we have no more movement left, we are done moving end loop
        if (move <= 0) return;

        //when we are here we are on a possible tile, and we then go to the neighboring spots using our move cost
        findMovement(move - terrainCost, x - 1, y, orig_x, orig_y);
        findMovement(move - terrainCost, x + 1, y, orig_x, orig_y);
        findMovement(move - terrainCost, x, y - 1, orig_x, orig_y);
        findMovement(move - terrainCost, x, y + 1, orig_x, orig_y);
    }

    private int getTerrainTypeCost(int x, int y)
    {
        GameObject curTile;
        curTile = BScript.PassObject(x, y);
        //If we are on a grass or resource tile
        if (curTile.tag == "Grass" || curTile.tag == "Resource" || curTile.tag == "Powerspot")
        {
            return 1;
        }
        //if on a rock tile
        else if (curTile.tag == "Rocky")
        {
            return 2;
        }
        //Else we are on a player1base, player2base, power, water, enemy Tile
        //and cannot move on it so return -1
        return -1;

    }

    private void resetPossible()
    {
        //sets all values in possible to zero
        int i, j, k;
        for (i = 0; i < 20; i++)
        {
            for (j = 0; j < 50; j++)
            {
                possible[i, j] = 0;
            }
        }
    }

    private int getPlayerMove() {
        return 2;
    }

    private void doShade(){
        int i, j, k;
        for(i = 0; i < iteratorCount; i++)
        {
            requestedTile[i] = BScript.PassObject((int) tileCollection[i].x, (int) tileCollection[i].y);
            requestedTile[i].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    private void undoShade() {
        int i, j, k;
        for (i = 0; i < iteratorCount; i++)
        {
            requestedTile[i] = BScript.PassObject((int)tileCollection[i].x, (int)tileCollection[i].y);
            requestedTile[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        }
        iteratorCount = 0;
    }
}
