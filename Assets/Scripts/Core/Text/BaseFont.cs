﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace FairyGUI
{
    /// <summary>
    /// Base class for all kind of fonts. 
    /// </summary>
    public class BaseFont
    {
        /// <summary>
        /// The name of this font object.
        /// </summary>
        public string name;

        /// <summary>
        /// The texture of this font object.
        /// </summary>
        public NTexture mainTexture;

        /// <summary>
        ///  Can this font be tinted? Will be true for dynamic font and fonts generated by BMFont.
        /// </summary>
        public bool canTint;

        /// <summary>
        /// If true, it will use extra vertices to enhance bold effect
        /// </summary>
        public bool customBold;

        /// <summary>
        /// If true, it will use extra vertices to enhance bold effect ONLY when it is in italic style.
        /// </summary>
        public bool customBoldAndItalic;

        /// <summary>
        /// If true, it will use extra vertices(4 direction) to enhance outline effect
        /// </summary>
        public bool customOutline;

        /// <summary>
        /// The shader for this font object.
        /// </summary>
        public string shader;

        /// <summary>
        /// Keep text crisp.
        /// </summary>
        public bool keepCrisp;

        /// <summary>
        /// 
        /// </summary>
        public int version;

        protected internal static bool textRebuildFlag;

        public static float SupScale = 0.6f;
        public static float SupOffset = 0.1f;
        public static float RubyOffset = 0.9f;

        virtual public void SetFormat(TextFormat format, float fontSizeScale)
        {
        }

        virtual public void PrepareCharacters(string text, TextFormat format, float fontSizeScale)
        {
        }

        virtual public void Prepare(TextFormat format)
        {
        }

        virtual public bool BuildGraphics(NGraphics graphics)
        {
            return false;
        }

        virtual public void StartDraw(NGraphics graphics)
        {
        }

        virtual public bool GetGlyph(char ch, out float width, out float height, out float baseline)
        {
            width = 0;
            height = 0;
            baseline = 0;
            return false;
        }

        virtual public void DrawGlyph(VertexBuffer vb, float x, float y2)
        {
        }

        virtual public void DrawLine(VertexBuffer vb, float x, float y, float width, int fontSize, int type)
        {
        }

        virtual public bool HasCharacter(char ch)
        {
            return false;
        }

        virtual public int GetLineHeight(int size)
        {
            return 0;
        }

        virtual public void Dispose()
        {
        }

        virtual public int GetDrawVertCount()
        {
            return 0;
        }
    }
}
