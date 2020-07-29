using System;
using System.Activities;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms

namespace Dragon_Designer
{
    /// <summary>
    /// Custom file format for PhotoDragon
    /// </summary>
    class Structures
    {
        //Region for all the pdpf structures
        #region pdpfFile
        /// <summary>
        /// PDPF STRUCTURE
        /// </summary>
        struct pdpfFile
        {
            char[] start;
            UInt32 fileSize;
            string name;
            Type type;
            System.Drawing.Color color;
            Font font;
            Location location;
        }

        #endregion

    }
}
