﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tile
{
    public GameObject theTile;
    public float creationTime;

    public Tile(GameObject tile, float creationTime)
    {
        theTile = tile;
        this.creationTime = creationTime;
    }
}

public class GenerateInfinite : MonoBehaviour
{
    public GameObject plane;
    public GameObject player;

    private int planeSize = 2;
    private int halfTilesX = 10;
    private int halfTilesZ = 10;

    private Vector3 startPos;
    Hashtable tiles = new Hashtable();

	void Start ()
	{
        
	    this.gameObject.transform.position = Vector3.zero;
	    startPos = Vector3.zero;

	    float updateTime = Time.realtimeSinceStartup;

	    for (int x = -halfTilesX; x < halfTilesX; x++)
	    {
	        for (int z = -halfTilesZ; z < halfTilesZ; z++)
	        {
	            Vector3 pos = new Vector3((x * planeSize + startPos.x), 0, (z * planeSize + startPos.z));

                GameObject newTile = (GameObject)Instantiate(plane, pos, Quaternion.identity);

	            string tilename = "Tile_" + ((int) (pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
	            newTile.name = tilename;

                Tile tile = new Tile(newTile, updateTime);
                tiles.Add(tilename, tile);
	        }
	    }
        
	}
	
	
	void Update ()
	{
	    int xMove = (int) (player.transform.position.x - startPos.x);
	    int zMove = (int) (player.transform.position.z - startPos.z);


	    if (Mathf.Abs(xMove) <= planeSize || Mathf.Abs(zMove) >= planeSize)
	    {
	        float updateTime = Time.realtimeSinceStartup;

	        int playerX = (int) (Mathf.Floor((player.transform.position.x / planeSize) * planeSize));
	        int playerZ = (int) (Mathf.Floor((player.transform.position.z / planeSize) * planeSize));

	        for (int x = -halfTilesX; x < halfTilesX; x++)
	        {
	            for (int z = -halfTilesZ; z < halfTilesZ; z++)
	            {
	                Vector3 pos = new Vector3((x * planeSize + playerX),
                        0,
                        z * planeSize + playerZ);

	                string tilename = "Tile_" + ((int) (pos.x)).ToString() + " " + ((int) (pos.z)).ToString();

	                if (!tiles.ContainsKey(tilename))
	                {
	                    GameObject t = (GameObject) Instantiate(plane, pos, Quaternion.identity);
	                    t.name = tilename;
	                    Tile tile = new Tile(t, updateTime);
	                    tiles.Add(tilename, tile);
	                }
	                else
	                {
	                    (tiles[tilename] as Tile).creationTime = updateTime;
	                }
	            }
	        }

            // destroy other tiles
	        Hashtable newTerrain = new Hashtable();
	        foreach (Tile tls in tiles.Values)
	        {
	            if (tls.creationTime != updateTime)
	            {
	                Destroy(tls.theTile);
	            }
	            else
	            {
	                newTerrain.Add(tls.theTile.name, tls);
	            }
	        }

	        tiles = newTerrain;

	        startPos = player.transform.position;
	    }
	}
}
