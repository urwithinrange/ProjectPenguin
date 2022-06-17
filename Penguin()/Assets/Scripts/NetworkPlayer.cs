using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform lefthand;
    public Transform righthand;

    private PhotonView photonView;
    private Text PlayerNameText;
    [HideInInspector] public Transform headOrigin;
    [HideInInspector] public Transform leftHandOrigin;
    [HideInInspector] public Transform rightHandOrigin;

    private XROrigin origin;
    // Start is called before the first frame update
    void OnEnable()
    {
        photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
        PlayerNameText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            MapPosition(head, origin.transform.Find("Camera Offset/Main Camera"));
            MapPosition(lefthand, leftHandOrigin);
            MapPosition(righthand, rightHandOrigin);
            // MapPosition(head, XRNode.Head);
            // MapPosition(lefthand, XRNode.LeftHand);
            // MapPosition(righthand, XRNode.RightHand);
        }
        PlayerNameText.text = PlayerPrefs.GetString("PlayerName");
    }
    void MapPosition(Transform target, Transform originTransform)
    {
        target.SetPositionAndRotation(originTransform.position, originTransform.rotation);
        // InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        // InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        // target.localPosition = position;
        // target.localRotation = rotation;
    }
    void NewMapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

    public void EatTheBigMushroom()
    {
        SceneManager.LoadScene(0);
    }
}
