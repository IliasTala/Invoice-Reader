using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DataEncode
{
    public class RoundedButton : Button
    {
        protected override void OnPaint ( PaintEventArgs pevent )
        {
            GraphicsPath grPath = new GraphicsPath ();
            float radius = 30;
            grPath.AddArc ( new Rectangle ( 0, 0, (int)radius, (int)radius ), 180, 90 );
            grPath.AddArc ( new Rectangle ( Width - (int)radius - 1, 0, (int)radius, (int)radius ), -90, 90 );
            grPath.AddArc ( new Rectangle ( Width - (int)radius - 1, Height - (int)radius - 1, (int)radius, (int)radius ), 0, 90 );
            grPath.AddArc ( new Rectangle ( 0, Height - (int)radius - 1, (int)radius, (int)radius ), 90, 90 );
            grPath.CloseFigure ();
            this.Region = new Region ( grPath ); 
            base.OnPaint ( pevent );
        }
    }
}
