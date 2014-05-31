using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class ElevationDeform : MonoBehaviour {
	PerlinNoise perlin;
	public bool round;
	public float baseHeight = 0f;
	public int octaves = 2;
	public float frequency = 20f;
	public float amplitude = 8f;

	public void Deform () {
		MeshCollider mCollider = GetComponent<MeshCollider>();
		mCollider.sharedMesh = null;
		
		perlin = new PerlinNoise(ChunkManager.i.randomSeed);
		
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		for(int i = 0; i < vertices.Length; i++) {
			if (vertices[i].y >= transform.position.y - 5f) { // if top face vertex
				float height = baseHeight + perlin.FractalNoise2D(transform.position.x + vertices[i].x, transform.position.z + vertices[i].z, octaves, frequency, amplitude); 
				if(height < transform.position.y - 5f) height = transform.position.y - 5f;
				if (round) height = Mathf.Floor(height);
				vertices[i].y = height;
			}
		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		
		mCollider.sharedMesh = mesh;
	}

}

