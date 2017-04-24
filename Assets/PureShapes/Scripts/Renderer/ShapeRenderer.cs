using UnityEngine;

namespace PureShape {
[RequireComponent(typeof(Rigidbody2D))]
[ExecuteInEditMode]
public abstract class ShapeRenderer : MonoBehaviour {


    /***** CONST *****/
    const string INNER_MESH_NAME = "Inner Mesh";
    const string OUTER_MESH_NAME = "Outer Mesh";



    /***** PROTECTED: VARIABLES *****/
    protected bool propertyObjectChanged = true; // hax
    protected ShapeMeshController innerMeshController;
    protected ShapeMeshController outerMeshController;


    /***** INITIALIZER *****/
    protected virtual void Awake() {
        innerMeshController = gameObject.GetComponentInChildByName<ShapeMeshController>(INNER_MESH_NAME);
        if (innerMeshController == null) {
            innerMeshController = createSubmeshWithName(INNER_MESH_NAME);
        }

        outerMeshController = gameObject.GetComponentInChildByName<ShapeMeshController>(OUTER_MESH_NAME);
        if (outerMeshController == null) {
            outerMeshController = createSubmeshWithName(OUTER_MESH_NAME);
        }
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    ShapeMeshController createSubmeshWithName(string name) {
        var go = new GameObject(name);
        go.transform.parent = transform;
        go.transform.localPosition = Vector3.zero;
        return go.AddComponent<ShapeMeshController>();
    }

    /***** MONOBEHAVIOUR *****/
    void Update() {
        RenderAndUpdatePropertyIfNeeded();
    }


    /***** PUBLIC: FORCE RENDER *****/
    public void RenderAndUpdatePropertyIfNeeded() {
        if (propertyObjectChanged ||
            (Application.isEditor && PropertyObjectModifiedInEditor())) {
            UpdateGameObject();

            UpdateMeshIfNeeded();

            CacheProperty();
        } else if (Application.isEditor && GameObjectWasModified()) {
            SetProperty(GameObjectToShapeProperty());
            UpdateGameObject();

            UpdateMeshIfNeeded();

            CacheProperty();
        }
    }


    /***** ABSTRACT METHODS *****/
    // Update transform
    protected abstract void UpdateGameObject();

    // Recreate mesh if needed
    protected abstract void UpdateMeshIfNeeded();

    // Make a copy of property for comparison
    protected abstract void CacheProperty();

    // Property setter
    protected abstract void SetProperty(ShapeProperty property);

    // Checks if GameObject/Transform was modified in editor mode
    protected abstract bool GameObjectWasModified();

    // Extract ShapeProperty from GameObject/Transform
    protected abstract ShapeProperty GameObjectToShapeProperty();

    protected abstract bool PropertyObjectModifiedInEditor();
}
}
