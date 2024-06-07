public static class EnumerableExtensions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));
        if (convertToNumber == null) throw new ArgumentNullException(nameof(convertToNumber));
                

        using (var enumerator = collection.GetEnumerator())
        {
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }

            T maxElement = enumerator.Current;
            float maxValue = convertToNumber(maxElement);

            while (enumerator.MoveNext())
            {
                T currentElement = enumerator.Current;
                float currentValue = convertToNumber(currentElement);

                if (currentValue > maxValue)
                {
                    maxElement = currentElement;
                    maxValue = currentValue;
                }
            }

            return maxElement;
        }
    }
}