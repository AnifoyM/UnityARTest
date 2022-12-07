using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectobject : MonoBehaviour
{
    public static Vector3 currentScale;
    private Touch oldTouch1;
    private Touch oldTouch2;

    public GameObject Selectobject01;
    GameObject Selectobject02;
    public GameObject Arcamare01;
    public GameObject Reobject;

    public int Touchstate = 0;//0-初始状态 1-移动模块状态 2-测试状态
    // Use this for initialization
    void OnMouseDrag()
    {
        
        //获取到鼠标的位置(鼠标水平的输入和竖直的输入以及距离)
        Vector3 mousePosition = new Vector3(Input.mousePosition.x/(Mathf.Cos(((Arcamare01.transform.rotation.y)*(Mathf.PI))/180)), Input.mousePosition.y, Selectobject01.transform.position.z-Arcamare01.transform.position.z);
        //物体的位置，屏幕坐标转换为世界坐标
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //把鼠标位置传给物体
        Vector3 v3 = new Vector3(objectPosition.x, objectPosition.y, Selectobject01.transform.position.z);
        Selectobject01.transform.position = v3;
        Selectobject01.transform.localPosition = new Vector3(Selectobject01.transform.localPosition.x, Selectobject01.transform.localPosition.y, 0);

    }
    // Update is called once per frame
    void Update()
    {
        if (Touchstate == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Selectobject01 = hit.collider.gameObject;    //获得选中物体
                    string goName = Selectobject01.name;    //获得选中物体的名字，使用hit.transform.name也可以
                    print(goName);
                }

            }
            else if (Input.GetMouseButton(0))
            {
                OnMouseDrag();
            }
        }
        if (Touchstate == 0)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //得到手指在这一帧的移动距离
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                //在X 轴上旋转物体
                Reobject.transform.Rotate(0, -touchDeltaPosition.x, 0);
            }//长按旋转脚本

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        if (Input.GetTouch(0).tapCount == 2)
                        {
                            //下面输入双击后的操作内容↓
                            Selectobject02 = hitInfo.collider.gameObject;

                            Debug.Log("get a object!");
                            //**************************
                        }
                    }
                }
            }

            if (Input.touchCount == 2)
            {
                //缩放
                Touch newTouch1 = Input.GetTouch(0);

                Touch newTouch2 = Input.GetTouch(1);

                if (newTouch2.phase == TouchPhase.Began)
                {
                    oldTouch2 = newTouch2;
                    oldTouch1 = newTouch1;

                    return;
                }
                float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
                float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);

                float offset = newDistance - oldDistance;

                float scaleFactor = offset / 200f;

                Vector3 localScale = Reobject.transform.localScale;

                Vector3 scale = new Vector3(localScale.x + scaleFactor, localScale.y + scaleFactor, localScale.z + scaleFactor);
                //限制最低最高值
                if ((scale.x >= 0.5f && scale.x <= 3) && (scale.y >= 0.5f && scale.y <= 3f) && (scale.z >= 0.5f && scale.z <= 3f))
                {
                    Reobject.transform.localScale = scale;
                    currentScale = scale;
                }
                oldTouch1 = newTouch1;
                oldTouch2 = newTouch2;
            }
        }
    }
}
