using PAEF3.Domain;

using VNC.Core.Mvvm;

namespace PAEF3.Presentation.ModelWrappers
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
