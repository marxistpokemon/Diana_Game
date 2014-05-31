using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Dir {
	North,
	East,
	South,
	West
}

[System.Serializable]
public class ChunkInfo : IEquatable<ChunkInfo> {
	public string name;
	public int gridX;
	public int gridZ;
	public float worldX;
	public float worldZ;
	public Chunk obj;

	public ChunkInfo (int pX, int pZ) {
		gridX = pX;
		gridZ = pZ;
		worldX = gridX * ChunkManager.i.side;
		worldZ = gridZ * ChunkManager.i.side;
		name = "C_" + gridX + "_" + gridZ;
		obj = null;
	}

	public void SetCoords (int pX, int pZ) {
		gridX = pX;
		gridZ = pZ;
		worldX = gridX * ChunkManager.i.side;
		worldZ = gridZ * ChunkManager.i.side;
		name = "C_" + gridX + "_" + gridZ;
	}

	public bool Equals (ChunkInfo other)
	{
		if(this.gridX == other.gridX && this.gridZ == other.gridZ){
			return true;
		}
		else {
			return false;
		}
	}

	public override bool Equals(System.Object obj)
	{
		if (!(obj is ChunkInfo)) return false;
		return Equals((ChunkInfo)obj);
	}

	public override int GetHashCode()
	{
		return this.name.GetHashCode();
	}

	public static bool operator == (ChunkInfo info1, ChunkInfo info2)
	{
		if ((System.Object)info1 == null || ((System.Object)info2) == null)
			return System.Object.Equals(info1, info2);
		
		return info1.Equals(info2);
	}

	public static bool operator != (ChunkInfo info1, ChunkInfo info2)
	{
		if (info1 == null || info2 == null)
			return !System.Object.Equals(info1, info2);
		
		return !info1.Equals(info2);
	}

	public static Dir GetOppositeDir(Dir dir){
		switch(dir){
		case Dir.North : return Dir.South;
		case Dir.South : return Dir.North;
		case Dir.East : return Dir.West;
		default : return Dir.East;
		}
	}
	public static int GetOppositeDir(int dir){
		switch(dir){
		case (int)Dir.North : return (int)Dir.South;
		case (int)Dir.South : return (int)Dir.North;
		case (int)Dir.East : return (int)Dir.West;
		default : return (int)Dir.East;
		}
	}

	public static List<ChunkInfo> ChunksInArea (int x, int z, int radius) {
		List<ChunkInfo> chunks = new List<ChunkInfo>();

		int maxX = x + radius;
		int minX = x - radius;
		int maxZ = z + radius;
		int minZ = z - radius;

		for (int i = minX; i <= maxX; i++){
			for(int j = minZ; j <= maxZ; j++){
				ChunkInfo temp = ChunkManager.i.GetChunkInfo(i, j);
				if(temp != null) {
					chunks.Add(temp);
				}
				else {
					chunks.Add(new ChunkInfo(i, j));
				}
			}
		}

		return chunks;
	}

}

public class Chunk : MonoBehaviour
{
	public ChunkInfo info;

	void Update () {
		// chunk transitions and Y position
		if (info != ChunkManager.i.currentChunk.info) {
			float dist = Vector2.Distance(
				new Vector2 (ChunkManager.i.player.transform.position.x, 
			             ChunkManager.i.player.transform.position.z),
			    new Vector2 (info.worldX, info.worldZ));
			float ratio = dist/ChunkManager.i.side*4/3;
			float altitude = ChunkManager.i.maxDepth - ratio*ChunkManager.i.maxDepth;
			if (altitude < -ChunkManager.i.maxDepth) altitude = -ChunkManager.i.maxDepth;
			else if (altitude > 0) altitude = 0;
			Vector3 target = new Vector3(info.worldX, altitude, info.worldZ);
			transform.position = Vector3.Lerp(transform.position, target, 0.5f);
		}
	}
}

