namespace DansWpfComponents.Demo.Utility;

public record KeyValuePair<K, V>
{
    public KeyValuePair() { }

    public KeyValuePair(K key, V value)
    {
        Key = key;
        Value = value;
    }

    public K Key { get; init; }

    public V Value { get; init; }

    public void Deconstruct(out K key, out V value)
    {
        key = Key;
        value = Value;
    }
}
