namespace TestApi.Models
{
    public class ResponseDeleteModel
    {
        public int Number { get; set; }


        public void Delete(int number)
        {
            Number = number - 100;
        }
    }
}
