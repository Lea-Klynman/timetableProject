namespace timetableProject
{
    public class Validation
    {
        public static bool IdString(string id)
        {
            if(id==null|| id.Length != 9)
                return false;
            int sum = 0, curdig;
            for(int i = 0; i < id.Length; i++)
            {
                curdig=((int)id[i]-48)*((i%2)+1);
                sum += curdig > 9 ? curdig - 9 : curdig;
            }
            return sum%10 == 0;
        }
        
    }
}
