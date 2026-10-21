using UnityEngine;

public class SkinnedMeshBaker : MonoBehaviour
{
    private SkinnedMeshRenderer _skinnedRenderer;

    private Mesh _bakedMesh;
    private MeshRenderer _bakedMeshRenderer;
    private MeshFilter _bakedMeshFilter;

    private void Awake()
    {
        _skinnedRenderer = GetComponent<SkinnedMeshRenderer>();

        if (_skinnedRenderer == null)
            throw new System.Exception("Объект не содержит SkinnedMeshRenderer компонента");

        _bakedMeshFilter = gameObject.AddComponent<MeshFilter>();
        _bakedMeshRenderer = gameObject.AddComponent<MeshRenderer>();
    }

    public void ShowBaked()
    {
        _bakedMesh = new Mesh();
        _skinnedRenderer.BakeMesh(_bakedMesh);

        _bakedMeshFilter.sharedMesh = _bakedMesh;
        _bakedMeshRenderer.sharedMaterials = _skinnedRenderer.sharedMaterials;

        _skinnedRenderer.enabled = false;
        _bakedMeshRenderer.enabled = true;
        transform.localScale = Vector3.one;
    }

    public void ShowOriginal()
    {
        _bakedMeshRenderer.enabled = false;
        _skinnedRenderer.enabled = true;
    }
}
