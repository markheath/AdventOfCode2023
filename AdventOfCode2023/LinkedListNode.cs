﻿namespace AdventOfCode2023;

/// <summary>
/// Basic linked list
/// </summary>
/// <typeparam name="T"></typeparam>
class LinkedListNode<T>
{
    public LinkedListNode<T>? Prev { get; set; }
    public LinkedListNode<T>? Next { get; set; }
    public T Value { get; }

    public LinkedListNode(T value, LinkedListNode<T>? prev)
    {
        Value = value;
        Prev = prev;
    }

    public static LinkedListNode<T> ToLinkedList(IEnumerable<T> items, bool circular = true)
    {
        LinkedListNode<T>? head = null;
        LinkedListNode<T>? tail = null;
        foreach (var item in items)
        {
            var newNode = new LinkedListNode<T>(item, tail);
            head ??= newNode;
            if (tail != null) { tail.Next = newNode; }
            tail = newNode;
        }
        if (head == null) throw new InvalidOperationException("no items");
        if (circular)
        {
            tail!.Next = head; // make it circular
            head.Prev = tail;
        }
        return head;
    }

    public LinkedListNode<T> Skip(int steps)
    {
        var target = this;
        for (var n = 0; n < Math.Abs(steps); n++)
        {
            target = steps > 0 ? target.Next : target.Prev;
            // normally expecting to be used in a circular list where we can wrap round
            if (target == null) throw new InvalidOperationException("Not enough items in the list");
        }
        return target;
    }

    public void Move(int steps)
    {
        if (steps == 0) return;
        var startingPoint = steps > 0 ? Prev : Next;
        // take myself out
        Remove();
        if (startingPoint == null) throw new NotImplementedException("not implemented skip for non-circular lists yet");

        var target = startingPoint.Skip(steps);

        // add myself in
        if (steps > 0) InsertAfter(target);
        else InsertBefore(target);
    }

    public IEnumerable<LinkedListNode<T>> Enumerate()
    {
        var t = this;
        do
        {
            yield return t;
            t = t.Next;
        } while (t != this && t != null);
    }

    public void InsertAfter(LinkedListNode<T> target)
    {
        Next = target.Next;
        Prev = target;
        
        if (target.Next != null) target.Next.Prev = this;
        target.Next = this;
    }

    public void InsertBefore(LinkedListNode<T> target)
    {
        Next = target;
        Prev = target.Prev;

        if (target.Prev != null) target.Prev.Next = this;
        target.Prev = this;
    }

    public void Remove()
    {
        // take myself out
        if (Prev != null) Prev.Next = Next;
        if (Next != null) Next.Prev = Prev;
        Prev = null;
        Next = null;
    }
}