using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace šipky_Forms
{
	public class ResizeControl
	{
		public void ScaleFontSize(Control control, float scaleFactor = 1.5f)
		{
			control.Font = new Font(control.Font.FontFamily, control.Font.Size * scaleFactor, control.Font.Style);
			foreach (Control childControl in control.Controls)
			{
				ScaleFontSize(childControl, scaleFactor);
			}
		}

	}

}
