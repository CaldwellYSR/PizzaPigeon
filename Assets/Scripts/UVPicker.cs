using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVPicker : MonoBehaviour {

	public List<Material> Textures;

	private MeshRenderer Mesh;

	void Start() {
		Mesh = GetComponent<MeshRenderer> ();
		int selected = (int) Mathf.Floor(Random.Range (0, Textures.Count));
		Mesh.material = Textures[selected];
	}

}

