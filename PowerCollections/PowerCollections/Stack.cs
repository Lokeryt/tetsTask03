using System;
using System.Collections.Generic;
using System.Collections;

public class Stack<T> : IEnumerable<T>
{
	public int count = 0;
	public int capacity { get; set; }

	private T[] stack;

	public Stack(int capacity)
    {
	    try
	    {
		    this.capacity = capacity;
		    this.stack = new T[this.capacity];
	    }
	    catch
	    {
		    throw new ArgumentException("Ошибка при создании массива с указанной длиной");
	    }
    }

	public Stack()
	{
		try
		{
			this.capacity = 100;
			this.stack = new T[this.capacity];
		}
		catch
		{
			throw new ArgumentException("Ошибка при создании массива с размерностью 100");
		}
	}

	public void Push(T item)
    {
	    try
	    {
		    this.stack[this.count++] = item;
	    }
	    catch
	    {
		    throw new InvalidOperationException("Ошибка при добавлении элемента");
	    }
    }

	public T Pop()
    {
	    try
	    {
		    T item = this.stack[this.count - 1];
		    this.stack[--this.count] = default(T);
		    return item;
	    }
	    catch
	    {
		    throw new InvalidOperationException("Ошибка при снятии элемента с вершины");
	    }
    }

	public T Top()
    {
	    try
	    {
		    return this.stack[this.count - 1];
	    }
	    catch
	    {
		    throw new InvalidOperationException("Ошибка возращении элемента с вершины стека");
	    }
    }

	public IEnumerator<T> GetEnumerator()
    {
		for (int i = this.count - 1; i >= 0; i--)
		{
			yield return this.stack[i];
		}
    }

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
