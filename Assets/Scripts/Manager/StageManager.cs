using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using geniikw.DataSheetLab;

public class StageManager : MonoBehaviour
{
    // 스테이지 데이터를 관리해주는 매니저
    public StageSheet stageDatas = null;
    
    public int currentStage = 1;
    public StageData currentStageData = null;

    public void Initialize()
    {
        currentStageData = stageDatas[currentStage - 1];
        
    }
}
