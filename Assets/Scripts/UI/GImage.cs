﻿using UnityEngine;
using FairyGUI.Utils;

namespace FairyGUI
{
    /// <summary>
    /// GImage class.
    /// </summary>
    public class GImage : GObject, IGradientColorGear
    {
        Image _content;

        public GImage()
        {
        }

        override protected void CreateDisplayObject()
        {
            _content = new Image();
            _content.gOwner = this;
            displayObject = _content;
        }

        public Color32 originColor{ get; set; } = Color.white;

        /// <summary>
        /// Color of the image. 
        /// </summary>
        public Color color
        {
            get { return _content.color; }
            set
            {
                _content.color = value;
                UpdateGear(4);
            }
        }

        public Color[] gradientColors
        {
            get { return _content.gradientColors; }
            set
            {
                _content.gradientColors = value;
                UpdateGear(4);
            }
        }

        /// <summary>
        /// Flip type.
        /// </summary>
        /// <seealso cref="FlipType"/>
        public FlipType flip
        {
            get { return _content.graphics.flip; }
            set { _content.graphics.flip = value; }
        }

        public bool fillAsPivot
        {
            get => _content.fillAsPivot;
            set => _content.fillAsPivot = value;
        }
        public Vector2 fillPivot
        {
            get => _content.fillPivot;
            set => _content.fillPivot = value;
        }

        /// <summary>
        /// Fill method.
        /// </summary>
        /// <seealso cref="FillMethod"/>
        public FillMethod fillMethod
        {
            get { return _content.fillMethod; }
            set { _content.fillMethod = value; }
        }

        /// <summary>
        /// Fill origin.
        /// </summary>
        /// <seealso cref="OriginHorizontal"/>
        /// <seealso cref="OriginVertical"/>
        /// <seealso cref="Origin90"/>
        /// <seealso cref="Origin180"/>
        /// <seealso cref="Origin360"/>
        public int fillOrigin
        {
            get { return _content.fillOrigin; }
            set { _content.fillOrigin = value; }
        }

        /// <summary>
        /// Fill clockwise if true.
        /// </summary>
        public bool fillClockwise
        {
            get { return _content.fillClockwise; }
            set { _content.fillClockwise = value; }
        }

        /// <summary>
        /// Fill amount. (0~1)
        /// </summary>
        public float fillAmount
        {
            get { return _content.fillAmount; }
            set { _content.fillAmount = value; }
        }

        /// <summary>
        /// Fill rect border. (left,top,right,bottom)(0~1)
        /// </summary>
        public Vector4 fillRectBorder
        {
            get { return _content.fillRectBorder; }
            set { _content.fillRectBorder = value; }
        }

        /// <summary>
        /// Set texture directly. The image wont own the texture.
        /// </summary>
        public NTexture texture
        {
            get { return _content.texture; }
            set
            {
                if (value != null)
                {
                    sourceWidth = value.width;
                    sourceHeight = value.height;
                }
                else
                {
                    sourceWidth = 0;
                    sourceHeight = 0;
                }
                initWidth = sourceWidth;
                initHeight = sourceHeight;
                _content.texture = value;
            }
        }

        /// <summary>
        /// Set material.
        /// </summary>
        public Material material
        {
            get { return _content.material; }
            set { _content.material = value; }
        }

        /// <summary>
        /// Set shader.
        /// </summary>
        public string shader
        {
            get { return _content.shader; }
            set { _content.shader = value; }
        }

        override public void ConstructFromResource()
        {
            this.gameObjectName = packageItem.name;
            
            PackageItem contentItem = packageItem.getBranch();
            sourceWidth = contentItem.width;
            sourceHeight = contentItem.height;
            initWidth = sourceWidth;
            initHeight = sourceHeight;

            contentItem = contentItem.getHighResolution();
            contentItem.Load();
            _content.scale9Grid = contentItem.scale9Grid;
            _content.scaleByTile = contentItem.scaleByTile;
            _content.tileGridIndice = contentItem.tileGridIndice;
            _content.texture = contentItem.texture;
            _content.textureScale = new Vector2(contentItem.width / (float)sourceWidth, contentItem.height / (float)sourceHeight);

            SetSize(sourceWidth, sourceHeight);
        }

        override public void Setup_BeforeAdd(ByteBuffer buffer, int beginPos)
        {
            base.Setup_BeforeAdd(buffer, beginPos);

            buffer.Seek(beginPos, 5);

            if (buffer.ReadBool())
                _content.color = buffer.ReadColor();
            originColor = color;
            _content.graphics.flip = (FlipType)buffer.ReadByte();
            _content.fillMethod = (FillMethod)buffer.ReadByte();
            if (_content.fillMethod != FillMethod.None)
            {
                _content.fillOrigin = buffer.ReadByte();
                _content.fillClockwise = buffer.ReadBool();
                _content.fillAmount = buffer.ReadFloat();
            }
        }
    }
}
