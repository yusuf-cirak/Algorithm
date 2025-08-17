using System.Collections;

int[] arr = { 5,1,2,16 };

MergeSort(arr, 0, arr.Length-1);

Console.WriteLine(string.Join(" -> ", arr));

void MergeSort<T>(T[] array, int left, int right) where T : IComparable
{
    if (left < right)
    {
        int middle = left + (right - left) / 2;
        MergeSort(array, left, middle);
        MergeSort(array, middle + 1, right);

        Merge(array, left, middle, right);
    }
}

void Merge<T>(T[] array, int left, int middle, int right) where T : IComparable
{
    int leftSize = middle - left + 1;
    int rightSize = right - middle;

    T[] leftArray = new T[leftSize];
    T[] rightArray = new T[rightSize];

    for (int i = 0; i < leftSize; i++)
    {
        leftArray[i] = array[left + i];
    }

    for (int i = 0; i < rightSize; i++)
    {
        rightArray[i] = array[middle + 1 + i];
    }

    int leftIndex = 0;
    int rightIndex = 0;
    int mergedIndex = left;

    while (leftIndex < leftSize && rightIndex < rightSize)
    {
        if (Comparer<T>.Default.Compare(leftArray[leftIndex],(rightArray[rightIndex]))<=0)
        {
            array[mergedIndex] = leftArray[leftIndex];
            leftIndex++;
        }
        else
        {
            array[mergedIndex] = rightArray[rightIndex];
            rightIndex++;
        }

        mergedIndex++;
    }

    while (leftIndex < leftSize)
    {
        array[mergedIndex] = leftArray[leftIndex];
        leftIndex++;
        mergedIndex++;
    }

    while (rightIndex < rightSize)
    {
        array[mergedIndex] = rightArray[rightIndex];
        rightIndex++;
        mergedIndex++;
    }
}