// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// Placeholder stub without functionality, here only to support existence of 
//  TypeConverter.
// Dependency chain: TypeConverter -> ITypeDescriptorContext -> IContainer -> ComponentCollection

namespace System.ComponentModel
{
 	using System.Collections;
    public class ComponentCollection : ReadOnlyCollectionBase 
    {

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public ComponentCollection(IComponent[] components) {
            InnerList.AddRange(components);
        }

        /** The component in the container identified by name. */
        /// <devdoc>
        ///    <para>
        ///       Gets a specific <see cref='System.ComponentModel.Component'/> in the <see cref='System.ComponentModel.Container'/>
        ///       .
        ///    </para>
        /// </devdoc>
        public virtual IComponent this[string name] {
            get {
                if (name != null) {
                    IList list = InnerList;
                    foreach(IComponent comp in list) {
                        if (comp != null && comp.Site != null && comp.Site.Name != null && string.Equals(comp.Site.Name, name, StringComparison.OrdinalIgnoreCase)) {
                            return comp;
                        }
                    }
                }
                return null;
            }
        }
        
        /** The component in the container identified by index. */
        /// <devdoc>
        ///    <para>
        ///       Gets a specific <see cref='System.ComponentModel.Component'/> in the <see cref='System.ComponentModel.Container'/>
        ///       .
        ///    </para>
        /// </devdoc>
        public virtual IComponent this[int index] {
            get {
                return (IComponent)InnerList[index];
            }
        }
        
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public void CopyTo(IComponent[] array, int index) {
            InnerList.CopyTo(array, index);
        }   
    }
}

