using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardWindow.Models
{
    internal class CloudObject
    {
        public string Id { get; set; }
        public object Content { get; set; }
        public ObjectTypes Type { get; set; }
        public byte Size { get; set; }
        public DateTimeOffset Time { get; set; }
        public DateTimeOffset TimeInCloud { get; set; }

        public CloudObject() { }
        public CloudObject(ClipboardObject clipboardObject)
        {
            Id = GetId();
            Content = clipboardObject.Content;
            Type = clipboardObject.Type;
            Size = clipboardObject.Size;
            Time = clipboardObject.Time;
            TimeInCloud = DateTimeOffset.Now;
        }


        public static string GetId()
        {
            return DateTimeOffset.Now.ToString();
        }

        public ClipboardObject CreateClipbordObject()
        { return new ClipboardObject() { Content = Content, Type = Type, Size = Size, Time = Time }; }
    }
}
