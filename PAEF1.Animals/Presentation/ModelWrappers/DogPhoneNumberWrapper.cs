using PAEF1.Animals.Domain;

using VNC.Core.Mvvm;

namespace PAEF1.Animals.Presentation.ModelWrappers
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
