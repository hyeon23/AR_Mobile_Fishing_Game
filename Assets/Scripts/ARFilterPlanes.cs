using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ARFilterPlanes : MonoBehaviour
{
// [SerializedField] private Vector2 dimensionsForBigPlane;
[SerializeField] ARSession arSession =null;
  private ARPlaneManager arPlaneManager;
  private List<ARPlane> arPlanes;
  private ARPlane arPlane;
  private GameObject waterPlane;
  private CreateWaterMesh waterScript;

  private void OnEnable()
  {
        arPlanes = new List<ARPlane>();
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        arPlaneManager.planesChanged += OnPlanesChanged;
        waterScript = gameObject.GetComponent<CreateWaterMesh>();
  }
  void OnDisable()
  {
       arPlaneManager.planesChanged -= OnPlanesChanged; // 더 이상 이벤트를 받지 않음 
  }

  private void OnPlanesChanged(ARPlanesChangedEventArgs args){
        if(arPlane==null && args.added !=null && args.added.Count > 0 ){
            arPlane = args.added[0];
        }


        foreach(ARPlane plane in args.added){
            plane.gameObject.SetActive(false);
        }

        arPlane.gameObject.SetActive(true);

  }

    public void ResetDetection(){
        arSession.Reset();
        arPlaneManager.enabled = true;
        waterScript.RemovePlane();
        
    }

    public void CreateWater(){
        arPlane.gameObject.SetActive(false);
        arPlaneManager.enabled = false;
       
        waterScript.CreatePlane(arPlane.extents.y*1.5f,arPlane.extents.x*1.5f, arPlane.center);
    }
}