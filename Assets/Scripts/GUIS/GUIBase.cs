using UnityEngine;
using System.Collections;

public class GUIBase : MonoBehaviour {

    public bool isImportant = false; //determines whether to close it if another view is opened

    public virtual void openView(object data)
    {
        //overridable
    }

    public void Close()
    {
        Destroy(this);
    }
}
