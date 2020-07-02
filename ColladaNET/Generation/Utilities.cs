using ColladaNET.Elements;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ColladaNET
{
    public class Utilities
    {
        private static readonly Regex StringParseRegex = new Regex(@"\s+", RegexOptions.Compiled); // using regex within Unity is way slower then .NET String.Split operations although memory usage is higher
        private static readonly char[] SplitSeparator_NumericArrays = new char[] { ' ', '\r', '\n', '\t' };

        private static List<string> SplitResultList = new List<string>();


        public static T[] InitOrResize<T>(T[] array, int amount)
        {
            if (array == null)
                array = new T[amount];
            else
                Array.Resize<T>(ref array, array.Length + amount);
            return array;
        }





        public static string FromCollection<T>(IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return null;

            StringBuilder text = new StringBuilder();
            if (typeof(T) == typeof(float))
            {
                // If type is float or double, then use a plain ToString with no exponent
                foreach (T untypeValue in enumerable)
                {
                    float value = (float)(object)untypeValue;
                    text.Append(value.ToString("0.0######", NumberFormatInfo.InvariantInfo) + " ");
                }
            }
            else
            {
                foreach (T untypeValue in enumerable)
                {
                    text.Append(Convert.ToString(untypeValue, NumberFormatInfo.InvariantInfo) + " ");
                }
            }
            return text.ToString();
        }
        public static string FromList<T>(IList<T> list)
        {
            if (list == null)
                return null;

            StringBuilder text = new StringBuilder();
            if (typeof(T) == typeof(float))
            {
                // If type is float or double, then use a plain ToString with no exponent
                for (int i = 0; i < list.Count; i++)
                {
                    object untypedValue = list[i];
                    float value = (float)untypedValue;
                    text.Append(value.ToString("0.0######", NumberFormatInfo.InvariantInfo));
                    if ((i + 1) < list.Count)
                        text.Append(" ");
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    text.Append(Convert.ToString(list[i], NumberFormatInfo.InvariantInfo));
                    if ((i + 1) < list.Count)
                        text.Append(" ");
                }
            }
            return text.ToString();
        }
        public static string FromArray<T>(params T[] array)
        {
            // ! ! ! !
            // might this be changed to use static instead of local variables to reduce memory allocations
            //  ->  check other functions in this class
            if (array == null)
                return null;

            StringBuilder text = new StringBuilder();
            int arrayLengthMinusOne = array.Length - 1;
            if (typeof(T) == typeof(float))
            {
                // If type is float, then use a plain ToString with no exponent
                for (int i = 0; i < array.Length; i++)
                {
                    object untypedValue = array[i];
                    float value = (float)untypedValue;
                    text.Append(
                        value.ToString("0.0######", NumberFormatInfo.InvariantInfo));
                    if (i < arrayLengthMinusOne)
                        text.Append(" ");
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    text.Append(Convert.ToString(array[i], NumberFormatInfo.InvariantInfo));
                    if ((i + 1) < array.Length)
                        text.Append(" ");
                }
            }
            return text.ToString();
        }

        public static string[] ToStringArray(string stringValue)
        {
            string[] elements = stringValue.Split(SplitSeparator_NumericArrays, StringSplitOptions.RemoveEmptyEntries);

            string[] ret = new string[elements.Length];
            for (int i = 0; i < ret.Length; i++)
                ret[i] = elements[i];
            return ret;
        }
        public static int[] ToIntArray(string stringValue)
        {
            string[] elements = stringValue.Split(SplitSeparator_NumericArrays, StringSplitOptions.RemoveEmptyEntries);

            int[] ret = new int[elements.Length];
            try
            {
                for (int i = 0; i < ret.Length; i++)
                    ret[i] = int.Parse(elements[i]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ret;
        }
        public static float[] ToFloatArray(string stringValue)
        {
            string[] elements = stringValue.Split(SplitSeparator_NumericArrays, StringSplitOptions.RemoveEmptyEntries);

            float[] ret = new float[elements.Length];
            try
            {
                for (int i = 0; i < ret.Length; i++)
                    ret[i] = float.Parse(elements[i], NumberStyles.Float, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ret;
        }
        public static bool[] ToBoolArray(string stringValue)
        {
            string[] elements = stringValue.Split(SplitSeparator_NumericArrays, StringSplitOptions.RemoveEmptyEntries);

            bool[] ret = new bool[elements.Length];
            try
            {
                for (int i = 0; i < ret.Length; i++)
                    ret[i] = bool.Parse(elements[i]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ret;
        }



        public static void ToList(string stringValue, List<string> targetList)
        {
            targetList.AddRange(stringValue.Split(SplitSeparator_NumericArrays, StringSplitOptions.RemoveEmptyEntries));
        }
        public static void ToList(string stringValue, List<int> targetList)
        {
            string[] elements = stringValue.Split(SplitSeparator_NumericArrays, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < elements.Length; i++)
                targetList.Add(int.Parse(elements[i]));
        }
        public static void ToList(string stringValue, List<float> targetList)
        {
            string[] elements = stringValue.Split(SplitSeparator_NumericArrays, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                for (int i = 0; i < elements.Length; i++)
                    targetList.Add(float.Parse(elements[i], NumberStyles.Float, CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void ToList(string stringValue, List<bool> targetList)
        {
            string[] elements = stringValue.Split(SplitSeparator_NumericArrays, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < elements.Length; i++)
                targetList.Add(bool.Parse(elements[i]));
        }

    }

    public static class Extensions
    {

        public static Node Find(this INodeContainer node, string nodePath, NodeFindMethod method)
        {
            // early exit check against null for passed reference
            if (node == null)
                return null;

            nodePath = nodePath.Trim('/');
            int sepIndex = nodePath.IndexOf('/');
            string curLevel = nodePath;

            if (sepIndex != -1)
            {
                curLevel = nodePath.Substring(0, sepIndex);
                nodePath = nodePath.Substring(sepIndex);
            }
            else
                nodePath = nodePath.Substring(curLevel.Length);


            if (node != null && node.nodes != null)
            {
                if (method == NodeFindMethod.ByName)
                    // check if the path exceeds the current node level
                    foreach (Node child in node.nodes)
                    {
                        if (child.name != null && child.name.Equals(curLevel))
                        {
                            if (nodePath.Length > 1)
                            {
                                Node result = child.Find(nodePath, method);
                                if (result != null) return result;
                            }
                            return child;
                        }
                    }
                else
                    // check if the path exceeds the current node level
                    foreach (Node child in node.nodes)
                    {
                        if (child.id != null && child.id.Equals(curLevel))
                        {
                            if (nodePath.Length > 1)
                            {
                                Node result = child.Find(nodePath, method);
                                if (result != null) return result;
                            }
                            return child;
                        }
                    }
            }
            return null;
            /*
            if (node != null && node.nodes != null)
                // check if the path exceeds the current node level
                foreach (Node child in node.nodes)
                {
                    //if (child.name.Equals(curLevel))
                    if (child.id.Equals(curLevel)) // changed check against .name to .id
                    {
                        if (nodePath.Length > 1)
                        {
                            Node result = child.Find(nodePath);
                            if (result != null)
                                return result;
                        }
                        return child;
                    }
                }
            return null;
            */
        }

        public static IEnumerable<Node> GetCameraNodes(this INodeContainer nodeContainer)
        { return nodeContainer.nodes.Where((x) => x.HasCamera()); }
        public static IEnumerable<Node> GetLightNodes(this INodeContainer nodeContainer)
        { return nodeContainer.nodes.Where((x) => x.HasLight()); }
        public static IEnumerable<Node> GetControllerNodes(this INodeContainer nodeContainer)
        { return nodeContainer.nodes.Where((x) => x.HasController()); }
        public static IEnumerable<Node> GetGeometryNodes(this INodeContainer nodeContainer)
        { return nodeContainer.nodes.Where((x) => x.HasGeometry()); }
        public static IEnumerable<Node> GetOtherNodes(this INodeContainer nodeContainer)
        { return nodeContainer.nodes.Where((x) => !x.HasCamera() && !x.HasController() && !x.HasGeometry() && !x.HasLight()); }


        public static bool GetTechniqueElement(this Effect fx, out string techElement, string element, string profile = "")
        {
            techElement = string.Empty;
            foreach (Extra extra in fx.extra)
            {
                foreach (Technique tech in extra.technique)
                {
                    if (!string.IsNullOrEmpty(profile))
                        if (!tech.profile.Equals(profile))
                            continue;

                    foreach (System.Xml.XmlElement xmlElement in tech.any)
                    {
                        if (!string.IsNullOrEmpty(element))
                            if (!xmlElement.Name.Equals(element))
                                continue;

                        techElement = xmlElement.InnerText;
                        return true;
                    }

                }

            }
            return false;
        }
        public static int GetTechniqueIntElement(this Effect fx, string element, string profile = "")
        {
            string strValue = "";
            if (fx.GetTechniqueElement(out strValue, element, profile))
                return int.Parse(strValue);
            return 0;
        }
        public static bool GetTechniqueBoolElement(this Effect fx, string element, string profile = "")
        {
            string strValue = "";
            if (fx.GetTechniqueElement(out strValue, element, profile))
                return bool.Parse(strValue);
            return false;
        }
        public static float GetTechniqueFloatElement(this Effect fx, string element, string profile = "")
        {
            string strValue = "";
            if (fx.GetTechniqueElement(out strValue, element, profile))
                return float.Parse(strValue, NumberFormatInfo.InvariantInfo);
            return 0.0f;
        }

    }

    public static class StringExtensions
    {
        public static void ToList(this string stringValue, List<string> targetList)
        { Utilities.ToList(stringValue, targetList); }
        public static void ToList(this string stringValue, List<int> targetList)
        { Utilities.ToList(stringValue, targetList); }
        public static void ToList(this string stringValue, List<float> targetList)
        { Utilities.ToList(stringValue, targetList); }
        public static void ToList(this string stringValue, List<bool> targetList)
        { Utilities.ToList(stringValue, targetList); }

    }

}
