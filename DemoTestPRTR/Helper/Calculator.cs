namespace DemoTestPRTR.Helper
{
    public class Calculator
    {
        public int calRating(int viewCount = 0)
        {
            return (int)Math.Round((double)(viewCount/100), MidpointRounding.AwayFromZero);
        }
    }
}
