namespace SoundsUp.Business
{
    public class Validator : IValidator
    {
        public bool ValidateId(int id)
        {
            return id > 0;
        }
    }
}