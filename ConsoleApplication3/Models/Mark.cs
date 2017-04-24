using SchoolSystem.Core;
using SchoolSystem.Contracts;

namespace SchoolSystem.Models
{
    public class Mark : IMark
    {
        public Subject Subject { get; set; }

        public float Value { get; set; }

        public Mark(Subject subject, float Value)
        {
            this.Subject = subject;
            this.value = Value;
        }

        internal float value
        {
            get
            {
                return this.Value;
            }

            set
            {
                Validators.MarkValueValidator(this.Value);
                this.Value = value;
            }
        }
    }
}
