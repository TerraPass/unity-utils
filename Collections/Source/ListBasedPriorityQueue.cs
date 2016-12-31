using System;
using System.Collections;
using System.Collections.Generic;

namespace Terrapass.Collections
{
	/// <summary>
	/// Priority queue implementation, based on the underlying List<T> instance.
	/// Underlying List is re-sorted on each addition.
	/// </summary>
	/// <remarks>
	/// ListBasedPriorityQueue supports duplicate items.
	/// </remarks>
	public class ListBasedPriorityQueue<T> : IPriorityQueue<T>
	{
		private readonly List<T> list;
		private readonly IComparer<T> comparer;

		public ListBasedPriorityQueue()
		{
			this.list = new List<T>();
			this.comparer = Comparer<T>.Default;
		}

		public ListBasedPriorityQueue(IComparer<T> comparer)
		{
			this.list = new List<T>();
		}

		#region ICollection implementation
		public void Add(T item)
		{
			this.list.Add(item);
			this.list.Sort(this.comparer);
		}

		public void Clear()
		{
			this.list.Clear();
		}

		public bool Contains(T item)
		{
			return this.list.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			this.list.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			return this.list.Remove(item);
			// Removal does not upset the order
		}

		public int Count
		{
			get {
				return this.list.Count;
			}
		}

		public bool IsReadOnly
		{
			get {
				return false;
			}
		}
		#endregion

		#region IEnumerable implementation

		public IEnumerator<T> GetEnumerator ()
		{
			return this.list.GetEnumerator();
		}

		#endregion

		#region IEnumerable implementation

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return ((IEnumerable)this.list).GetEnumerator();
		}

		#endregion

		#region IPriorityQueue implementation

		public T PopFront()
		{
			var poppedValue = this.Front;
			this.list.RemoveAt(0);
			return poppedValue;
		}

		public T Front
		{
			get {
				if(this.Count == 0)
				{
					throw new InvalidOperationException(
						string.Format(
							"Attempted to retrieve Front from an empty {0}",
							this.GetType()
						)
					);
				}
				return this.list[0];
			}
		}
		#endregion
	}
}

