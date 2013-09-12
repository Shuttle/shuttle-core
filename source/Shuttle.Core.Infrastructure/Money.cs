using System;

namespace Shuttle.Core.Infrastructure
{
    public class Money : IEquatable<Money>, IComparable<Money>, IConvertible
    {
        private const int CurrencyDecimals = 2;

        private readonly decimal amount;

        public decimal Amount
        {
            get
            {
                return amount;
            }
        }

        public Money(decimal amount)
        {
            this.amount = RoundToCurrencyDecimals(amount);
        }

        public override string ToString()
        {
            return amount.ToString();
        }

        private static decimal RoundToCurrencyDecimals(decimal amount)
        {
            return Decimal.Round(amount, CurrencyDecimals, MidpointRounding.ToEven);
        }

        public override bool Equals(object other)
        {
            Guard.AgainstNull(other, "other");
            Guard.Against<InvalidCastException>(! (other is Money), "The 'other' argument is not of type Money.");

            return Equals((Money)other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Money other)
        {
            return Amount == other.Amount;
        }

        public int CompareTo(Money other)
        {
            Guard.AgainstNull(other, "other");

            return Amount == other.Amount ? 0 : (Amount < other.Amount ? -1 : 1);
        }

        public static Money Zero
        {
            get { return new Money(0); }
        }

        public static Money MaxValue
        {
            get { return new Money(decimal.MaxValue); }
        }

        public static implicit operator Money(long amount)
        {
            return new Money(amount);
        }

        public static implicit operator long(Money money)
        {
            return Convert.ToInt64(money.Amount);
        }

        public static implicit operator Money(double amount)
        {
            return new Money(Convert.ToDecimal(amount));
        }

        public static implicit operator double(Money money)
        {
            return Convert.ToDouble(money.Amount);
        }

        public static implicit operator Money(decimal amount)
        {
            return new Money(amount);
        }

        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }

        public static Money operator +(Money left, Money right)
        {
            return new Money(left.Amount + right.Amount);
        }

        public static Money operator +(Money left, long right)
        {
            return new Money(left.Amount + right);
        }
        public static Money operator +(Money left, double right)
        {
            return new Money(left.Amount + Convert.ToDecimal(right));
        }
        public static Money operator +(Money left, decimal right)
        {
            return new Money(left.Amount + right);
        }

        public static Money operator +(long left, Money right)
        {
            return new Money(left + right.Amount);
        }
        public static Money operator +(double left, Money right)
        {
            return new Money(Convert.ToDecimal(left) + right.Amount);
        }
        public static Money operator +(decimal left, Money right)
        {
            return new Money(left + right.Amount);
        }

        public static Money operator -(Money left, Money right)
        {
            return new Money(left.Amount - right.Amount);
        }

        public static Money operator -(Money left, long right)
        {
            return new Money(left.Amount - right);
        }
        public static Money operator -(Money left, double right)
        {
            return new Money(left.Amount - Convert.ToDecimal(right));
        }
        public static Money operator -(Money left, decimal right)
        {
            return new Money(left.Amount - right);
        }

        public static Money operator -(long left, Money right)
        {
            return new Money(left - right.Amount);
        }
        public static Money operator -(double left, Money right)
        {
            return new Money(Convert.ToDecimal(left) - right.Amount);
        }
        public static Money operator -(decimal left, Money right)
        {
            return new Money(left - right.Amount);
        }

        public static Money operator *(Money left, Money right)
        {
            return new Money(left.Amount * right.Amount);
        }

        public static Money operator *(Money left, long right)
        {
            return new Money(left.Amount * right);
        }
        public static Money operator *(Money left, double right)
        {
            return new Money(left.Amount * Convert.ToDecimal(right));
        }
        public static Money operator *(Money left, decimal right)
        {
            return new Money(left.Amount * right);
        }

        public static Money operator *(long left, Money right)
        {
            return new Money(left * right.Amount);
        }
        public static Money operator *(double left, Money right)
        {
            return new Money(Convert.ToDecimal(left) * right.Amount);
        }
        public static Money operator *(decimal left, Money right)
        {
            return new Money(left * right.Amount);
        }

        public static Money operator /(Money left, Money right)
        {
            return new Money(left.Amount / right.Amount);
        }

        public static Money operator /(Money left, long right)
        {
            return new Money(left.Amount / right);
        }
        public static Money operator /(Money left, double right)
        {
            return new Money(left.Amount / Convert.ToDecimal(right));
        }
        public static Money operator /(Money left, decimal right)
        {
            return new Money(left.Amount / right);
        }

        public static Money operator /(long left, Money right)
        {
            return new Money(left / right.Amount);
        }
        public static Money operator /(double left, Money right)
        {
            return new Money(Convert.ToDecimal(left) / right.Amount);
        }
        public static Money operator /(decimal left, Money right)
        {
            return new Money(left / right.Amount);
        }

        public static Money operator %(Money left, Money right)
        {
            return new Money(left.Amount % right.Amount);
        }

        public static Money operator %(Money left, long right)
        {
            return new Money(left.Amount % right);
        }
        public static Money operator %(Money left, double right)
        {
            return new Money(left.Amount % Convert.ToDecimal(right));
        }
        public static Money operator %(Money left, decimal right)
        {
            return new Money(left.Amount % right);
        }

        public static Money operator %(long left, Money right)
        {
            return new Money(left % right.Amount);
        }
        public static Money operator %(double left, Money right)
        {
            return new Money(Convert.ToDecimal(left) % right.Amount);
        }
        public static Money operator %(decimal left, Money right)
        {
            return new Money(left % right.Amount);
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return amount;
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return amount.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(string text, out Money money)
        {
            decimal dec;

            if (!decimal.TryParse(text, out dec))
            {
                money = null;

                return false;
            }
            
            money = new Money(dec);

            return true;
        }
    }
}
