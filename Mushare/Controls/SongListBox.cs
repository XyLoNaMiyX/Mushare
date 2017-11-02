using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mushare.Controls
{
    public class SongListBox : ListBox
    {
        public SongListBox()
        {
            AllowDrop = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (SelectedItem == null)
                return;

            DoDragDrop(SelectedItem, DragDropEffects.Move);
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effect = DragDropEffects.Move;
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            var point = PointToClient(new Point(e.X, e.Y));
            var index = IndexFromPoint(point);
            if (index < 0)
                index = Items.Count - 1;

            object data = e.Data.GetData(typeof(DateTime));
            Items.Remove(data);
            Items.Insert(index, data);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.Delete:
                case Keys.Back:

                    if (SelectedIndex > -1)
                    {
                        var newIndex = SelectedIndex - 1;
                        Items.Remove(SelectedItem);

                        if (newIndex < 0)
                            newIndex = 0;

                        if (newIndex < Items.Count)
                            SelectedIndex = newIndex;
                    }

                    break;
            }
        }
    }
}
