using PrismAppEF1.Domain;

using VNC.Core.Mvvm;

namespace PrismAppEF1.Presentation.ModelWrappers
{
    public class BirdPhoneNumberWrapper : ModelWrapper<BirdPhoneNumber>
    {
        public BirdPhoneNumberWrapper(BirdPhoneNumber model) : base(model)
        {
        }

        public string Number
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

    }
}
