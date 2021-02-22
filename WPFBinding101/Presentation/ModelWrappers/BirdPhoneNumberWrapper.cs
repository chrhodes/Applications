using VNC.Core.Mvvm;

using WPFBinding101.Domain;

namespace WPFBinding101.Presentation.ModelWrappers
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
