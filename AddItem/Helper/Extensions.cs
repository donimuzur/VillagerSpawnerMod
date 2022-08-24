using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AddItemMod
{
    public static class Extensions
    {
        public static bool ContainsIgnoreCase(this string _this, string s)
        {
            return CultureInfo.CurrentCulture.CompareInfo.IndexOf(_this, s, CompareOptions.IgnoreCase) >= 0;
        }

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
