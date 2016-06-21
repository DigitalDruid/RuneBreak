using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageMap : MonoBehaviour {

    public StageSelector [] selectors;
    public Button prevPageButton, nextPageButton;

    public void prevPage() { loadPage(--currentPage); }
    public void nextPage() { loadPage(++currentPage); }

    int currentPage = 1;
    int stageCount, pageCount;

    int IndexOnPage (int stageNumber) { return (stageNumber-1) % 9; }

    // Use this for initialization
	void Awake () {
        stageCount = ProgressManager.levelMap.Length;
        pageCount = Mathf.CeilToInt(stageCount / 9) + 1;
        loadPage(currentPage);
	}
    void loadPage(int pageNumber) {
        for (int j = 0; j < 9; j++) {
            int sN = ((pageNumber - 1) * 9) + (j + 1);
            if (sN <= stageCount) {
                setBtn(selectors[j]);
                selectors[j]._stageNumber = sN;
                selectors[j].Init();
            } else {
                setBtn(selectors[j], false);
            }
        }
        if (pageNumber == 1) setBtn(prevPageButton, false); else setBtn(prevPageButton);
        if (pageNumber == pageCount) setBtn(nextPageButton, false); else setBtn(nextPageButton);
    }
    void setBtn (Behaviour btn, bool enabled = true) {
        btn.gameObject.SetActive(enabled);
        btn.enabled = enabled;
    }
}
