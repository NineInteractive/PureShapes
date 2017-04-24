using UnityEngine;
using System.Collections;

namespace PureShape {

public static class ShapeGOFactory {
    // instantiate static // maybe no need to be monobehaviour

    const string LINE_PREFAB_PATH = "UnitLine";
    const string RECT_PREFAB_PATH = "UnitRect";
    const string CIRCLE_PREFAB_PATH = "UnitCircle";

    public static ShapeRenderer InstantiateShape(ShapeProperty property) {
        ShapeRenderer shape = null;
        switch (property.shapeType) {
            case ShapeType.Circle:
                shape = InstantiateCircle((CircleProperty)property);
                break;
            case ShapeType.Line:
                shape = InstantiateLine((LineProperty)property);
                break;
            case ShapeType.Rect:
                shape = InstantiateRect((RectProperty)property);
                break;
            default:
                break;
        }
        return shape;
    }

    public static ShapeRenderer UpdateShapeProperty(ShapeRenderer renderer, ShapeProperty property) {
        switch (property.shapeType) {
            case ShapeType.Circle:
                ((CircleRenderer)renderer).property = (CircleProperty)property;
                break;
            case ShapeType.Line:
                ((LineRenderer)renderer).property = (LineProperty)property;
                break;
            case ShapeType.Rect:
                ((RectRenderer)renderer).property = (RectProperty)property;
                break;
            default:
                break;
        }
        return renderer;
    }

    public static LineRenderer InstantiateLine(LineProperty property) {
        var go = new GameObject("Line");
        var rd = go.AddComponent<LineRenderer>();
        rd.property = property;
        return rd;
    }

    public static CircleRenderer InstantiateCircle(CircleProperty property) {
        var go = new GameObject("Circle");
        var rd = go.AddComponent<CircleRenderer>();
        rd.property = property;
        return rd;
    }

    public static RectRenderer InstantiateRect(RectProperty property) {
        var go = new GameObject("Rect");
        var rd = go.AddComponent<RectRenderer>();
        rd.property = property;
        return rd;
    }

    static GameObject InstantiateGO(string prefabPath, Vector2 center) {
        var prefab = Resources.Load<GameObject>(prefabPath);

        if (prefab == null) {
            Debug.LogError("couldn't load " + prefabPath);
            return null;
        }

        var go = Object.Instantiate(prefab, center, Quaternion.identity) as GameObject;

        if (go == null) {
            Debug.LogError("couldn't instantiate prefab");
            return null;
        }

        return go;
    }
}
}
