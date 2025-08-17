int[] sortedArray = [1, 3, 4, 5, 8, 9, 11, 15, 55, 123, 434, 687, 2222, 8888];


int BinarySearch(int[] array, int startIndex, int endIndex, int searchValue)
{
    while (startIndex <= endIndex)
    {
        // Aşağıdaki hesaplama kötü çünkü int overflow yaşanabilir bundan dolayı bölme işlemi sonrası eksili değer elde edebiliriz.
        // int mid = (startIndex + endIndex) / 2; 
        
        // checked
        // {
        //  // eğer ki checked içerisinde mid'i hesaplarsan hata alırsın çünkü int overflow'a izin vermez.   
        // }

        // Bu ise olması gereken çünkü end - start yaptığımızda int overflow yaşanmıyor. örneğin 2m - 1m = 1m değeri kalıyor ve int overflow olmuyor.


        int middleIndex = startIndex + ((endIndex - startIndex) / 2);

        if (array[middleIndex] == searchValue)
        {
            return middleIndex;
        }


        if (array[middleIndex] > searchValue)
        {
            endIndex = middleIndex - 1;
        }
        else if (array[middleIndex] < searchValue)
        {
            startIndex = middleIndex + 1;
        }
    }

    return -1;
}


Console.WriteLine(BinarySearch(sortedArray,0,sortedArray.Length -1,9));