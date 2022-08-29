using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VillagerSpawnerMod
{
    public static class Extensions
    {
        public static void AddListener(this UnityEvent action, Action listener)
        {
            action.AddListener(listener);
        }

        public static void AddListener<T>(this UnityEvent<T> action, Action<T> listener)
        {
            action.AddListener(listener);
        }

        public static void RemoveListener(this UnityEvent action, Action listener)
        {
            action.RemoveListener(listener);
        }

        public static void RemoveListener<T>(this UnityEvent<T> action, Action<T> listener)
        {
            action.RemoveListener(listener);
        }

        public static void SetChildControlHeight(this HorizontalOrVerticalLayoutGroup group, bool value)
        {
            group.childControlHeight = value;
        }

        public static void SetChildControlWidth(this HorizontalOrVerticalLayoutGroup group, bool value)
        {
            group.childControlWidth = value;
        }
    }

}
