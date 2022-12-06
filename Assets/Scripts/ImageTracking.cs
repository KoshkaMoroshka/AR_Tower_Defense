using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField] private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (var prefab in placeablePrefabs)
        {
            var newPrefab = Instantiate(prefab, new Vector3(100, 100, 100), Quaternion.identity);
            newPrefab.name = prefab.name;
            newPrefab.gameObject.SetActive(false);
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    void Update()
    {
        if (spawnedPrefabs["kitty"].active)
        {
            trackedImageManager.trackedImagesChanged -= ImageChanged;
            return;
        }
            

        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    //private void OnEnable()
    //{
    //    trackedImageManager.trackedImagesChanged += ImageChanged;
    //}

    //private void OnDisable()
    //{
    //    trackedImageManager.trackedImagesChanged += ImageChanged;
    //}

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        foreach (var trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (var trackedImage in eventArgs.removed)
        {
            spawnedPrefabs[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage image)
    {
        AssignGameObject(image.referenceImage.name, image.transform.position);
    }

    private void AssignGameObject(string name, Vector3 position)
    {
        if (spawnedPrefabs == null)
            return;
        spawnedPrefabs[name].SetActive(true);
        spawnedPrefabs[name].transform.position = position;
        foreach (var go in spawnedPrefabs.Values)
        {
            if (go.name != name)
                go.SetActive(false);
        }
    }
}
