using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HotQueen.Inventory
{
    public class Slot : Button
    {
        [SerializeField] private TMP_Text m_name;
        [SerializeField] private TMP_Text m_count;
        public TMP_Text name { get { return m_name; } }
        public TMP_Text count { get { return m_count; } }
        private Button m_button;

        public UnityEvent OnHover;
        public UnityEvent OnStopHover;

        private void Start()
        {
            m_button = GetComponent<Button>();
            m_name = this.transform.Find("Name").GetComponent<TMP_Text>();
            m_count = this.transform.Find("Count").GetComponent<TMP_Text>();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            OnHover?.Invoke();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            OnStopHover?.Invoke();
        }

    }

}