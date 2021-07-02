using PAEF1a.Domain;

using VNC.Core.Mvvm;

namespace PAEF1a.Presentation.ModelWrappers
{
    public class CatPhoneNumberWrapper : ModelWrapper<CatPhoneNumber>
    {
        public CatPhoneNumberWrapper(CatPhoneNumber model) : base(model)
        {
        }

        public string Number
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

    }
}
