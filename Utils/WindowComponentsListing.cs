using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DinnamuS_2._0_Desktop.Utils
{
    public static class WindowComponentsListing
    {
        //public int Clear(Window window)
        //{


        //    int filhos = VisualTreeHelper.GetChildrenCount(window);
        //    return filhos;

        //    for (int node = 0; node <= VisualTreeHelper)
        //    {

        //    }


        //}

        public static IList<Control> GetControls(this DependencyObject parent)
        {
            var result = new List<Control>();
            for (int x = 0; x < VisualTreeHelper.GetChildrenCount(parent); x++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, x);
                var instance = child as Control;

                if (null != instance)
                    result.Add(instance);

                result.AddRange(child.GetControls());
            }
            return result;
        }

        public static void EnumVisual(Visual parent, List<Visual> collection)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                // Get the child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(parent, i);

                // Add the child visual object to the collection.
                collection.Add(childVisual);

                // Recursively enumerate children of the child visual object.
                EnumVisual(childVisual, collection);
            }
        }
    }
}
