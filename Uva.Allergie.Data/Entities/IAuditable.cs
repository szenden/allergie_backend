using System;
using System.Collections.Generic;
using System.Text;

namespace Uva.Allergie.Data.Entities
{
    public interface IAuditable
    {
        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        DateTime? CreatedOn { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        string CreatedBy { get; set; }

        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        DateTime? ModifiedOn { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        string ModifiedBy { get; set; }
    }
}
