#pragma strict

public var tilePrefab: GameObject;
public var numberOfTiles: int = 10;
public var distanceBetweenTiles: float = 1.0;

function Start () 
{
	CreateTiles();	
}

function CreateTiles()
{
	var xOffset: float = 0.0;

	for(var tilesCreated: int = 0; tilesCreated < numberOfTiles; tilesCreated += 1)
	{
		xOffset += distanceBetweenTiles;
		Instantiate(tilePrefab, Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z), transform.rotation);
	}
}

function Update () {
	
}
