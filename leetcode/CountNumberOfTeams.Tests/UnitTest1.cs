namespace CountNumberOfTeams.Tests;

public class Solution
{
    // int numTeams(vector<int>& arr) {
    //     int n = arr.size();
    //     int result = 0;
    //     for(int i = 1 ; i < n-1 ; i++){
    //         int leftSmall = 0, leftLarge = 0;
    //         int rightSmall = 0, rightLarge = 0;
    //         //left part
    //         for(int j = 0 ; j < i ; j++){
    //             if(arr[j] < arr[i]){
    //                 leftSmall++;
    //             }
    //             if(arr[j] > arr[i]){
    //                 leftLarge++;
    //             }
    //         }
    //         //right part
    //         for(int j = i+1 ; j < n ; j++){
    //             if(arr[j] < arr[i]){
    //                 rightSmall++;
    //             }
    //             if(arr[j] > arr[i]){
    //                 rightLarge++;
    //             }
    //         }
    //         result += leftSmall * rightLarge + leftLarge * rightSmall;
    //     }
    //     return result;
    // }

    public int NumTeams(int[] rating) // {1,2,3,4}
    {
        var n = rating.Length;

        var result = 0;

        for (var i = 1; i < n - 1; i++)
        {
            var leftSmall = 0;
            var leftLarge = 0;
            var rightSmall = 0;
            var rightLarge = 0;

            for (var j = 0; j < i; j++)
            {
                if (rating[j] < rating[i])
                {
                    leftSmall++;
                }

                if (rating[j] > rating[i])
                {
                    leftLarge++;
                }
            }

            for (var j = 0; j < i; j++)
            {
                if (rating[j] > rating[i])
                {
                    rightLarge++;
                }

                if (rating[j] < rating[i])
                {
                    rightSmall++;
                }
            }

            result += leftSmall * rightLarge;
        }

        return result;
    }
}

public class Tests
{
    [TestCase(new[] { 2, 5, 3, 4, 1, }, 3)]
    public void Test0(int[] input, int expected)
    {
        var actual = new Solution().NumTeams(input);
        Assert.That(expected, Is.EqualTo(actual));
    }
}