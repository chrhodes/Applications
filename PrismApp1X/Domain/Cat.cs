using System;
using System.ComponentModel.DataAnnotations;

using VNC.Core.DomainServices;

namespace PrismApp1.Domain
{
    public class Cat : IEntity<int>, IModificationHistory
    {
        #region IEntity<int>

        public int Id { get; set; }

        #endregion

        // TODO(crhodes)
        // Examples with each different datatype

        [StringLength(50)]
        public string FieldString { get; set; }

        public int? FieldInt { get; set; }

        public double? FieldDouble { get; set; }

        public Single? FieldSingle { get; set; }

        public DateTime? FieldDate { get; set; }

        #region IModificationHistory

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsDirty { get; set; }

        #endregion
    }
}
