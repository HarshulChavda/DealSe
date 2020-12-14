namespace DealSe.Common
{
    public static class ShortText
    {
        public static string ShortTextString(string Text, int length)
        {
            string cont = "";
            if (!string.IsNullOrEmpty(Text))
            {
                string[] templength;
                templength = Text.Split(' ');
                if (Text.Length < length)
                {
                    cont = Text;
                }
                else
                {
                    cont = Text.Substring(0, length);
                }
            }
            return cont;
        }
    }
}
