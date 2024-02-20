using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoundButton : Button
{
 

    public RoundButton()
    {
       
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        GraphicsPath path = new GraphicsPath();
        int radius = 20; // Rayon pour les coins arrondis
        path.AddArc(0, 0, radius, radius, 180, 90); // Coin supérieur gauche
        path.AddArc(Width - radius, 0, radius, radius, 270, 90); // Coin supérieur droit
        path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90); // Coin inférieur droit
        path.AddArc(0, Height - radius, radius, radius, 90, 90); // Coin inférieur gauche
        path.CloseFigure();

        this.Region = new System.Drawing.Region(path);
        base.OnPaint(e);
    }
}