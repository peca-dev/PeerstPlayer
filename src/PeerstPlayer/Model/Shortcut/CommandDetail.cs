using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerstPlayer.Model.Shortcut
{
	public class CommandDetailAttribute : Attribute
	{
		public string CommandDetail { get; private set; }

		public CommandDetailAttribute(string detail)
		{
			this.CommandDetail = detail;
		}
	}

	public static class CommandDetailUtiliy
	{
		public static T ThrowIf<T>(this T value, Func<T, bool> predicate, Exception exception)
		{
			if (predicate(value)) throw exception;
			else return value;
		}

		public static string ToAliasName(this Enum value)
		{
			return value.GetType()
				.GetField(value.ToString())
				.GetCustomAttributes(typeof(CommandDetailAttribute), false)
				.Cast<CommandDetailAttribute>()
				.FirstOrDefault()
				.CommandDetail;
		}
	}

}
