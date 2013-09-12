using System;
using System.Data;
using System.Resources;
using System.Threading;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Data
{
	public class MappedColumn
	{
		protected byte? precision;
		protected byte? scale;

		public MappedColumn(string columnName, DbType type)
			: this(columnName, type, null)
		{
		}

		public MappedColumn(string columnName, DbType type, int? size)
		{
			ColumnName = columnName;
			DbType = type;
			Size = size;
			precision = null;
			scale = null;

			IsIdentifier = false;
		}

		public MappedColumn(string columnName, DbType type, byte precision, byte scale)
		{
			ColumnName = columnName;
			DbType = type;
			this.precision = precision;
			this.scale = scale;
			Size = null;

			IsIdentifier = false;
		}

		public string ColumnName { get; protected set; }
		public DbType DbType { get; private set; }
		public int? Size { get; protected set; }
		public bool IsIdentifier { get; protected set; }

		public string Text(ResourceManager manager)
		{
			Guard.AgainstNull(manager, "manager");

			var result = manager.GetString("ColumnText_" + ColumnName, Thread.CurrentThread.CurrentUICulture);

			if (string.IsNullOrEmpty(result))
			{
				result = string.Format("{{ColumnText_{0}}}", ColumnName);
			}

			return result;
		}

		public string FlattenedColumnName()
		{
			return ColumnName.Replace(".", "_");
		}

		public object RetrieveRawValueFrom(DataRow row)
		{
			return row[ColumnName];
		}

		public bool IsNullFor(DataRow row)
		{
			return row.IsNull(ColumnName);
		}

		public IDbDataParameter CreateDataParameter(IDbDataParameterFactory factory, object value)
		{
			return Size.HasValue
			       	? factory.Create("@" + FlattenedColumnName(), DbType, Size.Value, value)
			       	: (precision.HasValue
			       	   	? factory.Create("@" + FlattenedColumnName(), DbType, precision.Value, scale ?? 0, value)
			       	   	: factory.Create("@" + FlattenedColumnName(), DbType, value));
		}

		public static implicit operator string(MappedColumn column)
		{
			return column.ColumnName;
		}

		public MappedColumn AsIdentifier()
		{
			IsIdentifier = true;

			return this;
		}

		public MappedColumn Rename(string name)
		{
			return Size.HasValue
			       	? new MappedColumn(name, DbType, Size.Value)
			       	: precision.HasValue
			       	  	? new MappedColumn(name, DbType, precision.Value, scale ?? 0)
			       	  	: new MappedColumn(name, DbType);
		}
	}

	public class MappedColumn<T> : MappedColumn
	{
		private Type underlyingSystemType;

		public MappedColumn(string columnName, DbType type)
			: this(columnName, type, null)
		{
		}

		public MappedColumn(string columnName, DbType type, int? size)
			: base(columnName, type, size)
		{
			GetUnderlyingSystemType();
		}

		public MappedColumn(string columnName, DbType type, byte precision, byte scale)
			: base(columnName, type, precision, scale)
		{
			GetUnderlyingSystemType();
		}

		public static implicit operator string(MappedColumn<T> column)
		{
			return column.ColumnName;
		}

		private void GetUnderlyingSystemType()
		{
			underlyingSystemType = Nullable.GetUnderlyingType(typeof (T)) ?? typeof (T);
		}

		public T MapFrom(DataRow row)
		{
			if (row.Table.Columns.Contains(ColumnName))
			{
				return (row.IsNull(ColumnName)
				        	? default(T)
				        	: (T) Convert.ChangeType(RetrieveRawValueFrom(row), underlyingSystemType));
			}

			return default(T);
		}

		public new MappedColumn<T> AsIdentifier()
		{
			IsIdentifier = true;

			return this;
		}

		public T MapFrom(IDataRecord record)
		{
			var ordinal = Ordinal(record);

			if (ordinal > -1)
			{
				return (record.IsDBNull(ordinal)
				        	? default(T)
				        	: (T) Convert.ChangeType(RetrieveRawValueFrom(record), underlyingSystemType));
			}

			return default(T);
		}

		private object RetrieveRawValueFrom(IDataRecord record)
		{
			return record[ColumnName];
		}

		private int Ordinal(IDataRecord reader)
		{
			try
			{
				return reader.GetOrdinal(ColumnName);
			}
			catch
			{
				return -1;
			}
		}
	}
}