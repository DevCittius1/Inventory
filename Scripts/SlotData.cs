public struct SlotData<T>
{
    public T data;
    public int count;

    public SlotData(T data, int count)
    {
        this.data = data;
        this.count = count;
    }
}
