using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Psych1
{
    public class DraggableStimulus : PictureBox
    {
        public bool isDraggable;
        public Stimuli stimulus;
        public DraggableStimulus()
            : base()
        {
            isDraggable = true;
        }
    }
}
