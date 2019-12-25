using System;
using System.Linq;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private readonly int capacity;
    private readonly Queue<T> buffer;

    public CircularBuffer(int capacity) {
        this.capacity = capacity;
        this.buffer = new Queue<T>(capacity);
    }

    public T Read() => buffer.Dequeue();

    public void Write(T value) {
        if (buffer.Count == capacity) throw new InvalidOperationException();
        buffer.Enqueue(value);
    }

    public void Overwrite(T value){
        if (buffer.Count == capacity) buffer.Dequeue();
        this.Write(value);
    }

    public void Clear() => buffer.Clear();
}