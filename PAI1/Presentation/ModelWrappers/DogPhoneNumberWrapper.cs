using PAI1.Domain;

using VNC.Core.Mvvm;

namespace PAI1.Presentation.ModelWrappers
{
    public class DogPhoneNumberWrapper : ModelWrapper<DogPhoneNumber>
    {
        public DogPhoneNumberWrapper(DogPhoneNumber model) : base(model)
        {
        }

        public string Number
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

    }
}
