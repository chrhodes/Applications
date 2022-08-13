using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using VNC.Core.DomainServices;

namespace PAEF2.Domain
{
    public class CarPhoneNumber : IEntity<int>, IModificationHistory, IOptimistic
    {
        #region IEntity<int>

        public int Id { get; set; }

        #endregion

        [Phone]
        [Required]
        public string Number { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        #region IModificationHistory

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        public Boolean? IsDirty { get; set; }

        #endregion

        #region IOptimistic

        // Need to have data annotation here.  
        // Presence in interface ignored.
        [Timestamp]
        public byte[] RowVersion { get; set; }

        #endregion
    }
}
