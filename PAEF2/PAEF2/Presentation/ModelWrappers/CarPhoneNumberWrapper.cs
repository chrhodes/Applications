using PAEF2.Domain;

using VNC.Core.Mvvm;

namespace PAEF2.Presentation.ModelWrappers
{
    public class CarPhoneNumberWrapper : ModelWrapper<CarPhoneNumber>
    {
        public CarPhoneNumberWrapper(CarPhoneNumber model) : base(model)
        {
        }

        public string Number
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

    }
}
