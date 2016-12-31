using System;
using System.Collections.Generic;
using System.Linq;

// TODO: Maybe use a more detailed namespace,
// e.g. Terrapass.Extensions.System.Collections.Generic?
namespace Terrapass.Extensions.NET
{
	public static class GenericIDictionaryExtensions
	{
		public static void DeleteNullEntries<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
		{
			var nullEntryKeys = from kvp in dictionary where kvp.Value == null select kvp.Key;
			foreach(TKey option in nullEntryKeys)
			{
				dictionary.Remove(option);
			}
		}
	}
}

