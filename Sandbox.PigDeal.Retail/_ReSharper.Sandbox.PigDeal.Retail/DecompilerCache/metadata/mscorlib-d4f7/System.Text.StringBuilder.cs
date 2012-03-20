// Type: System.Text.StringBuilder
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Text
{
    [ComVisible(true)]
    [Serializable]
    public sealed class StringBuilder : ISerializable
    {
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public StringBuilder();

        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public StringBuilder(int capacity);

        public StringBuilder(string value);

        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public StringBuilder(string value, int capacity);

        [SecuritySafeCritical]
        public StringBuilder(string value, int startIndex, int length, int capacity);

        [SecuritySafeCritical]
        public StringBuilder(int capacity, int maxCapacity);

        public int Capacity { [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        get; set; }

        public int MaxCapacity { get; }

        public int Length { [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        get; [SecuritySafeCritical]
        set; }

        [IndexerName("Chars")]
        public char this[int index] { get; set; }

        #region ISerializable Members

        [SecurityCritical]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context);

        #endregion

        public int EnsureCapacity(int capacity);

        [SecuritySafeCritical]
        public override string ToString();

        [SecuritySafeCritical]
        public string ToString(int startIndex, int length);

        public StringBuilder Clear();

        [SecuritySafeCritical]
        public StringBuilder Append(char value, int repeatCount);

        [SecuritySafeCritical]
        public StringBuilder Append(char[] value, int startIndex, int charCount);

        [SecuritySafeCritical]
        public StringBuilder Append(string value);

        [SecuritySafeCritical]
        public StringBuilder Append(string value, int startIndex, int count);

        [ComVisible(false)]
        public StringBuilder AppendLine();

        [ComVisible(false)]
        public StringBuilder AppendLine(string value);

        [ComVisible(false)]
        [SecuritySafeCritical]
        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count);

        [SecuritySafeCritical]
        public StringBuilder Insert(int index, string value, int count);

        [SecuritySafeCritical]
        public StringBuilder Remove(int startIndex, int length);

        public StringBuilder Append(bool value);

        [CLSCompliant(false)]
        public StringBuilder Append(sbyte value);

        public StringBuilder Append(byte value);

        [SecuritySafeCritical]
        public StringBuilder Append(char value);

        public StringBuilder Append(short value);

        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public StringBuilder Append(int value);

        public StringBuilder Append(long value);
        public StringBuilder Append(float value);
        public StringBuilder Append(double value);
        public StringBuilder Append(decimal value);

        [CLSCompliant(false)]
        public StringBuilder Append(ushort value);

        [CLSCompliant(false)]
        public StringBuilder Append(uint value);

        [CLSCompliant(false)]
        public StringBuilder Append(ulong value);

        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public StringBuilder Append(object value);

        [SecuritySafeCritical]
        public StringBuilder Append(char[] value);

        [SecuritySafeCritical]
        public StringBuilder Insert(int index, string value);

        public StringBuilder Insert(int index, bool value);

        [CLSCompliant(false)]
        public StringBuilder Insert(int index, sbyte value);

        public StringBuilder Insert(int index, byte value);
        public StringBuilder Insert(int index, short value);

        [SecuritySafeCritical]
        public StringBuilder Insert(int index, char value);

        public StringBuilder Insert(int index, char[] value);

        [SecuritySafeCritical]
        public StringBuilder Insert(int index, char[] value, int startIndex, int charCount);

        public StringBuilder Insert(int index, int value);
        public StringBuilder Insert(int index, long value);
        public StringBuilder Insert(int index, float value);
        public StringBuilder Insert(int index, double value);
        public StringBuilder Insert(int index, decimal value);

        [CLSCompliant(false)]
        public StringBuilder Insert(int index, ushort value);

        [CLSCompliant(false)]
        public StringBuilder Insert(int index, uint value);

        [CLSCompliant(false)]
        public StringBuilder Insert(int index, ulong value);

        public StringBuilder Insert(int index, object value);

        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public StringBuilder AppendFormat(string format, object arg0);

        public StringBuilder AppendFormat(string format, object arg0, object arg1);
        public StringBuilder AppendFormat(string format, object arg0, object arg1, object arg2);
        public StringBuilder AppendFormat(string format, params object[] args);

        [SecuritySafeCritical]
        public StringBuilder AppendFormat(IFormatProvider provider, string format, params object[] args);

        [SecuritySafeCritical]
        public StringBuilder Replace(string oldValue, string newValue);

        public bool Equals(StringBuilder sb);

        [SecuritySafeCritical]
        public StringBuilder Replace(string oldValue, string newValue, int startIndex, int count);

        public StringBuilder Replace(char oldChar, char newChar);

        [SecuritySafeCritical]
        public StringBuilder Replace(char oldChar, char newChar, int startIndex, int count);
    }
}
