using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
[ExecuteInEditMode]
public class ShapeMeshController : MonoBehaviour {


    /***** CONST *****/
    const string MATERIAL_PATH = "Materials/SolidColor";


    /***** INITIALIZER *****/
    void Awake() {
        if (renderer == null) return; // HAX set that material
    }


    /***** PUBLIC: PROPERTIES *****/
    public Color color {
        get {
            return renderer.material.color;
        }

        set {
            var baseMaterial = Resources.Load<Material>(MATERIAL_PATH);
            var newMat = Material.Instantiate(baseMaterial);
            newMat.color = value;
            newMat.name = baseMaterial.name;
            renderer.material = newMat;
        }
    }

    public Mesh mesh {
        get {
            return filter.mesh;
        }

        set {
            filter.mesh = value;
        }
    }

    MeshFilter filter {
        get {
            return GetComponent<MeshFilter>();
        }
    }

    MeshRenderer renderer {
        get {
            var rend = GetComponent<MeshRenderer>();
            if (rend.material == null) {
                rend.material = Resources.Load<Material>(MATERIAL_PATH);
            }
            return rend;
        }
    }
}
