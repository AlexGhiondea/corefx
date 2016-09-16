using System;
using System.ComponentModel;

namespace System
{
	[AttributeUsage(AttributeTargets.All)]
	internal sealed class SRDescriptionAttribute : DescriptionAttribute
	{
		private bool replaced;

		public override string Description
		{
			get
			{
				if (!this.replaced)
				{
					this.replaced = true;
					base.DescriptionValue = SR.GetResourceString(base.Description,"");
				}
				return base.Description;
			}
		}

		public SRDescriptionAttribute(string description) : base(description)
		{
		}
	}

	[AttributeUsage(AttributeTargets.All)]
	internal sealed class SRCategoryAttribute : CategoryAttribute
	{
		public SRCategoryAttribute(string category) : base(category)
		{
		}

		protected override string GetLocalizedString(string value)
		{
			return SR.GetResourceString(value,"");
		}
	}
}

namespace System.Resources
{
    public partial interface IResourceReader : System.Collections.IEnumerable, System.IDisposable
    {
        void Close();
        new System.Collections.IDictionaryEnumerator GetEnumerator();
    }
    public partial interface IResourceWriter : System.IDisposable
    {
        void AddResource(string name, byte[] value);
        void AddResource(string name, object value);
        void AddResource(string name, string value);
        void Close();
        void Generate();
    }

    public partial class ResourceSet : System.Collections.IEnumerable, System.IDisposable
    {
        protected System.Resources.IResourceReader Reader;
        protected System.Collections.Hashtable Table;
        protected ResourceSet() { }
        public ResourceSet(System.IO.Stream stream) { }
        public ResourceSet(System.Resources.IResourceReader reader) { }
        public ResourceSet(string fileName) { }
        public virtual void Close() { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public virtual System.Type GetDefaultReader() { throw null; }
        public virtual System.Type GetDefaultWriter() { throw null; }
        public virtual System.Collections.IDictionaryEnumerator GetEnumerator() { throw null; }
        public virtual object GetObject(string name) { throw null; }
        public virtual object GetObject(string name, bool ignoreCase) { throw null; }
        public virtual string GetString(string name) { throw null; }
        public virtual string GetString(string name, bool ignoreCase) { throw null; }
        protected virtual void ReadResources() { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
}

internal static class AssemblyRef
{
	internal const string SystemDrawing = "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
}