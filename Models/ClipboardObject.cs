using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.ApplicationModel.DataTransfer;

namespace ClipboardWindow.Models
{
    internal class ClipboardObject
    {
        public object Content { get; set; }
        public ObjectTypes Type { get; set; }
        public byte Size { get; set; }
        public DateTimeOffset Time { get; set; }


        public ClipboardObject() { }
        public ClipboardObject(ClipboardHistoryItem clipboardItem) 
        {
            if (clipboardItem.Content.Contains(DataFormats.Text)) { Type = ObjectTypes.Text; Content = SeizureOfData.GetTxt(clipboardItem); }
            else if (clipboardItem.Content.Contains(DataFormats.Bitmap)) { Type = ObjectTypes.Bitmap; Content = SeizureOfData.GetImageFromHistoryItem(clipboardItem); }
            
            Size = (byte)clipboardItem.ToString().Length;
            Time = clipboardItem.Timestamp;
        }

        public CloudObject CreateCloudObject()
        {
            return new CloudObject() { Time = Time, Content = Content, Size = Size, TimeInCloud = DateTimeOffset.Now, Type = Type, Id = CloudObject.GetId()};
        }
    }
}
