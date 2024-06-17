using UnityEngine;

namespace FairyGUI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IColorGear
    {
        /// <summary>
        /// 
        /// </summary>
        Color color { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ITextColorGear : IAdditionColorGear
    {
        /// <summary>
        /// 
        /// </summary>
        Color strokeColor { get; set; }
    }

    /// <summary>
    /// 可叠加颜色的实现，如按钮下的可变颜色物体，存储一个原始颜色，可在变暗时通过原始颜色叠加而不是直接改色
    /// </summary>
    public interface IAdditionColorGear : IColorGear
    {
        /// <summary>
        /// 
        /// </summary>
        Color32 originColor { get; set; }
    }

    /// <summary>
    /// 简单线性渐变色
    /// </summary>
    public interface IGradientColorGear : IAdditionColorGear
    {
        Color[] gradientColors{ get; set; }
    }
}
