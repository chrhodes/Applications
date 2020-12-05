
using System;

using VNC.Core.Mvvm;

namespace PrismApp1.Presentation.ModelWrappers
{
    public class CatWrapper : ModelWrapper<Domain.Cat>
    {
        public CatWrapper() { }
        public CatWrapper(Domain.Cat model) : base(model)
        {
        }

        // TODO(crhodes)
        // Wrap each property from the passed in model.

        public string FieldString { get { return GetValue<string>(); } set { SetValue(value); } }
        public int FieldInt { get { return GetValue<int>(); } set { SetValue(value); } }
        public Double FieldDouble { get { return GetValue<Double>(); } set { SetValue(value); } }
        public Single FieldSingle { get { return GetValue<Single>(); } set { SetValue(value); } }
        public DateTime FieldDate { get { return GetValue<DateTime>(); } set { SetValue(value); } }

    }
}
