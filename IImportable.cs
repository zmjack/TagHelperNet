using System;
using System.Collections.Generic;
using System.Text;

namespace TagHelperNet
{
    public interface IImportable
    {
        /// <summary>
        /// Server url
        /// </summary>
        string From { get; set; }

        /// <summary>
        /// Root directory
        /// </summary>
        string In { get; set; }
    }
}
