using System.Collections.Generic;
using FairyGUI.Utils;

namespace FairyGUI
{
    /// <summary>
    /// Gear is a connection between object and controller.
    /// </summary>
    public class GearFontSize : GearBase
    {
        Dictionary<string, int> _storage;
        int _default;
        int textFontSize
        {
            get
            {
                if(_owner is GTextField textField)
                {
                    return textField.textFormat.size;
                }
                else if(_owner is GLabel label)
                {
                    return label.titleFontSize;
                }
                else if(_owner is GButton button)
                {
                    return button.titleFontSize;
                }
                return 0;
            }
            set
            {
                if(_owner is GTextField textField)
                {
                    TextFormat format = textField.textFormat;
                    format.size = value;
                    textField.textFormat = format;
                }
                else if(_owner is GLabel label)
                {
                    label.titleFontSize = value;
                }
                else if(_owner is GButton button)
                {
                    button.titleFontSize = value;
                }
            }
        }

        public GearFontSize(GObject owner)
            : base(owner)
        {
        }

        protected override void Init()
        {
            _default = textFontSize;
            _storage = new Dictionary<string, int>();
        }

        override protected void AddStatus(string pageId, ByteBuffer buffer)
        {
            if (pageId == null)
                _default = buffer.ReadInt();
            else
                _storage[pageId] = buffer.ReadInt();
        }

        override public void Apply()
        {
            _owner._gearLocked = true;

            int cv;
            if (!_storage.TryGetValue(_controller.selectedPageId, out cv))
                cv = _default;

            textFontSize = cv;

            _owner._gearLocked = false;
        }

        override public void UpdateState()
        {
            _storage[_controller.selectedPageId] = textFontSize;
        }
    }
}
