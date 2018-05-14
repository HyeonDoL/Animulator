using UnityEngine;

namespace HD
{
    public static class HD
    {
        #region Color
        public static Color ChangeAlpha(this Color color, float alpha)
        {
            Color newColor = new Color(color.r, color.g, color.b, alpha);

            return newColor;
        }

        public static Color AlphaLerp(this Color color, float startAlpha, float endAlpha, float t)
        {
            Color startColor = new Color(color.r, color.g, color.b, startAlpha);

            Color endColor = new Color(color.r, color.g, color.b, endAlpha);

            return Color.Lerp(startColor, endColor, t);
        }
        #endregion

        public static Quaternion ChangeY(this Quaternion rotation, float eulerY)
        {
            Quaternion newQuaternion = Quaternion.Euler(rotation.eulerAngles.x,
                                                        eulerY,
                                                        rotation.eulerAngles.z);

            return newQuaternion;
        }
    }
}