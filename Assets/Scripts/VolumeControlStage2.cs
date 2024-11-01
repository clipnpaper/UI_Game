using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControlStage2 : VolumeControlBase
{

    public RectTransform panel;

    private Vector3 panelStartPosition;
    private Vector3 panelTargetPosition;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        panelStartPosition = panel.anchoredPosition;
        panelTargetPosition = panelStartPosition;
    }

    public override void OnVolumeChange(float value)
    {
        base.OnVolumeChange(value);

        float panelOffset = value * 1500; //이동 범위에 따라 조정
        panelTargetPosition = panelStartPosition + new Vector3(panelOffset, 0, 0); //패널 이동
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        panel.anchoredPosition = Vector3.MoveTowards(panel.anchoredPosition, panelTargetPosition, 1000 * Time.deltaTime);
    }
}
